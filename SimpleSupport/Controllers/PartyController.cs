using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.ViewModels;
using SimpleSupport.DAL;
using SimpleSupport.DAL.Query;
using SimpleSupport.Models;
using Microsoft.AspNet.Identity; // GetUserId
using System.Threading.Tasks; // Task

namespace SimpleSupport.Controllers
{
    [Authorize]
    public class PartyController : Controller
    {
        private SupportContext context = new SupportContext();

        [Authorize]
        public async Task<ActionResult> Index(int id, int partyId)
        {
            QueryCases caseRepo = new QueryCases(context);
            //PartyTypeRepository pTypeRepo = new PartyTypeRepository(context);
            QueryCityTax cityTaxRepo = new QueryCityTax(context);
            QueryFilingStatus filingStatusRepo = new QueryFilingStatus(context);

            string userId = User.Identity.GetUserId();

            Case aCase = await caseRepo.CaseByIdAsync(id, userId);

            Party party = aCase.Parties.Where(p => p.Id == partyId).FirstOrDefault();

            PartyViewModel VM = new PartyViewModel(party);
            VM.CaseMenu = new CaseMenuViewModel(aCase, "Party");

            VM.FilingStatuses = filingStatusRepo.GetFilingStatuses();
            VM.CityTaxes = cityTaxRepo.GetCityTaxTypes();

            return View(VM);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateParty(PartyViewModel vModel)
        {
            QueryParty partyRepo = new QueryParty(context);

            string userId = User.Identity.GetUserId();

            // should be creating aparty with a party ID ????
            Party party = await partyRepo.PartyByIdAsync(vModel.PartyId, userId);

            return RedirectToAction("Index", new { id = vModel.PartyId });
        }
    }
}