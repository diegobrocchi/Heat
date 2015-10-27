using System;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Manager;
using Heat.ViewModels.Invoices;

namespace Heat.Controllers
{
    [OutputCache(Duration = 0, NoStore = true, VaryByParam = "*")]
	[HandleError()]
	public class InvoicesController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private InvoiceModelBuilder _modelBuilder;

		private InvoiceManager _businessService;
		public InvoicesController(IHeatDBContext context)
		{
			_db = context;

			_businessService = new InvoiceManager(_db);
			_modelBuilder = new InvoiceModelBuilder(_db, _businessService);
		}

		public ActionResult Index(DocumentState state = DocumentState.Confirmed)
		{
			try {
				switch (state) {
					case DocumentState.Inserted:
						return View("insertedIndex", _modelBuilder.GetInsertedInvoicesIndexViewModel());
					case DocumentState.Confirmed:
						return View("confirmedIndex", _modelBuilder.GetConfirmedInvoicesIndexViewModel());
					case DocumentState.Deleted:
						return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
					default:
						return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}


		}

		[HttpGet()]
		public ActionResult Details(int id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Invoice invoice = _db.Invoices.Find(id);
				if ((invoice == null)) {
					return HttpNotFound();
				}

				InvoiceDetailsViewModel model = null;
				model = _modelBuilder.GetDetailsInvoiceViewModel(id);
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult Create(int customerID)
		{
			//La creazione di una fattura passa per:
			//1: creazione documento con numerazione temporanea
			//2: salvataggio del contesto, per persistere i numeratori
			//3: modifica del documento appena creato (aggiunta righe)

			try {
				Invoice tmpDoc = null;

				tmpDoc = _businessService.GetTemporaryDocument(customerID);
				_db.SaveChanges();

				return RedirectToAction("Edit", new { id = tmpDoc.ID });
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult Edit(int  id)
		{
			//secondo passo della creazione della fattura: aggiunta righe
			//la funzione è chiamata solo da GET per permettere l'aggiorNamento
			//facile della view durante l'immissione delle righe.

			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				Invoice invoice = _db.Invoices.Include(i => i.Customer).Where(i => i.ID == id).Single();

				if ((invoice == null)) {
					return HttpNotFound();
				}

				EditableInvoiceValidator validator = new EditableInvoiceValidator(_db, id);

				if (validator.IsValid) {
					EditInvoiceViewModel model = null;
					model = _modelBuilder.GetEditInvoiceViewModel(invoice);
					return View(model);
				} else {
					ViewBag.message = validator.ErrorMessage;
					return View("Error");
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult EditPayment(int ID)
		{
			try {
				InvoicePaymentViewModel model = null;

				model = _modelBuilder.getEditInvoicePaymentViewModel(ID);

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpPost()]
		public ActionResult EditPayment(InvoicePaymentViewModel model)
		{
			try {
				if (ModelState.IsValid) {
					Invoice dbInvoice = null;
					dbInvoice = _db.Invoices.Find(model.ID);

					dbInvoice.IsTaxExempt = model.IsTaxExempt;
					dbInvoice.Payment = _db.Payments.Find(model.PaymentID);
					dbInvoice.TaxExemption = model.TaxExemption;

					_db.SaveChanges();

					return RedirectToAction("Confirm", new { id = model.ID });
				} else {
					ViewBag.message = "Impossibile salvare il modello";
					return View("error");
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult Confirm(int ID)
		{

			try {
				ConfirmInvoiceViewModel model = null;
				model = _modelBuilder.getConfirmInvoiceViewModel(ID);

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");

			}
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Confirm(EditInvoiceViewModel invoice)
		{
			//L'azione POST su Confirm è la conferma del documento e la attribuzione dello stato 'Confirmed'
			//Cerco la fattura con ID specificato,
			//se State = DocumentState.Inserted confermo l'inserimento.
			try {
				if (ModelState.IsValid) {
					EditableInvoiceValidator validator = new EditableInvoiceValidator(_db, invoice.ID);

					if (validator.IsValid) {

						if (_businessService.SetConfirmedDocument(invoice.ID)) {
							_db.SaveChanges();

							return RedirectToAction("Index");


						} else {
							ViewBag.message = "Impossibile confermare il documento";
							return View("Error");
						}
					} else {
						ViewBag.message = "Il documento non è in uno stato che ammette la conferma.";
						return View("error");
					}


				} else {
					ViewBag.message = "Il documento non è editabile: impossibile confermare il documento!";
					return View("error");
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}


		// GET: Invoices/Delete/5
		public ActionResult Delete(int  id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Invoice invoice = _db.Invoices.Find(id);
				if ((invoice == null)) {
					return HttpNotFound();
				}

				if (invoice.State == DocumentState.Inserted) {
					return View("delete", _modelBuilder.getDeleteInvoiceViewModel(id));

				} else {
					ViewBag.message = "Impossibile eliminare una fattura già confermata, o già eliminata.";
					return View("error");
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		// POST: Invoices/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Invoice invoice = _db.Invoices.Find(id);

			if ((invoice == null)) {
				return HttpNotFound();
			}

			if (invoice.State == DocumentState.Inserted) {
				_db.Invoices.Remove(invoice);
				_db.SaveChanges();
			} else {
				ViewBag.message = "Impossibile eliminare una fattura già confermata, o già eliminata.";
			}
			return RedirectToAction("Index", new { state = DocumentState.Inserted });
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
