using System.Web.Mvc;
namespace Heat
{

    public static class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new AuthorizeAttribute());
			filters.Add(new HandleErrorAttribute());
			//filters.Add(New ClaimsAutorizeAttribute())
		}
	}
}
