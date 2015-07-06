@ModelType IEnumerable(Of Heat.Models.Invoice)
@Code
ViewData("Title") = "Index"
End Code

<h2>Fatture</h2>

<p>
    @Html.ActionLink("Crea nuova fattura", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.ConfirmedNumber.SerialString)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Customer.Name)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ConfirmedNumber.SerialString)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Customer.Name)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
