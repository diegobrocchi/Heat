@Code
    ViewData("Title") = "Configurazioni"
End Code

<h2>Configurazioni</h2>

<ul class="list-group">
    <li class="list-group-item">@Html.ActionLink("Tipi di impianti", "index", "PlantTypes")</li>
    <li class="list-group-item">@Html.ActionLink("Classi di impianti", "index", "PlantClasses")</li>
    <li class="list-group-item">@Html.ActionLink("Combustibili","index","Fuels")</li>
    <li class="list-group-item">@Html.ActionLink("Causali di documento","index", "causalDocuments")</li>
    <li class="list-group-item">@Html.ActionLink("Causali di magazzino", "index", "CausalWarehouses")</li>
    <li class="list-group-item">@Html.ActionLink("Gruppi di causali di magazzino", "index", "CausalWarehouseGroups")</li>
    <li class="list-group-item">@Html.ActionLink("Numeratori documenti", "index","Numberings")</li>
    <li class="list-group-item">@Html.ActionLink("Schemi di numerazione", "index", "SerialSchemes")</li>
    <li class="list-group-item">@Html.ActionLink("Tipi di documento", "index", "DocumentTypes")</li>
    <li class="list-group-item">@Html.ActionLink("Magazzini", "index", "Warehouses")</li>
    <li class="list-group-item">@Html.ActionLink("Movimenti di magazzino", "index", "WarehouseMovements")</li>
    <li class="list-group-item">@Html.ActionLink("Pagamenti", "index", "payments")</li>
    <li class="list-group-item">@Html.ActionLink("Tipi di indirizzo", "index", "AddressTypes")</li>
    <li class="list-group-item">@Html.ActionLink("Archivio operazioni", "index", "Operations")</li>
    

</ul>



