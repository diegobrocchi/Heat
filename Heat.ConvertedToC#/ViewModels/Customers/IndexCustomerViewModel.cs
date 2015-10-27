using System.Collections.Generic;

namespace Heat.ViewModels.Customers
{

    public class IndexCustomerViewModel
	{

		/// <summary>
		/// Indica se sono visualizzati anche i clienti disabilitati.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool IsIncludeDisable { get; set; }

		/// <summary>
		/// Indica se nella lista dei clienti ci sono soggetti disabilitati.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool HasDisabled { get; set; }

		public List<IndexCustomerGridViewModel> Rows { get; set; }

	}

}
