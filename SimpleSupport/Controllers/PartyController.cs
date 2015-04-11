using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.ViewModels;
using SimpleSupport.DAL;
using SimpleSupport.Models;
using Microsoft.AspNet.Identity; // GetUserId
using System.Threading.Tasks; // Task

namespace SimpleSupport.Controllers
{
    [Authorize]
    public class PartyController : Controller
    {
        // GET: Party
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public async Task<ActionResult> Index(int id, int partyId)
        {
            SupportContext context = new SupportContext();
            CasesRepository caseRepo = new CasesRepository(context);
            PartyTypeRepository pTypeRepo = new PartyTypeRepository(context);
            CityTaxRepository cityTaxRepo = new CityTaxRepository(context);
            FilingStatusRepository filingStatusRepo = new FilingStatusRepository(context);

            string userId = User.Identity.GetUserId();

            Case aCase = await caseRepo.CaseByIdAsync(id, userId);

            Party thisParty = aCase.Parties.Where(p => p.PartyId == partyId).FirstOrDefault();

            PartyViewModel VM = new PartyViewModel(thisParty);
            VM.CaseMenu = new CaseMenuViewModel(aCase, "Party");

            VM.FilingStatuses = filingStatusRepo.GetFilingStatuses();
            VM.CityTaxes = cityTaxRepo.GetCityTaxTypes();

            return View(VM);
        }
    }
}