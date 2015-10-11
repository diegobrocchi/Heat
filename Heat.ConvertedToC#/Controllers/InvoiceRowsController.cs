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
	public class InvoiceRowsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private InvoiceModelBuilder _modelBuilder;

		private InvoiceManager _manager;

		public InvoiceRowsController(IHeatDBContext context)
		{
			_db = context;
			_manager = new InvoiceManager(_db);
			_modelBuilder = new InvoiceModelBuilder(_db, _manager);

		}
		// GET: InvoiceRows
		public ActionResult Index()
		{
			return View(_db.InvoiceRows.ToList());
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

		// POST: InvoiceRows/Create
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
				invoiceRowDB.RateDiscount1 = invoiceRow.Discount1;
				invoiceRowDB.RateDiscount2 = invoiceRow.Discount2;
				invoiceRowDB.RateDiscount3 = invoiceRow.Discount3;
				invoiceRowDB.UnitPrice = invoiceRow.UnitPrice;
				invoiceRowDB.VAT_Rate = invoiceRow.VAT;


				_db.InvoiceRows.Add(invoiceRowDB);
				_db.SaveChanges();
				return RedirectToAction("edit", "invoices", new { ID = invoiceRow.InvoiceID });
			} else {
				ViewBag.message = "Errore nel salvataggio della riga";
				return View("error");
			}

		}

		// GET: InvoiceRows/Edit/5
		public ActionResult Edit(int? id)
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

		// POST: InvoiceRows/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,RowID,ItemOrder,Quantity,UnitPrice,VAT_Rate,RateDiscount1,RateDiscount2,RateDiscount3")]
InvoiceRow invoiceRow)
		{
			if (ModelState.IsValid) {
				//_db.Entry(invoiceRow).State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(invoiceRow);
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
