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
        <p><a class="btn btn-default" href=@Url.Action("index", "customers")>Clienti</a></p>
    </div>
    <div class="col-md-4">
        <h2>Documenti</h2>
        <p>Accedi all'area di gestione dei documenti aziendali</p>
        <p><a class="btn btn-default" href=@Url.Action("index", "Documents")>Documenti</a></p>
    </div>
    <div class="col-md-4">
        <h2>Attività</h2>
        <p>Accedi all'area di gesione delle attività aziendali</p>
        <p><a class="btn btn-default" href=@Url.Action("index", "Operations")>Attività</a></p>
    </div>
</div>
<div class="row">
    <h1>Claims</h1>
    <div>
        @For Each claim In DirectCast(User, ClaimsPrincipal).Claims
            @<div>@claim.Type: @claim.Value </div>
        Next
    </div>
</div>

  
