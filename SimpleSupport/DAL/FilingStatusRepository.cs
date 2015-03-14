using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include
using System.Web.Mvc; // SelectList and SelectListItem

using SimpleSupport.Models;

namespace SimpleSupport.DAL
{
    public class FilingStatusRepository : BaseRepository<FilingStatus>
    {
        private readonly SupportContext _dbContext;

        public FilingStatusRepository(SupportContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        internal IEnumerable<SelectListItem> GetFilingStatuses()
        {
            List<SelectListItem> allitems = _dbContext.FilingStatus.ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.FilingStatusId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            allitems.Insert(0, new SelectListItem() { Value = "", Text = "Select a Filing Status" });

            return new SelectList(allitems, "Value", "Text");
        }
    }
}