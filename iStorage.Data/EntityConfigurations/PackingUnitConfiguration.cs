using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStorage.Domain.AggregatesModels.PackingUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductApp.DataLayer.Models.Data.Configurations
{
    public class PackingUnitConfiguration : IEntityTypeConfiguration<PackingUnit>
    {
        //public PackingUnitConfiguration()
        //{
        //    this.ToTable("PackingUnit");
        //    this.HasKey(u => u.PackingUnitId);
        //    //this.Property(p => p.PackingUnitId)
        //        //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    this.Property(u => u.PackingUnitName)
        //        .HasMaxLength(20)
        //        .IsRequired()
        //        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        //                            new IndexAnnotation(new IndexAttribute() { IsUnique = true })
        //                            );
        //}
        public void Configure(EntityTypeBuilder<PackingUnit> builder)
        {
            builder.ToTable("PackingUnit");
            builder.HasKey(u => u.Id);
            //builder.Property(p => p.PackingUnitId)
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //builder.Property(u => u.PackingUnitName)
            //.HasMaxLength(20)
            //.IsRequired()
            //.HasColumnAnnotation(IndexAnnotation.AnnotationName,
            //new IndexAnnotation(new IndexAttribute() { IsUnique = true })
            //);
        }
    }
}
