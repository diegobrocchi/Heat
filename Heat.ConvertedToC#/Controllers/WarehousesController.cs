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
	public class WarehousesController : System.Web.Mvc.Controller
	{


		private HeatDBContext _db;
		public WarehousesController(IHeatDBContext context)
		{
			_db = context;
		}


		// GET: Warehouses
		public ActionResult Index()
		{
			return View(_db.Warehouses.ToList());
		}

		// GET: Warehouses/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Warehouse warehouse = _db.Warehouses.Find(id);
			if ((warehouse == null)) {
				return HttpNotFound();
			}
			return View(warehouse);
		}

		// GET: Warehouses/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Warehouses/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Code,Description,HasValue")]
Warehouse warehouse)
		{
			if (ModelState.IsValid) {
				_db.Warehouses.Add(warehouse);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(warehouse);
		}

		// GET: Warehouses/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Warehouse warehouse = _db.Warehouses.Find(id);
			if ((warehouse == null)) {
				return HttpNotFound();
			}
			return View(warehouse);
		}

		// POST: Warehouses/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Description,HasValue")]
Warehouse warehouse)
		{
			if (ModelState.IsValid) {
				_db.Entry(warehouse).State = EntityState.Modified;
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(warehouse);
		}

		// GET: Warehouses/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Warehouse warehouse = _db.Warehouses.Find(id);
			if ((warehouse == null)) {
				return HttpNotFound();
			}
			return View(warehouse);
		}

		// POST: Warehouses/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Warehouse warehouse = _db.Warehouses.Find(id);
			_db.Warehouses.Remove(warehouse);
			_db.SaveChanges();
			return RedirectToAction("Index");
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
