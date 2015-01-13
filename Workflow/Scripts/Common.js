
$(document).ready(
    function () {

        $(".textdate").datepicker({ changeMonth: true, changeYear: true });
        $(function () { $("#accordion").accordion(); });
        $("input:text:first").focus();
        var $inp = $("input:text");
        $inp.bind("keydown", function (e) {
            var key = e.which;
            if (key == 13) {
                e.preventDefault();
                var nxtIdx = $inp.index(this) + 1;
                $("input:text:eq(" + nxtIdx + ")").focus();
            }
        })
        //$(".btnNormal").click(function () {
        //    $(".btnNormal").each(function () {
        //        $(this).attr("disabled", "true");
        //        $(this).val("Submiting");
        //    })
        //})
        $(".textbox").focus(function () { $(this).css("background-color", "#ABABAB") })
            .blur(function () { $(this).css("background-color", "white") })
        if (self == top) {
            alert("You can not enter url in web browser directly!");
            window.location.href = getRootPath() + "/Login.aspx"
            return false;
        }
    }
)
function getRootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    return (prePath + postPath);
}
function resizePOApprovalWindow() {
    var windowHeight = getPOWindowHeight();

    if (document.getElementById("div_po_detail") != null) {
        document.getElementById("div_po_detail").style.height = (windowHeight - 520) + "px";

    }
}
function showMessage() {
    $("#dialog-alert").dialog({
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
};

function getPOWindowHeight() {
    var windowHeight = 0;
    if (typeof (window.innerHeight) == 'number') {
        windowHeight = window.innerHeight;
    }
    else {
        if (document.documentElement && document.documentElement.clientHeight) {
            windowHeight = document.documentElement.clientHeight;
        }
        else {
            if (document.body && document.body.clientHeight) {
                windowHeight = document.body.clientHeight;
            }
        }
    }
    return windowHeight;
}


//function getPOBrowser() {
//    var agt = navigator.userAgent.toLowerCase();
//    var appVer = navigator.appVersion.toLowerCase();

//    //*** Browser Version ***
//    var is_minor = parseFloat(appVer);
//    var is_major = parseInt(is_minor);

//    // alert(agt.toString());
//    //alert(appVer.toString());

//    var iePos = appVer.indexOf("msie");
//    if (iePos != -1) {
//        is_minor = parseFloat(appVer.substring(iePos + 5, appVer.indexOf(";", iePos)));
//        is_major = parseInt(is_minor);

//    }
//    return is_major;
//}