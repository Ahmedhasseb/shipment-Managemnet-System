using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ShipmentRequestConfiguration : IEntityTypeConfiguration<ShipmentRequest>
    {
        public void Configure(EntityTypeBuilder<ShipmentRequest> builder)
        {
            builder.HasOne(s => s.Merchant)
                 .WithMany(m => m.ShipmentRequests)
                 .HasForeignKey(s => s.MerchantId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.FromLocation)
                .WithMany(l => l.FromShipmentRequests)
                .HasForeignKey(s => s.FromLocationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.ToLocation)
                .WithMany(l => l.ToShipmentRequests)
                .HasForeignKey(s => s.ToLocationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.EmployeeBranch)
                .WithMany(e => e.ShipmentRequests)
                .HasForeignKey(s => s.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.EmployeeMerchant)
               .WithMany(e => e.ShipmentRequests)
               .HasForeignKey(s => s.MerchantEmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
