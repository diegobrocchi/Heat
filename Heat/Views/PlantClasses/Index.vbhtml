@ModelType IEnumerable(Of Heat.PlantClass)
@Code
    ViewData("Title") = "Classe di impianto"
End Code

<h2>Classe di impianto</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
            @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) |
            @Html.ActionLink("Elimina", "Delete", New With {.id = item.ID})
        </td>
    </tr>
Next

</table>
