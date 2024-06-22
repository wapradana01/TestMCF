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
    public class BpkbTransactionEntityBuilder : EntityBuilderBase<BpkbTransaction>
    {
        public override void Configure(EntityTypeBuilder<BpkbTransaction> builder)
        {
            base.Configure(builder);

            builder
                .Property(e => e.AgreementNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(e => e.BpkbNo)
                .HasMaxLength(100);

            builder
                .Property(e => e.BranchId)
                .HasMaxLength(10);

            builder
                .Property(e => e.FakturNo)
                .HasMaxLength(100);

            builder
                .Property(e => e.LocationId)
                .HasMaxLength(10);

            builder
                .Property(e => e.PoliceNo)
                .HasMaxLength(20);

            builder
                .HasOne(e => e.Location)
                .WithMany(e => e.BpkbTransactions)
                .HasForeignKey(e => e.LocationId);
        }
    }
}
