@modeltype ViewModels.Invoices.insertedIndexViewModel 
@Code
    ViewData("Title") = "Fatture in modifica"
End Code

<h2>Fatture in modifica non ancora confermate</h2>

@If Model.InsertedInvoiceList.Count > 0 Then
    @<table class="table table-bordered">
        <thead>
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.InsertedInvoiceList(0).InvoiceNumber)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.InsertedInvoiceList(0).InvoiceDate)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.InsertedInvoiceList(0).Customer)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.InsertedInvoiceList(0).RowCount)
                </th>
                <th></th>
            </tr>
        </thead>
    <tbody>
        @For Each Item In Model.InsertedInvoiceList
                @<tr>
        <td>
                @Html.DisplayFor(Function(x) Item.InvoiceNumber )
                    </td>
        <td>
            @Html.DisplayFor(Function(x) Item.InvoiceDate)
        </td>
        <td>
            @Html.DisplayFor(Function(x) Item.Customer)
        </td>
        <td>
            @Html.DisplayFor(Function(x) Item.RowCount )
        </td>
        <td>
            @Html.ActionLink("Continua con le modifiche", "Edit", New With {.id = Item.ID}, New With {.class = "btn btn-default"})
            @Html.ActionLink("Elimina", "delete", New With {.id = Item.ID}, New With {.class = "btn btn-danger"})
        </td>
        </tr>
                                
            Next
    </tbody>
    </table>
        End If

