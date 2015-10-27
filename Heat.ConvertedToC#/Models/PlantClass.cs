using System.ComponentModel.DataAnnotations;
namespace Heat.Models
{
    public class PlantClass
	{
		[Key()]
		public int ID { get; set; }
		public string Name { get; set; }


	}
}

