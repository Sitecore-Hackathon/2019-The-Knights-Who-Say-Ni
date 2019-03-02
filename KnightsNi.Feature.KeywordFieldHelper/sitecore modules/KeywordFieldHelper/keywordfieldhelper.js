
(function ($) {
    $(document).ready(function () {
            var options = {
                url: "/example.json",

                getValue: "name",

                list: {
                    match: {
                        enabled: true
                    }
                }
            };

            $("input.scContentControl").easyAutocomplete(options);
    });
})(jQuery);