namespace SimpleSupport.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using SimpleSupport.Models;
   
    public class PartyViewModel
    {
        public PartyViewModel()
        {
            PartyId = 0;
            Name = "";
            HealthCareAmount = 0m;
            ChildCareAmount = 0m;
            Exemptions = 0;
            ExemptionsUnder17 = 0;
            AdditionalChildren = 0;
            FilingStatusId = 0;
            CityTaxID = 0;

            FilingStatuses = new List<SelectListItem>();
            CityTaxes = new List<SelectListItem>();

            CaseMenu = new CaseMenuViewModel();
        }

        public PartyViewModel(Party party)
        {
            PartyId = party.PartyId;
            Name = party.Name;
            HealthCareAmount = party.HealthCareAmount;
            ChildCareAmount = party.ChildCareAmount;
            Exemptions = party.Exemptions;
            ExemptionsUnder17 = party.ExemptionsUnder17;
            AdditionalChildren = party.AdditionalChildren;
            FilingStatusId = party.FilingStatus.FilingStatusId;
            CityTaxID = party.CityTax.CityTaxId;

            FilingStatuses = new List<SelectListItem>();
            CityTaxes = new List<SelectListItem>();
        }

        public int PartyId { get; set; }

        public CaseMenuViewModel CaseMenu { get; set; }
        
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
        [Display(Name = "Total Exemptions")]
        [Required(ErrorMessage = "Provide the Total Tax Exemptions")]
        public short Exemptions { get; set; }

        [Display(Name = "Total Exemptions Under 17")]
        [Required(ErrorMessage = "Provide the Tax Exemptions Under 17")]
        public short ExemptionsUnder17 { get; set; }

        [Display(Name = "Additional Children")]
        [Required(ErrorMessage = "Provide the Additional Children")]
        public short AdditionalChildren { get; set; }

        // Also store the selected id
        public int PartyTypeId { get; set; }
        public string PartyTypeCode { get; set; }

        [Display(Name = "Filing Status")]
        [Required(ErrorMessage = "Provide your tax Filing Status.")]
        public int FilingStatusId { get; set; }

        [Display(Name = "Filing Status")]
        public IEnumerable<SelectListItem> FilingStatuses { get; set; }

        [Display(Name = "City Tax")]
        [Required(ErrorMessage = "Enter any local taxes you may have.")]
        public int CityTaxID { get; set; }

        [Display(Name = "City Taxes")]
        public IEnumerable<SelectListItem> CityTaxes { get; set; }

        [Display(Name = "Income")]
        public int IncomeId { get; set; }

        [Display(Name = "Income Types")]
        public IEnumerable<Income> Incomes { get; set; }

        public int DeductionId { get; set; }
        public IEnumerable<Deduction> Deductions { get; set; }
    }
}