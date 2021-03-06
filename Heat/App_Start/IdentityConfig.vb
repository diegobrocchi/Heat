﻿Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System.Data.Entity
Imports Heat.Repositories

Public Class EmailService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' Plug in your email service here to send an email.
        Return Task.FromResult(0)
    End Function
End Class

Public Class SmsService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' Plug in your SMS service here to send a text message.
        Return Task.FromResult(0)
    End Function
End Class

' Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
Public Class HeatUserManager
    Inherits UserManager(Of HeatUser)

    Public Sub New(store As IUserStore(Of HeatUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of HeatUserManager), context As IOwinContext) As HeatUserManager
        Dim manager = New HeatUserManager(New UserStore(Of HeatUser)(context.Get(Of HeatDBContext)()))

        ' Configure validation logic for usernames
        manager.UserValidator = New UserValidator(Of HeatUser)(manager) With {
            .AllowOnlyAlphanumericUserNames = False,
            .RequireUniqueEmail = False
        }

        ' Configure validation logic for passwords
        manager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 3,
            .RequireNonLetterOrDigit = False,
            .RequireDigit = False,
            .RequireLowercase = False,
            .RequireUppercase = False
        }

        ' Configure user lockout defaults
        manager.UserLockoutEnabledByDefault = True
        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5)
        manager.MaxFailedAccessAttemptsBeforeLockout = 5

        ' Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        ' You can write your own provider and plug it in here.
        manager.RegisterTwoFactorProvider("Phone Code", New PhoneNumberTokenProvider(Of HeatUser) With {
                                          .MessageFormat = "Your security code is {0}"
                                      })
        manager.RegisterTwoFactorProvider("Email Code", New EmailTokenProvider(Of HeatUser) With {
                                          .Subject = "Security Code",
                                          .BodyFormat = "Your security code is {0}"
                                          })
        manager.EmailService = New EmailService()
        manager.SmsService = New SmsService()
        Dim dataProtectionProvider = options.DataProtectionProvider
        If (dataProtectionProvider IsNot Nothing) Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of HeatUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If

        Return manager
    End Function

End Class

' Configure the application sign-in manager which is used in this application.
Public Class ApplicationSignInManager
    Inherits SignInManager(Of HeatUser, String)
    Public Sub New(userManager As HeatUserManager, authenticationManager As IAuthenticationManager)
        MyBase.New(userManager, authenticationManager)
    End Sub

    Public Overrides Function CreateUserIdentityAsync(user As HeatUser) As Task(Of ClaimsIdentity)
        Return user.GenerateUserIdentityAsync(DirectCast(UserManager, HeatUserManager))
    End Function

     

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationSignInManager), context As IOwinContext) As ApplicationSignInManager
        Return New ApplicationSignInManager(context.GetUserManager(Of HeatUserManager)(), context.Authentication)
    End Function
End Class

'Public Class HeatDBInitializer
'    Inherits DropCreateDatabaseAlways(Of HeatDBContext) ' CreateDatabaseIfNotExists(Of HeatDBContext)

'    Protected Overrides Sub Seed(context As HeatDBContext)
'        'InitializeIdentity(context)
'        MyBase.Seed(context)
'    End Sub

'    Public Sub InitializeIdentity(DbConfiguration As HeatDBContext)
'        'Dim um As HeatUserManager = HttpContext.Current.GetOwinContext().GetUserManager(Of HeatUserManager)()
'        'Dim rm As HeatRoleManager = HttpContext.Current.GetOwinContext().Get(Of HeatRoleManager)()

'        'Const username As String = "demo"
'        'Const password As String = "demo"
'        'Const role As String = "canView"

'        'Dim cr = rm.FindByName(role)

'        'If IsNothing(cr) Then
'        '    cr = New HeatRole(role, "Può visualizzare")
'        '    Dim result = rm.Create(cr)
'        'End If

'        'Dim cu = um.FindByName(username)
'        'If IsNothing(cu) Then
'        '    cu = New HeatUser With {.UserName = username}
'        '    Dim result = um.Create(cu, password)
'        '    result = um.SetLockoutEnabled(cu.Id, False)
'        'End If

'        'Dim RolesForUser = um.GetRoles(cu.Id)
'        'If Not RolesForUser.Contains(cr.Name) Then
'        '    Dim result = um.AddToRole(cu.Id, cr.Name)

'        'End If

'    End Sub


'End Class

Public Class HeatRoleManager
    Inherits RoleManager(Of HeatRole)

    Sub New(roleStore As IRoleStore(Of HeatRole, String))
        MyBase.New(roleStore)
    End Sub

    Shared Function Create(options As IdentityFactoryOptions(Of HeatRoleManager), context As IOwinContext) As HeatRoleManager
        Dim roleStore = New RoleStore(Of HeatRole)(context.Get(Of HeatDBContext))
        Return New HeatRoleManager(roleStore)
    End Function

End Class