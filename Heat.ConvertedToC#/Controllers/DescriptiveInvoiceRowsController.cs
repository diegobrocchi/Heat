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
using Heat.Manager;
using Heat.ViewModels.Invoices;

namespace Heat.Controllers
{
	public class DescriptiveInvoiceRowsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private InvoiceModelBuilder _modelBuilder;

		private InvoiceManager _manager;
		public DescriptiveInvoiceRowsController(IHeatDBContext context)
		{
			_db = context;
			_manager = new InvoiceManager(_db);
			_modelBuilder = new InvoiceModelBuilder(_db, _manager);

		}

		// GET: DescriptiveInvoiceRows
		public ActionResult Index()
		{
			return View(_db.DescriptiveInvoiceRows.ToList());
		}

		// GET: DescriptiveInvoiceRows/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DescriptiveInvoiceRow descriptiveInvoiceRow =(DescriptiveInvoiceRow)  _db.InvoiceRows.Find(id);
			if ((descriptiveInvoiceRow == null)) {
				return HttpNotFound();
			}
			return View(descriptiveInvoiceRow);
		}

		// GET: DescriptiveInvoiceRows/Create
		public ActionResult Create(int invoiceID)
		{
			AddNewDescriptiveInvoiceRowViewModel invoiceRow = null;

			invoiceRow = _modelBuilder.GetAddDescriptiveInvoiceRowViewModel(invoiceID);
			return View(invoiceRow);
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(AddNewDescriptiveInvoiceRowViewModel descriptiveInvoiceRow)
		{
			if (ModelState.IsValid) {
				DescriptiveInvoiceRow invoiceRowDB = new DescriptiveInvoiceRow();
				invoiceRowDB.Invoice = _db.Invoices.Find(descriptiveInvoiceRow.InvoiceID);

				if (_db.InvoiceRows.Where(x => x.Invoice.ID == descriptiveInvoiceRow.InvoiceID).Count() > 0) {
					invoiceRowDB.ItemOrder = _db.InvoiceRows.Where(x => x.Invoice.ID == descriptiveInvoiceRow.InvoiceID).Max(x => x.ItemOrder) + 1;
				} else {
					invoiceRowDB.ItemOrder = 1;
				}

				invoiceRowDB.RowDescription = descriptiveInvoiceRow.RowDescription;
				invoiceRowDB.Quantity = descriptiveInvoiceRow.Quantity;
				invoiceRowDB.RateDiscount1 = (decimal) descriptiveInvoiceRow.Discount1;
				invoiceRowDB.RateDiscount2 = (decimal) descriptiveInvoiceRow.Discount2;
				invoiceRowDB.RateDiscount3 = (decimal) descriptiveInvoiceRow.Discount3;
				invoiceRowDB.UnitPrice = descriptiveInvoiceRow.UnitPrice;
				invoiceRowDB.VAT_Rate = descriptiveInvoiceRow.VAT;


				_db.InvoiceRows.Add(invoiceRowDB);
				_db.SaveChanges();
				return RedirectToAction("edit", "invoices", new { ID = descriptiveInvoiceRow.InvoiceID });

			}
			return View(descriptiveInvoiceRow);
		}

		// GET: DescriptiveInvoiceRows/Edit/5
		public ActionResult Edit(int id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				//Dim descriptiveInvoiceRow As DescriptiveInvoiceRow = _db.InvoiceRows.Find(id)
				//If IsNothing(descriptiveInvoiceRow) Then
				//    Return HttpNotFound()
				//End If
				EditDescriptiveInvoiceRowViewModel model = null;
				model = _modelBuilder.GetEditDescriptiveInvoiceRowViewModel(id);
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditDescriptiveInvoiceRowViewModel editedDescriptiveInvoiceRow)
		{

			if (ModelState.IsValid) {
				DescriptiveInvoiceRow dbRow = null;
				dbRow = _db.DescriptiveInvoiceRows.Find(editedDescriptiveInvoiceRow.ID);

				dbRow.Quantity = editedDescriptiveInvoiceRow.Quantity;
				dbRow.RateDiscount1 = (decimal) editedDescriptiveInvoiceRow.Discount1;
				dbRow.RateDiscount2 = (decimal)editedDescriptiveInvoiceRow.Discount2;
				dbRow.RateDiscount3 = (decimal)editedDescriptiveInvoiceRow.Discount3;
				dbRow.RowDescription = editedDescriptiveInvoiceRow.RowDescription;
				dbRow.UnitPrice = editedDescriptiveInvoiceRow.UnitPrice;
				dbRow.VAT_Rate = editedDescriptiveInvoiceRow.VAT;


				_db.SaveChanges();
				return RedirectToAction("edit", "invoices", new { id = editedDescriptiveInvoiceRow.InvoiceID });
			} else {
				//il modello non è valido, torna alla vista di edit.
				return View(editedDescriptiveInvoiceRow);
			}

		}

		// GET: DescriptiveInvoiceRows/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DescriptiveInvoiceRow descriptiveInvoiceRow = (DescriptiveInvoiceRow) _db.InvoiceRows.Find(id);
			if ((descriptiveInvoiceRow == null)) {
				return HttpNotFound();
			}
			return View(descriptiveInvoiceRow);
		}

		// POST: DescriptiveInvoiceRows/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			DescriptiveInvoiceRow descriptiveInvoiceRow = (DescriptiveInvoiceRow)  _db.InvoiceRows.Find(id);
			_db.InvoiceRows.Remove(descriptiveInvoiceRow);
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
