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
using Heat.ViewModels.ThermalUnits;

namespace Heat.Controllers
{
	public class ThermalUnitsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;

		private ThermalUnitModelViewBuilder _mb;
		public ThermalUnitsController(IHeatDBContext dbContext)
		{
			_db = dbContext;
			_mb = new ThermalUnitModelViewBuilder(_db);
		}

		// GET: ThermalUnits
		public ActionResult Index()
		{
			return View(_db.ThermalUnits.ToList());
		}

		// GET: ThermalUnits/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ThermalUnit thermalUnit = _db.ThermalUnits.Find(id);
			if ((thermalUnit == null)) {
				return HttpNotFound();
			}
			return View(thermalUnit);
		}

		//<HttpGet> _
		//<Route("ThermalUnits/Create")> _
		//Function Create() As ActionResult
		//    Try
		//        Dim model As CreateThermalUnitViewModel
		//        model = _mb.GetCreateThermalUnitViewModel
		//        Return View(model)
		//    Catch ex As Exception
		//        ViewBag.message = ex.ToString
		//        Return View("error")
		//    End Try

		//End Function

		[HttpGet()]
		public ActionResult Create(int plantID = -1)
		{
			try {
				CreateThermalUnitViewModel model = null;

				if (plantID == -1) {
					model = _mb.GetCreateThermalUnitViewModel();

				} else {
					if (!_db.Plants.Any(x => x.ID == plantID)) {
						return HttpNotFound();
					}

					model = _mb.GetCreateThermalUnitViewModel(plantID);

				}
				return View(model);


			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}



		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateThermalUnitViewModel newThermalUnit)
		{
			if (ModelState.IsValid) {
				ThermalUnit tu = null;
				Plant p = null;

				p = _db.Plants.Find(newThermalUnit.PlantID);

				tu = AutoMapper.Mapper.Map<ThermalUnit>(newThermalUnit);

				p.ThermalUnit = tu;
				_db.ThermalUnits.Add(tu);

				_db.SaveChanges();

				return RedirectToAction("Index");
			} else {
				//il modello non è valido, quindi torna in view per correggere gli errori.
				//il modelBuilder ricostruisce le select.

				CreateThermalUnitViewModel model = null;
				if (newThermalUnit.PlantID != 0) {
					model = _mb.GetCreateThermalUnitViewModel(newThermalUnit.PlantID);
				} else {
					model = _mb.GetCreateThermalUnitViewModel();
				}

				return View(model);

			}
		}

		// GET: ThermalUnits/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ThermalUnit thermalUnit = _db.ThermalUnits.Find(id);
			if ((thermalUnit == null)) {
				return HttpNotFound();
			}
			return View(thermalUnit);
		}

		// POST: ThermalUnits/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,SerialNumber,InstallationDate,FirstStartUp,Warranty,WarrantyExpiration,NominalThermalPowerMax,DismissDate,ThermalEfficiencyPowerMax,Kind")]
ThermalUnit thermalUnit)
		{
			if (ModelState.IsValid) {
				// _db.Entry(thermalUnit).State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(thermalUnit);
		}

		// GET: ThermalUnits/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ThermalUnit thermalUnit = _db.ThermalUnits.Find(id);
			if ((thermalUnit == null)) {
				return HttpNotFound();
			}
			return View(thermalUnit);
		}

		// POST: ThermalUnits/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			try {
				ThermalUnit thermalUnit = _db.ThermalUnits.Find(id);
				Plant plant = _db.Plants.Where(x => x.ThermalUnit.ID == thermalUnit.ID).First();
				plant.ThermalUnit = null;
				_db.ThermalUnits.Remove(thermalUnit);
				_db.SaveChanges();
				return RedirectToAction("Index");
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

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
