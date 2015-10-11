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
using Heat.Models;
using Heat.ViewModels.Invoices;
using Heat.Manager;
using System.Data.Entity;
namespace Heat
{

	/// <summary>
	/// Create models for managing Invoices
	/// </summary>
	/// <remarks></remarks>
	public class InvoiceModelBuilder
	{

		private IHeatDBContext _db;

		private InvoiceManager _manager;
		public InvoiceModelBuilder(IHeatDBContext repository, InvoiceManager manager)
		{
			_db = repository;
			_manager = manager;
		}


		/// <summary>
		/// Prepara il modello da visualizzare nella view con l'elenco delle fatture confermate.
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		public Viewmodels.Invoices.confirmedIndexViewModel GetConfirmedInvoicesIndexViewModel()
		{

			ViewModels.Invoices.confirmedIndexViewModel result = new ViewModels.Invoices.confirmedIndexViewModel();

			result.State = DocumentState.Confirmed;
			result.InsertedInvoiceCount = _db.Invoices.Where(x => x.State == DocumentState.Inserted).Count();

			result.ConfirmedInvoiceList = _db.Invoices.Where(x => x.State == DocumentState.Confirmed).OrderBy(x => x.ConfirmedNumber.SerialInteger).Select(x => new confirmedInvoicesGridViewModel {
				ID = x.ID,
				Customer = x.Customer.Name,
				InvoiceDate = x.InvoiceDate,
				InvoiceNumber = x.ConfirmedNumber.SerialString,
				TotalAmount = x.TotalAmount,
				TaxableAmount = x.TaxableAmount,
				TaxesAmount = x.TaxesAmount
			}).ToList();

			return result;
		}

		/// <summary>
		/// Prepara il modello per la view con l'elenco delle fatture INSERITE (ma non ancora confermate).
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		public Viewmodels.Invoices.insertedIndexViewModel GetInsertedInvoicesIndexViewModel()
		{
			Viewmodels.Invoices.insertedIndexViewModel result = new Viewmodels.Invoices.insertedIndexViewModel();

			result.State = DocumentState.Inserted;
			result.InsertedInvoiceList = _db.Invoices.Include(x => x.InvoiceRows).Where(x => x.State == DocumentState.Inserted).Select(x => new InsertedInvoicesGridViewModel {
				ID = x.ID,
				Customer = x.Customer.Name,
				InvoiceDate = x.InvoiceDate,
				InvoiceNumber = x.InsertedNumber.SerialString,
				RowCount = x.InvoiceRows.Count
			}).ToList();

			return result;
		}

		/// <summary>
		/// Prepara il modello per la view di Edit della fattura.
		/// </summary>
		/// <param name="tempDoc"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public EditInvoiceViewModel GetEditInvoiceViewModel(Invoice tempDoc)
		{
			//l'elenco delle righe della fattura è composto da 2 tipi differenti di righe: 
			//'Prodotto' e 'Descrittive'.

			EditInvoiceViewModel result = new EditInvoiceViewModel();
			List<ProductInvoiceRow> dbProductRowList = new List<ProductInvoiceRow>();
			List<DescriptiveInvoiceRow> dbDescriptiveRowList = new List<DescriptiveInvoiceRow>();


			result.ID = tempDoc.ID;
			result.CustomerName = tempDoc.Customer.Name;
			result.InvoiceNumber = tempDoc.InsertedNumber.SerialString;
			result.InvoiceDate = tempDoc.InvoiceDate.ToShortDateString();

			dbProductRowList = _db.ProductInvoiceRows.Include("Product").Where(r => r.Invoice.ID == tempDoc.ID).ToList();

			dbDescriptiveRowList = _db.DescriptiveInvoiceRows.Where(x => x.Invoice.ID == tempDoc.ID).ToList();

			result.Rows = dbProductRowList.Select(x => new PresentationInvoiceRowViewModel {
				ID = x.ID,
				Item = x.ItemOrder,
				InvoiceID = x.Invoice.ID,
				SKU = x.Product.SKU,
				Product = x.Product.Description,
				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,
				Discount1 = x.RateDiscount1,
				Discount2 = x.RateDiscount2,
				Discount3 = x.RateDiscount3,
				TotalBeforeTax = x.DiscountedAmount,
				Total = x.TotalAmount,
				VAT = x.VAT_Rate,
				RowType = InvoiceRowType.ProductRow
			}).ToList();

			result.Rows.AddRange(dbDescriptiveRowList.Select(x => new PresentationInvoiceRowViewModel {
				ID = x.ID,
				Item = x.ItemOrder,
				InvoiceID = x.Invoice.ID,
				SKU = string.Empty,
				Product = x.RowDescription,
				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,
				Discount1 = x.RateDiscount1,
				Discount2 = x.RateDiscount2,
				Discount3 = x.RateDiscount3,
				TotalBeforeTax = x.DiscountedAmount,
				Total = x.TotalAmount,
				VAT = x.VAT_Rate,
				RowType = InvoiceRowType.DescriptiveRow
			}).ToList());


			result.Rows = result.Rows.OrderBy(x => x.Item).ToList();

			return result;


		}


