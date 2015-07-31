@modelType Heat.ViewModels.Customers.DisableCustomerViewModel 
@Code
    ViewData("Title") = "DisableCustomer"
End Code

<h2>Disabilita un cliente</h2>

@Using (Html.BeginForm)
    @Html.AntiForgeryToken()

    @Html.HiddenFor(Function(x) x.ID )
    
    @Html.LabelFor(Function(x) x.CustomerName)
    @Html.DisplayFor(Function(x) x.CustomerName)

    @<input type="submit" value="Disabilita il cliente" class="btn btn-primary" /> 
    
End Using

    



