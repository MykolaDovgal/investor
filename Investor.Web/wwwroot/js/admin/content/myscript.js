$(document).ready(function () {
    //var path = window.location.pathname + window.location.hash;
    //console.log(path);
    //$('.nav-item a').each(function () {
    //    if (this.attr('href') === path) {
    //        $(this).addClass('active-item');
    //    }
    //});
    
});

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
