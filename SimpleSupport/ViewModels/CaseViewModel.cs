using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.Models;

namespace SimpleSupport.ViewModels
{
    public class CaseViewModel
    {
        public int CaseId { get; set; }

        [Display(Name = "Case Number",
                     Description = "The case number used by the courts.")]
        [Required(ErrorMessage = "Please provide a Case Number")]
        [RegularExpression(@"^[a-zA-Z0-9-:/_]+$", ErrorMessage = "Please only use numbers, letters, and - : / _")]
        public string CaseNumber { get; set; }

        public string CaseTitle { get; set; }

        public int ChildCount { get; set; }
    }
}