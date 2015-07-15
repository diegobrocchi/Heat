@ModelType viewmodels.Invoices.indexViewModel 
@Code
    ViewData("Title") = "Fatture"
End Code

<h2>Fatture</h2>

<p>
    @Html.ActionLink("Crea nuova fattura", "Create", Nothing, New With {.class = "btn btn-default"})
</p>

@If Model.InvoiceList.Count > 0 Then
  @<table class="table">
    <tr>
        <th>
    @Html.DisplayNameFor(Function(model) model.InvoiceList(0).InvoiceNumber)
        </th>
        <th>
    @Html.DisplayNameFor(Function(model) model.InvoiceList(0).InvoiceDate)
        </th>
        <th>
    @Html.DisplayNameFor(Function(model) model.InvoiceList(0).Customer)
        </th>
        <th></th>
    </tr>

    @For Each item In Model.InvoiceList
        @<tr>
            <td>
        @Html.DisplayFor(Function(modelItem) item.InvoiceNumber)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.InvoiceDate)
            </td>
    <td>
                @Html.DisplayFor(Function(modelItem) item.Customer)
    </td>
            <td>
                 
                @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}, New With {.class = "btn btn-primary"})

            </td>
        </tr>
    Next

</table>
End If

