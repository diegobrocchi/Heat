@ModelType Heat.PlantClass
@Code
    ViewData("Title") = "Dettagli della classe di impianto"
End Code

<h2>Details</h2>

<div>
    <h4>PlantClass</h4>
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
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
