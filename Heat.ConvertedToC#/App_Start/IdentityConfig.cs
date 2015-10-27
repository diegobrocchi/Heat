using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Heat.Repositories;
using Heat.Models;

namespace Heat
{

    public class EmailService : IIdentityMessageService
	{

		public Task SendAsync(IdentityMessage message)
		{
			// Plug in your email service here to send an email.
			return Task.FromResult(0);
		}
	}
}
namespace Heat
{

    public class SmsService : IIdentityMessageService
	{

		public Task SendAsync(IdentityMessage message)
		{
			// Plug in your SMS service here to send a text message.
			return Task.FromResult(0);
		}
	}
}
namespace Heat
{

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class HeatUserManager : UserManager<HeatUser>
	{

		public HeatUserManager(IUserStore<HeatUser> store) : base(store)
		{
		}

		public static HeatUserManager Create(IdentityFactoryOptions<HeatUserManager> options, IOwinContext context)
		{
			var manager = new HeatUserManager(new UserStore<HeatUser>(context.Get<HeatDBContext>()));

			// Configure validation logic for userNames
			manager.UserValidator = new UserValidator<HeatUser>(manager) {
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = false
			};

			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator {
				RequiredLength = 3,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false
			};

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = true;
			manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			manager.MaxFailedAccessAttemptsBeforeLockout = 5;

			// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
			// You can write your own provider and plug it in here.
			manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<HeatUser> { MessageFormat = "Your security code is {0}" });
			manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<HeatUser> {
				Subject = "Security Code",
				BodyFormat = "Your security code is {0}"
			});
			manager.EmailService = new EmailService();
			manager.SmsService = new SmsService();
			var dataProtectionProvider = options.DataProtectionProvider;
			if ((dataProtectionProvider != null)) {
				manager.UserTokenProvider = new DataProtectorTokenProvider<HeatUser>(dataProtectionProvider.Create("ASP.NET Identity"));
			}

			return manager;
		}

	}
}
namespace Heat
{

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<HeatUser, string>
	{
		public ApplicationSignInManager(HeatUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
		{
		}

		public override Task<ClaimsIdentity> CreateUserIdentityAsync(HeatUser user)
		{
			return user.GenerateUserIdentityAsync((HeatUserManager)UserManager);
		}



		public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
		{
			return new ApplicationSignInManager(context.GetUserManager<HeatUserManager>(), context.Authentication);
		}
	}
}
namespace Heat
{

    //Public Class HeatDBInitializer
    //    Inherits DropCreateDatabaseAlways(Of HeatDBContext) ' CreateDatabaseIfNotExists(Of HeatDBContext)

    //    Protected Overrides Sub Seed(context As HeatDBContext)
    //        'InitializeIdentity(context)
    //        MyBase.Seed(context)
    //    End Sub

    //    Public Sub InitializeIdentity(DbConfiguration As HeatDBContext)
    //        'Dim um As HeatUserManager = HttpContext.Current.GetOwinContext().GetUserManager(Of HeatUserManager)()
    //        'Dim rm As HeatRoleManager = HttpContext.Current.GetOwinContext().Get(Of HeatRoleManager)()

    //        'Const userName As String = "demo"
    //        'Const password As String = "demo"
    //        'Const role As String = "canView"

    //        'Dim cr = rm.FindByName(role)

    //        'If IsNothing(cr) Then
    //        '    cr = New HeatRole(role, "Può visualizzare")
    //        '    Dim result = rm.Create(cr)
    //        'End If

    //        'Dim cu = um.FindByName(userName)
    //        'If IsNothing(cu) Then
    //        '    cu = New HeatUser With {.UserName = userName}
    //        '    Dim result = um.Create(cu, password)
    //        '    result = um.SetLockoutEnabled(cu.Id, False)
    //        'End If

    //        'Dim RolesForUser = um.GetRoles(cu.Id)
    //        'If Not RolesForUser.Contains(cr.Name) Then
    //        '    Dim result = um.AddToRole(cu.Id, cr.Name)

    //        'End If

    //    End Sub


    //End Class

    public class HeatRoleManager : RoleManager<HeatRole>
	{

		public HeatRoleManager(IRoleStore<HeatRole, string> roleStore) : base(roleStore)
		{
		}

		public static HeatRoleManager Create(IdentityFactoryOptions<HeatRoleManager> options, IOwinContext context)
		{
			var roleStore = new RoleStore<HeatRole>(context.Get<HeatDBContext>());
			return new HeatRoleManager(roleStore);
		}

	}
}
