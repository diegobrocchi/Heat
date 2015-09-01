﻿@ModelType IEnumerable(Of Heat.MOdels.Plant)
@Code
    ViewData("Title") = "Impianti"
End Code

<h2>Impianti</h2>

<p>
    @Html.ActionLink("Crea un nuovo impianto", "Create", Nothing, New With {.class = "btn btn-success"})
</p>
<table id="index_table" class="table table-bordered table-hover table-striped">
    <thead >
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Code)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Address)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.City)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.PostalCode)
            </th>
             
            <th>
                @Html.DisplayNameFor(Function(model) model.PlantTelephone1)
            </th>
             
            <th>
                @Html.DisplayNameFor(Function(model) model.PlantDistictCode)
            </th>
             
            <th></th>
        </tr>
    </thead>
   <tbody>
@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Code)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address)
        </td>
         
        <td>
            @Html.DisplayFor(Function(modelItem) item.City)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PostalCode)
        </td>
         
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantTelephone1)
        </td>
         
        <td>
            @Html.DisplayFor(Function(modelItem) item.PlantDistictCode)
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