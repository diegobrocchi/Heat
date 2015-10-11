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

namespace Heat.Controllers
{
	public class PaymentsController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: Payments
		public ActionResult Index()
		{
			return View(db.Payments.ToList());
		}

		// GET: Payments/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Payment payment = db.Payments.Find(id);
			if ((payment == null)) {
				return HttpNotFound();
			}
			return View(payment);
		}

		// GET: Payments/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Payments/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Code,Description")]
Payment payment)
		{
			if (ModelState.IsValid) {
				db.Payments.Add(payment);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(payment);
		}

		// GET: Payments/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Payment payment = db.Payments.Find(id);
			if ((payment == null)) {
				return HttpNotFound();
			}
			return View(payment);
		}

		// POST: Payments/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Description")]
Payment payment)
		{
			if (ModelState.IsValid) {
				db.Entry(payment).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(payment);
		}

		// GET: Payments/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Payment payment = db.Payments.Find(id);
			if ((payment == null)) {
				return HttpNotFound();
			}
			return View(payment);
		}

		// POST: Payments/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Payment payment = db.Payments.Find(id);
			db.Payments.Remove(payment);
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
