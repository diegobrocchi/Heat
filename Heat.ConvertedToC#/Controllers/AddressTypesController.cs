using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;

namespace Heat.Controllers
{
    public class AddressTypesController : System.Web.Mvc.Controller
	{


		private HeatDBContext db = new HeatDBContext();
		// GET: AddressTypes
		public ActionResult Index()
		{
			return View(db.AddressTypes.ToList());
		}

		// GET: AddressTypes/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AddressType addressType = db.AddressTypes.Find(id);
			if ((addressType == null)) {
				return HttpNotFound();
			}
			return View(addressType);
		}

		// GET: AddressTypes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AddressTypes/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,Description")]
AddressType addressType)
		{
			if (ModelState.IsValid) {
				db.AddressTypes.Add(addressType);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(addressType);
		}

		// GET: AddressTypes/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AddressType addressType = db.AddressTypes.Find(id);
			if ((addressType == null)) {
				return HttpNotFound();
			}
			return View(addressType);
		}

		// POST: AddressTypes/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Description")]
AddressType addressType)
		{
			if (ModelState.IsValid) {
				db.Entry(addressType).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(addressType);
		}

		// GET: AddressTypes/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AddressType addressType = db.AddressTypes.Find(id);
			if ((addressType == null)) {
				return HttpNotFound();
			}
			return View(addressType);
		}

		// POST: AddressTypes/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			AddressType addressType = db.AddressTypes.Find(id);
			db.AddressTypes.Remove(addressType);
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
