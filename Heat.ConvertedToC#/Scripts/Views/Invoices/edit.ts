/// <reference path="../../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/jquery-validation-unobtrusive/jquery-validation-unobtrusive.d.ts" />
/// <reference path="../../typings/globalize/globalize.d.ts" />

function showAddRowPanel() {
    $('#addRowModal').modal({ 'show': true });
};


//Questa funzione è necessaria per la validazione di un form dentro una partial view caricata via Ajax.
//Deve essere eseguita sul'evento onSuccess della chiamata Ajax.
function reparseForm() {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
};


