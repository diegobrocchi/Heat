//$(document).ready(function () {
//    $('#index_table').DataTable({
//        language: {
//            url: 'Scripts/DataTableLocalization/it-IT.json'
//        },
//        serverSide: true,
//        ajax: "/Customers/PageCustomerData",
//        responsive: true,
//        processing: true,
//        columns: [{ data: "Name" },
//            { data: "Address" },
//            { data: "City" },
//            { data: "Telephone1" },
//            { data: "Telephone2" },
//            {data: null}]
//    });
//});

$(document).ready(function () {
    $('#paged_table').dataTable({
        language: {url: 'Scripts/DataTableLocalization/it-IT.json'},
        serverSide: true,
        ajax: "Customers/PageCustomerData",
        columns: [{ data: "name" },
            { data: "address" },
            { data: "city" },
            { data: "telephone1" },
            { data: "telephone2" },
            {data: null}]

    });
})



 