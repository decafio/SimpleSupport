namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Deduction
    {
        [Key]
        public int DeductionId { get; set; }

        [Required(ErrorMessage = "Provide a Deduction Amount")]
        public decimal Amount { get; set; }

        // Foreign keys
        public virtual Party Party { get; set; }
        public virtual DeductionType DeductionType { get; set; }
    }
}
