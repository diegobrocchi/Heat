using System.Web.Mvc;

namespace Heat.Controllers
{
    [Authorize()]
	public class SettingsController : Controller
	{

		// GET: Settings
		public ActionResult Index()
		{
			return View();
		}


	}
}
