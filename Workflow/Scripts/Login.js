$(document).ready(function () {
    $("input:password").blur(function () {
        $(this).css("background-color", "white");
    }).focus(function () {
        $(this).css("background-color", "#ABABAB");
    })
})