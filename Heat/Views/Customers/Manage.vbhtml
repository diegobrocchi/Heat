@modeltype ViewModels.Customers.ManageCustomerViewModel
@Code
    ViewData("Title") = "Gestisci cliente"
End Code


<h3>@Html.DisplayFor(Function(m) m.Name)</h3>

@Html.ActionLink("Dettagli cliente", "Details", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Modifica cliente", "Edit", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
@code
    If Model.IsEnabled Then
@Html.ActionLink("Disabilita cliente", "DisableCustomer", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
    Else
@Html.ActionLink("Abilita cliente", "EnableCustomer", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
    End If
End Code  
          
@Html.ActionLink("Emetti fattura", "Create", "invoices", New With {.customerID = Model.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Preventivo", "Create", "quotation", New With {.customerID = Model.ID}, New With {.class = "btn btn-primary"})

              