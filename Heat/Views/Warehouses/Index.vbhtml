﻿@ModelType IEnumerable(Of Heat.Warehouse)
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
            @Html.DisplayNameFor(Function(model) model.Descrition)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.HasValue)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Code)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Descrition)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.HasValue)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>