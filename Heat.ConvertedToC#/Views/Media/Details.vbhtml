@ModelType Heat.Models.Medium
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
