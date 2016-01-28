using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;

namespace Heat.Controllers
{
    public class CausalWarehousesController : System.Web.Mvc.Controller
	{


		private IHeatDBContext _db;
		public CausalWarehousesController(IHeatDBContext context)
		{
			_db = context;
		}

		// GET: CausalWarehouses
		public ActionResult Index()
		{
			var causalWarehouses = _db.CausalWarehouses;
			return View(causalWarehouses.ToList());
		}

		// GET: CausalWarehouses/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalWarehouse causalWarehouse = _db.CausalWarehouses.Find(id);
			if ((causalWarehouse == null)) {
				return HttpNotFound();
			}
			return View(causalWarehouse);
		}

		// GET: CausalWarehouses/Create
		public ActionResult Create()
		{
			ViewBag.TypeID = new SelectList(_db.CausalWarehouseGroups, "ID", "Code");
			return View();
		}

		// POST: CausalWarehouses/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Code,Sign,TypeID,Transaction")]
CausalWarehouse causalWarehouse)
		{
			if (ModelState.IsValid) {
				_db.CausalWarehouses.Add(causalWarehouse);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.TypeID = new SelectList(_db.CausalWarehouseGroups, "ID", "Code", causalWarehouse.TypeID);
			return View(causalWarehouse);
		}

		// GET: CausalWarehouses/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalWarehouse causalWarehouse = _db.CausalWarehouses.Find(id);
			if ((causalWarehouse == null)) {
				return HttpNotFound();
			}
			ViewBag.TypeID = new SelectList(_db.CausalWarehouseGroups, "ID", "Code", causalWarehouse.TypeID);
			return View(causalWarehouse);
		}

		// POST: CausalWarehouses/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Sign,TypeID,Transaction")]
CausalWarehouse causalWarehouse)
		{
			if (ModelState.IsValid) {
				_db.SetModified(causalWarehouse);
				//.State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.TypeID = new SelectList(_db.CausalWarehouseGroups, "ID", "Code", causalWarehouse.TypeID);
			return View(causalWarehouse);
		}

		// GET: CausalWarehouses/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalWarehouse causalWarehouse = _db.CausalWarehouses.Find(id);
			if ((causalWarehouse == null)) {
				return HttpNotFound();
			}
			return View(causalWarehouse);
		}

		// POST: CausalWarehouses/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			CausalWarehouse causalWarehouse = _db.CausalWarehouses.Find(id);
			_db.CausalWarehouses.Remove(causalWarehouse);
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
