using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Data;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Configurer le DbContext pour l'accès à la base de données
builder.Services.AddDbContext<ProductsAPIContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductsAPIContext")
        ?? throw new InvalidOperationException("Connection string 'ProductsAPIContext' not found.")
    ));

// Ajouter MassTransit avec RabbitMQ
builder.Services.AddMassTransit(options =>
{
    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost:4001"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

// Ajouter des services au conteneur
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
