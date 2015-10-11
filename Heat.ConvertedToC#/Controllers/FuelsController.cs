using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Entity;
using System.Net;
using Heat;
using Heat.Models;
using Heat.Repositories;
using System.Security.Claims;
using log4net;
using System.IdentityModel.Services;

namespace Heat.Controllers
{
	public class FuelsController : System.Web.Mvc.Controller
	{


		public HeatDBContext db = new HeatDBContext();
		// GET: Fuels
		//<Authorize(roles:="canViewFuels")> _
		[ClaimsAutorize(ClaimTypes.Name, "demo")]
		public ActionResult Index()
		{
			return View(db.Fuels.ToList());
		}

		// GET: Fuels/Details/5
		[ResourceAuthorize(ResourceOperations.ReadOwn, "FuelDetail")]
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Fuel fuel = db.Fuels.Find(id);
			if ((fuel == null)) {
				return HttpNotFound();
			}
			return View(fuel);
		}

		// GET: Fuels/Create
		[ClaimsPrincipalPermission(System.Security.Permissions.SecurityAction.Demand, Operation = "Create", Resource = "Fuel")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Fuels/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name")]
Fuel fuel)
		{
			if (ModelState.IsValid) {
				db.Fuels.Add(fuel);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(fuel);
		}

		// GET: Fuels/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Fuel fuel = db.Fuels.Find(id);
			if ((fuel == null)) {
				return HttpNotFound();
			}
			return View(fuel);
		}

		// POST: Fuels/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name")]
Fuel fuel)
		{
			if (ModelState.IsValid) {
				db.Entry(fuel).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(fuel);
		}

		// GET: Fuels/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Fuel fuel = db.Fuels.Find(id);
			if ((fuel == null)) {
				return HttpNotFound();
			}
			return View(fuel);
		}

		// POST: Fuels/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Fuel fuel = db.Fuels.Find(id);
			db.Fuels.Remove(fuel);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet()]
		public FileResult PrintToPDF()
		{
			return File("c:\\temp\\prova.pdf", "application/pdf");
		}
		protected override void Dispose(bool disposing)
		{
			if ((disposing)) {
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
