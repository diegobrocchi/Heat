using System.Security.Claims;
using System.Security.Principal;
namespace Heat
{

    public class HeatClaimsPrincipal : ClaimsPrincipal
	{

		public HeatClaimsPrincipal(string userName)
		{
			GenericIdentity gi = new GenericIdentity(userName, "Heat Custom authentication");
			ClaimsIdentity ci = new ClaimsIdentity(gi);

			this.AddIdentity(ci);
		}


	}
}
