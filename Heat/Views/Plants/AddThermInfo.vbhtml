@ModelType Heat.ViewModels.Plants.AddThermInfoPlantViewModel
@Code
    ViewData("Title") = "Aggiungi dati termici"
End Code

<h2>Aggiungi dati termici</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @Html.HiddenFor(Function(x) x.PlantID )
    
    @<div class="form-horizontal">
        <h4>AddThermInfoPlantViewModel</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PlantClassID, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.PlantClassID, Model.PlantClassList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.PlantClassID, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PlantTypeID, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.PlantTypeID, Model.PlantTypeList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.PlantTypeID, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.PlantDistinctCode, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PlantDistinctCode, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.PlantDistinctCode, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.IsSingleUnit, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.IsSingleUnit)
                    @Html.ValidationMessageFor(Function(model) model.IsSingleUnit, "", New With { .class = "text-danger" })
                </div>
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.GrossHeatedVolumeM3, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.GrossHeatedVolumeM3, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.GrossHeatedVolumeM3, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.GrossCooledVolumeM3, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.GrossCooledVolumeM3, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.GrossCooledVolumeM3, "", New With { .class = "text-danger" })
            </div>
        </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.EnergyCategory, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EnumDropDownListFor(Function(model) model.EnergyCategory, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.EnergyCategory, "", New With {.class = "text-danger"})
             </div>
         </div>



        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
