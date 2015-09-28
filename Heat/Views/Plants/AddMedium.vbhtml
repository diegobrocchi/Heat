@ModelType Heat.ViewModels.Plants.AddMediumPlantViewModel
@Code
    ViewData("Title") = "Aggiungi un allegato all'impianto"
End Code

<h2>Aggiungi un allegato all'impianto</h2>

@Using (Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken 
    @Html.HiddenFor(Function(m) Model.PlantId)

    @<div class="form-horizontal">
         
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Tags, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Tags, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Tags, "", New With {.class = "text-danger"})
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.UploadFile, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.UploadFile, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.UploadFile, "", New With {.class = "text-danger"})
             </div>
         </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">

                <label for="fileSubmit" class="btn btn-success">
                <i class="glyphicon glyphicon-upload"></i>Carica il file</label>
                <input id="fileSubmit" type="submit" value="Carica il file"  class="hidden" />
                
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section