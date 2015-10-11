@ModelType Heat.Models.Medium
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Medium</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.FileName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FileName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.RelativePath)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.RelativePath)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AbsolutePath)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AbsolutePath)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Lenght)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Lenght)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Extension)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Extension)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Tags)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Tags)
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
