using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.WorkActions
{
    public class CreateWorkActionViewModel
	{

		[Display(Name = "Impianto")]
		public int PlantID { get; set; }
		[Display(Name = "Riferita all'impianto")]
		public string PlantDescription { get; set; }
		public IEnumerable<SelectListItem> PlantList { get; set; }
		public bool PlantIDSelected { get; set; }

		[Display(Name = "Data di esecuzione")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ActionDate { get; set; }

		[Display(Name = "Tipo di operazione")]
		public int OperationID { get; set; }
		public IEnumerable<SelectListItem> OperationList { get; set; }

		[Display(Name = "Operatore assegnato")]
		public int AssignedOperatorID { get; set; }
		public IEnumerable<SelectListItem> AssignedOperatorList { get; set; }

		[Display(Name = "Tipo di operazione")]
		public int TypeID { get; set; }
		public IEnumerable<SelectListItem> TypeList { get; set; }

	}
}

