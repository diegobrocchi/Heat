@ModelType Heat.Models.ThermalUnit
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>ThermalUnit</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SerialNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SerialNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.InstallationDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.InstallationDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FirstStartUp)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FirstStartUp)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Warranty)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Warranty)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.WarrantyExpiration)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.WarrantyExpiration)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NominalThermalPowerMax)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NominalThermalPowerMax)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DismissDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DismissDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ThermalEfficiencyPowerMax)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ThermalEfficiencyPowerMax)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Kind)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Kind)
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
