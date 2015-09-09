@ModelType Heat.viewModels.Heaters.CreateHeaterViewModel 
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @Html.HiddenFor(Function(model) model.ThermalUnitID )
    
    @<div class="form-horizontal">
        <h4>Heater</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ThermalUnitDescription)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ManifacturerID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.ManifacturerID, Model.ManifacturerList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.ManifacturerID, "", New With {.class = "text-danger"})
             </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ModelID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.ModelID, Model.ModelList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.ModelID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SerialNumber, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SerialNumber, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.SerialNumber, "", New With { .class = "text-danger" })
            </div>
        </div>
        
         <div class="form-group">
             @Html.LabelFor(Function(model) model.InstallationDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.InstallationDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.InstallationDate, "", New With {.class = "text-danger"})
             </div>
         </div>

         <div class="form-group">
            @Html.LabelFor(Function(model) model.MinimumPowerKW, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.MinimumPowerKW, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.MinimumPowerKW, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.MaximumPowerKW, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.MaximumPowerKW, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.MaximumPowerKW, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Type, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Type, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Type, "", New With {.class = "text-danger"})
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.FuelID, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.FuelID, Model.FuelList, New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.FuelID, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Inserisci" class="btn btn-success" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
