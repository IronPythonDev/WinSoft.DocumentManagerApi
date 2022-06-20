using Microsoft.EntityFrameworkCore;
using WinSoft.Core.Data.Configurations;
using WinSoft.Core.Domain.Entitites;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Domain.Entitites.Documents.DocumentTypes;

namespace WinSoft.Core.Data
{

    public class ApplicationContext : DbContext
    {
        static bool IsEnsured = false;
        private readonly string dbName;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Passport> Passports { get; set; } = null!;
        public DbSet<DrivingLicence> DrivingLicences { get; set; } = null!;
        public DbSet<CreditCard> CreditCards { get; set; } = null!;

        public DbSet<DocumentDirectory> DocumentDirectories { get; set; } = null!;
        public DbSet<DocumentsPackage> DocumentsPackages { get; set; } = null!;

        public ApplicationContext(string dbName = "WinSoftDB")
        {
            this.dbName=dbName;

            if (IsEnsured) return;

            Database.EnsureCreated();
            IsEnsured = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseInMemoryDatabase(dbName);

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder
            .ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new PassportConfiguration())
            .ApplyConfiguration(new DrivingLicenceConfiguration())
            .ApplyConfiguration(new CreditCardConfiguration())
            .ApplyConfiguration(new DocumentDirectoryConfiguration())
            .ApplyConfiguration(new DocumentsPackageConfiguration());
    }
}