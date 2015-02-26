using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include

using SimpleSupport.Models;

namespace SimpleSupport.DAL
{
    public class ParentingTimeRepository : BaseRepository<ParentingTime>
    {
        private readonly SupportContext _dbContext;

        public ParentingTimeRepository(SupportContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task RemoveUnused()
        {
            // Get a list of Parenting Times without children. These will be deleted.
            List<ParentingTime> delParentingTimes = await
                _dbContext.ParentingTimes.Where(m => m.Children.Count() < 1).ToListAsync<ParentingTime>();

            foreach (ParentingTime delParentingTime in delParentingTimes)
            {
                _dbContext.ParentingTimes.Remove(delParentingTime);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}