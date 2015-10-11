@modeltype ViewModels.Plants.ManagePlantViewModel 
@Code
    ViewData("Title") = "Gestione impianti"
End Code

<h2>Gestione</h2>

<p>
    Impianto: @Model.Name 
</p>

@Html.ActionLink("Dettagli impianto", "Details", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Modifica impianto", "Edit", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
@Html.ActionLink("Aggiungi generatore", "create", "ThermalUnits", New With {.plantID = Model.ID}, New With {.class = "btn btn-primary"})

