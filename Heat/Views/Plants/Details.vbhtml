@ModelType Heat.models.Plant
@Code
    ViewData("Title") = "Dettagli impianto"
End Code

<h2>Dettagli impianto</h2>

<div>
    <h4>Plant</h4>

    <ul class="nav nav-tabs" role="tablist" id="plantDetailsTab">
        <li role="presentation" class="active"><a href="#pagina1" role="tab" data-toggle="tab">Pagina 1</a></li>
        <li role="presentation"><a href="#pagina2" role="tab" data-toggle="tab">pagina 2</a></li>
        <li role="presentation"><a href="#pagina3" role="tab" data-toggle="tab">Pagina 3</a></li>
    </ul>

    <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="pagina1">Qui i dettagli dell'identificazione impianto</div>
        <div role="tabpanel" class="tab-pane" id="pagina2">qui i dettagli tecnici del'impianto</div>
        <div role="tabpanel" class="tab-pane" id="pagina3">qui lo stato della manutenzione</div>
    </div>

    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Code)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Code)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
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
            @Html.DisplayNameFor(Function(model) model.Area)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Area)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Zone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Zone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantTelephone1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantTelephone2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantTelephone3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantTelephone3)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PlantDistictCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantDistictCode)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
