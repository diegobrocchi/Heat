@ModelType IEnumerable(Of Heat.SerialSchemeviewmodel)
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
            @Html.DisplayNameFor(Function(model) model.Name ) 
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description )
        </th>
         
        <th>
            @Html.DisplayNameFor(Function(model) model.Increment)
        </th>
         
        <th>
            @Html.DisplayNameFor(Function(model) model.Period)
        </th>
         
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
         <td>
             @Html.DisplayFor(Function(model) item.Name)
         </td>
         <td>
             @Html.DisplayFor(Function(model) item.Description)
         </td>

         
        <td>
            @Html.DisplayFor(Function(modelItem) item.Increment)
        </td>
         
        <td>
            @Html.DisplayFor(Function(modelItem) item.Period)
        </td>
         
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
