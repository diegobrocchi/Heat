@ModelType Heat.ViewModels.Invoices.InvoicePaymentViewModel

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Dati di pagamento</h4>
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
         
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PaymentID, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.PaymentID, Model.PaymentList, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.PaymentID, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.IsTaxExempt, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.IsTaxExempt)
                    @Html.ValidationMessageFor(Function(model) model.IsTaxExempt, "", New With { .class = "text-danger" })
                </div>
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.TaxExemption, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.TaxExemption, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.TaxExemption, "", New With { .class = "text-danger" })
            </div>
        </div>

         <div id="invoiceRows">
             @Html.Partial("partials/_invoiceRows", Model.Rows)
         </div>

        <div class="form-group">
            <div>
                @Html.ActionLink("Torna all'inserimento righe", "edit", "invoices", New With {.id = Model.ID}, New With {.class = "btn btn-primary"})
                <input type="submit" value="Conferma il documento" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

 

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
