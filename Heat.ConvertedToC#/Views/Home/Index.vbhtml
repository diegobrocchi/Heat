@imports System.Security.Claims
@Code
    ViewData("Title") = "Home Page"

End Code

<div class="jumbotron">
    <h1>Heat</h1>
    <p class="lead">Sistema di gestione aziendale</p>

</div>

<div class="row">
    <div class="col-md-4">
        <h2>Clienti</h2>
        <p>
            Accedi all'area di gestione dei clienti.
        </p>
        <p><a class="btn btn-primary" href=@Url.Action("index", "customers")>Clienti</a></p>
    </div>
    <div class="col-md-4">
        <h2>Fatture</h2>
        <p>Visualizza le fatture</p>
        <p><a class="btn btn-primary" href=@Url.Action("index", "Invoices")>Fatture</a></p>
    </div>
    <div class="col-md-4">
        <h2>Interventi</h2>
        <p>Accedi all'area di gesione delle attività aziendali</p>
        <p><a class="btn btn-primary" href=@Url.Action("index", "WorkActions")>Interventi</a></p>
    </div>
</div>

@*<div class="row">
    <div class="col-md-12 ">
        <h1>Claims</h1>
        <div>
            @For Each claim In DirectCast(User, ClaimsPrincipal).Claims
                @<div>@claim.Type: @claim.Value </div>
            Next
        </div>
    </div>
    
</div>*@

  
