$(document).ready(function () {
    $('#tblPagedPlants').DataTable({
        language: { url: 'Scripts/DataTableLocalization/it-IT.json' },
        serverSide: true,
        processing: true,
        ajax: {
            url: "Plants/PagedPlants",
            type: "GET",
            error: function(result){
                alert(result.responseText)} 
        },
        columns: [
            { data: "plantDistinctCode" },
            { data: "Name" },
            //{ data: "plantclass" },
            //{ data: "planttype" },
            { data: "id" }],
        columnDefs: [{
            "targets": 2,
            "orderable": false,
            "render": function (data, type, full, meta) {
                return '<a class="btn btn-primary btn-sm" href="Plants/Manage/' + data + '"><span class="glyphicon glyphicon-option-horizontal" /></a>';
            }
        }]
    }) 
});
