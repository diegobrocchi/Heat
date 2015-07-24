@ModelType IEnumerable(Of Heat.Models.InvoiceRow)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.RowID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ItemOrder)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Quantity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UnitPrice)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.VAT_Rate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RateDiscount1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RateDiscount2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RateDiscount3)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RowID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ItemOrder)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Quantity)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UnitPrice)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.VAT_Rate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RateDiscount1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RateDiscount2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RateDiscount3)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
