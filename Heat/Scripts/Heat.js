$(document).ready(function () {
    $.when(
        $.get("../scripts/cldr/supplemental/likelySubtags.json"),
        $.get("../scripts/cldr/main/it/currencies.json"),
        $.get("../scripts/cldr/supplemental/currencyData.json"),
        $.get("../scripts/cldr/main/it/numbers.json"),
        $.get("../scripts/cldr/supplemental/numberingSystems.json")

    ).then(function () {

        // Normalize $.get results, we only need the JSON, not the request statuses.
        return [].slice.apply(arguments, [0]).map(function (result) {
            return result[0];
        });

    }).then(Globalize.load).then(function () {

        Globalize.locale("it");
        
    });

});


$.validator.methods.number = function (value, element) {
    return this.optional(element) || !isNaN(Globalize.parseNumber(value));
}

$.validator.methods.date = function (value, element) {
    if (this.optional(element))
        return true;
    var result = Globalize.parseNumber(value);
    return !isNaN(result) && (result != null);
}

$.validator.methods.min = function (value, element, param) {
    return this.optional(element) || Globalize.parseNumber(value) >= param;
}

$.validator.methods.max = function (value, element, param) {
    return this.optional(element) || Globalize.parseNumber(value) <= param;
}

$.validator.methods.range = function (value, element, param) {
    if (this.optional(element))
        return true;
    var result = Globalize.parseNumber(value);
    return (result >= param[0] && result <= param[1]);
}
