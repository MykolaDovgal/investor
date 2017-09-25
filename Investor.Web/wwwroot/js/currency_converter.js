window.onload = function () {
	$.ajax({
		url: "http://devel.farebookings.com/api/curconversor/EUR/UAH/1/",
		dataType: 'jsonp',
		success: function (data) {
			console.log(data.UAH);
			console.log($('#EUR').text());
			$('#EUR').text($('#EUR').text() + data.UAH);
		}

	}); 
	$.ajax({
		url: "http://devel.farebookings.com/api/curconversor/USD/UAH/1/",
		dataType: 'jsonp',
		success: function (data) {
			console.log(data.UAH);
			console.log($('#USD').text());
			$('#USD').text($('#USD').text() + data.UAH);
		}

	});
}



	