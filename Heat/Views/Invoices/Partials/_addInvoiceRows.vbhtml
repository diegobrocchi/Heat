@modeltype ViewModels.AddNewInvoiceRowViewModel



 
@Using Html.BeginForm()
    @Html.AntiForgeryToken 
    
    @<div class="form-horizontal">
        <div class="form-group">
            @Html.LabelFor(Function(x) x.ProductID, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(x) x.ProductID, Model.ProductList, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(x) x.Quantity, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(x) x.Quantity, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(x) x.Quantity, "", New With {.class = "text-danger"})
            </div>
        </div>
         <div class="form-group">
             @Html.LabelFor(Function(x) x.UnitPrice, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(x) x.UnitPrice, New With {.htmlAttributes = New With {.class = "form-control"}})
             @Html.ValidationMessageFor(Function(x) x.UnitPrice, "", New With {.class = "text-danger"})
</div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(x) x.VAT, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(x) x.VAT, New With {.htmlAttributes = New With {.class = "form-control"}})
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(x) x.Discount1, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(x) x.Discount1, New With {.htmlAttributes = New With {.class = "form-control"}})
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(x) x.Discount2, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(x) x.Discount2, New With {.htmlAttributes = New With {.class = "form-control"}})
             </div>
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(x) x.Discount3, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(x) x.Discount3, New With {.htmlAttributes = New With {.class = "form-control"}})
             </div>
         </div>
    </div>
    @<div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Inserisci" class="btn btn-default" />
            </div>
        </div>
End Using

