using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Plants
{
    public class AddContactPlantViewModel
	{
		public int PlantID { get; set; }

		[Required()]
		[Display(Name = "Nominativo")]
		public string Name { get; set; }

		[Display(Name = "Tipo contatto")]
		public int AddressTypeID { get; set; }
		public IEnumerable<SelectListItem> AddressTypeList { get; set; }

		[Display(Name = "Indirizzo")]
		public string Street { get; set; }

		[Display(Name = "Numero civico")]
		public string StreetNumber { get; set; }

		[Display(Name = "Località")]
		public string City { get; set; }

		[Display(Name = "CAP")]
		public string PostalCode { get; set; }

		[Display(Name = "Provincia")]
		public string District { get; set; }


		[Display(Name = "Note")]
		[DataType(DataType.MultilineText)]
		public string Note { get; set; }

		[Display(Name = "Telefono")]
		public string Phone { get; set; }

		[Display(Name = "Cellulare")]
		public string CellPhone { get; set; }

		[Display(Name = "Fax")]
		public string Fax { get; set; }

		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "Web")]
		[DataType(DataType.Url)]
		public string URL { get; set; }


	}

}
