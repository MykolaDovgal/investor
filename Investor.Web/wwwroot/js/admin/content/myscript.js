$(document).ready(function(){
    
    $('.nav-item a').click(function () {
        $(".nav-item a").each(function (index) {
            $(".nav-item a")[index].removeAttribute('active-item');
            });
            if ($(this).is(".nav-item a")) {
                $(this).addClass('active-item');
            }
            else {
                $(this).closest('.nav-item a').addClass('active-item');
            }
	});

	$("#logoff").click(function (e) {
		e.preventDefault();
		logOff();
	});
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
