using SimpleSupport.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleSupport.DAL
{
    public class SupportContext : DbContext
    {

        public SupportContext()
            : base("SupportContext")
        {
            Database.SetInitializer<SupportContext>(new CreateDatabaseIfNotExists<SupportContext>());
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<CityTax> CityTaxes { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<DeductionType> DeductionTypes { get; set; }
        public DbSet<FilingStatus> FilingStatus { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<ParentingTime> ParentingTimes { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyType> PartyTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deduction>().Property(x => x.Amount).HasPrecision(8, 2);
            modelBuilder.Entity<Income>().Property(x => x.Amount).HasPrecision(8, 2);
            modelBuilder.Entity<Party>().Property(x => x.ChildCareAmount).HasPrecision(8, 2);
            modelBuilder.Entity<Party>().Property(x => x.HealthCareAmount).HasPrecision(8, 2);
            modelBuilder.Entity<CityTax>().Property(x => x.TaxRate).HasPrecision(6, 3);
        }


    }
}