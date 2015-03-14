namespace SimpleSupport.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using SimpleSupport.Models;

    public class PartiesViewModel
    {
        // Case Fields
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }

        public PartyViewModel ParentA { get; set; }
        public PartyViewModel ParentB { get; set; }
        public PartyViewModel ThirdParty { get; set; }

        // Button Label and determinations
        public string ButtonParentA { get; set; }
        public string ButtonParentB { get; set; }
        public string ButtonThird { get; set; }
    }
}