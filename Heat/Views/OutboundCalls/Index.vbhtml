@ModelType IEnumerable(Of Heat.Models.OutboundCall)
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
            @Html.DisplayNameFor(Function(model) model.Contact.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CallDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ResultID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Login)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Contact.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CallDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ResultID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Login)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
