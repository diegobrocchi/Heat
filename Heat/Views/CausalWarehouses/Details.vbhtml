@ModelType Heat.CausalWarehouse
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>CausalWarehouse</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Type.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sign)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sign)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Transaction)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Transaction)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
