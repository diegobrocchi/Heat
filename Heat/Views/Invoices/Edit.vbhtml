@ModelType Heat.ViewModels.EditInvoiceViewModel
@Code
    ViewData("Title") = "Modifica"
End Code

<h2>Immissione fattura</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Invoice</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.ID)

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
         
    </div>
End Using

 
@Ajax.ActionLink("Aggiungi una riga Async", "addNewRow", New With {.invoiceID = Model.ID}, New AjaxOptions With {
                      .HttpMethod = "GET",
                      .InsertionMode = InsertionMode.Replace,
                      .OnBegin = "showAddRowPanel",
                      .OnSuccess = "reparseForm",
                      .UpdateTargetId = "id_addNewRowPanel"}, New With {.class = "btn btn-default"})

@Html.ActionLink("Aggiungi una riga", "create", "invoiceRows", New With {.invoiceId = Model.ID}, New With {.class = "btn btn-primary"})

<div id="invoiceRows">
    @Html.Partial("partials/_invoiceRows", Model.rows)
</div>

<div class="modal" id="addRowModal" tabindex="-1" role="dialog" aria-labelledby="modalTitle">
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
</div>


@section scripts

    @*<script src="~/scripts/jquery.unobtrusive-ajax.min.js"> </script>*@
    <script src="~/Scripts/cldr.js"></script>
    <script src="~/Scripts/cldr/event.js"></script>
    <script src="~/Scripts/cldr/supplemental.js"></script>
    <script src="~/Scripts/globalize.js"></script>
    <script src="~/scripts/jquery.validate.globalize.js"></script>
    <script src="~/Scripts/Heat.js"></script>
    <script src="~/Scripts/Views/Invoices/edit.js"></script>
 
End Section

