@ModelType IEnumerable(Of Heat.Models.ThermalUnit)
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
            @Html.DisplayNameFor(Function(model) model.SerialNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.InstallationDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstStartUp)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Warranty)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.WarrantyExpiration)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NominalThermalPowerMax)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DismissDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ThermalEfficiencyPowerMax)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Kind)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SerialNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.InstallationDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstStartUp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Warranty)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.WarrantyExpiration)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NominalThermalPowerMax)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DismissDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ThermalEfficiencyPowerMax)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Kind)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
