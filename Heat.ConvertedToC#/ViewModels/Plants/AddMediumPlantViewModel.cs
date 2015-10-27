using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Heat.ViewModels.Plants
{
    public class AddMediumPlantViewModel
	{

		public int PlantId { get; set; }

		[Required()]
		[Display(Name = "Descrizione immagine")]
		public string Description { get; set; }

		[Display(Name = "Etichette")]
		public string Tags { get; set; }

		[Display(Name = "File")]
		[DataType(DataType.Upload)]
		public HttpPostedFileBase UploadFile { get; set; }

	}

}
