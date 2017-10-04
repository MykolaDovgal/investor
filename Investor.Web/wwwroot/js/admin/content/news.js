$(document).ready(function () {

    $("a.nav-link").click(function (e) {

        const url = $(this).data("href");
        const type = $(e.target).data("type");

        if (type && type === "news") {
            getPartialView(`admin${url}`, initialTable, "#newsTable");
        }
        if (type && type === "blogs") {
            getPartialView(`admin${url}`, initialTable, "#blogsTable");
        }
    });

});




let initialTable = function (tableId) {
    $(tableId).DataTable({
        "ajax": "/api/Content/more",
        "columns": [
            {
                "data": "",
                render: function (data, type, full, meta) {
                    return `<div class="text-center"><input type="checkbox" class="md-check"></div>`;
                }

            },
            {
                "data": "title"

            },
            {
                "data": "publishedOn",
                render: function (data, type, full, meta) {
                    return moment(data).format("DD.MM.YYYY HH:mm");
                }
            },
            { "data": "category.name" },
            {
                "data": "isPublished",
                render: function (data, type, full, meta) {
                    return `<div class="text-center"><input disabled type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
                }
            },
            {
                "data": "isOnMainPage",
                render: function (data, type, full, meta) {
                    return `<div class="text-center"><input disabled type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
                }
            },
            {
                "data": "isImportant",
                render: function (data, type, full, meta) {
                    return `<div class="text-center"><input disabled type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
                }
            }
        ]
    });
}

let getPartialView = function (url, callback = undefined, tableId = undefined) {
    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
            $("#container").empty();
            $("#container").append(data);

            if (callback) {
                callback(tableId);
            }
        }
    });
};