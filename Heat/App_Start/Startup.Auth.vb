﻿Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
'Imports Microsoft.Owin.Security.Google
Imports Owin
Imports Heat.Repositories

Partial Public Class Startup
    ' For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Configure the db context, user manager and signin manager to use a single instance per request
        app.CreatePerOwinContext(Of HeatDBContext)(AddressOf HeatDBContext.Create)
        app.CreatePerOwinContext(Of HeatUserManager)(AddressOf HeatUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        'configura anche HeatRoleManager
        app.CreatePerOwinContext(Of HeatRoleManager)(AddressOf HeatRoleManager.Create)

        ' Enable the application to use a cookie to store information for the signed in user
        ' and to use a cookie to temporarily store inforation about a user logging in with a third party login provider
        ' Configure the sign in cookie
        ' OnValidateIdentity enables the application to validate the security stamp when the user logs in.
        ' This is a security feature which is used when you change a password or add an external login to your account.
        'Attenzione alla modifica su OnException: serve per i casi di 'Cookie Monster'
        'http://stackoverflow.com/questions/26327092/why-is-owin-throwing-a-null-exception-on-new-project
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {.OnException = Sub(c) Throw c.Exception,
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of HeatUserManager, HeatUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})

        
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' Enables the application to remember the second login verification factor such as phone or email.
        ' Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
        ' This is similar to the RememberMe option when you log in.
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        ' Uncomment the following lines to enable logging in with third party login providers
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '   consumerKey:="",
        '   consumerSecret:="")

        'app.UseFacebookAuthentication(
        '   appId:="",
        '   appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '   .ClientId = "",
        '   .ClientSecret = ""})
    End Sub
End Class
