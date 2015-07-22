Imports System.Globalization

Public Class DecimalModelBinder
    Implements IModelBinder


    Public Function BindModel(controllerContext As ControllerContext, bindingContext As ModelBindingContext) As Object Implements IModelBinder.BindModel
        Dim valueResult As ValueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName)
        Dim modelState As ModelState = New ModelState()
        modelState.Value = valueResult

        Dim actualValue As Object = Nothing

        Try
            actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture)

        Catch ex As FormatException
            modelState.Errors.Add(ex.Message)

        End Try
        bindingContext.ModelState.Add(bindingContext.ModelName, modelState)
        Return actualValue

    End Function
End Class
