@ModelType Heat.CreateSerialSchemeViewModel 
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>SerialScheme</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
         <div class="form-group">
             @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-4"})
             <div class="col-md-8">
                 @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
             </div>
         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-4"})
             <div class="col-md-8">
                 @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
             </div>
         </div>



            <div class="form-group">
            @Html.LabelFor(Function(model) model.InitialValue, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                @Html.EditorFor(Function(model) model.InitialValue, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.InitialValue, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Increment, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                @Html.EditorFor(Function(model) model.Increment, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Increment, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.MinValue, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                @Html.EditorFor(Function(model) model.MinValue, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.MinValue, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.MaxValue, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                @Html.EditorFor(Function(model) model.MaxValue, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.MaxValue, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.FormatMask, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-4">
                @Html.EditorFor(Function(model) model.FormatMask, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.FormatMask, "", New With { .class = "text-danger" })
            </div>
            <div class="col-md-4">
                É possibile utilizzare i segnaposto speciali '{{ww}}' per il numero di settimana dell'anno e '{{yyyy}}' per l'anno a quattro cifre.
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ExpiryDate, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                @Html.EditorFor(Function(model) model.ExpiryDate, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.ExpiryDate, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.RecycleWhenExpired, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.RecycleWhenExpired)
                    @Html.ValidationMessageFor(Function(model) model.RecycleWhenExpired, "", New With { .class = "text-danger" })
                </div>
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Period, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                @Html.EnumDropDownListFor(Function(model) model.Period, htmlAttributes:= New With { .class = "form-control" })
                @Html.ValidationMessageFor(Function(model) model.Period, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.RecycleWhenMaxIsReached, htmlAttributes:=New With {.class = "control-label col-md-4"})
            <div class="col-md-8">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.RecycleWhenMaxIsReached)
                    @Html.ValidationMessageFor(Function(model) model.RecycleWhenMaxIsReached, "", New With { .class = "text-danger" })
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-4 col-md-8">
                <input type="submit" value="Create" class="btn btn-default" />
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
