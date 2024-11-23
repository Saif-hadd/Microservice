using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OrdersAPI.Data
{
    public class OrdersAPIContext : DbContext
    {
        public OrdersAPIContext(DbContextOptions<OrdersAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Orders> Orders { get; set; } = default!;
        public DbSet<Models.Product> Products { get; set; }
    }
}