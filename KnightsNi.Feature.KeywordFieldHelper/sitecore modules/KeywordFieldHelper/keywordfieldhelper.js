
//(function ($) {
//    $(document).ready(function () {

//        var volumeLabel = 'volume',
//            cpcLabel = 'cpc',
//            competitionLabel = 'competition',
//            formatVolume = function(value) {
//                return parseInt(value).toFixed(0).replace(/./g,
//                    function(c, i, a) {
//                        return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
//                    });
//            };

//        $.get('/keywords/getlabels').done(function (response) {
//            volumeLabel = response.VolumeLabel;
//            cpcLabel = response.CpcLabel;
//            competitionLabel = response.CompetitionLabel;
//        });

//        var options = {
//            url: function (phrase) {
//                if (phrase !== "") {
//                    return "/keywords/get/" + phrase;
//                }
//                return null;
//            },
//            getValue: "Text",
//            listLocation: "Keywords",
//            list: {
//                match: {
//                    enabled: true
//                },
//                onLoadEvent: function (args) {
//                    console.log('onLoadEvent', args);
//                }
//            },
//            requestDelay: 300,
//            template: {
//                type: "custom",
//                method: function (value, item) {
//                    var html = '<table style="width:100%;">' +
//                        '<tr>' +
//                        '<td style="width:60%;">' + value + '</td>' +
//                        '<td style="width:15%; color: #999;">' + volumeLabel + ': ' + formatVolume(item.Volume) + '</td>' +
//                        '<td style="width:10%; color: #999;">' + cpcLabel + ': ' + item.CostPerClick + '</td>' +
//                        '<td style="width:15%; color: #999;">' + competitionLabel + ': ' + item.Competition + '</td>' +
//                        '</tr>' +
//                        '</table>';
//                    return html;
//                }
//            }
//        };

//        var rankKeyword = function ($element) {
//            if ($element.val()) {
//                $.get('/keywords/rank/' + $element.val()).done(function (response) {
//                    var item = response.item[0];
//                    if (item) {
//                        var html = '<p>' +
//                            response.VolumeLabel +
//                            ': ' +
//                            formatVolume(item.Volume) +
//                            '&nbsp;&nbsp;&nbsp;' +
//                            response.CpcLabel +
//                            ': ' +
//                            item.CostPerClick +
//                            '&nbsp;&nbsp;&nbsp;' +
//                            response.CompetitionLabel +
//                            ': ' +
//                            item.Competition +
//                            '</p>';

//                        $(html).insertAfter($element);
//                    }
                   
//                });
//            }
           
//        };

//        $('.keyword-helper-field').each(function () {
//            $(this).easyAutocomplete(options);
//            rankKeyword($(this));
//        });
        
//    });
//})(jQuery);


function initKeywordHelperField(el) {

    var $element = jQuery(el);

    var volumeLabel = 'volume',
        cpcLabel = 'cpc',
        competitionLabel = 'competition',
        formatVolume = function (value) {
            return parseInt(value).toFixed(0).replace(/./g,
                function (c, i, a) {
                    return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
                });
        };

    jQuery.get('/keywords/getlabels').done(function (response) {
        volumeLabel = response.VolumeLabel;
        cpcLabel = response.CpcLabel;
        competitionLabel = response.CompetitionLabel;
    });

    var options = {
        url: function (phrase) {
            if (phrase !== "") {
                return "/keywords/get/" + phrase;
            }
            return null;
        },
        getValue: "Text",
        listLocation: "Keywords",
        list: {
            match: {
                enabled: true
            },
            onShowListEvent: function () {
                console.log('onLoadEvent', args);
            }
        },
        adjustWidth: false,
        requestDelay: 300,
        template: {
            type: "custom",
            method: function (value, item) {
                var html = '<table style="width:100%;">' +
                    '<tr>' +
                    '<td style="width:60%;">' + value + '</td>' +
                    '<td style="width:15%; color: #999;">' + volumeLabel + ': ' + formatVolume(item.Volume) + '</td>' +
                    '<td style="width:10%; color: #999;">' + cpcLabel + ': ' + item.CostPerClick + '</td>' +
                    '<td style="width:15%; color: #999;">' + competitionLabel + ': ' + item.Competition + '</td>' +
                    '</tr>' +
                    '</table>';
                return html;
            }
        }
    };

    var rankKeyword = function ($element) {
        if ($element.val()) {
            jQuery.get('/keywords/rank/' + $element.val()).done(function (response) {
                var item = response.Keywords[0];
                if (item) {
                    var html = '<p style="color:#999; float:left;">&nbsp;&nbsp;' +
                        response.VolumeLabel +
                        ': ' +
                        formatVolume(item.Volume) +
                        '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' +
                        response.CpcLabel +
                        ': ' +
                        item.CostPerClick +
                        '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' +
                        response.CompetitionLabel +
                        ': ' +
                        item.Competition +
                        '</p>';

                    jQuery(html).insertAfter($element);
                }

            });
        }

    };

    jQuery($element).easyAutocomplete(options);
    rankKeyword($element);


    //$('.keyword-helper-field').each(function () {
    //    $(this).easyAutocomplete(options);
    //    rankKeyword($(this));
    //});

//});

}

