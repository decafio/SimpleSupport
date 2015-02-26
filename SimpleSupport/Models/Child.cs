namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Child
    {
        [Key]
        public int ChildId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Provide child's First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Provide child's Last Name")]
        public string LastName { get; set; }

        // [RegularExpression(@"^([0]?[1-9]|[1][0-2])[/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[/-](19|20)\d\d$", ErrorMessage = "Format as mm/dd/yyyy")]
        public Nullable<int> ParentingTimeId { get; set; }
        public Nullable<bool> ThirdPartyCustody { get; set; }

        // Foreign key to Case
        public virtual Case Case { get; set; }
        public virtual ParentingTime ParentingTime { get; set; }
    }
}
