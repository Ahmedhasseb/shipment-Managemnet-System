using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class DriverConfigurations : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            //builder.HasIndex(m => m.UserId)
            //         .IsUnique();
            builder.Property(d => d.name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.VehicleType)
                 .IsRequired()
                 .HasMaxLength(50);
            builder.Property(d => d.VehiclePlateNumber)
                    .IsRequired();


            //builder.HasOne(d => d.EmployeeBranch)
            //        .WithOne(eb => eb.Drivers)
            //    .HasForeignKey<Driver>(d => d.EmployeeBranchId)
            //    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Branch)
                .WithMany(b => b.Drivers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(d => d.Shipments)
                .WithOne(s => s.Driver)
                .HasForeignKey(s => s.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<User>()
                   .WithOne()
                  .HasForeignKey<Driver>(d => d.UserId)

                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
