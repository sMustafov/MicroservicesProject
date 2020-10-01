namespace OrderApi.Data.Database
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using OrderApi.Domain;
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
          : base(options)
        {
            // Using In-memory Database
            // Creating list of predefined orders
            var orders = new[]
            {
                new Order
                {
                    
                    Id = Guid.NewGuid(),
                    OrderState = 1,
                    CustomerGuid = Guid.NewGuid(),
                    CustomerFullName = "Jerry Long"
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    OrderState = 1,
                    CustomerGuid = Guid.NewGuid(),
                    CustomerFullName = "Oliver Holland"
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    OrderState = 2,
                    CustomerGuid = Guid.NewGuid(),
                    CustomerFullName = "Glenn Hawkins"
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    OrderState = 2,
                    CustomerGuid = Guid.NewGuid(),
                    CustomerFullName = "Ken Long"
                }
            };

            Order.AddRange(orders);
            SaveChanges();
        }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerFullName).IsRequired();
            });
        }
    }
}
