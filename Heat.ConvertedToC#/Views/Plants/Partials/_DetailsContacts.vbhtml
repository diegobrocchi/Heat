@ModelType Heat.ViewModels.Plants.DetailsContactPlantViewModel

<h3>Contatti</h3>

<table id="tblPlantDetailsContact" class="table table-bordered table-condensed table-striped ">
    <thead >
        <tr>
            <th>Nome</th>
            <th>Indirizzo</th>
        </tr>
    </thead>
    <tbody>
        @For Each Item In Model.Contacts
            @<tr>
        <td>
            @Item.Name 
        </td>
        <td>
            @Item.Address.Street  
        </td>
        </tr>
        Next
    </tbody>
</table>
@Html.ActionLink("Aggiungi contatto", "addAnotherContact", New With {.id = Model.ID}, New With {.class = "btn btn-success"})
 