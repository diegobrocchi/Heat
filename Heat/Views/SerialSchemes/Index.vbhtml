@ModelType IEnumerable(Of Heat.SerialScheme)
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
            @Html.DisplayNameFor(Function(model) model.InitialValue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Increment)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MinValue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MaxValue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FormatMask)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ExpiryDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RecycleWhenExpired)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Period)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.RecycleWhenMaxIsReached)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.InitialValue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Increment)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MinValue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MaxValue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FormatMask)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ExpiryDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RecycleWhenExpired)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Period)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.RecycleWhenMaxIsReached)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
