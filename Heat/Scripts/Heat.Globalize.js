


function loadGlobalize(locale) {

    $.when(
            $.get("../scripts/cldr/supplemental/likelySubtags.json"),
            $.get("../scripts/cldr/main/" + locale + "/currencies.json"),
            $.get("../scripts/cldr/supplemental/currencyData.json"),
            $.get("../scripts/cldr/main/" + locale + "/numbers.json"),
            $.get("../scripts/cldr/supplemental/numberingSystems.json")

        ).then(function () {

            // Normalize $.get results, we only need the JSON, not the request statuses.
            return [].slice.apply(arguments, [0]).map(function (result) {
                return result[0];
            });

        }).then(Globalize.load).then(function () {

            Globalize.locale(locale);

        });
};
