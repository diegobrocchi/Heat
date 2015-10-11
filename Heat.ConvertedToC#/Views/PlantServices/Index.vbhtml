@ModelType IEnumerable(Of Heat.Models.PlantService)
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
            @Html.DisplayNameFor(Function(model) model.Plant.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlantID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PreviousServiceDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Periodicity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LegalExpirationDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PlannedServiceDate)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Plant.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PreviousServiceDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Periodicity)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LegalExpirationDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlannedServiceDate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
