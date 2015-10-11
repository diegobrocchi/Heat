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
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Mvc;
using WebActivatorEx;
using Ninject.Web.Common;
using Heat.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Heat.App_Start.NinjectMVC5), "StartNinject")]

[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Heat.App_Start.NinjectMVC5), "StopNinject")]
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
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IHeatDBContext>().To<HeatDBContext>().InRequestScope();
		}
	}
}
