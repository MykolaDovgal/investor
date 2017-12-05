
$(document).on("click", "a.nav-link", function (e) {
	const url = $(this).data("href");
	const type = $(this).data("type");

	if (type && type === "tags") {
		getPartialView(`admin${url}`, initialTagsTable, "#tagsTable")
	}	
});

$(document).on("click", "a.tag-submit", function (e) {

	const tableId = `#${$(this).closest("table").prop("id")}`;
	console.log(tableId);
	const row = $(this).closest("tr").index();
	const tableDataObj = tables[tableId].row($(this).parents("tr")).data();

	$(`${$(this).attr("href")} input[name='TagId']`).val(tableDataObj.tagId);
	$(`${$(this).attr("href")} input[name='Url']`).val(tableDataObj.url);
	$(`${$(this).attr("href")} input[name='Name']`).val(tableDataObj.name);

});

//create + update
$(document).on("click", ".tag-update", function (e) {
	var url = $(this).data("href");
	console.log($(this).attr("form"));
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
			console.log(tableId);
			$(tableId).dataTable().fnDestroy(); //TODO ВИПРАВИТИ!!!!!!!!
			initialTagsTable(tableId);
		}
	});
});

let initialTagsTable = function (tableId) {

	tables[tableId] = $(tableId).DataTable({

        "ajax": "/api/TagsApi/GetAllTags",
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
				data: "url",
				"visible": false,
				render: function (data) {
					return data;
				}
			}
		]
    });
}
