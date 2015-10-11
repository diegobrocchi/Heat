@ModelType Heat.ViewModels.Invoices.DeleteInvoiceViewModel 

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Elimina una fattura non ancora confermata</h2>

<h3>Sei sicuro di voler eliminare questa fattura?</h3>
<div>
    <h4>Fattura</h4>
    <hr />
    <dl class="dl-horizontal">
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
            @Html.DisplayNameFor(Function(model) model.CustomerName)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.CustomerName)
        </dd>

    </dl>

    @If Model.Rows.Count > 0 Then
        @<table class=" table table-bordered">
        <thead>
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(x) Model.Rows(0).Item)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(x) Model.Rows(0).Product)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(x) Model.Rows(0).Quantity)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(x) Model.Rows(0).UnitPrice)
                </th>
            </tr>
        </thead>
    @For Each Item In Model.Rows
            @<tr>
    <td>
        @Html.DisplayFor(Function(x) Item.Item)
    </td>
    <td>
        @Html.DisplayFor(Function(x) Item.Product)
    </td>
    <td>
        @Html.DisplayFor(Function(x) Item.Quantity)
    </td>
    <td>
        @Html.DisplayFor(Function(x) Item.UnitPrice)
    </td>
    </tr>
        Next
    </table>
    End If

    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            @Html.ActionLink("Torna all'elenco", "Index", Nothing, New With {.class = "btn btn-default"})
            <input type="submit" value="Elimina" class="btn btn-danger" />  
        </div>
    End Using
</div>
