namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class Income
    {
        public int IncomeId { get; set; }

        [Required(ErrorMessage = "Provide an Income Amount")]
        [DisplayName("Gross Income")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Amount { get; set; }
                
        // Foreign keys
        public virtual Party Party { get; set; }
        public virtual IncomeType IncomeType { get; set; }
    }
}
