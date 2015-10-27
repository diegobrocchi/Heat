using System.Web.Mvc;

namespace Heat.Controllers
{
    [Authorize()]
	public class SearchController : Controller
	{

		[HttpPost()]
		public ActionResult Index(string searchquery, string fromcontroller)
		{
			switch (fromcontroller) {
				case "Customers":
					ViewBag.message = "Search results for " + searchquery + " in Customers";
					break;
				case "PlantClasses":
					ViewBag.message = "Search results for " + searchquery + " in  PlantClasses";
					break;
				case "Plants":
					ViewBag.message = "Search results for " + searchquery + " in  Plant";
					break;
				case "PlantTypes":
					ViewBag.message = "Search results for " + searchquery + " in  PlantTypes";

					break;
			}
			return View();
		}
	}
}