		/// <summary>
		/// Produce il modello per la vista Create di una riga fattura di tipo 'Prodotto'. 
		/// </summary>
		/// <param name="invoiceID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public AddNewProductInvoiceRowViewModel GetAddProductInvoiceRowViewModel(int invoiceID)
		{
			AddNewProductInvoiceRowViewModel result = new AddNewProductInvoiceRowViewModel();

			result.InvoiceID = invoiceID;
			result.ProductList = _db.Products.ToList().OrderBy(x => x.Description).ToSelectListItems(p => p.Description, p => p.ID, "");
			result.VAT = 22;

			return result;

		}

		/// <summary>
		/// Produce il modello per la vista Edit di una riga fattura di tipo 'Prodotto'.
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public EditProductInvoiceRowViewModel GetEditProductInvoiceRowViewModel(int ID)
		{
			EditProductInvoiceRowViewModel result = new EditProductInvoiceRowViewModel();
			ProductInvoiceRow dbRow = null;

			dbRow = _db.ProductInvoiceRows.Include(x => x.Invoice).Include(x => x.Product).Where(x => x.ID == ID).Single();

			result.ID = ID;
			result.Discount1 = dbRow.RateDiscount1;
			result.Discount2 = dbRow.RateDiscount2;
			result.Discount3 = dbRow.RateDiscount3;
			result.InvoiceID = dbRow.Invoice.ID;
			result.ProductID = dbRow.Product.ID;
			result.ProductList = _db.Products.ToList().OrderBy(x => x.Description).ToSelectListItems(p => p.Description, p => p.ID, dbRow.Product.ID);
			result.Quantity = dbRow.Quantity;
			result.UnitPrice = dbRow.UnitPrice;
			result.VAT = dbRow.VAT_Rate;

			return result;

		}

		/// <summary>
		/// Produce il modello per la vista Create di una riga fattura di tipo 'Descrittivo'.
		/// </summary>
		/// <param name="invoiceID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public AddNewDescriptiveInvoiceRowViewModel GetAddDescriptiveInvoiceRowViewModel(int invoiceID)
		{
			AddNewDescriptiveInvoiceRowViewModel result = new AddNewDescriptiveInvoiceRowViewModel();

			result.InvoiceID = invoiceID;
			result.VAT = 22;

			return result;

		}

		/// <summary>
		/// Produce il modello per la vista Edit di una riga fattura di tipo 'Descrittivo'.
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public EditDescriptiveInvoiceRowViewModel GetEditDescriptiveInvoiceRowViewModel(int ID)
		{
			EditDescriptiveInvoiceRowViewModel result = new EditDescriptiveInvoiceRowViewModel();
			DescriptiveInvoiceRow dbRow = null;

			dbRow = _db.DescriptiveInvoiceRows.Include(x => x.Invoice).Where(x => x.ID == ID).Single();

			result.ID = dbRow.ID;
			result.Discount1 = dbRow.RateDiscount1;
			result.Discount2 = dbRow.RateDiscount2;
			result.Discount3 = dbRow.RateDiscount3;
			result.InvoiceID = dbRow.Invoice.ID;
			result.Quantity = dbRow.Quantity;
			result.RowDescription = dbRow.RowDescription;
			result.UnitPrice = dbRow.UnitPrice;
			result.VAT = dbRow.VAT_Rate;

			return result;
		}

