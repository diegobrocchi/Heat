using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Repositories;
using Heat.Models;

namespace Heat.Controllers
{
    [Authorize()]
	public class PlantClassesController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: PlantClasses
		public ActionResult Index()
		{
			return View(db.PlantClasses.ToList());
		}

		// GET: PlantClasses/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantClass plantClass = db.PlantClasses.Find(id);
			if ((plantClass == null)) {
				return HttpNotFound();
			}
			return View(plantClass);
		}

		// GET: PlantClasses/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PlantClasses/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name")]
PlantClass plantClass)
		{
			if (ModelState.IsValid) {
				db.PlantClasses.Add(plantClass);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(plantClass);
		}

		// GET: PlantClasses/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantClass plantClass = db.PlantClasses.Find(id);
			if ((plantClass == null)) {
				return HttpNotFound();
			}
			return View(plantClass);
		}

		// POST: PlantClasses/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name")]
PlantClass plantClass)
		{
			if (ModelState.IsValid) {
				db.Entry(plantClass).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(plantClass);
		}

		// GET: PlantClasses/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			PlantClass plantClass = db.PlantClasses.Find(id);
			if ((plantClass == null)) {
				return HttpNotFound();
			}
			return View(plantClass);
		}

		// POST: PlantClasses/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			PlantClass plantClass = db.PlantClasses.Find(id);
			db.PlantClasses.Remove(plantClass);
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
