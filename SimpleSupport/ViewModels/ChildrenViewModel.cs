using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SimpleSupport.ViewModels;
using SimpleSupport.Models;

namespace SimpleSupport.ViewModels
{
    public class ChildrenViewModel
    {
        public ChildrenViewModel()
        {
            CaseMenu = new CaseMenuViewModel();
            Children = new List<Child>();
        }

        public CaseMenuViewModel CaseMenu { get; set; }
        public List<Child> Children { get; set; }
    }
}