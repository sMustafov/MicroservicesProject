namespace CustomerApi.Data.Repository
{
    using CustomerApi.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
            var customers = new[]
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jerry",
                    LastName = "Long",
                    Birthday = new DateTime(1990, 10, 10),
                    Age = 30
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Oliver",
                    LastName = "Holland",
                    Birthday = new DateTime(1995, 05, 05),
                    Age = 25
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Glenn",
                    LastName = "Hawkins",
                    Birthday = new DateTime(1980, 06, 06),
                    Age = 40
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ken",
                    LastName = "Long",
                    Birthday = new DateTime(1985, 07, 07),
                    Age = 35
                }
            };

            Customer.AddRange(customers);
            SaveChanges();
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}
