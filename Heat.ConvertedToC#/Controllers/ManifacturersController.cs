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
using Heat.Models;
using Heat.Repositories;
using Heat.ViewModels.ManifacturerModels;

namespace Heat.Controllers
{
	public class ManifacturersController : System.Web.Mvc.Controller
	{


		HeatDBContext db = new HeatDBContext();
		// GET: Manifacturers
		public ActionResult Index()
		{
			return View(db.Manifacturers.ToList());


		}

		// GET: Manifacturers/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Manifacturer manifacturer = db.Manifacturers.Find(id);
			if ((manifacturer == null)) {
				return HttpNotFound();
			}
			return View(manifacturer);
		}

		// GET: Manifacturers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Manifacturers/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name")]
Manifacturer manifacturer)
		{
			if (ModelState.IsValid) {
				db.Manifacturers.Add(manifacturer);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(manifacturer);
		}

		// GET: Manifacturers/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Manifacturer manifacturer = db.Manifacturers.Find(id);
			if ((manifacturer == null)) {
				return HttpNotFound();
			}
			return View(manifacturer);
		}

		// POST: Manifacturers/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name")]
Manifacturer manifacturer)
		{
			if (ModelState.IsValid) {
				db.Entry(manifacturer).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(manifacturer);
		}

		// GET: Manifacturers/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Manifacturer manifacturer = db.Manifacturers.Find(id);
			if ((manifacturer == null)) {
				return HttpNotFound();
			}
			return View(manifacturer);
		}

		// POST: Manifacturers/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Manifacturer manifacturer = db.Manifacturers.Find(id);
			db.Manifacturers.Remove(manifacturer);
			db.SaveChanges();
			return RedirectToAction("Index");
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