@ModelType Heat.Models.OutboundCall
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
