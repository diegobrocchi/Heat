@ModelType IEnumerable(Of Heat.indexSerialSchemeviewmodel)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Schemi di numerazione</h2>
<p>
    Lo schema di numerazione definisce il modo in cui viene generato il numero successivo di un numeratore.
</p>

<p>
    @Html.ActionLink("Crea un nuovo schema", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
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
                @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Elimina", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next

</table>
