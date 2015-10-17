using System;
using System.Web;
using System.Web.Mvc;
using Heat.Repositories;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Collections.ObjectModel;
namespace Heat
{




    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
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
			operationClaims.Add(new Claim("http://scheme.diegobrocchi.it/claims/2015/operation", _operation.ToString() , "ResourceOperations"));

			if (cm.CheckAccess(new System.Security.Claims.AuthorizationContext((ClaimsPrincipal)filterContext.HttpContext.User, resourceClaims, operationClaims))) {
				base.OnAuthorization(filterContext);
			} else {
				base.HandleUnauthorizedRequest(filterContext);

			}

		}



	}
}
