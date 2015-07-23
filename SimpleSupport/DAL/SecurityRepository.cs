using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Threading.Tasks;
using SimpleSupport.Models;

namespace SimpleSupport.DAL
{
    public class SecurityRepository
    {
        /// <summary>
        /// Verifies a user has access to a case.
        /// </summary>
        public static async Task<bool> VerifyAccess(SupportContext _dbContext, int caseId, string userId)
        {
            string caseUserId = await GetCaseUserId(_dbContext, caseId);

            if (caseUserId == userId) return true;
            else return false;
        }

        private static async Task<string> GetCaseUserId(SupportContext _dbContext, int caseId)
        {
            return await _dbContext.Cases.Where(c => c.Id == caseId).Select(c => c.AspNetUserId).FirstOrDefaultAsync();
        }
    }
}