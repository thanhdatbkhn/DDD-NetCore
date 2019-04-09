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
    public class PackingUnitExchangeConfiguration : IEntityTypeConfiguration<PackingUnitExchange>
    {

        public void Configure(EntityTypeBuilder<PackingUnitExchange> builder)
        {
            builder.ToTable("PackingUnitExchange");

            builder.HasKey(ux => ux.Id);

            //builder.Property(p => p.PackingUnitExchangeId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //builder.Ignore(ux => ux.PackingUnitExchangeName);
        }
    }
}
