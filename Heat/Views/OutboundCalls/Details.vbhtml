@ModelType Heat.Models.OutboundCall
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>OutboundCall</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Contact.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contact.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CallDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CallDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ResultID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ResultID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Login)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Login)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
