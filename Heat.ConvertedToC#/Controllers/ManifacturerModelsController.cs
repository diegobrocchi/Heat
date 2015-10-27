using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using Heat.Models;
using Heat.ViewModels.ManifacturerModels;

namespace Heat.Controllers
{
    public class ManifacturerModelsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;

		private ManifacturerModelViewBuilder _mb;

		public ManifacturerModelsController(IHeatDBContext context)
		{
			_db = context;
			_mb = new ManifacturerModelViewBuilder(_db);
		}

		// GET: ManifacturerModels
		public ActionResult Index()
		{
			List<IndexManifacturerModelViewModel> model = null;

			model = _mb.GetIndexManifacturerModelViewModel();

			return View(model);
		}

		// GET: ManifacturerModels/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ManifacturerModel manifacturerModel = _db.ManifacturerModels.Find(id);
			if ((manifacturerModel == null)) {
				return HttpNotFound();
			}
			return View(manifacturerModel);
		}

		[HttpGet()]
		public ActionResult Create()
		{
			try {
				CreateManifacturerModelViewModel model = null;

				model = _mb.GetCreateManifacturerModelViewModel();

				return View(model);

			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateManifacturerModelViewModel newManifacturerModel)
		{
			try {
				if (ModelState.IsValid) {
					ManifacturerModel mm = null;

					mm = AutoMapper.Mapper.Map<ManifacturerModel>(newManifacturerModel);

					_db.ManifacturerModels.Add(mm);
					_db.SaveChanges();
					return RedirectToAction("Index");
				} else {
					return View(newManifacturerModel);
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}


		}

		// GET: ManifacturerModels/Edit/5
		public ActionResult Edit(int id)
		{

			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				if (!_db.ManifacturerModels.Any(x => x.ID == id)) {
					return HttpNotFound();
				}
				EditManifacturerModelViewModel model = null;
				model = _mb.GetEditManifacturerModelViewModel(id);
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		// POST: ManifacturerModels/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditManifacturerModelViewModel editedManifacturerModel)
		{

			try {
				if (ModelState.IsValid) {
					ManifacturerModel dbItem = null;
					dbItem = _db.ManifacturerModels.Find(editedManifacturerModel.ID);

					AutoMapper.Mapper.Map(editedManifacturerModel, dbItem);

					_db.SaveChanges();

					return RedirectToAction("Index");
				} else {
					return View(editedManifacturerModel);
				}

			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		// GET: ManifacturerModels/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ManifacturerModel manifacturerModel = _db.ManifacturerModels.Find(id);
			if ((manifacturerModel == null)) {
				return HttpNotFound();
			}
			return View(manifacturerModel);
		}

		// POST: ManifacturerModels/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			ManifacturerModel manifacturerModel = _db.ManifacturerModels.Find(id);
			_db.ManifacturerModels.Remove(manifacturerModel);
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
