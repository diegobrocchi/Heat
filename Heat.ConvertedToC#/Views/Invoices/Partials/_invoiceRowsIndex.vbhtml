@*@modeltype ienumerable(of ViewModels.Invoices.InvoiceRowViewModel )*@
@modeltype IEnumerable(Of ViewModels.Invoices.PresentationInvoiceRowViewModel)



<table class="table table-bordered">
    <thead>
        <tr>
            <th>Item</th>
            <th>Prodotto</th>
            <th>Quantità</th>
            <th>Prezzo Unitario</th>
            <th>Sc.1</th>
            <th>Sc.2</th>
            <th>Sc.3</th>
            <th>Imponibile</th>
            <th>IVA</th>
            <th>TOTALE</th>
             
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
        <td>
            @Html.DisplayFor(Function(x) itemModel.Discount1 )
        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.Discount2)
        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.Discount3)
        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.TotalBeforeTax) 
        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.VAT)
        </td>
        <td>
            @Html.DisplayFor(Function(x) itemModel.Total)
        </td>
         
            </tr>

        Next
    </tbody>
</table>






