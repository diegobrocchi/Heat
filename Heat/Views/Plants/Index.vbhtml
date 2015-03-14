@ModelType IEnumerable(Of Heat.Plant)
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
            @Html.DisplayNameFor(Function(model) model.Code)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Address)
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
            @Html.DisplayNameFor(Function(model) model.Area)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Zone)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone1)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone2)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone3)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlantDistictCode)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fuel)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Code)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address)
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
            @Html.DisplayFor(Function(modelItem) item.Area)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Zone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantTelephone1)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantTelephone2)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantTelephone3)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantDistictCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Fuel)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
