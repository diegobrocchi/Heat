using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;

namespace Heat.Controllers
{
    public class MediaController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: Media
		public ActionResult Index()
		{
			return View(db.Media.ToList());
		}

		// GET: Media/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Medium medium = db.Media.Find(id);
			if ((medium == null)) {
				return HttpNotFound();
			}
			return View(medium);
		}

		// GET: Media/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Media/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,FileName,RelativePath,AbsolutePath,Lenght,Extension,Description,Tags")]
Medium medium)
		{
			if (ModelState.IsValid) {
				db.Media.Add(medium);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(medium);

		}

		// GET: Media/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Medium medium = db.Media.Find(id);
			if ((medium == null)) {
				return HttpNotFound();
			}
			return View(medium);
		}

		// POST: Media/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,FileName,RelativePath,AbsolutePath,Lenght,Extension,Description,Tags")]
Medium medium)
		{
			if (ModelState.IsValid) {
				db.Entry(medium).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(medium);
		}

		// GET: Media/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Medium medium = db.Media.Find(id);
			if ((medium == null)) {
				return HttpNotFound();
			}
			return View(medium);
		}

		// POST: Media/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Medium medium = db.Media.Find(id);
			db.Media.Remove(medium);
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
