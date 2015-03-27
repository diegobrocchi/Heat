@ModelType Heat.Models.Product
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
