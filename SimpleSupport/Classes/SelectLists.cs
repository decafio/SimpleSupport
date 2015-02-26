using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.Models;
using SimpleSupport.DAL;

namespace SimpleSupport.Classes
{
    public class SelectLists
    {
        private SupportContext db = new SupportContext();

        internal IEnumerable<SelectListItem> GetIncomeTypes()
        {
            List<SelectListItem> allitems = db.IncomeTypes.ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.IncomeTypeId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            return new SelectList(allitems, "Value", "Text");
        }

        internal IEnumerable<SelectListItem> GetDeductionTypes()
        {
            List<SelectListItem> allitems = db.DeductionTypes.ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.DeductionTypeId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            return new SelectList(allitems, "Value", "Text");
        }

        internal IEnumerable<SelectListItem> GetParents(Case aCase)
        {
            List<SelectListItem> bothParents = aCase.Parties.Where(p => p.PartyType.Code != "3").ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.PartyId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            return new SelectList(bothParents, "Value", "Text");
        }

        internal IEnumerable<SelectListItem> GetCityTaxTypes()
        {
            List<SelectListItem> allitems = db.CityTaxes.ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.CityTaxId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            allitems.Insert(0, new SelectListItem() { Value = "", Text = "Select a City Tax" });

            return new SelectList(allitems, "Value", "Text");
        }

        internal IEnumerable<SelectListItem> GetFilingStatuses()
        {
            List<SelectListItem> allitems = db.FilingStatus.ToList().Select(x =>
                new SelectListItem
                {
                    Value = x.FilingStatusId.ToString(),
                    Text = x.Name
                }).ToList<SelectListItem>();

            allitems.Insert(0, new SelectListItem() { Value = "", Text = "Select a Filing Status" });

            return new SelectList(allitems, "Value", "Text");
        }

        internal IEnumerable<SelectListItem> GetUnusedPartyTypes(Case aCase)
        {
            List<PartyType> partyTypes = db.PartyTypes.ToList();
            List<SelectListItem> types = new List<SelectListItem>();

            foreach (PartyType aType in partyTypes)
            {
                if (aCase.Parties.Where(a => a.PartyType.Code == aType.Code).Count() == 0)
                    types.Add(
                        new SelectListItem
                        {
                            Text = aType.Name,
                            Value = aType.PartyTypeId.ToString()
                        });
            }
            
            return new SelectList(types, "Value", "Text");
        }

        internal IEnumerable<SelectListItem> GetCustodyOptions(Case aCase)
        {
            List<SelectListItem> types = new List<SelectListItem>();

            List<Party> Custody = (aCase.Parties.Where(a => a.PartyType.Code == "3").ToList());
            // List<SelectListItem> CustodyList = new List<SelectListItem>();

            types.Add(new SelectListItem
            {
                Text = "Parent Custody",
                Value = ""
            });

            // If there is a Third Party setup then allow the selection of Third Party Custody
            if (Custody.Count() > 0)
            {
                types.Add(new SelectListItem
                {
                    Text = "Third Party Custody",
                    Value = "True"
                });
            }

            // Since we are defaulting to Parents I am giving Parents the "" value so that it is selected whether the value is null
            // types.Insert(0, new SelectListItem() { Value = "", Text = "Select a Party Type" });

            return new SelectList(types, "Value", "Text");
        }
    }
}