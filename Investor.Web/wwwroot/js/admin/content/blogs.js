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
                    return `<a href="#" data-type="singleblog" class="nav-link" data-href="/content/singleblog/${full.postId}">${data}</a>`
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
}