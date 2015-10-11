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
namespace Heat.Models
{
	public abstract class InvoiceRow
	{
		public int ID { get; set; }
		public Invoice Invoice { get; set; }
		public int RowID { get; set; }
		public int ItemOrder { get; set; }
		//Property Product As Product
		public double Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public double VAT_Rate { get; set; }
		public decimal RateDiscount1 { get; set; }
		public decimal RateDiscount2 { get; set; }
		public decimal RateDiscount3 { get; set; }

		/// <summary>
		/// Totale LORDO nominale: prezzo unitario * quantità
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal GrossAmount {
			get { return UnitPrice * Quantity; }
		}
		/// <summary>
		/// Totale IMPONIBILE: LORDO - SCONTI
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal DiscountedAmount {
			get {
				decimal discountAmount1 = default(decimal);
				decimal discountAmount2 = default(decimal);
				decimal discountAmount3 = default(decimal);

				discountAmount1 = GrossAmount * RateDiscount1 / 100;
				decimal partial1 = default(decimal);

				partial1 = GrossAmount - discountAmount1;

				discountAmount2 = partial1 * RateDiscount2 / 100;
				decimal partial2 = default(decimal);

				partial2 = GrossAmount - discountAmount1 - discountAmount2;

				discountAmount3 = partial2 * RateDiscount3 / 100;

				return GrossAmount - discountAmount1 - discountAmount2 - discountAmount3;

			}
		}

		/// <summary>
		/// Importo dell'IVA.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal TaxAmount {
			get { return DiscountedAmount * VAT_Rate / 100; }
		}
		/// <summary>
		/// Importo TOTALE.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public decimal TotalAmount {
			get { return DiscountedAmount + TaxAmount; }
		}
	}

}

