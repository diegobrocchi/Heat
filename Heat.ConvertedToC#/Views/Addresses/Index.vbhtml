@ModelType IEnumerable(Of Heat.Models.Address)
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
            @Html.DisplayNameFor(Function(model) model.AddressType.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Street)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StreetNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.City)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PostalCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Province)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.State)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CellPhone)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fax)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Note)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AddressType.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Street)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StreetNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.City)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PostalCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Province)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.State)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Phone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CellPhone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Fax)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Note)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
