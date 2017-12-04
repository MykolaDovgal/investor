$(document).on("click", "a.nav-link", function (e) {

    const url = $(this).data("href");
    const type = $(this).data("type");

	if (type && type === "blogs") {
		tablesUpdetedData = {};
        getPartialView(`admin${url}`, initialTableBlogs, "#blogsTable");
    }
});

let initialTableBlogs = function (tableId) {

    tables[tableId] = $(tableId).DataTable({

        "ajax": "/api/Content/GetAllBlogs",

        "columns": [
            {
                data: null,
                orderable: false,
                render: function () {
                    return `<div class="text-center"><input type="checkbox" class="md-check"></div>`
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
                    return `<a href="#" data-type="singleblog" class="nav-link" data-href="/content/singleblog/${full.postId}">${data}</a>`
                }

            },
            {
                "data": "author.name",
                render: function (data, type, full) {
                    return data ? data : "Unknown";
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
                    return `<div class="text-center"><input data-name="IsPublished" type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
                }
            }
        ]
    });
}