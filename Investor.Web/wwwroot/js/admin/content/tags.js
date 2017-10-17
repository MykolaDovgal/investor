
$(document).on("click", "a.nav-link", function (e) {
	const url = $(this).data("href");
	const type = $(e.target).data("type");

	if (type && type === "tags") {
		getPartialView(`admin${url}`, initialTagsTable, "#tagsTable")
	}
});

let initialTagsTable = function (tableId) {

	tables[tableId] = $(tableId).DataTable({

		"ajax": "/api/Content/GetAllTags",
		"columns": [
			{
				data: null,
				orderable: false,
				render: function () {
					return `<div class="text-center"><input type="checkbox" class="md-check"></div>`
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
					return `<p>${data}</p>`
				}

			},
			{
				"data": "postCount",
				render: function (data, type, full) {
					return `<p>${data}</p>`
				}
			}
		]
	});
}
