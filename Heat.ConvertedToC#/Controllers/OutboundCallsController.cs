using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Security.Principal;
using Heat.Models;
using Heat.ViewModels.OutboundCall;

namespace Heat.Controllers
{
    public class OutboundCallsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private OutboundCallsModelViewBuilder _mb;

		public OutboundCallsController(IHeatDBContext dbContext)
		{
			_db = dbContext;
			_mb = new OutboundCallsModelViewBuilder(_db);
		}

		// GET: OutboundCalls
		public ActionResult Index(IPrincipal user)
		{
            var model = _mb.GetIndexViewModel(user.Identity.Name );
			return View(model);
		}

		// GET: OutboundCalls/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OutboundCall outboundCall = _db.OutboundCalls.Find(id);
			if ((outboundCall == null)) {
				return HttpNotFound();
			}
			return View(outboundCall);
		}

		// GET: OutboundCalls/Create
		public ActionResult Create()
		{
			ViewBag.ContactID = new SelectList(_db.Contacts, "ID", "Name");
			return View();
		}

		// POST: OutboundCalls/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,CallDate,ContactID,ResultID,Login")]
OutboundCall outboundCall)
		{
			if (ModelState.IsValid) {
				_db.OutboundCalls.Add(outboundCall);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ContactID = new SelectList(_db.Contacts, "ID", "Name", outboundCall.ContactID);
			return View(outboundCall);
		}

		// GET: OutboundCalls/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OutboundCall outboundCall = _db.OutboundCalls.Find(id);
			if ((outboundCall == null)) {
				return HttpNotFound();
			}
			ViewBag.ContactID = new SelectList(_db.Contacts, "ID", "Name", outboundCall.ContactID);
			return View(outboundCall);
		}

		// POST: OutboundCalls/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,CallDate,ContactID,ResultID,Login")]
OutboundCall outboundCall)
		{
			if (ModelState.IsValid) {
				//_db.Entry(outboundCall).State = EntityState.Modified
				_db.SetModified(outboundCall);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ContactID = new SelectList(_db.Contacts, "ID", "Name", outboundCall.ContactID);
			return View(outboundCall);
		}

		// GET: OutboundCalls/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OutboundCall outboundCall = _db.OutboundCalls.Find(id);
			if ((outboundCall == null)) {
				return HttpNotFound();
			}
			return View(outboundCall);
		}

		// POST: OutboundCalls/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			OutboundCall outboundCall = _db.OutboundCalls.Find(id);
			_db.OutboundCalls.Remove(outboundCall);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet()]
		public ActionResult GetNextProposed(IPrincipal login)
		{
			try {
				ProposedOutboundCallsViewModel model = null;
				model = _mb.GetNextProposed(login.Identity.Name);
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		protected override void Dispose(bool disposing)
		{
			if ((disposing)) {
				_db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
