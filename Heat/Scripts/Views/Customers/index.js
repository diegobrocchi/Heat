
$(document).ready(function () {
    $('#paged_table').dataTable({
        language: {url: 'Scripts/DataTableLocalization/it-IT.json'},
        serverSide: true,
        processing: true,
        ajax: {
            url: "Customers/PageCustomerData",
            type: "GET"},
        columns: [
            { data: "name" },
            { data: "address" },
            { data: "city" },
            { data: "telephone1" },
            { data: "id" }],
        columnDefs: [{
            "targets": 4,
            "orderable": false,
            "render": function (data, type, full, meta) {
                return '<a class="btn btn-primary" href="Customers/Manage/' + data + '"><span class="glyphicon glyphicon-option-horizontal" /></a>';
            }
        }] 
    

    });
})



 