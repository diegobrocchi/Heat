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
using Heat.Repositories;
using Heat.Controllers;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Collections.ObjectModel;
namespace Heat
{




	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, inherited = true, AllowMultiple = true)]
	public class ResourceAuthorizeAttribute : AuthorizeAttribute
	{

		private ResourceOperations _operation;

		private string _resource;
		public ResourceAuthorizeAttribute(ResourceOperations Operation, string Resource)
		{
			_operation = Operation;
			_resource = Resource;
		}


		public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
		{
			var dbContext = filterContext.HttpContext.GetOwinContext().Get<HeatDBContext>();
			ResourceClaimsAuthorizeManager cm = new ResourceClaimsAuthorizeManager(dbContext);

			ClaimsPrincipal p = (ClaimsPrincipal)filterContext.HttpContext.User;
			Collection<Claim> resourceClaims = new Collection<Claim>();
			Collection<Claim> operationClaims = new Collection<Claim>();

			resourceClaims.Add(new Claim("http://scheme.diegobrocchi.it/claims/2015/resource", _resource));
			operationClaims.Add(new Claim("http://scheme.diegobrocchi.it/claims/2015/operation", _operation, "ResourceOperations"));

			if (cm.CheckAccess(new AuthorizationContext((ClaimsPrincipal)filterContext.HttpContext.User, resourceClaims, operationClaims))) {
				base.OnAuthorization(filterContext);
			} else {
				base.HandleUnauthorizedRequest(filterContext);

			}

		}



	}
}
