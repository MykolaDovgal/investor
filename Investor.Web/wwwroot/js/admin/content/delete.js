let chosenPostsIds = [];

$(document).on('click',
	".delete",
	function (e) {
		if ($(this).hasClass('tags')){
			$('#question').html("Ви дійсно хочете видалити теги? Кільксть: " + chosenPostsIds.length);
		}
		else if ($(this).hasClass('news')) {
			$('#question').html("Ви дійсно хочете видалити новини? Кільксть: "  + chosenPostsIds.length);
		}
		else if ($(this).hasClass('blogs')) {
			$('#question').html("Ви дійсно хочете видалити блоги? Кільксть: "  + chosenPostsIds.length);
		}

	});

$(document).on('change',
	'tbody td:first-child',
	function (e) {
		const tableId = "#" + $(this).closest('table').prop("id");
		const tableDataObj = tables[tableId].row($(this).parents('tr')).data();
		let ObjId = 0;
		if (tableId == "#blogsTable" || tableId == "#newsTable") {
			ObjId = tableDataObj.postId;
		}
		else if (tableId == "#tagsTable") {
			ObjId = tableDataObj.tagId;
		}
		console.log(tableDataObj);
		const propertyValue = $(e.target).prop("checked");
		if (propertyValue) {
			console.log(ObjId);
			chosenPostsIds.push(ObjId);
		}
		else {
			delete chosenPostsIds[chosenPostsIds.indexOf(ObjId)];
		}
		console.log(chosenPostsIds);
		console.log(($('tbody td:first-child :checked').length));
		if (chosenPostsIds.length > 0) {
			$(".delete").removeAttr('disabled');
		}
		else {
			$(".delete").attr('disabled', 'true');
		}

	});

$(document).on("click", "a.nav-link", function (e) {
	const url = $(this).data("href");
	const type = $(e.target).data("type");
	if (type && type === "delete") {
		deleteObj.call(this, url, chosenPostsIds);
		chosenPostsIds = [];
		const tableId = $('.table').attr('id');
		console.log(tableId);
		$(tableId).dataTable().fnDestroy(); //TODO ВИПРАВИТИ!!!!!!!!
		initialTable(tableId);
	}
});

let deleteObj = function (url, data) {
	//console.log(postData);
	$.ajax({
		url: url,
		contentType: 'application/x-www-form-urlencoded; charset=utf-8',
		dataType: 'json',
		type: "POST",
		data: { id: data },
		success: function (data) {
			console.log(data);
		}
	});
}