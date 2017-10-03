window.onload = function () {
	$.ajax({
		url: "http://devel.farebookings.com/api/curconversor/EUR/UAH/1/",
		dataType: 'jsonp',
		success: function (data) {
			$('#EUR').text($('#EUR').text() + Math.round(data.UAH * 100) / 100);
		}

	}); 
	$.ajax({
		url: "http://devel.farebookings.com/api/curconversor/USD/UAH/1/",
		dataType: 'jsonp',
		success: function (data) {
			$('#USD').text($('#USD').text() + data.UAH);
		}

	});
}



	