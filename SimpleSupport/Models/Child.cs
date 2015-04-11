namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Child
    {
        public Child()
        {
            Overnights = 0;
        }

        public int ChildId { get; set; }

        public string Name { get; set; }
        public decimal Overnights { get; set; }

        private bool _thirdPartyCustody = false;
        public bool ThirdPartyCustody { 
            get { return _thirdPartyCustody; }
            set { _thirdPartyCustody = value; }
        }

        // [ForeignKey("Case")]
        public virtual Case Case { get; set; }
    }
}
