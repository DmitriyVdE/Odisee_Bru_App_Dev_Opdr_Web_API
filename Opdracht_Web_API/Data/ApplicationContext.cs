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

            modelBuilder.Entity<StoreItem>().HasData(
                new StoreItem() { Id = 1, Code = "L0001", Name = "Lamp", Active = true, AmountInStock = 100, BuyPrice = 2, TaxLevelId = 1 },
                new StoreItem() { Id = 2, Code = "E0001", Name = "Broodrooster", Active = true, AmountInStock = 35, BuyPrice = 20, TaxLevelId = 1 },
                new StoreItem() { Id = 3, Code = "E0002", Name = "Koelkast", Active = true, AmountInStock = 10, BuyPrice = 150, TaxLevelId = 1 },
                new StoreItem() { Id = 4, Code = "E0003", Name = "Wasmachine", Active = true, AmountInStock = 10, BuyPrice = 200, TaxLevelId = 1 },
                new StoreItem() { Id = 5, Code = "E0004", Name = "Vaatwasmachine", Active = true, AmountInStock = 10, BuyPrice = 200, TaxLevelId = 1 },
                new StoreItem() { Id = 6, Code = "E0005", Name = "Mixer", Active = true, AmountInStock = 30, BuyPrice = 15, TaxLevelId = 1 },
                new StoreItem() { Id = 7, Code = "E0006", Name = "Strijkijzer", Active = true, AmountInStock = 40, BuyPrice = 100, TaxLevelId = 1 },
                new StoreItem() { Id = 8, Code = "H0001", Name = "Strijkplank", Active = true, AmountInStock = 20, BuyPrice = 20, TaxLevelId = 1 },
                new StoreItem() { Id = 9, Code = "E0007", Name = "Keukenrobot", Active = true, AmountInStock = 25, BuyPrice = 250, TaxLevelId = 1 }
            );
        }

        public DbSet<Tax> Taxes { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
