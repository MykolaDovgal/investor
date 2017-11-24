let moreNewsPage = 1;
let moreLastNewsPage = 1;
let moreNewsLimit = 10;

$(document).ready(function () {
    $(".btn-more.dynamic").click(function (e) {
		e.preventDefault();
		moreNewsPage += 1;
		getMoreNews.apply(this, [$(this).data("categoryName"), moreNewsPage, moreNewsLimit, '/api/post/more', ".category-news-body"]);
	});

	$(".btn-more.lastnews").click(function (e) {
		e.preventDefault();
		moreLastNewsPage += 1;
		getMoreNews.apply(this, ["", moreLastNewsPage, moreNewsLimit, '/api/post/morelastnews', ".last-news-wrapper"]);
	});

});

let getMoreNews = function (categoryName,page,limit,url,target) {
    const params = `?categoryUrl=${categoryName}&page=${page}&limit=${limit}`;
    $.ajax({
        url: `${url + params}`,
        type: "GET",
		success: function (data) {
			$(target).append(data);
			if ($(".numberOfPosts").last().val() < moreNewsLimit) {
				$(".wrapper-btn-more").attr("hidden", "true");
			}
            
        }
    });
};