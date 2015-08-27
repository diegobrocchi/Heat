@ModelType Heat.ViewModels.Customers.IndexCustomerViewModel 
@Code
    ViewData("Title") = "Gestione clienti"
End Code

    <h3>Heat - visualizza clienti</h3>
  
<p>
    @Html.ActionLink("Crea un nuovo cliente", "Create", Nothing, New With {.class = "btn btn-success"})
    @code
        If Model.HasDisabled Then
            If Model.IsIncludeDisable Then
    @Html.ActionLink("Nascondi i clienti disabilitati", "index", Nothing, New With {.class = "btn btn-danger"})
            Else
    @Html.ActionLink("Visualizza anche i clienti disabilitati", "index", New With {.IncludeDisabled = True}, New With {.class = "btn btn-danger"})
            End If
        End If
    End Code
    
</p>

@Html.Partial("partials/_customerGrid", Model.Rows)

@section scripts
     <script type="text/javascript"  src="~/Scripts/Views/Customers/index.js"></script>
End Section