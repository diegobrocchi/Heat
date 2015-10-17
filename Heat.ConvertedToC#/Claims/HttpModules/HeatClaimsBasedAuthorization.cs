using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
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
