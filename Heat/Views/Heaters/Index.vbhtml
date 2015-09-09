@ModelType IEnumerable(Of Heat.Models.Heater)
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
            @Html.DisplayNameFor(Function(model) model.MinimumPowerKW)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MaximumPowerKW)
        </th>
         
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SerialNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MinimumPowerKW)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MaximumPowerKW)
        </td>
         
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
