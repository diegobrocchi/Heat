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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
//Imports Microsoft.Owin.Security.Google
using Owin;
using Heat.Repositories;
using Heat.Models;

namespace Heat
{

	public partial class Startup
	{
		// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
		public void ConfigureAuth(IAppBuilder app)
		{
			// Configure the db context, user manager and signin manager to use a single instance per request
			app.CreatePerOwinContext<HeatDBContext>(HeatDBContext.Create);
			app.CreatePerOwinContext<HeatUserManager>(HeatUserManager.Create);
			app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

			//configura anche HeatRoleManager
			app.CreatePerOwinContext<HeatRoleManager>(HeatRoleManager.Create);

			// Enable the application to use a cookie to store information for the signed in user
			// and to use a cookie to temporarily store inforation about a user logging in with a third party login provider
			// Configure the sign in cookie
			// OnValidateIdentity enables the application to validate the security stamp when the user logs in.
			// This is a security feature which is used when you change a password or add an external login to your account.
			//Attenzione alla modifica su OnException: serve per i casi di 'Cookie Monster'
			//http://stackoverflow.com/questions/26327092/why-is-owin-throwing-a-null-exception-on-new-project
			app.UseCookieAuthentication(new CookieAuthenticationOptions {
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				Provider = new CookieAuthenticationProvider {
					OnException = context => { },
					OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<HeatUserManager, HeatUser>(validateInterval: TimeSpan.FromMinutes(30), regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
				},
				LoginPath = new PathString("/Account/Login")
			});


			app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			// Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
			app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

			// Enables the application to remember the second login verification factor such as phone or email.
			// Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
			// This is similar to the RememberMe option when you log in.
			app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

			// Uncomment the following lines to enable logging in with third party login providers
			//app.UseMicrosoftAccountAuthentication(
			//    clientId:="",
			//    clientSecret:="")

			//app.UseTwitterAuthentication(
			//   consumerKey:="",
			//   consumerSecret:="")

			//app.UseFacebookAuthentication(
			//   appId:="",
			//   appSecret:="")

			//app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
			//   .ClientId = "",
			//   .ClientSecret = ""})
		}
	}
}
