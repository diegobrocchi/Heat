@ModelType Heat.viewModels.WorkActions.CreateWorkActionViewModel  
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
                
    @<div class="form-horizontal">
        <h4>WorkAction</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
    
    @* La vista visualizza elementi differenti nel caso di PlantID selezionato o da selezionare *@

    @If Model.PlantIDSelected Then
        @<div class="form-group">
            @Html.LabelFor(Function(model) model.PlantDescription, New With {.class = "control-label col-md-2"})
            <div class="col-md-10 form-control-static">
                @Html.DisplayFor(Function(model) model.PlantDescription)
            </div>
        </div>
        @Html.HiddenFor(Function(model) model.PlantID)
    Else
        @<div class="form-group">
            @Html.LabelFor(Function(model) model.PlantID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10 ">
                @Html.DropDownListFor(Function(model) model.PlantID, Model.PlantList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.PlantID, "", New With {.class = "text-danger"})
            </div>
        </div>
    End If

    @* fine della parte *@    
     
        <div class="form-group">
            @Html.LabelFor(Function(model) model.ActionDate, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ActionDate, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.ActionDate, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.OperationID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("OperationID", Model.OperationList, htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.OperationID, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.AssignedOperatorID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.AssignedOperatorID, Model.AssignedOperatorList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.AssignedOperatorID, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TypeID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.TypeID, Model.TypeList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.TypeID, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-success" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
