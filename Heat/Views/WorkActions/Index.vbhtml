@ModelType IEnumerable(Of Heat.Models.WorkAction)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Aggiungi", "Create", Nothing, New With {.class = "btn btn-success"})
</p>
<table id="index_table" class="table table-bordered table-hover table-striped">
    <thead >
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.AssignedOperator.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Customer.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Operation.Code)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Type.Description)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ActionDate)
            </th>
            <th></th>
        </tr>

    </thead>
    <tbody>
@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AssignedOperator.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Customer.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Operation.Code)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Type.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ActionDate)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
        </td>
    </tr>
Next
    </tbody>
   
    </table>


    @section scripts
        <script type="text/javascript" src="~/Scripts/Views/WorkActions/index.js"></script>
    End Section
