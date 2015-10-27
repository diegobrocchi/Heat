using System.ComponentModel.DataAnnotations;
namespace Heat.Models
{
    public class PlantType
	{
		[Key()]
		public int ID { get; set; }
		[Display(Name = "Tipo impianto")]
		public string Name { get; set; }

	}
}

