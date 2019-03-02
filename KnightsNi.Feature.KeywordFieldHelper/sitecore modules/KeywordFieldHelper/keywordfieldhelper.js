
(function ($) {
    $(document).ready(function () {
        var options = {
            url: function (phrase) {
                if (phrase !== "") {
                    return "/Keywords/Get/" + phrase;
                } else {
                    //duckduckgo doesn't support empty strings
                    return "/Keywords/Get/";
                }
            },

            getValue: "Text",

            list: {
                match: {
                    enabled: true
                }
            },

            requestDelay: 300,

        };

        $("input.scContentControl").easyAutocomplete(options);
    });
})(jQuery);