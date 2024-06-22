using DataAccess.Bases;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Builders
{
    public class UserEntityBuilder : EntityBuilderBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.IsActive)
                .IsRequired();
        }
    }
}
