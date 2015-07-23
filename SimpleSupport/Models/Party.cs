namespace SimpleSupport.Models
{
    using System.Collections.Generic;
    
    public class Party : ISecureModel
    {
        public Party()
        {
            this.Incomes = new HashSet<Income>();
            this.Deductions = new HashSet<Deduction>();

            this.Exemptions = 0;
            this.ExemptionsUnder17 = 0;
            this.AdditionalChildren = 0;
            this.HealthCareAmount = 0.00m;
            this.ChildCareAmount = 0.00m;
        }
    
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal HealthCareAmount { get; set; }
        public decimal ChildCareAmount { get; set; }

        // Tax Fields
        public short Exemptions { get; set; }
        public short ExemptionsUnder17 { get; set; }
        public short AdditionalChildren { get; set; }
        
        // Foreign keys
        public virtual Case Case { get; set; }
        public virtual PartyType PartyType { get; set; }
        public virtual FilingStatus FilingStatus { get; set; }
        public virtual CityTax CityTax { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Deduction> Deductions { get; set; }

        // Interface
        public string GetUserId() { return Case.AspNetUserId; }  
    }
}
