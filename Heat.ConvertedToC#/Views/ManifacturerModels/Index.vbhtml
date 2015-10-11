@ModelType IEnumerable(Of Heat.ViewModels.ManifacturerModels.IndexManifacturerModelViewModel)
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
            @Html.DisplayNameFor(Function(model) model.Manifacturer)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Model)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Manifacturer)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Model)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next

</table>
