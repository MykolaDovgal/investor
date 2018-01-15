let tables = {};

let initialTable = function (tableId) {

	switch (tableId) {
		case "#newsTable":
			tables[tableId] = $(tableId).DataTable({
				"ajax": "/api/NewsApi/GetAllNews",
				"columns": [
					{
						data: null,
						orderable: false,
						render: function () {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" class="custom-control-input md-check" >
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					},
					{
						"data": "postId",
						"visible": false,
						render: function (data, type, full, meta) {
							return data;
						}

					},
					{
						"data": "title",
						render: function (data, type, full) {
							return `<a href="/admin#/post/${full.postId
								}" data-type="singlepost" class="nav-link max-link-w" data-href="/content/singlepost/${full.postId}">${data}</a>`;
						}

					},
					{
						"data": "publishedOn",
						render: function (data, type, full, meta) {
							return `<p class="max-date-w">${moment(data).format("DD.MM.YYYY HH:mm")}<p>`;
						}
					},
					{ "data": "category.name" },
					{
						"data": "isPublished",
						render: function (data, type, full, meta) {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" data-name="IsPublished" class="custom-control-input md-check" ${data ? "checked" : ""}>
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					},
					{
						"data": "isOnMainPage",
						render: function (data, type, full, meta) {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" data-name="IsOnMainPage" class="custom-control-input md-check" ${data ? "checked" : ""}>
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					},
					{
						"data": "isImportant",
						render: function (data, type, full, meta) {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" data-name="IsImportant" class="custom-control-input md-check" ${data ? "checked" : ""}>
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					},
					{
						"data": "isOnSide",
						render: function (data, type, full, meta) {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" data-name="isOnSide" class="custom-control-input md-check" ${data ? "checked" : ""}>
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					},
					{
						"data": "isOnSlider",
						render: function (data, type, full, meta) {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" data-name="isOnSlider" class="custom-control-input md-check" ${data ? "checked" : ""}>
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					}
				]
			});
			break;
		case "#blogsTable":
			tables[tableId] = $(tableId).DataTable({

				"ajax": "/api/BlogsApi/GetAllBlogs",
				"columns": [
					{
						data: null,
						orderable: false,
						render: function () {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input type="checkbox" class="custom-control-input md-check" >
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					},
					{
						"data": "postId",
						"visible": false,
						render: function (data, type, full, meta) {
							return data;
						}

					},
					{
						"data": "title",
						render: function (data, type, full) {
							return `<a href="/admin#/blog/${full.postId
								}" data-type="singleblog" class="nav-link" data-href="/content/singleblog/${full.postId}">${data
								}</a>`;
						}

					},
					{
						"data": null,
						render: function (data, type, full) {
							return `<a href="blog/blogerpage/${full["author"]["userName"]}">${full["author"] ? `${full["author"]["surname"]}  ${full["author"]["name"]}` : "Unknown"}</a>`;
						}
					},
					{
						"data": "createdOn",
						render: function (data, type, full, meta) {
							return moment(data).format("DD.MM.YYYY HH:mm");
						}
					},
					{
						"data": "isPublished",
						render: function (data, type, full, meta) {
							return `<div class="text-center">  <label class="custom-control custom-checkbox ">
                                    <input asp-for="IsPublished" type="checkbox" data-name="IsPublished"  ${data ? "checked" : ""} 
									class="custom-control-input md-check"  name="IsPublished" >
                                    <span class="custom-control-indicator size-check"></span>
                                </label></div>`;
						}
					}
				]
			});
			break;
		case "#tagsTable":
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
							return `<a data-toggle="modal" href="#editTag" class="tag-submit">${data}</a>`;
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
			break;
		case "#usersTable":
			var select = $(`<select></select>`);
			var userRoles = {};

			tables[tableId] = $(tableId).DataTable({
				ajax: {
					url: "/api/UsersApi/GetAllUsers",
					"dataSrc": function (json) {
						select = $(`<select class="roles"></select>`);
						for (let i = 0; i < json.data.roles.length; i++)
							select.append(`<option class='${json.data.roles[i]}'>${json.data.roles[i]}</option>`);
						return json.data.result;
					},
				},

				"columns": [
					{
						data: null,
						orderable: false,
						render: function () {
							return `<div class="text-center"><input type="checkbox" class="md-check"></div>`;
						}
					},
					{
						"data": "id",
						"visible": false,
						render: function (data, type, full, meta) {
							return data;
						}

					},
					{
						"data": null,
						render: function (data, type, full) {
							return `<a href="/blog/blogerpage/${full.userName}" class="tag-submit">${full.surname} ${full.name}</a>`;
						}

					},
					{
						"data": "userName",
						render: function (data, type, full) {
							return data;
						}

					},
					{
						"data": "email",
						render: function (data, type, full) {
							return data;
						}
					},
					{
						"data": "numberOfBlogs",
						render: function (data, type, full) {
							return data;
						}
					},
					{
						data: "role",
						render: function (data) {
							var newSelect = select.clone();
							newSelect.children(`.${data}`).attr(`selected`, true);
							return newSelect.prop("outerHTML");
						}
					}
				]
			});
			break;
		default:
			break;
	}

}

let getPartialView = function (url, callback = undefined, tableId = undefined) {
	$.ajax({
		url: url,
		type: "GET",
		success: function (data) {
			$("#container").empty();
			$("#container").append(data);
			chosenPostsIds = [];
			if (callback) {
				callback(`#${$("table").attr("id")}`);
			}
		},
		error: function(xhr, status, error) {
			$.ajax({
				url: `admin/StatusCode/${xhr.status}`,
				type: "GET",
				success: function(data) {
					$("#container").empty();
					$("#container").append(data);
				}
			});
		}
	});
};

$(document).on('change',
	'tbody td:not(:first-child)',
	function (e) {

		const tableId = `#${$(this).closest('table').prop("id")}`;
		const idx = tables[tableId].cell(this).index().column;

		const tableDataObj = tables[tableId].row($(this).parents("tr")).data();
		const propertyName = tables[tableId].settings().init().columns[idx].data;
		var properyValue;
		if ($(e.target).is("input")) {
			properyValue = $(e.target).prop("checked");
			if (tablesUpdetedData[tableDataObj.postId]) {
				tablesUpdetedData[tableDataObj.postId][propertyName] = properyValue;
			} else {
				tablesUpdetedData[tableDataObj.postId] = tableDataObj;
				tablesUpdetedData[tableDataObj.postId][propertyName] = properyValue;
			}
			if ((e.target).classList.contains('modified')) {
				(e.target).classList.remove('modified');
			} else {
				(e.target).classList.add('modified');
			}
		}
		else if ($(e.target).is('select')) {
			properyValue = $(e.target).val();
			if (tablesUpdetedData[tableDataObj.id]) {
				tablesUpdetedData[tableDataObj.id][propertyName] = properyValue;
			} else {
				tablesUpdetedData[tableDataObj.id] = tableDataObj;
				tablesUpdetedData[tableDataObj.id][propertyName] = properyValue;
				(e.target).classList.add('modified');
			}
		}
		if ($('.modified').length > 0) {
			$('.update').removeClass('disabled');
		} else {
			$('.update').addClass('disabled');
		}
	});
