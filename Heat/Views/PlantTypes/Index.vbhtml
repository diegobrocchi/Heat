@ModelType IEnumerable(Of Heat.PlantType)
@Code
    ViewData("Title") = "Tipo di impianto"
End Code

<h2>Tipo di impianto</h2>

<p>
    @Html.ActionLink("Crea un nuovo tipo di impianto", "Create")
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
            @Html.ActionLink("Elimina", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
