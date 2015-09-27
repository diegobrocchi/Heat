@ModelType IEnumerable(Of Heat.Models.Medium)
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
            @Html.DisplayNameFor(Function(model) model.FileName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RelativePath)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AbsolutePath)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Lenght)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Extension)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Tags)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FileName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RelativePath)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AbsolutePath)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Lenght)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Extension)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Tags)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
