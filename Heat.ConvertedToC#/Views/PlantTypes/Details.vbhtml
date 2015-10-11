@ModelType Heat.PlantType
@Code
    ViewData("Title") = "Dettagli tipo di impianto"
End Code

<h2>Dettagli tipo di impianto</h2>

<div>
    <h4>Tipo di impianto</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Modifica", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Torna alla lista", "Index")
</p>
