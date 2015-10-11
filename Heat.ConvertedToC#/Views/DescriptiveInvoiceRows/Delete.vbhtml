@ModelType Heat.Models.DescriptiveInvoiceRow
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>DescriptiveInvoiceRow</h4>
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

        <dt>
            @Html.DisplayNameFor(Function(model) model.RowDescription)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RowDescription)
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
