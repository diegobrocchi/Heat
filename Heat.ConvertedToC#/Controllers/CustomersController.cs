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
using Heat.ViewModels.Customers;
using Heat.Manager;
using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DataTables.AspNet.Mvc5;
using DataTables.AspNet.Core;



namespace Heat.Controllers
{

	public class CustomersController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private CustomerModelViewBuilder _mb;

		private CustomerManager _cm;
		public CustomersController(IHeatDBContext dbcontext)
		{
			_db = dbcontext;
			_mb = new CustomerModelViewBuilder(_db);
			_cm = new CustomerManager(_db);
		}


		public ActionResult Index(bool IncludeDisabled = false)
		{
			try {
				IndexCustomerViewModel model = null;
				model = _mb.GetIndexCustomerViewModel(IncludeDisabled);

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		// GET: Customers/Details/5
		public ActionResult Details(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = _db.Customers.Find(id);
			if ((customer == null)) {
				return HttpNotFound();
			}
			return View(customer);
		}

		// GET: Customers/Create
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreateCustomerViewModel newCustomer)
		{
			if (ModelState.IsValid) {
				Customer c = new Customer();
				c = Mapper.Map<Customer>(newCustomer);
				c.CreationDate = DateAndTime.Now;
				c.EnableDate = DateAndTime.Now;

				_db.Customers.Add(c);
				_db.SaveChanges();
				return RedirectToAction("Index");
			} else {
				return View(newCustomer);
			}

		}

		// GET: Customers/Edit/5
		public ActionResult Edit(int? id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				if (!_db.Customers.Any(x => x.ID == id)) {
					return HttpNotFound();
				}
				EditCustomerViewModel model = null;
				model = _mb.GetEditCustomerViewModel(id);
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}


		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(EditCustomerViewModel editedCustomer)
		{
			if (ModelState.IsValid) {
				Customer dbCustomer = null;
				dbCustomer = _db.Customers.Find(editedCustomer.ID);

				Mapper.Map(editedCustomer, dbCustomer);

				_db.SaveChanges();
				return RedirectToAction("Index");
			} else {
				return View(editedCustomer);
			}
		}

		// GET: Customers/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = _db.Customers.Find(id);
			if ((customer == null)) {
				return HttpNotFound();
			}
			return View(customer);
		}

		// POST: Customers/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Customer customer = _db.Customers.Find(id);
			_db.Customers.Remove(customer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Search(string searchstring)
		{
			List<Customer> result = new List<Customer>();
			result = _db.Customers.Where(customer => customer.Name.Contains(searchstring)).ToList();

			return View(result);

		}

		[HttpGet()]
		public ActionResult Import()
		{
			return View();
		}

		[HttpPost()]
		public ActionResult Import(HttpPostedFileBase uploadFileCustomers)
		{
			if ((uploadFileCustomers != null) && uploadFileCustomers.ContentLength > 0) {
				string fileExt = null;
				fileExt = System.IO.Path.GetExtension(uploadFileCustomers.FileName).ToLower();
				if (fileExt == ".txt") {
					ImportHelper ih = new ImportHelper(_db);
					byte[] b = new byte[uploadFileCustomers.ContentLength + 1];
					uploadFileCustomers.InputStream.Read(b, 0, uploadFileCustomers.ContentLength);
					if (ih.Customer(System.Text.Encoding.ASCII.GetString(b))) {
						return RedirectToAction("index");
					} else {
						ViewBag.error = "Errore durante l'importazione del file";
						return View();
					}
				} else {
					ViewBag.error = "Sono ammmessi solo file .txt";
					return View();
				}

			} else {
				return View();
			}
		}

		[HttpGet()]
		public ActionResult GetCustomersByName(string searchText)
		{
			return Json(_db.Customers.Where(x => x.Name.Contains(searchText)).Select(x => new {
				id = x.ID,
				name = x.Name
			}).ToList(), JsonRequestBehavior.AllowGet);
		}

		[HttpGet()]
		public ActionResult DisableCustomer(int id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = _db.Customers.Find(id);
			if ((customer == null)) {
				return HttpNotFound();
			}
			DisableCustomerViewModel dc = null;
			dc = _mb.GetDisableCustomerViewModel(id);
			return View(dc);
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult DisableCustomer(DisableCustomerViewModel dc)
		{
			if (ModelState.IsValid) {
				try {
					CustomerManager cm = new CustomerManager(_db);
					Customer c = null;
					c = _db.Customers.Find(dc.ID);
					if ((c != null)) {
						cm.DisableCustomer(c);
						_db.SaveChanges();
						return RedirectToAction("index");
					} else {
						ViewBag.message = "Impossibile trovare il cliente con ID specificato!";
						return View("error");
					}
				} catch (Exception ex) {
					ViewBag.message = ex.Message;
					return View("error");
				}

			} else {
				ViewBag.message = "Modello non valido!";
				return View("Error");
			}

		}


		[HttpGet()]
		public ActionResult EnableCustomer(int id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Customer customer = _db.Customers.Find(id);
				if ((customer == null)) {
					return HttpNotFound();
				}
				EnableCustomerViewModel dc = null;
				dc = _mb.GetEnableCustomerViewModel(id);
				return View(dc);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult EnableCustomer(EnableCustomerViewModel ec)
		{
			try {
				if (ModelState.IsValid) {
					Customer c = null;
					c = _db.Customers.Find(ec.ID);
					if ((c != null)) {
						_cm.EnableCustomer(c);
						_db.SaveChanges();
						return RedirectToAction("index");
					} else {
						ViewBag.message = "impossibile trovare il cliente con ID specificato!";
						return View("error");
					}
				} else {
					ViewBag.message("Modello non valido");
					return View("error");
				}
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("Error");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((disposing)) {
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		[HttpGet()]
		public ActionResult Print(int id)
		{
			iTextSharp.text.Document d = new iTextSharp.text.Document();
			PdfWriter.GetInstance(d, new System.IO.FileStream(Request.PhysicalApplicationPath + "\\1.pdf", System.IO.FileMode.Create));
			d.Open();
			d.Add(new Paragraph("Hello " + id));
			d.Close();
			return Redirect("~/1.pdf");

		}

		/// <summary>
		/// Risponde alla chiamata AJAX dell'oggetto Datatable con la lista paginata dei clienti abilitati.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		[HttpGet()]
		public ActionResult PageCustomerEnabled(IDataTablesRequest request)
		{

			return _cm.GetPagedCustomers(request, true);

		}

		/// <summary>
		/// Risponde alla chiamata AJAX dell'oggetto Datatable con la lista paginata dei clienti disabilitati.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		[HttpGet()]
		public ActionResult PageCustomerDisabled(IDataTablesRequest request)
		{

			return _cm.GetPagedCustomers(request, false);

		}

		public ActionResult Manage(int id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Customer customer = _db.Customers.Find(id);
				if ((customer == null)) {
					return HttpNotFound();
				}
				ManageCustomerViewModel m = null;
				m = _mb.GetManageCustomerViewModel(id);
				return View(m);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}

		}

	}
}
