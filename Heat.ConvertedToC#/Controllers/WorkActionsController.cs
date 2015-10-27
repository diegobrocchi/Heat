using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.ViewModels.WorkActions;

namespace Heat.Controllers
{
    public class WorkActionsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;

		private WorkActionModelViewBuilder _mb;
		public WorkActionsController(IHeatDBContext dbContext)
		{
			_db = dbContext;
			_mb = new WorkActionModelViewBuilder(_db);
		}

		public ActionResult Index()
		{
			var workactions = _db.WorkActions.Include(w => w.AssignedOperator).Include(w => w.Operation).Include(w => w.Type);
			return View(workactions.ToList());
		}

		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkAction workAction = _db.WorkActions.Find(id);
			if ((workAction == null)) {
				return HttpNotFound();
			}
			return View(workAction);
		}

		[HttpGet()]
		public ActionResult Create(int plantID = -1)
		{
			try {
				CreateWorkActionViewModel model = null;


				if (plantID == -1) {
					model = _mb.GetCreateWorkActionViewModel();

				} else {
					if (!_db.Plants.Any(x => x.ID == plantID)) {
						return HttpNotFound();
					}

					model = _mb.GetCreateWorkActionViewModel(plantID);
				}

				//If IsNothing(plantID) Then
				//    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
				//End If

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateWorkActionViewModel newWorkAction)
		{
			try {
				if (ModelState.IsValid) {
					WorkAction wa = null;
					wa = AutoMapper.Mapper.Map<WorkAction>(newWorkAction);
					wa.Plant = _db.Plants.Find(newWorkAction.PlantID);

					_db.WorkActions.Add(wa);
					_db.SaveChanges();

					return RedirectToAction("index", "plants", null);

				} else {
					_mb.BindSelectListItems(newWorkAction);

					return View(newWorkAction);

				}
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		// GET: WorkActions/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkAction workAction = _db.WorkActions.Find(id);
			if ((workAction == null)) {
				return HttpNotFound();
			}
			ViewBag.AssignedOperatorID = new SelectList(_db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID);
			//ViewBag.CustomerID = New SelectList(_db.Customers, "ID", "Name", workAction.CustomerID)
			ViewBag.OperationID = new SelectList(_db.Operations, "ID", "Code", workAction.OperationID);
			ViewBag.TypeID = new SelectList(_db.ActionTypes, "ID", "Description", workAction.TypeID);
			return View(workAction);
		}

		// POST: WorkActions/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,CustomerID,ActionDate,OperationID,AssignedOperatorID,TypeID")]
WorkAction workAction)
		{
			if (ModelState.IsValid) {
				//_db.Entry(workAction).State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.AssignedOperatorID = new SelectList(_db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID);
			//ViewBag.CustomerID = New SelectList(_db.Customers, "ID", "Name", workAction.CustomerID)
			ViewBag.OperationID = new SelectList(_db.Operations, "ID", "Code", workAction.OperationID);
			ViewBag.TypeID = new SelectList(_db.ActionTypes, "ID", "Description", workAction.TypeID);
			return View(workAction);
		}

		// GET: WorkActions/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkAction workAction = _db.WorkActions.Find(id);
			if ((workAction == null)) {
				return HttpNotFound();
			}
			return View(workAction);
		}

		// POST: WorkActions/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			WorkAction workAction = _db.WorkActions.Find(id);
			_db.WorkActions.Remove(workAction);
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
