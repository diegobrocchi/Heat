@ModelType Heat.Models.Invoice
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Invoice</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.DocNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DocNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sum)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sum)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
