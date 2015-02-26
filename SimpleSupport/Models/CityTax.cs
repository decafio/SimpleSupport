namespace SimpleSupport.Models
{
    using System;
    using System.Collections.Generic;
    
    public class CityTax
    {
        public int CityTaxId { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
    }
}
