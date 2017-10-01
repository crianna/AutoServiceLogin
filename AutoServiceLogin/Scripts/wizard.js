jQuery(function ($) {
    var modelDD = $('#model');

    var producatorID = -1;
    var motorizareID = -1;
    var anulID = -1;
    var modelID = -1;


    $('#producator').autocomplete({
        source: function (req, res) {
            $.ajax(
                 wizzard.prodURL,
                 {
                     type: "GET",
                     dataType: "json",
                     data: {
                         q: req.term
                     },
                     success: function (data) {
                         var source = $.map(data, function (item) {
                             return {
                                 label: item.Value,
                                 value: item.Value,
                                 id: item.Key
                             }
                         });

                         res(source);
                     }
                 });
        },

        change: function (event, ui) {
            var prodId = ui.item ? ui.item.id : -1;
            producatorID = prodId;
            modelID = -1;

            $('#producator').parent().removeClass('has-error');
        }
    });

    $('#motorizare').autocomplete({
        source: function (req, res) {
            $.ajax(
                 wizzard.motorURL,
                 {
                     type: "GET",
                     dataType: "json",
                     data: {
                         prodId: producatorID,
                         q: req.term
                     },
                     success: function (data) {
                         var source = $.map(data, function (item) {
                             return {
                                 label: item.Value,
                                 value: item.Value,
                                 id: item.Key
                             }
                         });

                         res(source);
                     }
                 });
        },

        change: function (event, ui) {
            var motId = ui.item ? ui.item.id : -1;
            motorizareID = motId;
         

            $('#motorizare').parent().removeClass('has-error');
        }
    });

    $('#anul').autocomplete({
        source: function (req, res) {
            $.ajax(
                 wizzard.anulURL,
                 {
                     type: "GET",
                     dataType: "json",
                     data: {
                         prodId: producatorID,
                         q: req.term
                     },
                     success: function (data) {
                         var source = $.map(data, function (item) {
                             return {
                                 label: item.Value,
                                 value: item.Value,
                                 id: item.Value
                             }
                         });

                         res(source);
                     }
                 });
        },

        change: function (event, ui) {
            var anId = ui.item ? ui.item.id : -1;
           anulID = anId;


            $('#an').parent().removeClass('has-error');
        }
    });


    $('#model').autocomplete({
        source: function (req, res) {
            $.ajax(
                 wizzard.modelURL,
                 {
                     type: "GET",
                     dataType: "json",
                     data: {
                         prodId: producatorID,
                         q: req.term
                     },
                     success: function (data) {
                         var source = $.map(data, function (item) {
                             return {
                                 label: item.Value,
                                 value: item.Value,
                                 id: item.Key
                             }
                         });

                         res(source);
                     }
                 });
        },

        change: function (event, ui) {
            var id = ui.item ? ui.item.id : -1;
            modelID = id;
            $('#producator').parent().removeClass('has-error');
        }
    });

    $('#next').click(function () {
        if (producatorID == -1) {
            $('#producator').parent().addClass('has-error');
            return;
        }

        if (modelID == -1) {
            $('#model').parent().addClass('has-error');
            return;
        }
        if (motorizareID == -1) {
            $('#motorizare').parent().addClass('has-error');
            return;
        }
        if (anulID == -1) {
            $('#an').parent().addClass('has-error');
            return;
        }
        window.location = wizzard.viewMartori + '?p=' + producatorID + '&m=' + modelID + '&mot=' + motorizareID + '&an=' + anulID;
    });

    $('#finish').click(function () {
        window.location = wizzard.mapURL;
    });


});