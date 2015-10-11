@ModelType IEnumerable(Of Heat.Models.Seller)
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
            @Html.DisplayNameFor(Function(model) model.FiscalCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IBAN)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Logo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Vat_Number)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FiscalCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IBAN)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Logo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Vat_Number)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
