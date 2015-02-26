using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include

using SimpleSupport.Models;

namespace SimpleSupport.DAL
{
    public class ChildrenRepository : BaseRepository<Child>
    {
        private readonly SupportContext _dbContext;

        public ChildrenRepository(SupportContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RemoveAsync(int childId)
        {
            Child child = await _dbContext.Children.Where(c => c.ChildId == childId).FirstOrDefaultAsync();

            _dbContext.Children.Remove(child);

            await _dbContext.SaveChangesAsync();
        }
    }
}