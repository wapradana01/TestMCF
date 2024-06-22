using DataAccess.Bases;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Builders
{
    public class LocationEntityBuilder : EntityBuilderBase<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.LocationId)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.LocationName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
