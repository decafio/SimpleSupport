using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSupport.ViewModels
{
    public class DbResetViewModel
    {
        public DbResetViewModel()
        {
            this.Counts = new DbCounts();
        }

        public DbCounts Counts { get; set; }
    }

    public class DbCounts
    {
        public int CityTaxes { get; set; }
        public int IncomeTypes { get; set; }
        public int DeductionTypes { get; set; }
        public int PartTypes { get; set; }
        public int FilingStatus { get; set; }

        public int Cases { get; set; }
        public int Children { get; set; }
        public int Deductions { get; set; }
        public int Incomes { get; set; }
        public int ParentingTimes { get; set; }
        public int Parties { get; set; }
    }
}