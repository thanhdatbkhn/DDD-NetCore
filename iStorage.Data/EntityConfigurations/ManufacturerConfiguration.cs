using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStorage.Domain.AggregatesModels.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iStorage.Data.EntityConfigurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {

        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturer");

            builder.HasKey(m => m.Id);

            //builder.Property(m => m.ManufactureId)

            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //builder.Property(m => m.ManufacturerName)
                //.IsRequired()
                //.HasMaxLength(50)
                //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
                //new IndexAnnotation(
                //    new IndexAttribute
                //    {
                //        IsUnique = true
                //    }
                //    )
                //);
        }
    }
}
