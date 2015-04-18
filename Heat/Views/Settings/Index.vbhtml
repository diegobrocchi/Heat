﻿@Code
    ViewData("Title") = "Configurazioni"
End Code

<h2>Configurazioni</h2>

<ul class="list-group">
    <li class="list-group-item">@Html.ActionLink("Tipi di impianti", "index", "PlantTypes")</li>
    <li class="list-group-item">@Html.ActionLink("Classi di impianti", "index", "PlantClasses")</li>
    <li class="list-group-item">@Html.ActionLink("Combustibili","index","Fuels")</li>
    <li class="list-group-item">@Html.ActionLink("Causali di documento","index", "causalDocuments")</li>
    <li class="list-group-item">@Html.ActionLink("Numeratori documenti", "index","Numberings")</li>
    <li class="list-group-item">@Html.ActionLink("Tipi di documento", "index", "DocumentTypes")</li>
</ul>



