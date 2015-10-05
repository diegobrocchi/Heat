@ModelType Heat.ViewModels.Plants.DetailsServicePlantViewModel

<div>
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(x) x.PreviousServiceDate)
        </dt>
        <dd>
            @Html.DisplayFor(Function(x) x.PreviousServiceDate)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(x) x.Periodicity)
        </dt>
        <dd>
            @Html.DisplayFor(Function(x) x.Periodicity)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(x) x.LegalExpirationDate)
        </dt>
        <dd>
            @Html.DisplayFor(Function(x) x.LegalExpirationDate)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(x) x.PlannedServiceDate)
        </dt>
        <dd>
            @Html.DisplayFor(Function(x) x.PlannedServiceDate)
        </dd>
    </dl>

</div>

