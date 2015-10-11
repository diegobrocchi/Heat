@ModelType Heat.Models.Address
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Address</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AddressType.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AddressType.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Street)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Street)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StreetNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StreetNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PostalCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PostalCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Province)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Province)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.State)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.State)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CellPhone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CellPhone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fax)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fax)
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
