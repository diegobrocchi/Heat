@Code
    ViewData("Title") = "Configurazioni"
End Code

<h2>Configurazioni</h2>

<ul class="list-group">
    <li class="list-group-item">@Html.ActionLink("Tipi di impianti", "index", "PlantTypes")</li>
    <li class="list-group-item">@Html.ActionLink("Classi di impianti", "index", "PlantClasses")</li>
    <li class="list-group-item">@Html.ActionLink("Combustibili","index","Fuels")</li>
</ul>



