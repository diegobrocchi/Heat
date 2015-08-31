@ModelType Heat.ViewModels.ThermalUnits.CreateThermalUnitViewModel 
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @Html.HiddenFor(Function(model) model.PlantID )
    
    @<div class="form-horizontal">
        <h4>ThermalUnit</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })

        
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PlantDescription )
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
            @Html.LabelFor(Function(model) model.InstallationDate, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InstallationDate, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.InstallationDate, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.FirstStartUp, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.FirstStartUp, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.FirstStartUp, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Warranty, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Warranty, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Warranty, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.WarrantyExpiration, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.WarrantyExpiration, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.WarrantyExpiration, "", New With { .class = "text-danger" })
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
            @Html.LabelFor(Function(model) model.NominalThermalPowerMax, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.NominalThermalPowerMax, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.NominalThermalPowerMax, "", New With { .class = "text-danger" })
            </div>
        </div>

        

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ThermalEfficiencyPowerMax, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ThermalEfficiencyPowerMax, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.ThermalEfficiencyPowerMax, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.HeatTransferFluidID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.HeatTransferFluidID, Model.HeatTransferFluidList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Kind, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Kind, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EnumDropDownListFor(Function(model) model.Kind, htmlAttributes:= New With { .class = "form-control" })
                @Html.ValidationMessageFor(Function(model) model.Kind, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Assegna" class="btn btn-success" />
                @Html.ActionLink("Torna agli impianti", "index", "plants")
            </div>
        </div>
    </div>
End Using


