@ModelType Heat.Models.InvoiceRow
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>InvoiceRow</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.RowID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RowID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ItemOrder)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ItemOrder)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Quantity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Quantity)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UnitPrice)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UnitPrice)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.VAT_Rate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.VAT_Rate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RateDiscount1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RateDiscount1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RateDiscount2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RateDiscount2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RateDiscount3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RateDiscount3)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
