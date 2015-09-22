@ModelType IEnumerable(Of Heat.ViewModels.Plants.IndexPlantViewModel )
@Code
    ViewData("Title") = "Impianti"
End Code

<h2>Impianti</h2>

<p>
    @Html.ActionLink("Crea un nuovo impianto", "Create", Nothing, New With {.class = "btn btn-success"})
</p>

<table id="tblPagedPlants" class="table table-bordered table-hover table-striped">
    <thead>
        <tr>

            <th>Codice</th>
            <th>Nome</th>
            <th>Classe</th>
            <th>Tipo</th>
            <th><a href="@Url.Action("create")" class=" btn btn-success"><span class="glyphicon glyphicon-plus-sign" /></a> </th>
        </tr>

    </thead>
    <tbody></tbody>
    </table> 

<table id="tblPagedPlantsXXX" class="table table-bordered table-hover table-striped">
    <thead >
        <tr>
            <th>
                @Html.DisplayNameFor(Function(x) x.PlantDistinctCode)
            </th>
            <th>
                @Html.DisplayNameFor(Function(x) x.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(x) x.PlantClass)
            </th>
            <th>
                @Html.DisplayNameFor(Function(x) x.PlantType)
            </th>
            <th>
                @Html.DisplayNameFor(Function(x) x.Address)
            </th>
            
             
            <th></th>
        </tr>
    </thead>
   <tbody>
@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantDistinctCode)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
       <td>
           @Html.DisplayFor(Function(modelItem) item.PlantClass)
       </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantType)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address)
        </td> 
        <td>
            @Html.ActionLink("Modifica", "Edit", New With {.id = item.ID}) |
            @Html.ActionLink("Dettagli", "Details", New With {.id = item.ID}) |
            @Html.ActionLink("Cancella", "Delete", New With {.id = item.ID}) |
            @Html.ActionLink("Aggiungi un Generatore", "create", "ThermalUnits", New With {.plantID = item.ID}, Nothing)
        </td>
    </tr>
Next
   </tbody>

   

</table>


@section scripts
    <script type="text/javascript" src="~/Scripts/Views/Plants/index.js"></script>
End Section