namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Case
    {
        public Case()
        {
            this.Parties = new HashSet<Party>();
            this.Children = new HashSet<Child>();
        }

        [Key]
        public int CaseId { get; set; }

        [Display(Name = "Case Number", Description = "The case number used by the courts.")]
        [Required(ErrorMessage = "Please provide a Case Number")]
        [RegularExpression(@"^[a-zA-Z0-9-:/_]+$", ErrorMessage = "Please only use numbers, letters, and - : / _")]
        public string CaseNumber { get; set; }

        // Foreign Key (Inside Application Context)
        public string AspNetUserId { get; set; }

        public virtual ICollection<Party> Parties { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}
