using System;
using System.Linq;
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

		public override bool CheckAccess(System.Security.Claims.AuthorizationContext context)
		{
			var resource = context.Resource.First();
			var claims = context.Principal.Claims.ToList();
			var action = context.Action.First();

			//http://stackoverflow.com/questions/26464848/custom-authorization-in-asp-net-webapi-what-a-mess
			ResourceOperations authRequired = default(ResourceOperations);

			authRequired =(ResourceOperations) Enum.Parse(typeof(ResourceOperations), action.Value);

			foreach (Claim singleClaim in claims) {
				 
				if (singleClaim.Type == "http://scheme.diegobrocchi.it/claims/2015/operation")
                {
					ResourceOperations authOwned = (ResourceOperations) Enum.Parse(typeof(ResourceOperations), singleClaim.Value);
					if ((authOwned & authRequired) == authRequired) {
						return true;
					}
				}
			}

			return false;
		}



	}
}
