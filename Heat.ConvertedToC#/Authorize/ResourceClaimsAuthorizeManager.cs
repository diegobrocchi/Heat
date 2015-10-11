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
using Heat.Repositories;
namespace Heat
{

	public class ResourceClaimsAuthorizeManager : ClaimsAuthorizationManager
	{


		private HeatDBContext _db;
		public ResourceClaimsAuthorizeManager()
		{
		}

		public ResourceClaimsAuthorizeManager(HeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public override bool CheckAccess(AuthorizationContext context)
		{
			var resource = context.Resource.First();
			var claims = context.Principal.Claims.ToList();
			var action = context.Action.First();

			//http://stackoverflow.com/questions/26464848/custom-authorization-in-asp-net-webapi-what-a-mess
			ResourceOperations authRequired = default(ResourceOperations);

			authRequired = Enum.Parse(typeof(ResourceOperations), action.Value());

			foreach (? Claim_loopVariable in claims) {
				Claim = Claim_loopVariable;
				if (Claim.Type == "http://scheme.diegobrocchi.it/claims/2015/operation") {
					ResourceOperations authOwned = Enum.Parse(typeof(ResourceOperations), Claim.Value());
					if (authOwned & authRequired == authRequired) {
						return true;
					}
				}
			}

			return false;
		}



	}
}
