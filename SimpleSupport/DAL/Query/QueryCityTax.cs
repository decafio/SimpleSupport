using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include
using System.Web.Mvc; // SelectList and SelectListItem

using SimpleSupport.Models;

namespace SimpleSupport.DAL.Query
{
    public class QueryCityTax : QueryRepository<CityTax>
    {
        private readonly SupportContext _dbContext;

        public QueryCityTax(SupportContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        internal IEnumerable<SelectListItem> GetCityTaxTypes()
        {
            List<SelectListItem> allitems = _dbContext.CityTaxes.ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.CityTaxId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            allitems.Insert(0, new SelectListItem() { Value = "", Text = "Select a City Tax" });

            return new SelectList(allitems, "Value", "Text");
        }
    }
}