		/// <summary>
		/// Produce il modello per la view in cui si scelgono le condizioni di pagamento per la fattura.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public InvoicePaymentViewModel getEditInvoicePaymentViewModel(int id)
		{
			InvoicePaymentViewModel result = new InvoicePaymentViewModel();
			Invoice dbInvoice = null;
			List<PresentationInvoiceRowViewModel> rows = null;

			//dbInvoice = _db.Invoices.Where(Function(x) x.ID = id).
			//    Include(Function(x) x.Customer).
			//    Include(Function(x) x.InvoiceRows).
			//    Include(Function(x) x.Payment).Include(Function(x) x.InvoiceRows.Select(Function(r) r.Product)).FirstOrDefault()
			//rows = dbInvoice.InvoiceRows
			dbInvoice = _db.Invoices.Include(x => x.Customer).Include(x => x.Payment).Where(x => x.ID == id).FirstOrDefault();
			rows = _manager.GetInvoiceRows(id);

			result.ID = id;
			result.CustomerName = dbInvoice.Customer.Name;
			result.InvoiceNumber = dbInvoice.InsertedNumber.SerialString;
			result.InvoiceDate = dbInvoice.InvoiceDate.ToShortDateString();
			result.IsTaxExempt = dbInvoice.IsTaxExempt;
			result.Rows = rows;
			//result.Rows = rows.Select(Function(x) New InvoiceRowViewModel With {
			//               .ID = x.ID,
			//               .Item = x.ItemOrder,
			//               .InvoiceID = x.Invoice.ID,
			//               .Product = x.Description,
			//               .Quantity = x.Quantity,
			//               .UnitPrice = x.UnitPrice,
			//               .Discount1 = x.RateDiscount1,
			//               .Discount2 = x.RateDiscount2,
			//               .Discount3 = x.RateDiscount3,
			//                        .TotalBeforeTax = x.DiscountedAmount,
			//                        .Total = x.TotalAmount}).
			//         ToList()

			if ((dbInvoice.Payment != null)) {
				result.PaymentID = dbInvoice.Payment.ID;
			}

			result.PaymentList = _db.Payments.ToList().ToSelectListItems(x => x.Description, x => x.ID, result.PaymentID);
			result.TaxExemption = dbInvoice.TaxExemption;

			return result;

		}

		/// <summary>
		/// Produce il modello per la view in cui confermare la fattura.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public ConfirmInvoiceViewModel getConfirmInvoiceViewModel(int id)
		{
			ConfirmInvoiceViewModel result = new ConfirmInvoiceViewModel();
			Invoice invoiceDB = null;
			List<PresentationInvoiceRowViewModel> invoiceDBRows = null;


			//invoiceDB = _db.Invoices.Where(Function(x) x.ID = id).
			//    Include(Function(x) x.Customer).
			//    Include(Function(x) x.InvoiceRows).
			//    Include(Function(x) x.Payment).Include(Function(x) x.InvoiceRows.Select(Function(r) r.Product)).FirstOrDefault()

			//invoiceDBRows = invoiceDB.InvoiceRows

			invoiceDB = _db.Invoices.Include(x => x.Customer).Include(x => x.Payment).Where(x => x.ID == id).Single();
			invoiceDBRows = _manager.GetInvoiceRows(id);

			result.ID = id;
			result.CustomerName = invoiceDB.Customer.Name;
			result.InvoiceDate = invoiceDB.InvoiceDate.ToShortDateString();
			result.InvoiceNumber = invoiceDB.InsertedNumber.SerialString;
			result.Rows = invoiceDBRows;
			//result.Rows = invoiceDBRows.Select(Function(x) New InvoiceRowViewModel With {
			//               .ID = x.ID,
			//               .Item = x.ItemOrder,
			//               .InvoiceID = x.Invoice.ID,
			//               .Product = x.Description,
			//               .Quantity = x.Quantity,
			//               .UnitPrice = x.UnitPrice,
			//               .Discount1 = x.RateDiscount1,
			//               .Discount2 = x.RateDiscount2,
			//               .Discount3 = x.RateDiscount3,
			//                        .TotalBeforeTax = x.DiscountedAmount,
			//                        .Total = x.TotalAmount}).
			//         ToList()

			result.Payment = invoiceDB.Payment.Description;
			result.IsTaxExempt = invoiceDB.IsTaxExempt;
			result.TaxExemption = invoiceDB.TaxExemption;


			return result;


		}

