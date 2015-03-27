@ModelType IEnumerable(Of Heat.Models.InventoryMovement)
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
            @Html.DisplayNameFor(Function(model) model.Quantity)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ExecDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Note)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Quantity)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExecDate)
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
