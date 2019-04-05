var urlStr = "Default.aspx";
$(function () {
    if ($.urlParam('Camera') != null) {
        if ($.urlParam('Camera').toLowerCase() == "yes") {
            urlStr = "Default.aspx?Camera=yes";
            setTimeout(function () {
                location.href = urlStr;
            }, 10000);
        }
    }
});

$('#btnRefresh').click(function () {
    location.href = urlStr;
})


$.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (results == null) {
            return null;
        }
        else {
            return decodeURI(results[1]) || 0;
        }
    }