using System.Web.Mvc;
using log4net;
namespace Heat
{

    public class HomeController : System.Web.Mvc.Controller
	{


		private ILog _logger;
		public HomeController()
		{
			_logger = LogManager.GetLogger(typeof(HomeController));
		}

		public ActionResult Index()
		{
			_logger.Debug("Index function entered");

			return View();
		}

		public ActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public ActionResult test()
		{
			return View();
		}
	}
}
