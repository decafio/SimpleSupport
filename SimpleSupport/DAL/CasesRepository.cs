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

        // public async Task<TEntity> GetByIdAsync(int id) 
        public async Task<List<Case>> CasesByUserAsync(string userId)
        {
            // Include -- Eagerly Loading the Parties
            return await _dbContext.Cases.Where(p => p.AspNetUserId == userId).Include(c => c.Parties).ToListAsync();
        }

        public async Task<Case> CaseByIdAsync(int caseId, string userId)
        {
            return await _dbContext.Cases.Where(m => m.CaseId == caseId).Where(p => p.AspNetUserId == userId).FirstAsync();
        }
    }
}