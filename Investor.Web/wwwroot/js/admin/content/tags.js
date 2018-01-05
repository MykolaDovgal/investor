$(document).on("click", "a.tag-submit", function (e) {
	const tableId = `#${$(this).closest("table").prop("id")}`;
	const row = $(this).closest("tr").index();
	const tableDataObj = tables[tableId].row($(this).parents("tr")).data();
	$(`${$(this).attr("href")} input[name='TagId']`).val(tableDataObj.tagId);
	$(`${$(this).attr("href")} input[name='Url']`).val(tableDataObj.url);
	$(`${$(this).attr("href")} input[name='Name']`).val(tableDataObj.name);

});

//create + update
$(document).on("click", ".tag-update", function (e) {
	var url = $(this).data("href");
	let formData = new FormData(document.getElementById($(this).attr("form")));
	e.preventDefault();
	$.ajax({
		type: "POST",
		url: url,
		data: formData,
		cache: false,
		contentType: false,
		processData: false,

		success: function (data) {
			const tableId = "#" + $(".table").attr("id");
			$(tableId).dataTable().fnDestroy(); //TODO ВИПРАВИТИ!!!!!!!!
			initialTable(tableId);
			$.toaster({
				priority: 'success',
				title: 'Операція успішна',
				message: "\nТег збережено!",
				settings: {
					'timeout': 40000
				}
			});
		}
	});
});
