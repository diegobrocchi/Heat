@ModelType IEnumerable(Of Heat.Models.Customer)
@Code
    ViewData("Title") = "Gestione clienti"
End Code

    <h3>Heat - visualizza clienti</h3>
  
<p>
    @Html.ActionLink("Crea un nuovo cliente", "Create")
</p>
<table id="index_table" class="table table-bordered table-hover table-striped">
    <thead >
    <tr>
        <th class="col-md-3">
           @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th class="col-md-2">
            @Html.DisplayNameFor(Function(model) model.Address)
        </th>
        <th class="col-md-3">
            @Html.DisplayNameFor(Function(model) model.City)
        </th>
        <th class="col-md-1">
            @Html.DisplayNameFor(Function(model) model.Telephone1)
        </th>
        <th class="col-md-1">
            @Html.DisplayNameFor(Function(model) model.Telephone2)
        </th>
        <th class="col-md-2">

        </th>
    </tr>

    </thead>
    <tbody >


    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Address)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.City)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Telephone1)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Telephone2)
            </td>
            <td>
                @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) 
                @*@Html.ActionLink("Cancella", "Delete", New With {.id = item.ID})*@
            </td>
        </tr>
    Next
    </tbody>

</table>

@section scripts
     
<script type="text/javascript"  src="~/Scripts/Views/Customers/index.js"></script>
End Section