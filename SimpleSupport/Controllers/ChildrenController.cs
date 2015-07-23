using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

using SimpleSupport.DAL;
using SimpleSupport.DAL.Query;
using SimpleSupport.DAL.Command;

using SimpleSupport.Models;
using SimpleSupport.ViewModels;
using Microsoft.AspNet.Identity;
using System.Text; // GetUserId

namespace SimpleSupport.Controllers
{
    public class ChildrenController : Controller
    {
        private SupportContext db = new SupportContext();

        // GET: Children
        public async Task<ActionResult> Index(int id)
        {
            QueryCases caseRepo = new QueryCases(db);
            //PartyTypeRepository pTypeRepo = new PartyTypeRepository(db);

            string userId = User.Identity.GetUserId();

            Case aCase = await caseRepo.CaseByIdAsync(id, userId);

            ChildrenViewModel VM = new ChildrenViewModel();
            VM.CaseMenu = new CaseMenuViewModel(aCase, "Children");

            VM.Children = aCase.Children.ToList();

            return View(VM);
        }

        // GET: Children/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = await db.Children.FindAsync(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // GET: Children/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Overnights,ThirdPartyCustody")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(child);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(child);
        }

        // GET: Children/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || Request.QueryString["childId"] == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int childId = 0;
            if (int.TryParse(Request.QueryString["childId"], out childId))
            {
                Child child = await db.Children.FindAsync(childId);
                if (child != null) return View(child);
            }

            return HttpNotFound();
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Overnights,ThirdPartyCustody,Case")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Entry(child).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { id = child.Case.Id });
            }
            else
            {
                string validationErrors = string.Join(",",
        ModelState.Values.Where(E => E.Errors.Count > 0)
        .SelectMany(E => E.Errors)
        .Select(E => E.ErrorMessage)
        .ToArray());

                var query = from state in ModelState.Values
                            from error in state.Errors
                            select error.ErrorMessage;

                var errorList = query.ToList(); 

                //StringBuilder errorString = new StringBuilder();
                //var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                //foreach (ModelError err in allErrors)
                //{
                //    errorString.Append("::" + err.ErrorMessage + "||" + err.Exception.InnerException);
                //}
                //string temp = errorString.ToString();
                string temp2 = validationErrors + errorList;
            }

            return View(child);
        }

        // POST: Children/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int childId)
        {
            string userId = User.Identity.GetUserId();
            // CasesRepository caseRepo = new CasesRepository(db);
            bool booHasAccess = await SecurityRepository.VerifyAccess(db, id, userId);

            if (booHasAccess)
            {
                CommandChildren childRepo = new CommandChildren(db);
                await childRepo.RemoveAsync(childId, userId);
            }
            return RedirectToAction("Index", new { id = id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ProcessModelStateErrors()
        {
            string validationErrors = string.Join(",",
                    ModelState.Values.Where(E => E.Errors.Count > 0)
                    .SelectMany(E => E.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToArray());

            //StringBuilder errorString = new StringBuilder();
            //var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            //foreach (ModelError err in allErrors)
            //{
            //    errorString.Append("::" + err.ErrorMessage + "||" + err.Exception.InnerException);
            //}
            //string temp = errorString.ToString();
            string temp2 = validationErrors;
        }
    }
}
