using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.TrackingNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne<User>()
                   .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Merchant)
                .WithMany(m => m.Shipments)
                .HasForeignKey(s => s.MerchantId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.MerchantEmployee)
                    .WithMany(i => i.Shipments)
                    .HasForeignKey(s => s.MerchantEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.EmployeeBranch)
                   .WithMany(i => i.Shipments)
                   .HasForeignKey(s => s.AssignedEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Driver)
                 .WithMany(i => i.Shipments)
                 .HasForeignKey(s => s.DriverId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.ShipmentRequest)
                .WithOne(i => i.Shipment)
                .HasForeignKey<Shipment>(s => s.ShipmentRequestId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
