@ModelType IEnumerable(Of Heat.Models.Customer)
@Code
    ViewData("Title") = "Gestione clienti"
End Code

@Using Html.BeginForm("search", "Customers")
@<div class="row">

<div class="col-md-6">
    <h3>Heat - visualizza clienti</h3>
</div>

    <div class=" col-md-6">
        <h3>Cerca:@Html.TextBox("SearchString")
         <input type="submit" value="Cerca" class="btn btn-primary " />

        </h3>
    </div>
</div>
End Using





<p>
    @Html.ActionLink("Crea un nuovo cliente", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.ActionLink(Html.DisplayNameFor(Function(model) model.Name).ToString, "Heat ", New With {.sortOrder = ViewBag.SortOrderParam})
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Address)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.City)
        </th>
               <th>
            @Html.DisplayNameFor(Function(model) model.EMail)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Website)
        </th>
        <th></th>
    </tr>

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
                @Html.DisplayFor(Function(modelItem) item.EMail)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Website)
            </td>
            <td>
                @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Cancella", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next

</table>
