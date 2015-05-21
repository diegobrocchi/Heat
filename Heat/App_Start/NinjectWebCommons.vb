Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports Ninject
Imports Ninject.Web.Mvc
Imports WebActivatorEx
Imports Ninject.Web.Common
Imports Heat.Repositories

<Assembly: WebActivatorEx.PreApplicationStartMethod(GetType(Heat.App_Start.NinjectMVC5), "StartNinject")> 
<Assembly: WebActivatorEx.ApplicationShutdownMethod(GetType(Heat.App_Start.NinjectMVC5), "StopNinject")> 

Namespace Heat.App_Start
    Public Module NinjectMVC5
        Private ReadOnly bootstrapper As New Bootstrapper()

        ''' <summary>
        ''' Starts the application
        ''' </summary>
        Public Sub StartNinject()
            DynamicModuleUtility.RegisterModule(GetType(OnePerRequestHttpModule))

            bootstrapper.Initialize(AddressOf CreateKernel)
        End Sub

        ''' <summary>
        ''' Stops the application.
        ''' </summary>
        Public Sub StopNinject()
            bootstrapper.ShutDown()
        End Sub

        ''' <summary>
        ''' Creates the kernel that will manage your application.
        ''' </summary>
        ''' <returns>The created kernel.</returns>
        Private Function CreateKernel() As IKernel
            Dim kernel = New StandardKernel()
            'kernel.Bind(Of HeatDBContext)().ToSelf.InRequestScope()
            RegisterServices(kernel)
            Return kernel
        End Function

        ''' <summary>
        ''' Load your modules or register your services here!
        ''' </summary>
        ''' <param name="kernel">The kernel.</param>
        Private Sub RegisterServices(ByVal kernel As IKernel)

        End Sub
    End Module
End Namespace