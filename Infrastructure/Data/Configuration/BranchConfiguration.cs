using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.EmailBranch)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.PhoneBranch)
               .IsRequired();
            builder.Property(b => b.Address)
               .IsRequired()
               .HasMaxLength(300);

            builder.HasOne(b => b.ManagerBranch)
                    .WithOne(m => m.branch)
                    .HasForeignKey<ManagerBranch>(b => b.ManagerBranchId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(b => b.EmployeeBranches)
                    .WithOne(eb => eb.Branch)
                    .HasForeignKey(eb => eb.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(b => b.Merchants)
                   .WithOne(m => m.Branch)
                    .HasForeignKey(m => m.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(b => b.Shipments)
                    .WithOne(s => s.Branch)
                    .HasForeignKey(s => s.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
