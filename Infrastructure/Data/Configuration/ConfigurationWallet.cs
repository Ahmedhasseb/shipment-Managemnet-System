using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using model;

namespace Infrastructure.Data.Configuration
{
    public class ConfigurationWallet : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
           builder.HasKey(i => i.Id);
            builder.Property(i=>i.Balance).IsRequired();
            builder.Property(i=>i.WalletOwnerType).IsRequired();
        }
    }
}
