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

namespace Heat.Controllers
{
	public class WorkOperatorsController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: WorkOperators
		public ActionResult Index()
		{
			return View(db.WorkOperators.ToList());
		}

		// GET: WorkOperators/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkOperator workOperator = db.WorkOperators.Find(id);
			if ((workOperator == null)) {
				return HttpNotFound();
			}
			return View(workOperator);
		}

		// GET: WorkOperators/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: WorkOperators/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name")]
WorkOperator workOperator)
		{
			if (ModelState.IsValid) {
				db.WorkOperators.Add(workOperator);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(workOperator);
		}

		// GET: WorkOperators/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkOperator workOperator = db.WorkOperators.Find(id);
			if ((workOperator == null)) {
				return HttpNotFound();
			}
			return View(workOperator);
		}

		// POST: WorkOperators/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name")]
WorkOperator workOperator)
		{
			if (ModelState.IsValid) {
				db.Entry(workOperator).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(workOperator);
		}

		// GET: WorkOperators/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkOperator workOperator = db.WorkOperators.Find(id);
			if ((workOperator == null)) {
				return HttpNotFound();
			}
			return View(workOperator);
		}

		// POST: WorkOperators/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			WorkOperator workOperator = db.WorkOperators.Find(id);
			db.WorkOperators.Remove(workOperator);
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
