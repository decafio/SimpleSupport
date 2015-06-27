using SimpleSupport.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleSupport.DAL
{
    public class SupportContext : DbContext
    {

        public SupportContext()
            : base("SimpleSupportDbString")
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
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyType> PartyTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deduction>().Property(x => x.Amount).HasPrecision(8, 2);
            modelBuilder.Entity<Income>().Property(x => x.Amount).HasPrecision(8, 2);
            modelBuilder.Entity<Party>().Property(x => x.ChildCareAmount).HasPrecision(8, 2);
            modelBuilder.Entity<Party>().Property(x => x.HealthCareAmount).HasPrecision(8, 2);
            modelBuilder.Entity<CityTax>().Property(x => x.TaxRate).HasPrecision(6, 3);

            // Setup cascading deletes in database
            // i.e. If Case is deleted, casecade delete Child
            //  http://stackoverflow.com/questions/14898128/ef-code-first-cascade-delete-on-foreign-key-one-to-many
            // modelBuilder.Entity<Case>().HasMany(v => v.Children).WithOptional().WillCascadeOnDelete(true);
            // modelBuilder.Entity<Case>().HasMany(v => v.Parties).WithOptional().WillCascadeOnDelete(true);
            // modelBuilder.Entity<Party>().HasMany(v => v.Incomes).WithOptional().WillCascadeOnDelete(true);
            // modelBuilder.Entity<Party>().HasMany(v => v.Deductions).WithOptional().WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}