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

  @*http://www.html.it/guide/img/bootstrap/ref/modal.html*@  
<div>
    <a href="#" data-toggle="modal" data-target="#divModalID" onclick="t()">Apri il box!</a>
</div>
<div id="divModalID" class="modal">
    <div class="modal-dialog  modal-lg">
        <div class="modal-content">

            <div class="modal-header">
                <button class="close" type="button" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">
                    Titolo
                </h4>
            </div>
            <div class="modal-body">
                <p>
                    Corpo della finestra
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Chiudi</button>
                <button type="button" class="btn btn-primary">Invia</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" >
    function t() {
        $('#divModalID').load('/customers/index');
    };
</script>