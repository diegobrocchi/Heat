@ModelType Heat.models.Plant
@Code
    ViewData("Title") = "Cancella impianto"
End Code

<h2>Cancella impianto</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Plant</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StreetNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StreetNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PostalCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PostalCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Area)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Area)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Zone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Zone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantTelephone1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantTelephone2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantTelephone3)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantDistictCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantDistictCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fuel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fuel)
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
