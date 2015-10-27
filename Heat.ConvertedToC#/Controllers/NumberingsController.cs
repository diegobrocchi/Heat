using System.Linq;
using System.Web.Mvc;
using System.Net;
using Heat.Models;
using AutoMapper;

namespace Heat.Controllers
{
    public class NumberingsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;

		private NumberingViewModelsBuilder _modelBuilder;
		public NumberingsController(IHeatDBContext context)
		{
			_db = context;
			_modelBuilder = new NumberingViewModelsBuilder(context);
		}

		// GET: Numerators
		public ActionResult Index()
		{
			return View(_modelBuilder.GetIndexModel());
		}

		// GET: Numerators/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Numbering numbering = _db.Numberings.Find(id);
			if ((numbering == null)) {
				return HttpNotFound();
			}
			return View(numbering);
		}

		// GET: Numerators/Create
		public ActionResult Create()
		{
			return View(_modelBuilder.GetCreateModel());
		}

		// POST: Numerators/Create
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateNumberingViewModel newNumbering)
		{
			if (ModelState.IsValid) {
				Numbering numbering = new Numbering();

				numbering = Mapper.Map<Numbering>(newNumbering);

				numbering.LastFinalSerial = new SerialNumber();
				numbering.LastTempSerial = new SerialNumber();

				_db.Numberings.Add(numbering);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(newNumbering);
		}

		// GET: Numerators/Edit/5
		public ActionResult Edit(int  id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			if (!_db.Numberings.AsNoTracking().Any(x => x.ID == id)) {
				return HttpNotFound();
			}

			EditNumberingViewModel editNumbering = null;
			editNumbering = _modelBuilder.GetEditModel(id);
			return View(editNumbering);
		}

		// POST: Numerators/Edit/5
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditNumberingViewModel editNumberingVM)
		{
			if (ModelState.IsValid) {
				Numbering editNumbering = null;
				editNumbering = _db.Numberings.Find(editNumberingVM.ID);
				//Where(Function(x) x.ID = editNumberingVM.ID).FirstOrDefault
				//db.SerialSchemes.Attach(editNumberingVM.TempSerialSchema)
				//Try
				//    db.SerialSchemes.Attach(editNumberingVM.FinalSerialSchema)
				//Catch ex As Exception

				//End Try

				//editNumbering = Mapper.Map(Of Numbering)(editNumberingVM)
				//db.Numberings.Attach(editNumbering)

				//editNumbering.Code = editNumberingVM.Code
				//editNumbering.Description = editNumberingVM.Description
				//editNumbering.FinalSerialSchema = db.SerialSchemes.Find(editNumberingVM.FinalSerialSchema.ID)
				//editNumbering.TempSerialSchema = db.SerialSchemes.Find(editNumberingVM.TempSerialSchema.ID)

				//db.Entry(editNumbering).State = EntityState.Modified

				editNumbering = Mapper.Map<EditNumberingViewModel, Numbering>(editNumberingVM, editNumbering);

				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(editNumberingVM);
		}

		// GET: Numerators/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Numbering numbering = _db.Numberings.Find(id);
			if ((numbering == null)) {
				return HttpNotFound();
			}
			return View(numbering);
		}

		// POST: Numerators/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Numbering numbering = _db.Numberings.Find(id);
			_db.Numberings.Remove(numbering);
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
