using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.ManifacturerModels
{

    public class CreateManifacturerModelViewModel
	{
		[Required()]
		[Display(Name = "Marca")]
		public int ManifacturerID { get; set; }
		public IEnumerable<SelectListItem> ManifacturerList { get; set; }
		[Required()]
		public string Model { get; set; }
	}

}
