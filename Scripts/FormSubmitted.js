var urlStr = "Default.aspx";
$(function () {

    if ($.urlParam('Camera') != null) {
        if ($.urlParam('Camera').toLowerCase() == "yes") {
            
            urlStr = "Default.aspx?Camera=yes";
           // setTimeout(function () {
           //     $('#redirectDiv').css('display', 'block');
           // }, 2000);
           // setTimeout(function () {
              //  location.href = urlStr;
           //}, 7000);
        }
    }
    if ($.urlParam('ID') != null) {
        var idStr = $.urlParam('ID');
        $('#IDnum').text(idStr);
        $('#CustomerID').css('display', 'block');
    }
});

$('#btnRefresh').click(function () {
    $('#redirectDiv').css('display', 'none');
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