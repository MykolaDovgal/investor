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
		else if ($(this).hasClass('single-news') || $(this).hasClass('single-blog')) {
			var postId = $("input[name='PostId']").val();

			var url = $(this).data('href');
			chosenPostsIds.push(postId);
			deleteSinglePost.call(this, url, chosenPostsIds);
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
		const propertyValue = $(e.target).prop("checked");
		if (propertyValue) {
			chosenPostsIds.push(ObjId);
		}
		else {
			delete chosenPostsIds.splice([chosenPostsIds.indexOf(ObjId)], 1);
		}

		if (chosenPostsIds.length > 0) {
			$(".delete").removeClass('disabled');
		}
		else {
			$(".delete").addClass('disabled');
		}

	});

$(document).on("click", "a.nav-link", function (e) {
	const url = $(this).data("href");
	const type = $(e.target).data("type");
	if (type && type === "delete") {
		deleteObj.call(this, url, chosenPostsIds);
	}
});

let deleteObj = function (url, data) {
	$.ajax({
		url: url,
		contentType: 'application/x-www-form-urlencoded; charset=utf-8',
		dataType: 'json',
		type: "POST",
		data: { id: data },
		success: function (data) {
			const tableId = "#" + $('.table').attr('id');
			$(tableId).dataTable().fnDestroy(); //TODO ВИПРАВИТИ!!!!!!!!
			var a = '';
			if ($("a.nav-link").hasClass('tags')) {
				initialTable(tableId);
				a = 'Теги';
			}
			else if ($("a.nav-link").hasClass('news')) {
				initialTable(tableId);
				a = 'Статті';
			}
			else if ($("a.nav-link").hasClass('blogs')) {
				initialTable(tableId);
				a = 'Блоги';
			}
			chosenPostsIds = [];
			$.toaster({
				priority: 'warning',
				title: 'Операція успішна',
				message: `\n ${a} видалено!`,
				settings: {
					'timeout': 4000
				}
            });
		    $(".delete").addClass('disabled');
		}
	});
}

let deleteSinglePost = function (url, data) {
	let $this = this;
	$.ajax({
		url: url,
		type: 'POST',
		contentType: 'application/x-www-form-urlencoded; charset=utf-8',
		dataType: 'json',
		data: { id: data },
		success: function (data) {
			if ($($this).hasClass('single-blog')) {
				chosenPostsIds = [];
				location.replace("/admin#/content/blogs");
				$.toaster({
					priority: 'warning',
					title: 'Операція успішна',
					message: `Блог видалено!`,
					settings: {
						'timeout': 4000
					}
				});
			}
			else if ($($this).hasClass('single-news')) {
				chosenPostsIds = [];
				location.replace("/admin#/content/news");
				$.toaster({
					priority: 'warning',
					title: 'Операція успішна',
					message: `Статтю видалено!`,
					settings: {
						'timeout': 4000
					}
				});
			}
		}
	});
}