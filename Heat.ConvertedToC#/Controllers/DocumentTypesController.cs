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
using Heat.Viewmodels;

namespace Heat.Controllers
{
	public class DocumentTypesController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: DocumentTypes
		public ActionResult Index()
		{
			return View(db.DocumentTypes.ToList());
		}

		// GET: DocumentTypes/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DocumentType documentType = db.DocumentTypes.Find(id);
			if ((documentType == null)) {
				return HttpNotFound();
			}
			return View(documentType);
		}

		// GET: DocumentTypes/Create
		public ActionResult Create()
		{
			DocumentTypeAddViewModel dtvm = new DocumentTypeAddViewModel();

			dtvm.NumberingList = new SelectList(db.Numberings.ToList(), "ID", "Code");

			return View(dtvm);
		}

		// POST: DocumentTypes/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name,Description")]
DocumentType documentType)
		{
			if (ModelState.IsValid) {
				db.DocumentTypes.Add(documentType);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(documentType);
		}

		// GET: DocumentTypes/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DocumentType documentType = db.DocumentTypes.Find(id);
			if ((documentType == null)) {
				return HttpNotFound();
			}
			return View(documentType);
		}

		// POST: DocumentTypes/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name,Description")]
DocumentType documentType)
		{
			if (ModelState.IsValid) {
				db.Entry(documentType).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(documentType);
		}

		// GET: DocumentTypes/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DocumentType documentType = db.DocumentTypes.Find(id);
			if ((documentType == null)) {
				return HttpNotFound();
			}
			return View(documentType);
		}

		// POST: DocumentTypes/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			DocumentType documentType = db.DocumentTypes.Find(id);
			db.DocumentTypes.Remove(documentType);
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
