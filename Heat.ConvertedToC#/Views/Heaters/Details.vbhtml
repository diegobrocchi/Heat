@ModelType Heat.Models.Heater
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Heater</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SerialNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SerialNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MinimumPowerKW)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MinimumPowerKW)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MaximumPowerKW)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MaximumPowerKW)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CertificationReference)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CertificationReference)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
