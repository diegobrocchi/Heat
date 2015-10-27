using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;

namespace Heat.Controllers
{
    public class OperationsController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: Operations
		public ActionResult Index()
		{
			return View(db.Operations.ToList());
		}

		// GET: Operations/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Operation operation = db.Operations.Find(id);
			if ((operation == null)) {
				return HttpNotFound();
			}
			return View(operation);
		}

		// GET: Operations/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Operations/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Code,Description")]
Operation operation)
		{
			if (ModelState.IsValid) {
				db.Operations.Add(operation);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(operation);
		}

		// GET: Operations/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Operation operation = db.Operations.Find(id);
			if ((operation == null)) {
				return HttpNotFound();
			}
			return View(operation);
		}

		// POST: Operations/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Description")]
Operation operation)
		{
			if (ModelState.IsValid) {
				db.Entry(operation).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(operation);
		}

		// GET: Operations/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Operation operation = db.Operations.Find(id);
			if ((operation == null)) {
				return HttpNotFound();
			}
			return View(operation);
		}

		// POST: Operations/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Operation operation = db.Operations.Find(id);
			db.Operations.Remove(operation);
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
