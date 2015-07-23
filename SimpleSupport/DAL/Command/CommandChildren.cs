using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include

using SimpleSupport.Models;

namespace SimpleSupport.DAL.Command
{
    public class CommandChildren : CommandRepository<Child>
    {
        private readonly SupportContext _dbContext;

        public CommandChildren(SupportContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RemoveAsync(int childId, string userId)
        {
            Child child = await _dbContext.Children.Where(c => c.Id == childId).FirstOrDefaultAsync();
            await base.RemoveAsync(child, userId);

            //_dbContext.Children.Remove(child);

            //await _dbContext.SaveChangesAsync();
        }
    }
}