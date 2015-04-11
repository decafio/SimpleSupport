using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSupport.ViewModels
{
    public class ChildViewModel
    {
        public int ChildId { get; set; }

        public string Name { get; set; }
        public decimal Overnights { get; set; }

        public bool thirdPartyCustody { get; set; }
    }
}