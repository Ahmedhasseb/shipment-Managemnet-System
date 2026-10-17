using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class MerchantRequestConfiguration : IEntityTypeConfiguration<MerchantRequests>
    {
        public void Configure(EntityTypeBuilder<MerchantRequests> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasOne<User>()
                    .WithOne()
                    .HasForeignKey<MerchantRequests>(m => m.UserId)
                    .IsRequired(false);
            builder.HasOne(m => m.Branch)
                    .WithMany(b => b.MerchantRequests)
                    .HasForeignKey(m => m.BranchId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Property(m => m.FName)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(m => m.Email)
                 .IsRequired()
                    .HasMaxLength(100);
            builder.Property(m => m.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(m => m.PhoneMerchant)
                    .IsRequired();
            builder.Property(m => m.Address)
                    .IsRequired()
                    .HasMaxLength(200);
        }
    }
}
