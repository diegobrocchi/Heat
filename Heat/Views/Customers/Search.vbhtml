@ModelType IEnumerable(Of Heat.Models.Customer)
@Code
    ViewData("Title") = "Ricerca clienti"
End Code

<h2>Ricerca</h2>

<p>
    @Html.ActionLink("Crea un nuovo cliente", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        
        <th>
            @Html.DisplayNameFor(Function(model) model.EMail)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Website)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Enabled)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        
        <td>
            @Html.DisplayFor(Function(modelItem) item.EMail)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Website)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Enabled)
        </td>
        <td>
            @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
            @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) |
            @Html.ActionLink("Cancella", "Delete", New With {.id = item.ID})
        </td>
    </tr>
Next

</table>
