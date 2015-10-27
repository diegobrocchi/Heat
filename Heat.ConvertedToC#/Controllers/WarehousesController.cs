using System.Linq;
using System.Web.Mvc;
using System.Net;
using Heat.Models;

namespace Heat.Controllers
{
    public class WarehousesController : System.Web.Mvc.Controller
	{


		private IHeatDBContext _db;
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
                _db.SetModified(warehouse);
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
