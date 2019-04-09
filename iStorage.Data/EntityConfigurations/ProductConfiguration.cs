
using System.ComponentModel.DataAnnotations.Schema;
using iStorage.Domain.AggregatesModels.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iStorage.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            //builder.Property(p => p.Id)
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            builder.Property(p => p.ProductName)
                .IsRequired();
        }
    }
}
