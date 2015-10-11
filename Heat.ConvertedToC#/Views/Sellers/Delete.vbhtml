@ModelType Heat.Models.Seller
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
