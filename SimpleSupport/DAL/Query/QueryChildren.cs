using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include

using SimpleSupport.Models;

namespace SimpleSupport.DAL.Query
{
    public class QueryChildren : SecureRepository<Child>
    {
        private readonly SupportContext _dbContext;

        public QueryChildren(SupportContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns a list of cases.
        /// </summary>
        /// <param name="userId">Required to verify user has access to cases.</param>
        public async Task<List<Child>> ChildrenByCaseIdAsync(string userId, int caseId)
        {
            // Include -- Eagerly Loading the Parties
            return await _dbContext.Children
                .Where(p => p.Case.AspNetUserId == userId)
                .Where(k => k.Case.Id == caseId)
                .ToListAsync();
        }

        /// <summary>
        /// Returns a single case.
        /// </summary>
        /// <param name="userId">Required to verify user has access to case.</param>
        public async Task<Child> ChildByIdAsync(int childId, string userId)
        {
            return await _dbContext.Children
                .Where(c => c.Id == childId)
                .Where(p => p.Case.AspNetUserId == userId)
                .FirstAsync();
        }

        //public async Task RemoveAsync(int childId)
        //{
        //    Child child = await _dbContext.Children.Where(c => c.ChildId == childId).FirstOrDefaultAsync();
        //    await base.RemoveAsync(child);

        //    //_dbContext.Children.Remove(child);

        //    //await _dbContext.SaveChangesAsync();
        //}
    }
}