@ModelType Heat.ViewModels.Customers.IndexCustomerViewModel 
@Code
    ViewData("Title") = "Gestione clienti"
End Code

    <h3>Elenco clienti attivi</h3>
@*
        <p>
            @Html.ActionLink("Crea un nuovo cliente", "Create", Nothing, New With {.class = "btn btn-success"})
            @code
                If Model.HasDisabled Then
                    If Model.IsIncludeDisable Then
            @Html.ActionLink("Nascondi i clienti disabilitati", "index", Nothing, New With {.class = "btn btn-danger"})
                    Else
            @Html.ActionLink("Visualizza anche i clienti disabilitati", "index", New With {.IncludeDisabled = True}, New With {.class = "btn btn-danger"})
                    End If
                End If
            End Code

    </p>
*@

@*@Html.Partial("partials/_customerGrid", Model.Rows)*@

<table id="tblPagedEnabledCustomers" class="table table-bordered table-hover table-striped">
    <thead>
        <tr>
            
            <th>Nome</th>
            <th>Indirizzo</th>
            <th>Città</th>
            <th>Telefono</th>
            <th><a href="@Url.Action("create")" class=" btn btn-success"><span class="glyphicon glyphicon-plus-sign" /></a> </th> 
        </tr>

    </thead>
    <tbody>

    </tbody>
</table>

<br />
<h3>Elenco clienti non attivi</h3>
<table id="tblPagedDisabledCustomers" class="table table-bordered table-hover table-striped">
    <thead>
        <tr>

            <th>Nome</th>
            <th>Indirizzo</th>
            <th>Città</th>
            <th>Telefono</th>
            <th><a href="@Url.Action("create")" class=" btn btn-success"><span class="glyphicon glyphicon-plus-sign" /></a> </th>
        </tr>

    </thead>
    <tbody></tbody>
</table>

@section scripts
     <script type="text/javascript"  src="~/Scripts/Views/Customers/index.js"></script>
End Section