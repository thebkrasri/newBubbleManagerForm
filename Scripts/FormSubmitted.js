$(function () {
    var urlSr;
    if ($.urlParam('Camera') != null) {
        if ($.urlParam('Camera').toLowerCase() == "yes") {
            urlStr = "Default.aspx?Camera=yes";
        }
    }
    else {
        urlStr = "Default.aspx";
    }
    setTimeout(function () {
        location.href = urlStr;
    }, 3000);
});

$.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (results == null) {
            return null;
        }
        else {
            return decodeURI(results[1]) || 0;
        }
    }