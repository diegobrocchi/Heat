@ModelType Heat.ViewModels.invoices.InvoiceDetailsViewModel 

<div>
    <h4>Dettagli della fattura @Model.ID del @Model.InvoiceDate </h4>
    <hr />

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(x) x.ID)
        @Html.HiddenFor(Function(x) x.InvoiceDate)
        @Html.HiddenFor(Function(x) x.InvoiceNumber)
        @Html.HiddenFor(Function(x) x.IsTaxExempt)
        @Html.HiddenFor(Function(x) x.Payment)
        @Html.HiddenFor(Function(x) x.TaxExemption)

        @<dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.CustomerName)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.CustomerName)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.InvoiceNumber)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.InvoiceNumber)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.InvoiceDate)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.InvoiceDate)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Payment)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Payment)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.IsTaxExempt)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.IsTaxExempt)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.TaxExemption)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.TaxExemption)
            </dd>

        </dl>

        @<div>
            @Html.Partial("Partials/_invoiceRowsIndex", Model.Rows)
        </div>
        @<div class="form-group">
            <div>
                @Html.ActionLink("Torna all'elenco", "index", "invoices", Nothing, New With {.class = "btn btn-primary"})
            </div>
        </div>
    End Using

</div>

