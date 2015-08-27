@ModelType Heat.Models.WorkAction
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
