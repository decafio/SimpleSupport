namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Child : ISecureModel
    {
        public Child()
        {
            Overnights = 0;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Overnights { get; set; }

        private bool _thirdPartyCustody = false;
        public bool ThirdPartyCustody { 
            get { return _thirdPartyCustody; }
            set { _thirdPartyCustody = value; }
        }

        // [ForeignKey("Case")]
        public virtual Case Case { get; set; }

        // Interface
        public string GetUserId() { return Case.AspNetUserId; }       
    }
}
