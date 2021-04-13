using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opdracht_Web_API.Models;

namespace Opdracht_Web_API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
            //empty constructor
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tax>().HasData(
                new Tax() { Id = 1, Name = "standard", TaxPercentage = 21 },
                new Tax() { Id = 2, Name = "exceptions and meals", TaxPercentage = 12 },
                new Tax() { Id = 3, Name = "basic", TaxPercentage = 6 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Tax() { Id = 1, Name = "Lamps" },
                new Tax() { Id = 2, Name = "Kitchen" },
                new Tax() { Id = 3, Name = "Cleaning" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Code = "L0001", Name = "Lamp", CategoryId = 1, AmountInStock = 100, BuyPrice = 2, TaxLevelId = 1, Active = true },
                new Product() { Id = 2, Code = "E0001", Name = "Toaster", CategoryId = 2, AmountInStock = 35, BuyPrice = 20, TaxLevelId = 1, Active = true },
                new Product() { Id = 3, Code = "E0002", Name = "Refrigerator", CategoryId = 2, AmountInStock = 10, BuyPrice = 150, TaxLevelId = 1, Active = true },
                new Product() { Id = 4, Code = "E0003", Name = "Washing machine", CategoryId = 3, AmountInStock = 10, BuyPrice = 200, TaxLevelId = 1, Active = true },
                new Product() { Id = 5, Code = "E0004", Name = "Dishwasher", CategoryId = 3, AmountInStock = 10, BuyPrice = 200, TaxLevelId = 1, Active = false },
                new Product() { Id = 6, Code = "E0005", Name = "Mixer", CategoryId = 2, AmountInStock = 30, BuyPrice = 15, TaxLevelId = 1, Active = false },
                new Product() { Id = 7, Code = "E0006", Name = "Iron", CategoryId = 3, AmountInStock = 40, BuyPrice = 100, TaxLevelId = 1, Active = true },
                new Product() { Id = 8, Code = "H0001", Name = "Ironing board", CategoryId = 3, AmountInStock = 20, BuyPrice = 20, TaxLevelId = 1, Active = true },
                new Product() { Id = 9, Code = "E0007", Name = "Food processor", CategoryId = 2, AmountInStock = 25, BuyPrice = 250, TaxLevelId = 1, Active = true }
            );
        }

        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
