﻿@ModelType Heat.Models.WarehouseMovement
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
