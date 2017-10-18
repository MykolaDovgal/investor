
$(document).on("click", "a.nav-link", function (e) {
	const url = $(this).data("href");
	const type = $(e.target).data("type");

	if (type && type === "tags") {
		getPartialView(`admin${url}`, initialTagsTable, "#tagsTable")
	}	
});

$(document).on("click", "a.tag-submit", function (e) {

	const tableId = "#" + $(this).closest('table').prop("id");
	const row = $(this).closest('tr').index();
	const tableDataObj = tables[tableId].row(row).data();

	$("input[name='TagId']").val(tableDataObj.tagId);
	$("input[name='Url']").val(tableDataObj.url);
	$("input[name='Name']").val(tableDataObj.name);

});

$(document).on("click", "#tag-update-submit", function (e) {
	let formData = new FormData(document.getElementById('tag-update'));
	e.preventDefault();
	$.ajax({
		type: "POST",
		url: "/api/Content/UpdateTag",
		data: formData,
		cache: false,
		contentType: false,
		processData: false,

		success: function (data) {
			$("#tagsTable").dataTable().fnDestroy();
			initialTagsTable("#tagsTable");
		}
	});
});

$(document).on("click", "#tag-delete-submit", function (e) {
	let formData = new FormData(document.getElementById('tag-delete'));
	e.preventDefault();
	$.ajax({
		type: "POST",
		url: "/api/Content/RemoveTag",
		data: formData,
		cache: false,
		contentType: false,
		processData: false,

		success: function (data) {
			$("#tagsTable").dataTable().fnDestroy(); // ВИПРАВИТИ!!!!!!!!
			initialTagsTable("#tagsTable");
		}
	});
});

let initialTagsTable = function (tableId) {

	tables[tableId] = $(tableId).DataTable({

		"ajax": "/api/Content/GetAllTags",
		"columns": [
			{
				data: null,
				orderable: false,
				render: function () {
					return `<div class="text-center"><input type="checkbox" class="md-check"></div>`;
				}
			},
			{
				"data": "tagId",
				"visible": false,
				render: function (data, type, full, meta) {
					return data;
				}

			},
			{
				"data": "name",
				render: function (data, type, full) {
					return `<a data-toggle="modal" href="#updateTag" class="tag-submit">${data}</a>`;
				}

			},
			{
				"data": "postCount",
				render: function (data, type, full) {
					return data;
				}
			},
			{
				data: null,
				orderable: false,
				render: function () {
	
					return `<a class="btn btn-circle btn-icon-only btn-default tag-submit" data-toggle="modal" href="#deleteTag"><i class="icon-trash"></i></a>`;
				}
			},
			{
				data: "url",
				"visible": false,
				render: function (data) {
					return data;
				}
			}
		]
	});
}
