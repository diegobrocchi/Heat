@ModelType IEnumerable(Of Heat.Models.Customer )

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Address)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.City)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PostalCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.District)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Telephone1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Telephone2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Telephone3)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Taxcode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.VAT_Number)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IBAN)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EMail)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Website)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Enabled)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.City)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PostalCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.District)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Telephone1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Telephone2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Telephone3)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Taxcode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.VAT_Number)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IBAN)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EMail)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Website)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Enabled)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
