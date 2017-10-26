$(document).ready(function() {
    $("#logoff").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/account/logoff",
            type: "POST"
        });
    });
})