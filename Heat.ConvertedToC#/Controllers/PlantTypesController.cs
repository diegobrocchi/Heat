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
using Heat.Repositories;
using Heat.Models;

namespace Heat.Controllers
{
	[Authorize()]
	public class PlantTypesController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: PlantTypes
		public ActionResult Index()
		{
			return View(db.PlantTypes.ToList());
		}

		// GET: PlantTypes/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantType plantType = db.PlantTypes.Find(id);
			if ((plantType == null)) {
				return HttpNotFound();
			}
			return View(plantType);
		}

		// GET: PlantTypes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PlantTypes/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name")]
PlantType plantType)
		{
			if (ModelState.IsValid) {
				db.PlantTypes.Add(plantType);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(plantType);
		}

		// GET: PlantTypes/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantType plantType = db.PlantTypes.Find(id);
			if ((plantType == null)) {
				return HttpNotFound();
			}
			return View(plantType);
		}

		// POST: PlantTypes/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name")]
PlantType plantType)
		{
			if (ModelState.IsValid) {
				db.Entry(plantType).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(plantType);
		}

		// GET: PlantTypes/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantType plantType = db.PlantTypes.Find(id);
			if ((plantType == null)) {
				return HttpNotFound();
			}
			return View(plantType);
		}

		// POST: PlantTypes/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			PlantType plantType = db.PlantTypes.Find(id);
			db.PlantTypes.Remove(plantType);
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
