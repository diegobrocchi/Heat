using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Customers
{
    public class EditCustomerViewModel
	{
		[Key()]
		public int ID { get; set; }

		[Required()]
		[Display(Name = "Nome")]
		public string Name { get; set; }
		[Display(Name = "Indirizzo")]
		public string Address { get; set; }
		[Display(Name = "Città")]
		public string City { get; set; }
		[Display(Name = "CAP")]
		public string PostalCode { get; set; }
		[Display(Name = "Provincia")]
		public string District { get; set; }
		[Display(Name = "Telefono 1")]
		public string Telephone1 { get; set; }
		[Display(Name = "Telefono 2")]
		public string Telephone2 { get; set; }
		[Display(Name = "Telefono 3")]
		public string Telephone3 { get; set; }
		[Display(Name = "Codice fiscale")]
		public string Taxcode { get; set; }
		[Display(Name = "Partita IVA")]
		public string VAT_Number { get; set; }
		[Display(Name = "IBAN")]
		public string IBAN { get; set; }

		[EmailAddress()]
		public string EMail { get; set; }
		[Url()]
		public string Website { get; set; }

		[Display(Name = "Abilitato")]
		public bool IsEnabled { get; set; }

		[Display(Name = "Note")]
		[DataType(DataType.MultilineText)]
		public string Note { get; set; }

	}
}

