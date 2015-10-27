using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Heat.Repositories;
using Heat.Heat.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectMVC5), "StartNinject")]

[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectMVC5), "StopNinject")]
namespace Heat.Heat.App_Start
{
    public static class NinjectMVC5
	{

		private static readonly Bootstrapper bootstrapper = new Bootstrapper();
		/// <summary>
		/// Starts the application
		/// </summary>
		public static void StartNinject()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));

			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void StopNinject()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			//kernel.Bind(Of HeatDBContext)().ToSelf.InRequestScope()
			RegisterServices(kernel);
			return kernel;
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param Name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IHeatDBContext>().To<HeatDBContext>().InRequestScope();
		}
	}
}
