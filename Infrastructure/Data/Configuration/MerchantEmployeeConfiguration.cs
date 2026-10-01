using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class MerchantEmployeeConfiguration : IEntityTypeConfiguration<EmployeeMerchant>
    {
        public void Configure(EntityTypeBuilder<EmployeeMerchant> builder)
        {
            builder.Property(me => me.UserId);
            builder.Property(me => me.permisson)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(me => me.Merchant)
                .WithMany(m => m.MerchantEmployees)
                .HasForeignKey(me => me.MerchantId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(me => me.Shipments)
                    .WithOne(s => s.MerchantEmployee)
                    .HasForeignKey(s => s.MerchantEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<User>()
                        .WithOne()
                        .HasForeignKey<EmployeeMerchant>(me => me.UserId)

                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
