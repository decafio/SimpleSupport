using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSupport.ViewModels
{
    public class SingleCaseViewModel
    {
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }
        public int ChildCount { get; set; }
        public string CaseTitle { get; set; }
    }
}