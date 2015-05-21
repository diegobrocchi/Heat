@ModelType Heat.Warehouse
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Warehouse</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Descrition)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Descrition)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.HasValue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HasValue)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
