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
	public class SellersController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: Sellers
		public ActionResult Index()
		{
			return View(db.Seller.ToList());
		}

		// GET: Sellers/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Seller seller = db.Seller.Find(id);
			if ((seller == null)) {
				return HttpNotFound();
			}
			return View(seller);
		}

		// GET: Sellers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Sellers/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,FiscalCode,IBAN,Logo,Name,Vat_Number")]
Seller seller)
		{
			if (ModelState.IsValid) {
				db.Seller.Add(seller);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(seller);
		}

		// GET: Sellers/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Seller seller = db.Seller.Find(id);
			if ((seller == null)) {
				return HttpNotFound();
			}
			return View(seller);
		}

		// POST: Sellers/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,FiscalCode,IBAN,Logo,Name,Vat_Number")]
Seller seller)
		{
			if (ModelState.IsValid) {
				db.Entry(seller).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(seller);
		}

		// GET: Sellers/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Seller seller = db.Seller.Find(id);
			if ((seller == null)) {
				return HttpNotFound();
			}
			return View(seller);
		}

		// POST: Sellers/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Seller seller = db.Seller.Find(id);
			db.Seller.Remove(seller);
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
