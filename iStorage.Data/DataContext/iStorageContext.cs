using System;
using iStorage.Domain.AggregatesModels.Products;
using iStorage.Domain.AggregatesModels.Users;
using Microsoft.EntityFrameworkCore;

namespace iStorage.Data.DataContext
{
    public class iStorageContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Token> Tokens { get; set; }
        //public DbSet<PackingUnit> PackingUnits { get; set; }
        //public DbSet<PackingUnitExchange> PackingUnitExchanges { get; set; }
        //public DbSet<Manufacturer> Manufacturers { get; set; }
        //public DbSet<Vendor> Vendors { get; set; }

        public iStorageContext(DbContextOptions<iStorageContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<Token>().ToTable("Token");
            //modelBuilder.Entity<Medicine>().ToTable("Medicine");
            //modelBuilder.Entity<Equipment>().ToTable("Equipment");

            //modelBuilder.Configurations.Add(new ProductConfiguration());
            //modelBuilder.Configurations.Add(new PackingUnitConfiguration());
            //modelBuilder.Configurations.Add(new PackingUnitExchangeConfiguration());
            //modelBuilder.Configurations.Add(new ManufacturerConfiguration());
            //modelBuilder.Configurations.Add(new VendorConfiguration());
        }
    }
}
