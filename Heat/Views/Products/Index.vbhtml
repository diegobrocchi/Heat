@ModelType IEnumerable(Of Heat.Models.Product)
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
            @Html.DisplayNameFor(Function(model) model.SKU)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UnitPrice)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cost)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ReorderLevel)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SKU)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UnitPrice)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Cost)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ReorderLevel)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>

<table id="tblPagedProducts" class="table table-bordered table-hover table-striped">
    <thead>
        <tr>

            <th>SKU</th>
            <th>Descrizione</th>
            <th>Prezzo</th>
               
            <th><a href="@Url.Action("create")" class=" btn btn-success"><span class="glyphicon glyphicon-plus-sign" /></a> </th>
        </tr>

    </thead>
    <tbody></tbody>
</table>

@section scripts
    <script type="text/javascript" src="~/Scripts/Views/Products/index.js"></script>
End Section