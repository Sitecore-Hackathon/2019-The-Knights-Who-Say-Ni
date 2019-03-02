
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

            listLocation: "Keywords",

            list: {
                match: {
                    enabled: true
                },
                onLoadEvent: function(args) {
                    console.log('onLoadEvent', args);
                }
            },

            requestDelay: 300,

            template: {
                type: "custom",
                method: function (value, item) {
                    var html = '<table style="width:100%;">' +
                        '<tr>' +
                        '<td style="width:60%;">' + value + '</td>' +
                        '<td style="width:15%; color: #999;">volume: ' + parseInt(item.Volume).toFixed(0).replace(/./g, function (c, i, a) {
                            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
                        }) + '</td>' +
                        '<td style="width:10%; color: #999;">cpc: ' + item.CostPerClick + '</td>' +
                        '<td style="width:15%; color: #999;">competition: ' + item.Competition + '</td>' +
                        '</tr>' +
                        '</table>';
                    return html;
                }
            }

        };

        $("input.scContentControl").easyAutocomplete(options);
    });
})(jQuery);