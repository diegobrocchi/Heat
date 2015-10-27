using Owin;
using Microsoft.Owin;
using Heat;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace Heat
{
    public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
