@ModelType Heat.Models.ThermalUnit
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
