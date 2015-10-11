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
using System.Globalization;
namespace Heat
{

	public class DecimalModelBinder : IModelBinder
	{


		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState();
			modelState.Value = valueResult;

			object actualValue = null;


			try {
				actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);

			} catch (FormatException ex) {
				modelState.Errors.Add(ex.Message);

			}
			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;

		}
	}
}
