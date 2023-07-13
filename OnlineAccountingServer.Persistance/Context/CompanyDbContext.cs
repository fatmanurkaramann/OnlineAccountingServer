using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString;

        public CompanyDbContext(Company company = null)
        {
            if (company != null)
            {
                if (company.UserId == "")
                {
                    ConnectionString = $"" +
                        $"Data Source={company.ServerName};Initial Catalog={company.DatabaseName};" +
                  $"User Id={company.UserId};Password={company.Password};" +
                  $" Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                  $"TrustServerCertificate=False;" +
                  $"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                }
                else
                {
                    ConnectionString = $"" +
                        $"Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                  $"Integrated Security=True;Connect Timeout=30;" +
                  $"Encrypt=False;TrustServerCertificate=False;" +
                  $"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                }
            }


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {

                return new CompanyDbContext(new Company());
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var item in entries)
            {
                if (item.State == EntityState.Added)
                {

                    item.Property(p => p.CretedDate)
                        .CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Modified)
                {
                    item.Property(p => p.UpdatedDate).CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
