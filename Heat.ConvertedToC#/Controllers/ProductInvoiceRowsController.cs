using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Entity;
using System.Net;
using Heat.Models;
using Heat.Repositories;
using Heat.ViewModels.Invoices;
using Heat.Manager;

namespace Heat.Controllers
{
	public class ProductInvoiceRowsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private InvoiceModelBuilder _modelBuilder;

		private InvoiceManager _manager;

		public ProductInvoiceRowsController(IHeatDBContext context)
		{
			_db = context;
			_manager = new InvoiceManager(_db);
			_modelBuilder = new InvoiceModelBuilder(_db, _manager);

		}
		// GET: InvoiceRows
		public ActionResult Index()
		{
			return View(_db.ProductInvoiceRows.ToList());
		}

		// GET: InvoiceRows/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			InvoiceRow invoiceRow = _db.InvoiceRows.Find(id);
			if ((invoiceRow == null)) {
				return HttpNotFound();
			}
			return View(invoiceRow);
		}

		[HttpGet()]
		public ActionResult Create(int invoiceID)
		{
			AddNewProductInvoiceRowViewModel invoiceRow = null;

			invoiceRow = _modelBuilder.GetAddProductInvoiceRowViewModel(invoiceID);

			return View(invoiceRow);
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(AddNewProductInvoiceRowViewModel invoiceRow)
		{
			if (ModelState.IsValid) {
				ProductInvoiceRow invoiceRowDB = new ProductInvoiceRow();
				invoiceRowDB.Invoice = _db.Invoices.Find(invoiceRow.InvoiceID);
				if (_db.InvoiceRows.Where(x => x.Invoice.ID == invoiceRow.InvoiceID).Count() > 0) {
					invoiceRowDB.ItemOrder = _db.InvoiceRows.Where(x => x.Invoice.ID == invoiceRow.InvoiceID).Max(x => x.ItemOrder) + 1;
				} else {
					invoiceRowDB.ItemOrder = 1;
				}
				invoiceRowDB.Product = _db.Products.Find(invoiceRow.ProductID);
				invoiceRowDB.Quantity = invoiceRow.Quantity;
				invoiceRowDB.RateDiscount1 = (decimal) invoiceRow.Discount1;
				invoiceRowDB.RateDiscount2 = (decimal)invoiceRow.Discount2;
				invoiceRowDB.RateDiscount3 = (decimal)invoiceRow.Discount3;
				invoiceRowDB.UnitPrice = invoiceRow.UnitPrice;
				invoiceRowDB.VAT_Rate = invoiceRow.VAT;


				_db.ProductInvoiceRows.Add(invoiceRowDB);
				_db.SaveChanges();
				return RedirectToAction("edit", "invoices", new { ID = invoiceRow.InvoiceID });
			} else {
				ViewBag.message = "Errore nel salvataggio della riga";
				return View("error");
			}

		}


		public ActionResult Edit(int  id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				//Dim invoiceRow As ProductInvoiceRow = _db.ProductInvoiceRows.Include(Function(x) x.Invoice).Include(Function(x) x.Product).Where(Function(x) x.ID = id).Single

				//If IsNothing(invoiceRow) Then
				//    Return HttpNotFound()
				//End If

				EditProductInvoiceRowViewModel model = new EditProductInvoiceRowViewModel();

				model = _modelBuilder.GetEditProductInvoiceRowViewModel(id);

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}


		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditProductInvoiceRowViewModel editedProductInvoiceRow)
		{
			if (ModelState.IsValid) {
				ProductInvoiceRow dbInvoiceRow = null;
				dbInvoiceRow = _db.ProductInvoiceRows.Find(editedProductInvoiceRow.ID);

				dbInvoiceRow.Product = _db.Products.Find(editedProductInvoiceRow.ProductID);
				dbInvoiceRow.Quantity = editedProductInvoiceRow.Quantity;
				dbInvoiceRow.RateDiscount1 = (decimal) editedProductInvoiceRow.Discount1;
				dbInvoiceRow.RateDiscount2 = (decimal) editedProductInvoiceRow.Discount2;
				dbInvoiceRow.RateDiscount3 = (decimal) editedProductInvoiceRow.Discount3;
				dbInvoiceRow.UnitPrice = editedProductInvoiceRow.UnitPrice;
				dbInvoiceRow.VAT_Rate = editedProductInvoiceRow.VAT;

				_db.SetModified(dbInvoiceRow);
				_db.SaveChanges();
				return RedirectToAction("edit", "invoices", new { ID = editedProductInvoiceRow.InvoiceID });
			} else {
				//il modello non è valido, torna alla vista di edit.
				return View(editedProductInvoiceRow);
			}

		}

		// GET: InvoiceRows/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			InvoiceRow invoiceRow = _db.InvoiceRows.Find(id);
			if ((invoiceRow == null)) {
				return HttpNotFound();
			}
			return View(invoiceRow);
		}

		// POST: InvoiceRows/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			InvoiceRow invoiceRow = _db.InvoiceRows.Find(id);
			_db.InvoiceRows.Remove(invoiceRow);
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
