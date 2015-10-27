using System.Linq;
using System.Web.Mvc;
using System.Net;
using DataTables.AspNet.Core;
using Heat.Models;
using Heat.Manager;


namespace Heat.Controllers
{
    public class ProductsController : Controller
	{

		private IHeatDBContext _db;

		private ProductManager _pm;
		public ProductsController(IHeatDBContext dbcontext)
		{
			_db = dbcontext;
			_pm = new ProductManager(_db);
		}

		// GET: Products
		public ActionResult Index()
		{
			return View(_db.Products.ToList());
		}

		// GET: Products/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = _db.Products.Find(id);
			if ((product == null)) {
				return HttpNotFound();
			}
			return View(product);
		}

		// GET: Products/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Products/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(		[Bind(Include = "ID,SKU,Description,UnitPrice,Cost,ReorderLevel")]
Product product)
		{
			if (ModelState.IsValid) {
				_db.Products.Add(product);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}

		// GET: Products/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = _db.Products.Find(id);
			if ((product == null)) {
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,SKU,Description,UnitPrice,Cost,ReorderLevel")]
Product product)
		{
			if (ModelState.IsValid) {
				//_db.Entry(product).State = EntityState.Modified
				_db.SetModified(product);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(product);
		}

		// GET: Products/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = _db.Products.Find(id);
			if ((product == null)) {
				return HttpNotFound();
			}
			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = _db.Products.Find(id);
			_db.Products.Remove(product);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet()]
		public ActionResult GetPagedProducts(IDataTablesRequest request)
		{
			if (ModelState.IsValid) {
				return _pm.GetPagedProducts(request);
			} else {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
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
