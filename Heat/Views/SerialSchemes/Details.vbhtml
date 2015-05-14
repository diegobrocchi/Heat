@ModelType Heat.SerialScheme
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>SerialScheme</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.InitialValue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.InitialValue)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Increment)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Increment)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MinValue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MinValue)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MaxValue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MaxValue)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.FormatMask)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FormatMask)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExpiryDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExpiryDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RecycleWhenExpired)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RecycleWhenExpired)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Period)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Period)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RecycleWhenMaxIsReached)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RecycleWhenMaxIsReached)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
