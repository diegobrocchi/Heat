@ModelType Heat.Models.WarehouseMovement
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>WarehouseMovement</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Destination.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Destination.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Product.SKU)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Product.SKU)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Source.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Source.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Quantity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Quantity)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ExecDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ExecDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Note)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Note)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
