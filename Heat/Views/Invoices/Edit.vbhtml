@ModelType Heat.ViewModels.Invoices.EditInvoiceViewModel
@Code
    ViewData("Title") = "Modifica"
End Code

<h2>Immissione fattura</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

@<div class="form-horizontal">
    <h4>Fattura</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.ID)

    <div>
        <p class="form-control-static">Documento @Model.InvoiceNumber del @Model.InvoiceDate emesso a @Model.CustomerName </p>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.CustomerName, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <p class="form-control-static">@Model.CustomerName</p>
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.InvoiceDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <p class="form-control-static">@Model.InvoiceDate</p>
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.InvoiceNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            <p class="form-control-static">@Model.InvoiceNumber</p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-10">
            @Html.ActionLink("Aggiungi una riga", "create", "invoiceRows", New With {.invoiceId = Model.ID}, New With {.class = "btn btn-primary btn-sm"})

        </div>
    </div>
    
    
    <div id="invoiceRows">
        @Html.Partial("partials/_invoiceRows", Model.Rows)
    </div>

    @Html.ActionLink("Vai alle condizioni di pagamento", "EditPayment", "invoices", New With {.id = Model.ID}, New With {.class = "btn btn-default"})
    
</div>

End Using

 
@*@Ajax.ActionLink("Aggiungi una riga Async", "addNewRow", New With {.invoiceID = Model.ID}, New AjaxOptions With {
                      .HttpMethod = "GET",
                      .InsertionMode = InsertionMode.Replace,
                      .OnBegin = "showAddRowPanel",
                      .OnSuccess = "reparseForm",
                      .UpdateTargetId = "id_addNewRowPanel"}, New With {.class = "btn btn-default"})*@

 




@*<div class="modal" id="addRowModal" tabindex="-1" role="dialog" aria-labelledby="modalTitle">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="modalTitle">Aggiungi una riga alla fattura</h4>
            </div>
            <div class="modal-body">
                <div id="id_addNewRowPanel">

                </div>
            </div>
            <div class="modal-footer">
                 
            </div>
        </div>
    </div>
</div>*@


@*@section scripts
        <script src="~/Scripts/Views/Invoices/edit.js"></script>
 End Section*@

