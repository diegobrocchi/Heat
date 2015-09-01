@ModelType Heat.Models.PlantService
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
