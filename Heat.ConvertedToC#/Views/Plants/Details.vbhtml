@ModelType Heat.ViewModels.Plants.DetailsPlantViewModel
@Code
    ViewData("Title") = "Dettagli impianto"
End Code

<h2>Dettagli impianto</h2>

<div>
    <h4>Impianto</h4>

    <ul class="nav nav-tabs" role="tablist" id="plantDetailsTab">
        <li role="presentation" class="active"><a href="#tabIdentify" role="tab" data-toggle="tab">Dati identificativi</a></li>
        <li role="presentation"><a href="#tabThermal" role="tab" data-toggle="tab">Dati termici</a></li>
        <li role="presentation"><a href="#tabService" role="tab" data-toggle="tab">Manutenzione</a></li>
        <li role="presentation"><a href="#tabContacts" role="tab" data-toggle="tab">Contatti</a></li>
        <li role="presentation"><a href="#tabMedia" role="tab" data-toggle="tab">Allegati</a></li>

    </ul>

    <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="tabIdentify">
            @Html.Partial("partials/_DetailsIdentify", Model.IdentifyViewModel)
        </div>
        <div role="tabpanel" class="tab-pane" id="tabThermal">
            @Html.Partial("partials/_DetailsThermal", Model.ThermalViewModel)
        </div>
        <div role="tabpanel" class="tab-pane" id="tabService">
            @Html.Partial("partials/_DetailsService", Model.ServiceViewModel)
        </div>
        <div role="tabpanel" class="tab-pane" id="tabContacts">
            @Html.Partial("partials/_DetailsContacts", Model.ContactViewModel)
        </div>
        <div role="tabpanel" class="tab-pane" id="tabMedia">
            @Html.Partial("partials/_DetailsMedia", Model.MediaViewModel)
        </div>
    </div>

</div>

    @*<hr />
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
            @Html.DisplayNameFor(Function(model) model.PlantDistinctCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PlantDistinctCode)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>*@
