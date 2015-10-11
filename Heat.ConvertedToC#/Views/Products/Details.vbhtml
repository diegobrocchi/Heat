@ModelType Heat.Models.Product
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Product</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SKU)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SKU)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UnitPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UnitPrice)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cost)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cost)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ReorderLevel)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ReorderLevel)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
