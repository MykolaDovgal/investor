let chosenPostsIds = [];

$(document).on('click',
	".delete",
	function (e) {
		$('#question').html("Ви дійсно хочете видалити " + $('tbody td:first-child :checked').length + " постів?");
	});

$(document).on('change',
	'tbody td:first-child',
	function (e) {
		console.log(($('tbody td:first-child :checked').length));
		if ($('tbody td:first-child :checked').length > 0) {
			$(".delete").removeAttr('disabled');
		}
		else {
			$(".delete").attr('disabled', 'true');
		}
		const tableId = "#" + $(this).closest('table').prop("id");
		const tableDataObj = tables[tableId].row($(this).parents('tr')).data();
		const propertyValue = $(e.target).prop("checked");
		if (propertyValue) {
			console.log(tableDataObj.postId);
			chosenPostsIds.push(tableDataObj.postId);
		}
		else {
			delete chosenPostsIds[chosenPostsIds.indexOf(tableDataObj.postId)];
		}
		console.log(chosenPostsIds);

	});

$(document).on("click", "a.nav-link", function (e) {
	const url = $(this).data("href");
	const type = $(e.target).data("type");
	if (type && type === "delete") {
		//updetePosts.call(this, url, chosenPostsIds);
		chosenPostsIds = [];
		const tableId = $(this).parents('div').eq(1);
		console.log(tableId);
		$(tableId).dataTable().fnDestroy(); //TODO ВИПРАВИТИ!!!!!!!!
		initialTable(tableId);
	}
});