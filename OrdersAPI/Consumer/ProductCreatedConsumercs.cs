using MassTransit;

using OrdersAPI.Data;
using OrdersAPI.Models;
using Shared;

namespace OrdersAPI.Consumer
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        private readonly OrdersAPIContext _OrdersAPIContext;

        public ProductCreatedConsumer(OrdersAPIContext ordersAPIContext)
        {
            _OrdersAPIContext = ordersAPIContext;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            var newProduct = new Product
            {
                // Id = context.Message.Id,
                Name = context.Message.Name
            };

            _OrdersAPIContext.Add(newProduct);
            await _OrdersAPIContext.SaveChangesAsync();
        }
    }
}