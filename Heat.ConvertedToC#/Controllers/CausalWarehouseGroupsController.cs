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

namespace Heat.Controllers
{
	public class CausalWarehouseGroupsController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: CausalWarehouseGroups
		public ActionResult Index()
		{
			return View(db.CausalWarehouseGroups.ToList());
		}

		// GET: CausalWarehouseGroups/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalWarehouseGroup causalWarehouseGroup = db.CausalWarehouseGroups.Find(id);
			if ((causalWarehouseGroup == null)) {
				return HttpNotFound();
			}
			return View(causalWarehouseGroup);
		}

		// GET: CausalWarehouseGroups/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CausalWarehouseGroups/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Code,Description")]
CausalWarehouseGroup causalWarehouseGroup)
		{
			if (ModelState.IsValid) {
				db.CausalWarehouseGroups.Add(causalWarehouseGroup);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(causalWarehouseGroup);
		}

		// GET: CausalWarehouseGroups/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalWarehouseGroup causalWarehouseGroup = db.CausalWarehouseGroups.Find(id);
			if ((causalWarehouseGroup == null)) {
				return HttpNotFound();
			}
			return View(causalWarehouseGroup);
		}

		// POST: CausalWarehouseGroups/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Description")]
CausalWarehouseGroup causalWarehouseGroup)
		{
			if (ModelState.IsValid) {
				db.Entry(causalWarehouseGroup).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(causalWarehouseGroup);
		}

		// GET: CausalWarehouseGroups/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalWarehouseGroup causalWarehouseGroup = db.CausalWarehouseGroups.Find(id);
			if ((causalWarehouseGroup == null)) {
				return HttpNotFound();
			}
			return View(causalWarehouseGroup);
		}

		// POST: CausalWarehouseGroups/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			CausalWarehouseGroup causalWarehouseGroup = db.CausalWarehouseGroups.Find(id);
			db.CausalWarehouseGroups.Remove(causalWarehouseGroup);
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
