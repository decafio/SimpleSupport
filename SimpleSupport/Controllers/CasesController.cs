using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.ViewModels;
using SimpleSupport.Models;
using SimpleSupport.Classes;
using SimpleSupport.DAL;

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Net;

namespace SimpleSupport.Controllers
{
    public partial class CasesController : Controller
    {
        private SupportContext db = new SupportContext();

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var model = new List<CaseViewModel>();
            var caseRepo = new CasesRepository(db);

            ViewBag.ErrorMessage = "";
            if (Request.QueryString["error"] != null)
            {
                int errorMessage = Convert.ToInt32(Request.QueryString["error"]);
                ErrorsStrings er = (ErrorsStrings)errorMessage;
                ViewBag.ErrorMessage = ErrorMessage.GetEnumDescription(er);
            }

            string userId = User.Identity.GetUserId();

            // Get the cases related to the current user
            List<Case> cases = await caseRepo.CasesByUserAsync(userId);

            foreach (Case aCase in cases)
            {
                int childCount = aCase.Children.Count();
                string nameA = aCase.Parties.Where(c => c.PartyType.Code == "A").First().Name;
                string nameB = aCase.Parties.Where(c => c.PartyType.Code == "B").First().Name;
                string caseTitle = nameA + " vs " + nameB;

                model.Add(new CaseViewModel()
                {
                    CaseId = aCase.CaseId,
                    CaseNumber = aCase.CaseNumber,
                    ChildCount = childCount,
                    CaseTitle = caseTitle
                });
            }

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> DeleteCase(int id)
        {
            if (ModelState.IsValid)
            {
                // Check if user has access to this case
                string userId = User.Identity.GetUserId();
                Case aCase = await db.Cases.Where(m => m.CaseId == id).Where(p => p.AspNetUserId == userId).FirstAsync();

                if (aCase == null)
                {
                    // User does not have access
                    // ~~TODO~~ Make this redirect to a nicer message
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    db.Cases.Remove(aCase);
                    await db.SaveChangesAsync();
                }
            }

            return RedirectToAction("Cases", new { id = id });
        }

	}
}