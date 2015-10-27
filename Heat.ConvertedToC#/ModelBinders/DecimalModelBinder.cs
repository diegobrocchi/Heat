using System;
using System.Web.Mvc;
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
