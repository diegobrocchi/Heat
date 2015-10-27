using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Invoices
{

    /// <summary>
    /// Modello 
    /// </summary>
    /// <remarks></remarks>
    public class InvoiceCreateViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Display(Name = "Cliente")]
		public string CustomerName { get; set; }

		[Display(Name = "Numero documento")]
		public string TempNumber { get; set; }

		[Display(Name = "Data emissione")]
		public System.DateTime EmissionDate { get; set; }


	}

}

