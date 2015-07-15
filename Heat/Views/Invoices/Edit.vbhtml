@ModelType Heat.Models.Invoice
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Invoice</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.ID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.InsertedNumber.SerialString, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InsertedNumber.SerialString, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InsertedNumber.SerialString, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.InvoiceDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.InvoiceDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.InvoiceDate, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Ajax.ActionLink("Aggiungi una riga", "addNewRow", New With {.invoiceID = Model.ID}, New AjaxOptions With {
                      .HttpMethod = "GET",
                      .InsertionMode = InsertionMode.Replace,
                      .OnBegin = "showAddNewRowPanel",
                      .OnComplete = "onCompleteAddNewRowPanel",
                      .OnFailure = "onErrorAddNewRowPanel",
                      .UpdateTargetId = "id_addNewRowPanel"}, New With {.class = "btn btn-default"})

<div id="id_addNewRowPanel">

</div>