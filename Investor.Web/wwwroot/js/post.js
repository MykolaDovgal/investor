let moreNewsPage = 2;
let moreNewsLimit = 10;

$(document).ready(function () {
    $(".btn-more").click(function (e) {
        e.preventDefault();
        getMoreNews.apply(this, [$(this).data("categoryName"), moreNewsPage, moreNewsLimit]);
    });
});

let getMoreNews = function (categoryName,page,limit) {

    let params = `?categoryUrl=${categoryName}&page=${page}&limit=${limit}`;
    console.log(params);
    $.ajax({
        url: '/api/post/more' + params,
        type: 'GET',
        success: function (data) {
            $('.category-news-body').append(data);
            moreNewsPage += 1;
        }
    });

    
};