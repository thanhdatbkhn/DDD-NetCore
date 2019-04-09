using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStorage.Domain.AggregatesModels.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductApp.DataLayer.Models.Data.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {

        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Vendor");
            builder.HasKey(v => v.Id);
            //builder.Property(v => v.VendorId)
            //    .IsRequired()
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //builder.Property(v => v.VendorName)
                //.IsRequired()
                //.HasMaxLength(50)
                //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
                //    new IndexAnnotation(
                //        new IndexAttribute
                //        {
                //            IsUnique = true
                //        }
                //        )
                //);
        }
    }
}
