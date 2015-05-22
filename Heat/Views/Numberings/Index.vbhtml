@ModelType IEnumerable(Of Heat.IndexNumberingViewModel)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Numeratori</h2>

<p>
    @Html.ActionLink("Crea un nuovo Numeratore", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Code)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TempSerialSchema)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FinalSerialSchema)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Code)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TempSerialSchema)
            </td>
            <td>
                @Html.DisplayFor(Function(modelitem) item.FinalSerialSchema)
            </td>
            <td>
                @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
                @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) |
                @Html.ActionLink("Elimina", "Delete", New With {.id = item.ID})
            </td>
        </tr>
    Next

</table>
