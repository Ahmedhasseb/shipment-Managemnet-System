using Domain.Entites;
using Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using model;

namespace Infrastructure.Data
{
    public class dbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BranchConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(LocationConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(MerchantConfiguration).Assembly);

            builder.ApplyConfigurationsFromAssembly(typeof(MerchantEmployeeConfiguration).Assembly);

            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeBranchesConfigurations).Assembly);

            builder.ApplyConfigurationsFromAssembly(typeof(DriverConfigurations).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ShipmentConfiguration).Assembly);

            base.OnModelCreating(builder);
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<ManagerBranch> ManagerBranches { get; set; }
        public DbSet<EmployeeBranch> EmployeeBranches { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<EmployeeMerchant> MerchantEmployees { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> walletTransactions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Location> Pocations { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentTracking> ShipmentTrackings { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<ShipmentRequest> ShipmentRequests { get; set; }
        public DbSet<MerchantRequests> MerchantRequests { get; set; }



    }
}
