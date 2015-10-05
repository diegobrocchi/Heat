$(document).ready(function () {
    $('#tblPagedProducts').DataTable({
        language: { url: 'Scripts/DataTableLocalization/it-IT.json' },
        serverSide: true,
        processing: true,
        ajax: {
            url: "Products/GetPagedProducts",
            type: "GET",
            error: function (result) {
                alert(result.responseText)
            }
        },
        columns: [
            { data: "sku" },
            { data: "description" },
            { data: "unitPrice" },
            { data: "id" }],
        columnDefs: [{
            "targets": 3,
            "orderable": false,
            "render": function (data, type, full, meta) {
                return '<a class="btn btn-primary btn-sm" href="Products/Manage/' + data + '"><span class="glyphicon glyphicon-option-horizontal" /></a>';
            }
        }]
    })
});