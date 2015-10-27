using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;

namespace Heat.Controllers
{
    public class WorkOperatorsController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: WorkOperators
		public ActionResult Index()
		{
			return View(db.WorkOperators.ToList());
		}

		// GET: WorkOperators/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkOperator workOperator = db.WorkOperators.Find(id);
			if ((workOperator == null)) {
				return HttpNotFound();
			}
			return View(workOperator);
		}

		// GET: WorkOperators/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: WorkOperators/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Name")]
WorkOperator workOperator)
		{
			if (ModelState.IsValid) {
				db.WorkOperators.Add(workOperator);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(workOperator);
		}

		// GET: WorkOperators/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkOperator workOperator = db.WorkOperators.Find(id);
			if ((workOperator == null)) {
				return HttpNotFound();
			}
			return View(workOperator);
		}

		// POST: WorkOperators/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Name")]
WorkOperator workOperator)
		{
			if (ModelState.IsValid) {
				db.Entry(workOperator).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(workOperator);
		}

		// GET: WorkOperators/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			WorkOperator workOperator = db.WorkOperators.Find(id);
			if ((workOperator == null)) {
				return HttpNotFound();
			}
			return View(workOperator);
		}

		// POST: WorkOperators/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			WorkOperator workOperator = db.WorkOperators.Find(id);
			db.WorkOperators.Remove(workOperator);
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
