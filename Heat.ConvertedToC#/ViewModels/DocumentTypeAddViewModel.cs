using System.Web.Mvc;

namespace Heat.ViewModels
{

    public class DocumentTypeAddViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int NumberingID { get; set; }
		public SelectList NumberingList { get; set; }

	}
}
