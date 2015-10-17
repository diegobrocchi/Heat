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
using Heat.ViewModels.PlantServices;

namespace Heat.Controllers
{
	public class PlantServicesController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;

		private PlantServiceModelViewBuilder _mb;
		public PlantServicesController(IHeatDBContext dbContext)
		{
			_db = dbContext;
			_mb = new PlantServiceModelViewBuilder(_db);
		}


		// GET: PlantServices
		public ActionResult Index()
		{
			//Dim plantServices = _db.PlantServices.Include(Function(p) p.Plant)
			return View(_db.PlantServices.ToList());
		}

		// GET: PlantServices/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantService plantService = _db.PlantServices.Find(id);
			if ((plantService == null)) {
				return HttpNotFound();
			}
			return View(plantService);
		}

		[HttpGet()]
		public ActionResult Create(int plantID)
		{
			try {
				if ((plantID == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				if (!_db.Plants.Any(x => x.ID == plantID)) {
					return HttpNotFound();
				}

				CreatePlantServiceViewModel model = null;
				model = _mb.GetCreatePlantServiceViewModel(plantID);

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}
			ViewBag.ID  = new SelectList(_db.Plants, "ID", "Name");
			return View();
		}


		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreatePlantServiceViewModel newPlantService)
		{
			try {
				if (ModelState.IsValid) {
					PlantService ps = null;

					ps = AutoMapper.Mapper.Map<PlantService>(newPlantService);
					//ps.Plant = _db.Plants.Find(newPlantService.PlantID)

					_db.PlantServices.Add(ps);
					_db.SaveChanges();
					return RedirectToAction("Index");


				} else {
					return View(newPlantService);

				}
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}


		}

		// GET: PlantServices/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantService plantService = _db.PlantServices.Find(id);
			if ((plantService == null)) {
				return HttpNotFound();
			}
			ViewBag.ID  = new SelectList(_db.Plants, "ID", "Name", plantService.ID);
			return View(plantService);
		}

		// POST: PlantServices/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,PlantID,PreviousServiceDate,Periodicity,LegalExpirationDate,PlannedServiceDate")]
PlantService plantService)
		{
			if (ModelState.IsValid) {
				//_db.Entry(plantService).State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.ID  = new SelectList(_db.Plants, "ID", "Name", plantService.ID);
			return View(plantService);
		}

		// GET: PlantServices/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantService plantService = _db.PlantServices.Find(id);
			if ((plantService == null)) {
				return HttpNotFound();
			}
			return View(plantService);
		}

		// POST: PlantServices/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			PlantService plantService = _db.PlantServices.Find(id);
			_db.PlantServices.Remove(plantService);
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
