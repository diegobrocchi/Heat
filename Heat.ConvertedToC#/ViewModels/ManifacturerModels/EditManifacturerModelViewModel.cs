using System.Collections.Generic;
using System.Web.Mvc;
namespace Heat.ViewModels.ManifacturerModels
{
    public class EditManifacturerModelViewModel
	{

		public int ID { get; set; }
		public int ManifacturerID { get; set; }
		public IEnumerable<SelectListItem> ManifacturerList { get; set; }
		public string Model { get; set; }

	}

}
