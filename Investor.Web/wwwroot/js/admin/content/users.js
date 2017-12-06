$(document).on("click", "a.nav-link", function (e) {

	const url = $(this).data("href");
	const type = $(this).data("type");

	if (type && type === "users") {
		tablesUpdetedData = {};
		getPartialView(`admin${url}`, initialUsersTable, "#usersTable");
	}
});

var select = $(`<select></select>`);
var userRoles = {};

let initialUsersTable = function (tableId) {

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
				data : null,
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
				"data": "blogs",
				render: function (data, type, full) {
					return data.length;
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
}

