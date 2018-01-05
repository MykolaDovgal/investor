let tablesUpdetedData = {};
//let chosenPostsIds = [];

$(document).on("click", "a.nav-link", function (e) {

	const url = $(this).data("href");
	const type = $(this).data("type");

	if (type && type === "update") {
		let tempArray = [];
		const keys = Object.keys(tablesUpdetedData);

		for (let i = 0; i < keys.length; i += 1) {
			tempArray.push(tablesUpdetedData[keys[i]]);
		}
		updetePosts.call(this, url, tempArray);
		tablesUpdetedData = {};
	}
});

let updetePosts = function (url, postData) {
	var $this = this;
	$.ajax({
		url: url,
		contentType: 'application/x-www-form-urlencoded; charset=utf-8',
		dataType: 'json',
		type: "POST",
		data: { content: postData },
		success: function (data) {
			$.toaster({
				priority: 'success',
				title: 'Операція успішна',
				message: `Зміни збережено!`,
				settings: {
					'timeout': 4000
				}
			});
			$($this).addClass('disabled');
			$('input[type="checkbox"]').toArray().forEach(function (item) {
				item.classList.remove('modified');
			});
		}
	});
}

