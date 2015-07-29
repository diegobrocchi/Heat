@ModelType ViewModels.Invoices.confirmedIndexViewModel
@Code
    ViewData("Title") = "Fatture"
End Code

<h2>Fatture</h2>

<p>
    @Html.ActionLink("Crea nuova fattura", "Create", Nothing, New With {.class = "btn btn-default"})
    @If Model.InsertedInvoiceCount > 0 Then
        @Html.ActionLink("Lista fatture non ancora confermate", "index", New With {.state = Heat.Models.DocumentState.Inserted}, New With {.class = "btn btn-primary"})
    End If
</p>

@If Model.ConfirmedInvoiceList.Count > 0 Then
    @<table class="table table-bordered">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.ConfirmedInvoiceList(0).InvoiceNumber)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ConfirmedInvoiceList(0).InvoiceDate)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ConfirmedInvoiceList(0).Customer)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ConfirmedInvoiceList(0).TaxableAmount)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ConfirmedInvoiceList(0).TaxesAmount)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ConfirmedInvoiceList(0).TotalAmount)
            </th>
            <th></th>
        </tr>

        @For Each item In Model.ConfirmedInvoiceList
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
        @Html.DisplayFor(Function(modelitem) item.TaxableAmount )
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.TaxesAmount)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.TotalAmount)
    </td>
                <td>

                    @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}, New With {.class = "btn btn-primary"})

                </td>
            </tr>
        Next

    </table>
End If

