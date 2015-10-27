using System;
using System.Web;
using System.Security.Claims;
namespace Heat
{

    public class HeatClaimsBasedAuthorization : IHttpModule
	{


		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.PostAuthenticateRequest += ReplacePrincipal;
		}
		private static void ReplacePrincipal(object sender, EventArgs e)
		{
			if ((HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated) {
				ClaimsPrincipal cp = CreateClaimsBasedPrincipal();
			}

		}

		private static ClaimsPrincipal CreateClaimsBasedPrincipal()
		{
			string UserName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
			HeatClaimsPrincipal hcp = new HeatClaimsPrincipal(UserName);
			System.Threading.Thread.CurrentPrincipal = hcp;

			if ((HttpContext.Current != null)) {
				HttpContext.Current.User = hcp;
			}

			return hcp;
		}


	}
}
