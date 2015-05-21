@ModelType Heat.CreateNumberingViewModel
@Code
    ViewData("Title") = "Create"
End Code

<h2>Aggiungi un nuovo Numeratore</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Numeratore</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Code, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Code, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Code, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Description, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Description, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TempSerialSchemaID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.TempSerialSchemaID, Model.TempSerialSchemaList, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ActionLink("...", "create", "SerialSchemes", Nothing, New With {.class = "btn btn-sm btn-primary"})
                @Html.ValidationMessageFor(Function(model) model.TempSerialSchemaID, "", New With {.class = "text-danger"})
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.FinalSerialSchemaID, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.FinalSerialSchemaID, Model.TempSerialSchemaList, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ActionLink("...", "create", "SerialSchemes", Nothing, New With {.class = "btn btn-sm btn-primary"})
                 @Html.ValidationMessageFor(Function(model) model.FinalSerialSchemaID, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Aggiungi" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
