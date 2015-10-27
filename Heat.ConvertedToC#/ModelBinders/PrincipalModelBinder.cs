using System;
using System.Web.Mvc;
using System.Security.Principal;
namespace Heat
{

    public class PrincipalModelBinder : IModelBinder
	{

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if ((controllerContext == null)) {
				throw new ArgumentNullException("ControllerContext!");
			}
			if ((bindingContext == null)) {
				throw new ArgumentNullException("BindingContext!");
			}

			IPrincipal p = controllerContext.HttpContext.User;
			return p;

		}
	}
}
