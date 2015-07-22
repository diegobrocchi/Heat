/// <reference path="../../typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/jquery-validation-unobtrusive/jquery-validation-unobtrusive.d.ts" />

function showAddRowPanel() {
    $('#addRowModal').modal({ 'show': true });
};
 
//function reparseForm() {
//    $("form").removeData("validator");
//    $("form").removeData("unobtrusiveValidation");
//    $.validator.unobtrusive.parse("form");
//};
