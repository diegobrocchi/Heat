using System.Collections.Generic;
using Heat.Models;
namespace Heat
{

    public class DetailsMediaPlantViewModel
	{
		/// <summary>
		/// PlantID
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int ID { get; set; }
		public string BaseHref { get; set; }
		public List<Medium> Media { get; set; }


	}
}


