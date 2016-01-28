@Code
    ViewData("Title") = "Importa anagrafica clienti"
End Code

<h2>Importa l'anagrafica dei clienti</h2>

@Using Html.BeginForm("Import", "Customers", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<div class="form-horizontal">
        <div class="form-group">
            <label for="uploadFileCustomers">FileName:</label>
            <input id="uploadFileCustomers" type="file" Name="uploadFileCustomers" />
        </div>
    </div>
    @<input type="submit" value="Carica clienti" class="btn btn-primary" />


    @ViewBag.error


End Using

@Using Html.BeginForm("Import", "Plants", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<div class="form-horizontal">
        <div class="form-group">
            <label for="uploadFilePlant">FileName Impianti:</label>
            <input id="uploadFilePlant" type="file" Name="uploadFilePlant" />
        </div>

        <div class="form-group">
            <label for="uploadFileThermalUnit">FileName caldaie installate:</label>
            <input id="uploadFileThermalUnit" type="file" Name="uploadFileThermalUnit" />
        </div>
    </div>
    @<input type="submit" value="Carica impianti" class="btn btn-primary" />


    @ViewBag.error

End Using


