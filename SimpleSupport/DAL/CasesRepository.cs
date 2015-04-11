using System.Collections.Generic; // Used for List
using System.Linq; // Used for Where

using System.Threading.Tasks; // For Task
using System.Data.Entity; // for Async extensions, Include

using SimpleSupport.Models;

namespace SimpleSupport.DAL
{
    public class CasesRepository : BaseRepository<Case>
    {
        private readonly SupportContext _dbContext;

        public CasesRepository(SupportContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns a list of cases.
        /// </summary>
        /// <param name="userId">Required to verify user has access to cases.</param>
        public async Task<List<Case>> CasesByUserAsync(string userId)
        {
            // Include -- Eagerly Loading the Parties
            return await _dbContext.Cases.Where(p => p.AspNetUserId == userId).Include(c => c.Parties).ToListAsync();
        }

        /// <summary>
        /// Returns a single case.
        /// </summary>
        /// <param name="userId">Required to verify user has access to case.</param>
        public async Task<Case> CaseByIdAsync(int caseId, string userId)
        {
            return await _dbContext.Cases.Where(m => m.CaseId == caseId).Where(p => p.AspNetUserId == userId).FirstAsync();
        }

        /// <summary>
        /// Verifies a user has access to a case.
        /// </summary>
        public async Task<bool> VerifyAccess(int caseId, string userId)
        {
            Case aCase = await CaseByIdAsync(caseId, userId);

            if (aCase == null) return false;
            else return true; 
        }
    }
}