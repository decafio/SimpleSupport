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
using Microsoft.AspNet.Identity; // GetUserId
using System.Net;

namespace SimpleSupport.Controllers
{
    [Authorize]
    public partial class CasesController : Controller
    {
        private SupportContext db = new SupportContext();

        public async Task<ActionResult> Index()
        {
            var model = new CasesViewModel();
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

                model.Cases.Add(new SingleCaseViewModel()
                {
                    CaseId = aCase.CaseId,
                    CaseNumber = aCase.CaseNumber,
                    ChildCount = childCount,
                    CaseTitle = caseTitle
                });
            }

            return View(model);
        }

        public async Task<ActionResult> DeleteCase(int id)
        {
            if (ModelState.IsValid)
            {
                var caseRepo = new CasesRepository(db);

                // Check if user has access to this case
                string userId = User.Identity.GetUserId();

                //Case aCase = await db.Cases.Where(m => m.CaseId == id).Where(p => p.AspNetUserId == userId).FirstAsync();
                Case aCase = await caseRepo.CaseByIdAsync(id, userId);

                if (aCase == null)
                {
                    // User does not have access
                    // ~~TODO~~ Make this redirect to a nicer message
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    // db.Cases.Remove(aCase);
                    // await db.SaveChangesAsync();
                    await caseRepo.RemoveAsync(aCase);
                }
            }
            return RedirectToAction("Index", "Cases");
        }

        public async Task<ActionResult> Summary(int id)
        {
            var caseRepo = new CasesRepository(db);
            string userId = User.Identity.GetUserId();

            Case aCase = await caseRepo.CaseByIdAsync(id, userId);
            return View(aCase);
        }
	}
}