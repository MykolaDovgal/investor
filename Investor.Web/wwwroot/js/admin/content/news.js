let tables = { };

$(document).ready(function () {

    

});


$(document).on('change', 'tbody td:not(:first-child)', function (e) {

    const tableId = "#" + $(this).closest('table').prop("id");
    const idx = tables[tableId].cell(this).index().column;
    const tableDataObj = tables[tableId].row(idx).data();

    console.log(e.target);
    console.log(this);
    console.log(tableDataObj);

});

$(document).on("click", "a.nav-link", function (e) {

    const url = $(this).data("href");
    const type = $(e.target).data("type");

    if (type && type === "news") {
        getPartialView(`admin${url}`, initialTable, "#newsTable");
    }
    if (type && type === "blogs") {
        getPartialView(`admin${url}`, initialTable, "#blogsTable");
    }
    if (type && type === "singlepost") {
        getPartialView(`admin${url}`);
    }
});



//$(document).on('click', 'tbody td', function() {
//    var idx = table.cell(this).index().column;
//    console.log(table.row(idx).data());
//});




let initialTable = function (tableId) {

    tables[tableId] = $(tableId).DataTable({

        "ajax": "/api/Content/GetAllNews",
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
                    return `<a href="#" data-type="singlepost" class="nav-link" data-href="/content/singlepost/${full.postId}">${data}</a>`
                }

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
                    return `<div class="text-center"><input data-name="IsPublished" type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
                }
            },
            {
                "data": "isOnMainPage",
                render: function (data, type, full, meta) {
                    return `<div class="text-center"><input data-name="IsOnMainPage" type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
                }
            },
            {
                "data": "isImportant",
                render: function (data, type, full, meta) {
                    return `<div class="text-center"><input data-name="IsImportant" type="checkbox" ${data ? "checked" : ""} class="md-check"></div>`;
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