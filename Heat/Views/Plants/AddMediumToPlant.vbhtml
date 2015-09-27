@ModelType Heat.ViewModels.Plants.AddMediumPlantViewModel
@Code
    ViewData("Title") = "AddMediumToPlant"
End Code

<h2>AddMediumToPlant</h2>

@Using (Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"}))
    @Html.AntiForgeryToken 
    @Html.HiddenFor(Function(m) Model.PlantId)

    @<div class="form-horizontal">
        <h4>AddMediumPlantViewModel</h4>
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
                <input type="submit" value="Carica il file" class="btn btn-default" />
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