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

        public async Task<ActionResult> Index(int id)
        {
            PartiesViewModel VM = new PartiesViewModel();

            SupportContext context = new SupportContext();
            CasesRepository caseRepo = new CasesRepository(context);
            PartyTypeRepository pTypeRepo = new PartyTypeRepository(context);
            CityTaxRepository cityTaxRepo = new CityTaxRepository(context);
            FilingStatusRepository filingStatusRepo = new FilingStatusRepository(context);

            string userId = User.Identity.GetUserId();

            Case aCase = await caseRepo.CaseByIdAsync(id, userId);

            VM.CaseNumber = aCase.CaseNumber;

            // Populating the Parties
            Party partyA = aCase.Parties.Where(p => p.PartyType.Code == "A").FirstOrDefault();
            if (partyA != null)
            {
                VM.ParentA = new PartyViewModel(partyA);
                VM.ParentA.PartyTypeCode = "A";
                VM.ButtonParentA = "Edit " + partyA.Name;
            }
            else VM.ButtonParentA = "Add Parent A";

            Party partyB = aCase.Parties.Where(p => p.PartyType.Code == "B").FirstOrDefault();
            if (partyB != null)
            {
                VM.ParentB = new PartyViewModel(partyB);
                VM.ParentB.PartyTypeCode = "B";
                VM.ButtonParentB = "Edit " + partyB.Name;
            }
            else VM.ButtonParentB = "Add Parent B";

            Party thirdParty = aCase.Parties.Where(p => p.PartyType.Code == "3").FirstOrDefault();
            if (thirdParty != null)
            {
                VM.ThirdParty = new PartyViewModel(thirdParty);
                VM.ThirdParty.PartyTypeCode = "3";
                VM.ButtonThird = "Edit " + thirdParty.Name;
            }
            else
            {
                VM.ThirdParty = new PartyViewModel();
                VM.ButtonThird = "Add A Third Party";
            }

            VM.ParentB.FilingStatuses = VM.ParentA.FilingStatuses;
            VM.ParentB.CityTaxes = VM.ParentA.CityTaxes;

            VM.ParentA.FilingStatuses = filingStatusRepo.GetFilingStatuses();
            VM.ParentA.CityTaxes = cityTaxRepo.GetCityTaxTypes();

            return View(VM);
        }
    }
}