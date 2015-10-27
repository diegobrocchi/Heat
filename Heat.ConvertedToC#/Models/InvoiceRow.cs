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
			get { return UnitPrice * (decimal) Quantity; }
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
			get { return DiscountedAmount * (decimal) VAT_Rate / 100; }
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

