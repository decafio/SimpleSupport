using System.Collections.Generic; // Used for List
using System.Linq; // Used for Where

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include

using SimpleSupport.Models;

namespace SimpleSupport.DAL.Query
{
    public class QueryParty : QueryRepository<Party>
    {
        private readonly SupportContext _dbContext;

        public QueryParty(SupportContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns a list of cases.
        /// </summary>
        /// <param name="userId">Required to verify user has access to cases.</param>
        public async Task<List<Party>> PartiesByUserAsync(string userId)
        {
            // Include -- Eagerly Loading the Parties
            return await _dbContext.Cases.Where(p => p.AspNetUserId == userId).SelectMany(c => c.Parties).ToListAsync();
        }

        /// <summary>
        /// Returns a single case.
        /// </summary>
        /// <param name="userId">Required to verify user has access to case.</param>
        public async Task<Party> PartyByIdAsync(int partyId, string userId)
        {
            return await _dbContext.Parties.Where(p => p.Case.AspNetUserId == userId).Where(p => p.Id == partyId).FirstAsync();
            //return await _dbContext.Cases.Where(m => m.CaseId == caseId).Where(p => p.AspNetUserId == userId).FirstAsync();
        }

    }
}