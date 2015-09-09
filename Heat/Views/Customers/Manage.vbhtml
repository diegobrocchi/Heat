@Code
    ViewData("Title") = "Gestisci cliente"
End Code

<h2>Azioni</h2>

@Html.ActionLink("Dettagli cliente", "Details", New With {.id = ViewBag.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Modifica cliente", "Edit", New With {.id = ViewBag.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Abilita cliente", "EnableCustomer", New With {.id = ViewBag.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Disabilita cliente", "DisableCustomer", New With {.id = ViewBag.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Emetti fattura", "Create", "invoices", New With {.customerID = ViewBag.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Preventivo", "Create", "quotation", New With {.customerID = ViewBag.ID}, New With {.class = "btn btn-primary"})

              