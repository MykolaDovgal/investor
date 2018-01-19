$("#logoff").click(function (e) {
    e.preventDefault();
    logOff();
});


let logOff = function () {
    $.ajax({
        url: "/admin/account/logoff",
        type: "POST",
        success: function (data) {
            window.location.href = data;
        }
    });
}
