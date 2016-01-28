@ModelType Heat.viewModels.invoices.addnewDescriptiveInvoiceRowviewmodel
@Code
    ViewData("Title") = "Aggiungi una nuova riga descrittiva alla fattura"
    Dim languageCodeCLDR As String = Culture.Substring(0, 2)

End Code

<h2>Immissione di una nuova riga descrittiva per la fattura</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Riga descrittiva</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        
         <div class="form-group">
             @Html.LabelFor(Function(model) model.RowDescription, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.RowDescription, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.RowDescription, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Quantity, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Quantity, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Quantity, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.UnitPrice, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.UnitPrice, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.UnitPrice, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.VAT, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.VAT, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.VAT, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Discount1, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Discount1, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Discount1, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Discount2, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Discount2, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Discount2, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Discount3, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Discount3, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Discount3, "", New With {.class = "text-danger"})
            </div>
        </div>

        

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Inserisci" class="btn btn-default" />
                @Html.ActionLink("Annulla le modifiche e torna", "edit", "invoices", New With {.id = Model.InvoiceID}, New With {.class = "btn btn-primary"})
                
            </div>
        </div>
    </div>
End Using

@section scripts

    <script src="~/Scripts/cldr.js"></script>
    <script src="~/Scripts/cldr/event.js"></script>
    <script src="~/Scripts/cldr/supplemental.js"></script>
    <script src="~/Scripts/globalize.js"></script>
    <script src="~/Scripts/globalize/message.js"></script>
    <script src="~/Scripts/globalize/number.js"></script>
    <script src="~/Scripts/globalize/plural.js"></script>
    <script src="~/Scripts/globalize/date.js"></script>
    <script src="~/Scripts/globalize/currency.js"></script>
    <script src="~/Scripts/globalize/relative-time.js"></script>
    <script src="~/Scripts/jquery.validate.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
    <script src="~/Scripts/jquery.validate.globalize.fix.js"></script>
    <script src="~/Scripts/Heat.Globalize.js"></script>


    <script>

    $(document).ready(function () {
        loadGlobalize('@languageCodeCLDR');
    });


    </script>
End Section
