﻿@ModelType Heat.Models.WorkAction
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>WorkAction</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AssignedOperator.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AssignedOperator.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Operation.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Operation.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ActionDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ActionDate)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
