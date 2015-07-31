@ModelType Heat.Models.Customer
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Customer</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PostalCode)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PostalCode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telephone1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telephone1)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telephone2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telephone2)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telephone3)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telephone3)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Taxcode)
        </dt>
        <dd>
            @Html.DisplayFor(Function(model) model.Taxcode)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.VAT_Number)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.VAT_Number)
        </dd>
        
        <dt>
            @Html.DisplayNameFor(Function(model) model.EMail)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EMail)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Website)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Website)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Modifica", "Edit", New With {.id = Model.ID}) |
    @Html.ActionLink("Torna alla lista", "Index")
    @Html.ActionLink("Aggiungi un indirizzo al cliente", "Create", "Addresses", New With {.customerID = Model.ID}, New With {.class = "btn btn-default"})
</p>
