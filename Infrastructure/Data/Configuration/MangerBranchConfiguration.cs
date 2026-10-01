using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class MangerBranchConfiguration : IEntityTypeConfiguration<ManagerBranch>
    {
        public void Configure(EntityTypeBuilder<ManagerBranch> builder)
        {
            builder.HasIndex(m => m.UserId)
                    .IsUnique();
            builder.Property(e => e.UserId)
                   .HasMaxLength(450);
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.IsActive).HasDefaultValue(true);
            builder.HasOne(m => m.branch)
                    .WithOne(m => m.ManagerBranch)
                    .HasForeignKey<ManagerBranch>(m => m.ManagerBranchId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<User>()
                   .WithOne()
                   .HasForeignKey<ManagerBranch>(m => m.UserId)

                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
