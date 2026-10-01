using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class EmployeeBranchesConfigurations : IEntityTypeConfiguration<EmployeeBranch>
    {
        public void Configure(EntityTypeBuilder<EmployeeBranch> builder)
        {
            //builder.HasIndex(m => m.UserId)
            //         .IsUnique();
            builder.Property(eb => eb.UserId);
            builder.Property(eb => eb.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(eb => eb.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(eb => eb.permisson)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(eb => eb.Branch)
                    .WithMany(b => b.EmployeeBranches)
                    .HasForeignKey(eb => eb.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(eb => eb.Shipments)
                   .WithOne(eb => eb.EmployeeBranch)
                     .HasForeignKey(eb => eb.AssignedEmployeeId)
                     .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<User>()
                    .WithOne()
                     .HasForeignKey<EmployeeBranch>(eb => eb.UserId)

                     .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
