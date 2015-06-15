@ModelType Heat.Models.Seller
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Seller</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.FiscalCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FiscalCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IBAN)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IBAN)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Logo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Logo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Vat_Number)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Vat_Number)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
