namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Party
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
    
        [Key]
        public int PartyId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Provide a Name")]
        //[RegularExpression(@"^[a-zA-Z'-]+$", ErrorMessage = "Please only use letters, apostrophe, space, or hyphon.")]
        public string Name { get; set; }

        [Display(Name = "Monthly Health Insurance<br/>Premium (per child)")]
        [Required(ErrorMessage = "Provide a Health Ins. Amount")]
        public decimal HealthCareAmount { get; set; }

        [Display(Name = "Monthly Child Care Costs<br />(total for all children)")]
        [Required(ErrorMessage = "Provide a Child Care Amount")]
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
    }
}