		/// <summary>
		/// Prepara il modello per la vista di dettaglio di una fattura.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public InvoiceDetailsViewModel GetDetailsInvoiceViewModel(int id)
		{
			InvoiceDetailsViewModel result = new InvoiceDetailsViewModel();
			Invoice invoiceDB = null;
			List<PresentationInvoiceRowViewModel> invoiceDBRows = null;

			invoiceDB = _db.Invoices.Where(x => x.ID == id).Include(x => x.Customer).Include(x => x.Payment).Single();

			//invoiceDBRows = invoiceDB.InvoiceRows

			invoiceDB = _db.Invoices.Find(id);
			invoiceDBRows = _manager.GetInvoiceRows(id);

			result.ID = id;
			result.CustomerName = invoiceDB.Customer.Name;
			result.InvoiceDate = invoiceDB.InvoiceDate.ToShortDateString();
			result.InvoiceNumber = invoiceDB.InsertedNumber.SerialString;
			result.Rows = invoiceDBRows;
			//result.Rows = invoiceDBRows.Select(Function(x) New InvoiceRowViewModel With {
			//               .ID = x.ID,
			//               .Item = x.ItemOrder,
			//               .InvoiceID = x.Invoice.ID,
			//               .Product = x.Description,
			//               .Quantity = x.Quantity,
			//               .UnitPrice = x.UnitPrice,
			//               .Discount1 = x.RateDiscount1,
			//               .Discount2 = x.RateDiscount2,
			//               .Discount3 = x.RateDiscount3,
			//                        .TotalBeforeTax = x.DiscountedAmount,
			//                        .Total = x.TotalAmount}).
			//         ToList()

			result.Payment = invoiceDB.Payment.Description;
			result.IsTaxExempt = invoiceDB.IsTaxExempt;
			result.TaxExemption = invoiceDB.TaxExemption;

			return result;
		}

		public DeleteInvoiceViewModel getDeleteInvoiceViewModel(int id)
		{
			DeleteInvoiceViewModel result = new DeleteInvoiceViewModel();
			Invoice invoiceDB = null;
			List<PresentationInvoiceRowViewModel> invoiceDBRows = null;

			//invoiceDB = _db.Invoices.Where(Function(x) x.ID = id).Include(Function(x) x.Customer).Include(
			//    Function(x) x.InvoiceRows).Include(Function(x) x.InvoiceRows.Select(Function(r) r.Product)).First
			//invoiceDBRows = invoiceDB.InvoiceRows

			invoiceDB = _db.Invoices.Find(id);
			invoiceDBRows = _manager.GetInvoiceRows(id);

			result.ID = invoiceDB.ID;
			result.CustomerName = invoiceDB.Customer.Name;
			result.InvoiceDate = invoiceDB.InvoiceDate;
			result.InvoiceNumber = invoiceDB.InsertedNumber.SerialString;
			result.Rows = invoiceDBRows;
			//result.Rows = invoiceDBRows.Select(Function(x) New InvoiceRowViewModel With {
			//              .ID = x.ID,
			//              .Item = x.ItemOrder,
			//              .InvoiceID = x.Invoice.ID,
			//              .Product = x.Description,
			//              .Quantity = x.Quantity,
			//              .UnitPrice = x.UnitPrice,
			//              .Discount1 = x.RateDiscount1,
			//              .Discount2 = x.RateDiscount2,
			//              .Discount3 = x.RateDiscount3,
			//                       .TotalBeforeTax = x.DiscountedAmount,
			//                       .Total = x.TotalAmount}).
			//        ToList()

			return result;

		}

	}
}
