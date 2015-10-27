using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;

namespace Heat.Controllers
{
    public class CausalDocumentsController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: CausalDocuments
		public ActionResult Index()
		{
			return View("index", db.CausalDocuments.ToList());
		}

		// GET: CausalDocuments/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalDocument causalDocument = db.CausalDocuments.Find(id);
			if ((causalDocument == null)) {
				return HttpNotFound();
			}
			return View(causalDocument);
		}

		// GET: CausalDocuments/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CausalDocuments/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Code,Description")]
CausalDocument causalDocument)
		{
			if (ModelState.IsValid) {
				db.CausalDocuments.Add(causalDocument);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(causalDocument);
		}

		// GET: CausalDocuments/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalDocument causalDocument = db.CausalDocuments.Find(id);
			if ((causalDocument == null)) {
				return HttpNotFound();
			}
			return View(causalDocument);
		}

		// POST: CausalDocuments/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Description")]
CausalDocument causalDocument)
		{
			if (ModelState.IsValid) {
				db.Entry(causalDocument).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(causalDocument);
		}

		// GET: CausalDocuments/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CausalDocument causalDocument = db.CausalDocuments.Find(id);
			if ((causalDocument == null)) {
				return HttpNotFound();
			}
			return View(causalDocument);
		}

		// POST: CausalDocuments/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			CausalDocument causalDocument = db.CausalDocuments.Find(id);
			db.CausalDocuments.Remove(causalDocument);
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
