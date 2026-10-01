using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    internal class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            //builder.HasIndex(m => m.UserId)
            //         .IsUnique();

            builder.Property(m => m.name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
            builder.Property(m => m.PhoneMerchant).IsRequired();
            builder.Property(m => m.Address).IsRequired().HasMaxLength(200);

            builder.HasMany(m => m.Shipments)
                   .WithOne(s => s.Merchant)
                   .HasForeignKey(s => s.MerchantId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(m => m.MerchantEmployees)
                   .WithOne(me => me.Merchant)
                   .HasForeignKey(me => me.MerchantId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<User>()
                        .WithOne()
                        .HasForeignKey<Merchant>(m => m.UserId)

                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
