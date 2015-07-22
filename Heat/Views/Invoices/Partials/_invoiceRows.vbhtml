@modeltype ienumerable(of ViewModels.InvoiceRowViewModel )

<table class="table table-bordered">
    <thead>
        <tr>
            <th>Prodotto</th>
            <th>Quantità</th>
        </tr>
    </thead>
    <tbody >
        @For Each itemModel In Model
            @<tr>
        <td>
    @Html.DisplayFor(Function(x) itemModel.Product)

        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.Quantity)
        </td>
            </tr>

        Next
    </tbody>
</table>






