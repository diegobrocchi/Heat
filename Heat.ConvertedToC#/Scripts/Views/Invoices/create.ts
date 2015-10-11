/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/jqueryui/jqueryui.d.ts" />

function customerAutocomplete(id) {

    $('#' + id).autocomplete({
        minLength: 2,
        source: function (request, response) {
            $.ajax({
                url: '/customers/GetCustomersByName',
                type: 'GET',
                dataType: 'json',
                data: { searchText: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.name, value: item.value };
                    }));
                }
            });
        },
        change: function (event, ui) {
            if (!ui.item) {
                $(this).val('');
            }
        }



    });

};
 