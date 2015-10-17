using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Heat.Models
{
    public class HeatUser : IdentityUser
    {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<HeatUser> manager)
    {
        // Note the authenticationType must match the one 
        // defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        // Add custom user claims here
        return userIdentity;
    }
    }
}
public class HeatRole : IdentityRole
    {
        public HeatRole()
            : base()
        {
        }
        public HeatRole(string roleName, string description)
            : base(roleName)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
