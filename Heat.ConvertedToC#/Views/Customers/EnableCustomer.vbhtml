@ModelType Heat.ViewModels.Customers.EnableCustomerViewModel
@Code
    ViewData("Title") = "Abilita cliente"
End Code

<h2>Abilita cliente</h2>

@Using (Html.BeginForm)
    @Html.AntiForgeryToken 
    
    @Html.HiddenFor(Function(x) x.ID)
    
    @Html.LabelFor(Function(x) x.CustomerName )
    @Html.DisplayFor(Function(x) x.CustomerName )
    
    @<br/>
    @Html.LabelFor(Function(x) x.DisableDate)
    @Html.DisplayFor(Function(x) x.DisableDate )

    @<br/>
    @<input type="submit" value="Abilita il cliente" class="btn btn-success" />
    @Html.ActionLink("Torna alla lista", "Index", Nothing, New With {.class = "btn btn-primary"})
End Using

