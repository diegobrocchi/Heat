@ModelType Heat.Models.PlantService
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>PlantService</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Plant.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Plant.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PreviousServiceDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PreviousServiceDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Periodicity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Periodicity)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LegalExpirationDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LegalExpirationDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlannedServiceDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlannedServiceDate)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
