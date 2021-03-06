﻿@ModelType Heat.models.numbering
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Numerator</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastFinalSerial.SerialString)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastFinalSerial.SerialString)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Back to List", "Index")
</p>
