@modeltype ienumerable(of ViewModels.InvoiceRowViewModel )

<table class="table table-bordered">
    <thead>
        <tr>
            <th>Item</th>
            <th>Prodotto</th>
            <th>Quantità</th>
            <th>Prezzo</th>
        </tr>
    </thead>
    <tbody >
        @For Each itemModel In Model
            @<tr>
        <td>
            @Html.DisplayFor(Function(x) itemModel.Item)
        </td>
        <td>
    @Html.DisplayFor(Function(x) itemModel.Product)

        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.Quantity)
        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.UnitPrice)
        </td>
            </tr>

        Next
    </tbody>
</table>






