using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(l => l.Type).IsRequired();
            builder.Property(l => l.BasePrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.HasMany(l => l.FromShipments)
                   .WithOne(l => l.FromLocation)
                   .HasForeignKey(s => s.FromLocationId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(l => l.ToShipments)
                 .WithOne(l => l.ToLocation)
                 .HasForeignKey(s => s.ToLocationId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(l => l.Branches)
                   .WithOne(b => b.Location)
                   .HasForeignKey(b => b.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
