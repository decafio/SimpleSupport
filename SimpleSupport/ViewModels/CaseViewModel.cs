using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SimpleSupport.ViewModels
{
    public class CaseViewModel
    {
        public CaseViewModel()
        {
            ParentA = new PartyViewModel();
            ParentB = new PartyViewModel();
            ThirdParty = new PartyViewModel();
        }

        public int CaseId { get; set; }

        [Display(Name = "Case Number", Description = "The case number used by the courts.")]
        [Required(ErrorMessage = "Please provide a Case Number")]
        [RegularExpression(@"^[a-zA-Z0-9-:/_]+$", ErrorMessage = "Please only use numbers, letters, and - : / _")]
        public string CaseNumber { get; set; }

        public PartyViewModel ParentA { get; set; }
        public PartyViewModel ParentB { get; set; }
        public PartyViewModel ThirdParty { get; set; }


    }
}