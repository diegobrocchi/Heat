$(document).ready(function () {
    $('#tblPagedPlants').DataTable({
        language: {
            url: 'Scripts/DataTableLocalization/it-IT.json',
            serverSide: true,
            processing: true,
            ajax: {
                url: "Plants/PagedPlants",
                type: "GET"
            },
            columns: [
                { data: "plantdistinctcode" },
                { data: "name" },
                { data: "plantclass" },
                { data: "planttype" },
                {data: "id"}],
            columnDefs: [{
                "targets": 4,
                "orderable": false,
                "render": function (data, type, full, meta) {
                    return '<a class="btn btn-primary btn-sm" href="Plants/Manage/' + data + '"><span class="glyphicon glyphicon-option-horizontal" /></a>';
                }
            }]

        }
    });
});