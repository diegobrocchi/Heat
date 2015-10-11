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
using Heat.ViewModels.Heaters;

namespace Heat.Controllers
{
	public class HeatersController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;

		private HeaterModelViewBuilder _mb;
		public HeatersController(IHeatDBContext dbContext)
		{
			_db = dbContext;
			_mb = new HeaterModelViewBuilder(_db);
		}

		// GET: Heaters
		public ActionResult Index()
		{
			return View(_db.Heaters.ToList());
		}

		// GET: Heaters/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Heater heater = _db.Heaters.Find(id);
			if ((heater == null)) {
				return HttpNotFound();
			}
			return View(heater);
		}

		[HttpGet()]
		public ActionResult Create(int thermalUnitID)
		{
			try {
				if ((thermalUnitID == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				if (!_db.ThermalUnits.Any(x => x.ID == thermalUnitID)) {
					return HttpNotFound();
				}

				CreateHeaterViewModel model = null;
				model = _mb.GetCreateHeaterViewModel(thermalUnitID);

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateHeaterViewModel newHeater)
		{
			try {
				if (ModelState.IsValid) {
					ThermalUnit tu = null;
					Heater h = null;

					//a causa della relazione tra ThermalUnit e Heater (1-a-molti)
					//devo assegnare il ThermalUnit al Heater che sto inserendo
					tu = _db.ThermalUnits.Find(newHeater.ThermalUnitID);

					h = AutoMapper.Mapper.Map<Heater>(newHeater);
					h.ThermalUnit = tu;

					_db.Heaters.Add(h);
					_db.SaveChanges();
					return RedirectToAction("Index");
				} else {
					return View(newHeater);
				}

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		// GET: Heaters/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Heater heater = _db.Heaters.Find(id);
			if ((heater == null)) {
				return HttpNotFound();
			}
			return View(heater);
		}

		// POST: Heaters/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,SerialNumber,MinimumPowerKW,MaximumPowerKW,CertificationReference")]
Heater heater)
		{
			if (ModelState.IsValid) {
				//_db.Entry(heater).State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(heater);
		}

		// GET: Heaters/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Heater heater = _db.Heaters.Find(id);
			if ((heater == null)) {
				return HttpNotFound();
			}
			return View(heater);
		}

		// POST: Heaters/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Heater heater = _db.Heaters.Find(id);
			_db.Heaters.Remove(heater);
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
