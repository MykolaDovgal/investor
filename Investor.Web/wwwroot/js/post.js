let moreNewsPage = 2;
let moreNewsLimit = 10;

$(document).ready(function () {
    $(".btn-more.dynamic").click(function (e) {
        e.preventDefault();
        getMoreNews.apply(this, [$(this).data("categoryName"), moreNewsPage, moreNewsLimit]);
    });
});

let getMoreNews = function (categoryName,page,limit) {

    const params = `?categoryUrl=${categoryName}&page=${page}&limit=${limit}`;
    $.ajax({
        url: `/api/post/more${params}`,
        type: "GET",
        success: function (data) {
            $(".category-news-body").append(data);
            moreNewsPage += 1;
        }
    });
};