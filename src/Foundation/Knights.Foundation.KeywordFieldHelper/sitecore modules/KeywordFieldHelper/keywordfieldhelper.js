function initKeywordHelperField(el) {

    var $element = jQuery(el),
        volumeLabel = 'volume',
        cpcLabel = 'cpc',
        competitionLabel = 'competition',
        options = {
            url: function (phrase) {
                phrase = phrase.replace(/[^a-zA-Z ]/g, "");
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
        },
        formatVolume = function (value) {
            return parseInt(value).toFixed(0).replace(/./g,
                function (c, i, a) {
                    return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "," + c : c;
                });
        },
        fixOverlapping = function ($el) {
            $el.closest('.scEditorSectionPanel').css('overflow', 'visible');
        },
        popularLabels = function() {
            jQuery.get('/keywords/getlabels').done(function (response) {
                volumeLabel = response.VolumeLabel;
                cpcLabel = response.CpcLabel;
                competitionLabel = response.CompetitionLabel;
            });
        },
        rankKeyword = function ($el) {
            if ($el.val()) {
                jQuery.get('/keywords/rank/' + $el.val()).done(function (response) {
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
                        jQuery(html).insertAfter($el);
                    }
                });
            }
        };

    fixOverlapping($element);
    rankKeyword($element);
    popularLabels();
    jQuery($element).easyAutocomplete(options);

}