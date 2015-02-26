namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    
    public class IncomeType
    {
        public int IncomeTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool FederalTax { get; set; }
        public bool NIITax { get; set; }
        public bool AMTTax { get; set; }
        public bool SETax { get; set; }
        public bool StateTax { get; set; }
        public bool FICA { get; set; }
        public bool CityTax { get; set; }
        public string Code { get; set; }
    }
}
