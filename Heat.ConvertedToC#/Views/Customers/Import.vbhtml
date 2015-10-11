@Code
    ViewData("Title") = "Importa anagrafica clienti"
End Code

<h2>Importa l'anagrafica dei clienti</h2>

@Using Html.BeginForm("Import", "Customers", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<div class="form-horizontal">
    <div class="form-group">
    <label for="uploadFileCustomers">Filename:</label>
    <input id="uploadFileCustomers" type="file" name="uploadFileCustomers" />
            </div>
     </div>
    @<input type="submit" value="Carica clienti" class="btn btn-primary" />
    
     
        @ViewBag.error
    
    
End Using
    
@Using Html.BeginForm("Import", "Plants", FormMethod.Post, New With {.enctype = "multipart/form-data"})
    @<div class="form-horizontal">
    <div class="form-group">
        <label for="uploadFilePlant">Filename:</label>
        <input id="uploadFilePlant" type="file" name="uploadFilePlant" />
    </div>
</div>
@<input type="submit" value="Carica impianti" class="btn btn-primary" />


@ViewBag.error

End Using
    

