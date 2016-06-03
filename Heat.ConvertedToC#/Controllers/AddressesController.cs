using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;

namespace Heat.Controllers
{
    public class AddressesController : System.Web.Mvc.Controller
	{
        private IHeatDBContext _db;
        public AddressesController(IHeatDBContext context)
        {
            _db = context;
        }
		
		// GET: Addresses/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return RedirectToAction("badRequest", "error");
			}
			Address address = _db.Addresses.Find(id);
			if ((address == null)) {
				return HttpNotFound();
			}
			return View(address);
		}

		// GET: Addresses/Create
		public ActionResult Create()
		{
			ViewBag.AddressTypeID = new SelectList(_db.AddressTypes, "ID", "Description");
			return View();
		}

		[HttpGet()]
		public ActionResult Create(int customerID)
		{
			return View();
		}

		// POST: Addresses/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,AddressTypeID,Street,StreetNumber,City,PostalCode,Province,State,Phone,CellPhone,Fax,Note")]
Address address)
		{
			if (ModelState.IsValid) {
				_db.Addresses.Add(address);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.AddressTypeID = new SelectList(_db.AddressTypes, "ID", "Description", address.AddressTypeID);
			return View(address);
		}

		// GET: Addresses/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Address address = _db.Addresses.Find(id);
			if ((address == null)) {
				return HttpNotFound();
			}
			ViewBag.AddressTypeID = new SelectList(_db.AddressTypes, "ID", "Description", address.AddressTypeID);
			return View(address);
		}

		// POST: Addresses/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,AddressTypeID,Street,StreetNumber,City,PostalCode,Province,State,Phone,CellPhone,Fax,Note")]
Address address)
		{
			if (ModelState.IsValid) {
				_db.SetModified(address);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.AddressTypeID = new SelectList(_db.AddressTypes, "ID", "Description", address.AddressTypeID);
			return View(address);
		}

		// GET: Addresses/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Address address = _db.Addresses.Find(id);
			if ((address == null)) {
				return HttpNotFound();
			}
			return View(address);
		}

		// POST: Addresses/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Address address = _db.Addresses.Find(id);
			_db.Addresses.Remove(address);
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
