@ModelType Heat.ViewModels.Customers.IndexCustomerViewModel 
@Code
    ViewData("Title") = "Gestione clienti"
End Code

    <h3>Heat - visualizza clienti</h3>
  
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

@*@Html.Partial("partials/_customerGrid", Model.Rows)*@

<table id="paged_table" class="table table-bordered table-hover table-striped">
    <thead>
        <tr>
            <th>Nome</th>
            <th>Indirizzo</th>
            <th>Città</th>
            <th>Telefono 1</th>
            <th>Telefono 2</th>
            <th></th>
        </tr>

    </thead>
    <tbody>

    </tbody>
</table>

@section scripts
     <script type="text/javascript"  src="~/Scripts/Views/Customers/index.js"></script>
End Section