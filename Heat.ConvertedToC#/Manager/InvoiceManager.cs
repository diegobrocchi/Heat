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
using Heat.Repositories;
using Heat.Models;
using Heat.ViewModels.Invoices;
using System.Data.Entity;

namespace Heat.Manager
{
	/// <summary>
	/// Gestisce le regole di business per la fatturazione.
	/// </summary>
	/// <remarks></remarks>
	public class InvoiceManager
	{

		private IHeatDBContext _db;
		public InvoiceManager(IHeatDBContext context)
		{
			_db = context;
		}

		/// <summary>
		/// Prepara una fattura temporanea per il cliente indicato
		/// </summary>
		/// <param Name="customerID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public Invoice GetTemporaryDocument(int customerID)
		{
			Invoice result = new Invoice();
			NumeratorManager numberGenerator = NumeratorManager.Instance;
			DocumentType d = null;

			d = _db.DocumentTypes.Include(x => x.Numbering).Where(dt => dt.Name == "FTC").FirstOrDefault();

			result.Customer = _db.Customers.Find(customerID);
			result.InvoiceDate = DateTime.Now;
            Numbering num = d.Numbering;
			result.InsertedNumber = numberGenerator.GetNextTemp(ref num);
			result.ConfirmedNumber = new SerialNumber();
			result.IsTaxExempt = false;
			//result.Payment = 

			_db.Invoices.Add(result);

			return result;
		}

		/// <summary>
		/// Conferma il documento con ID specificato.
		/// </summary>
		/// <param Name="id"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool SetConfirmedDocument(int id)
		{
			Invoice invoice = new Invoice();
			List<InvoiceRow> rows = null;

			NumeratorManager numberGenerator = NumeratorManager.Instance;
			DocumentType d = null;

			d = _db.DocumentTypes.Include(x => x.Numbering).Where(dt => dt.Name == "FTC").FirstOrDefault();

			invoice = _db.Invoices.Include("InvoiceRows").Where(x => x.ID == id).First();
			rows = invoice.InvoiceRows;


			invoice.InvoiceDate = DateTime.Now;
			invoice.ConfirmedNumber = numberGenerator.GetNextFinal(d.Numbering);
			invoice.State = DocumentState.Confirmed;
			invoice.TaxableAmount = rows.Sum(x => x.DiscountedAmount);
			invoice.TaxesAmount = rows.Sum(x => x.TaxAmount);
			invoice.TotalAmount = invoice.TaxableAmount + invoice.TaxesAmount;

			return true;

		}

		public void Insert(Invoice invoice)
		{
			_db.Invoices.Add(invoice);
		}

		/// <summary>
		/// Recupera la lista delle righe di tipo 'Prodotto' e le righe di tipo 'Descrittiva' 
		/// e compone una lista di righe fattura di tipo 'Presentazione'.
		/// </summary>
		/// <param Name="invoiceID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public List<PresentationInvoiceRowViewModel> GetInvoiceRows(int invoiceID)
		{
			List<PresentationInvoiceRowViewModel> result = new List<PresentationInvoiceRowViewModel>();

			List<ProductInvoiceRow> productRowList = null;
			productRowList = _db.ProductInvoiceRows.Include(x => x.Product).Where(x => x.Invoice.ID == invoiceID).ToList();

			List<DescriptiveInvoiceRow> descriptiveRowList = null;
			descriptiveRowList = _db.DescriptiveInvoiceRows.Where(x => x.Invoice.ID == invoiceID).ToList();


			result.AddRange(productRowList.Select(x => new PresentationInvoiceRowViewModel {
				ID = x.ID,
				Item = x.ItemOrder,
				InvoiceID = x.Invoice.ID,
				SKU = x.Product.SKU,
				Product = x.Product.Description,
				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,
				Discount1 =(double) x.RateDiscount1,
				Discount2 = (double) x.RateDiscount2,
				Discount3 = (double) x.RateDiscount3,
				VAT = x.VAT_Rate,
				TotalBeforeTax = x.DiscountedAmount,
				Total = x.TotalAmount,
				RowType = InvoiceRowType.ProductRow
			}).ToList());

			result.AddRange(descriptiveRowList.Select(x => new PresentationInvoiceRowViewModel {
				ID = x.ID,
				Item = x.ItemOrder,
				InvoiceID = x.Invoice.ID,
				SKU = string.Empty,
				Product = x.RowDescription,
				Quantity = x.Quantity,
				UnitPrice = x.UnitPrice,
				Discount1 =(double) x.RateDiscount1,
				Discount2 = (double) x.RateDiscount2,
				Discount3 = (double) x.RateDiscount3,
				VAT = x.VAT_Rate,
				TotalBeforeTax = x.DiscountedAmount,
				Total = x.TotalAmount,
				RowType = InvoiceRowType.DescriptiveRow
			}).ToList());
			return result.OrderBy(x => x.Item).ToList();


		}
	}
}

