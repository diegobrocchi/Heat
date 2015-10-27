using System.Collections.Generic;
using Heat.Models;

namespace Heat.ViewModels.Plants
{
    public class DetailsContactPlantViewModel
	{

		/// <summary>
		/// PlantID
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		public int ID { get; set; }

		public List<Contact> Contacts { get; set; }


	}
}

