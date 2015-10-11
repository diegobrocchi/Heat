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
using AutoMapper;

namespace Heat.Controllers
{
	public class SerialSchemesController : System.Web.Mvc.Controller
	{

		private HeatDBContext _db;

		private SerialSchemeViewModelBuilder _vmBuilder;
		public SerialSchemesController(HeatDBContext context)
		{
			_db = context;
			_vmBuilder = new SerialSchemeViewModelBuilder(context);
		}
		// GET: SerialSchemes
		public ActionResult Index()
		{
			return View(_vmBuilder.getListViewModel());
		}

		// GET: SerialSchemes/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SerialScheme serialScheme = _db.SerialSchemes.Find(id);
			if ((serialScheme == null)) {
				return HttpNotFound();
			}
			CreateSerialSchemeViewModel schemaDetails = null;
			schemaDetails = Mapper.Map<CreateSerialSchemeViewModel>(serialScheme);

			return View(schemaDetails);
		}

		// GET: SerialSchemes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SerialSchemes/Create
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateSerialSchemeViewModel newSerialScheme)
		{
			if (ModelState.IsValid) {
				SerialScheme serialScheme = null;

				serialScheme = Mapper.Map<SerialScheme>(newSerialScheme);

				_db.SerialSchemes.Add(serialScheme);
				_db.SaveChanges();

				return RedirectToAction("Index");
			}
			return View(newSerialScheme);
		}

		// GET: SerialSchemes/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SerialScheme serialScheme = _db.SerialSchemes.Find(id);
			if ((serialScheme == null)) {
				return HttpNotFound();
			}
			CreateSerialSchemeViewModel editSerialScheme = null;
			editSerialScheme = Mapper.Map<CreateSerialSchemeViewModel>(serialScheme);
			return View(editSerialScheme);
		}

		// POST: SerialSchemes/Edit/5
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(CreateSerialSchemeViewModel editSerialScheme)
		{
			if (ModelState.IsValid) {
				SerialScheme serialScheme = null;
				serialScheme = Mapper.Map<SerialScheme>(editSerialScheme);
				_db.Entry(serialScheme).State = EntityState.Modified;
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(editSerialScheme);
		}

		// GET: SerialSchemes/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SerialScheme serialScheme = _db.SerialSchemes.Find(id);
			if ((serialScheme == null)) {
				return HttpNotFound();
			}
			return View(serialScheme);
		}

		// POST: SerialSchemes/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			SerialScheme serialScheme = _db.SerialSchemes.Find(id);
			_db.SerialSchemes.Remove(serialScheme);
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
