$(document).ready(function () {

	var data = new Date();
	var weekday = new Array(7);
	weekday[0] = "Неділя";
	weekday[1] = "Понеділок";
	weekday[2] = "Вівторок";
	weekday[3] = "Середа";
	weekday[4] = "Четвер";
	weekday[5] = "П'ятниця";
	weekday[6] = "Субота";
	var day = weekday[data.getDay()];

	var currentDate = data.toLocaleDateString();

	$("#data").html('<span class="day">' + day + '</span><span class="current-date">' + currentDate + '</span>');

	$(".my-datepicker").html(day + ' ' + currentDate);
    
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
