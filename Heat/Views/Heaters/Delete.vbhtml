@ModelType Heat.Models.Heater
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
