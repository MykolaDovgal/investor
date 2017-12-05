let moreNewsPage = 1;
let moreLastNewsPage = 1;
let moreLastBlogsPage = 1;
let moreNewsLimit = 10;

$(document).ready(function () {
    $(".btn-more.dynamic").click(function (e) {
		e.preventDefault();
		moreNewsPage += 1;
		getMoreNews.apply(this, [$(this).data("categoryName"), moreNewsPage, moreNewsLimit, '/api/news/morenews', ".category-news-body"]);
	});

	$(".btn-more.lastnews").click(function (e) {
		e.preventDefault();
		moreLastNewsPage += 1;
		getMoreNews.apply(this, ["", moreLastNewsPage, moreNewsLimit, '/api/news/morelastnews', ".last-news-wrapper"]);
	});

	$(".btn-more.lastblogs").click(function (e) {
		e.preventDefault();
		moreLastBlogsPage += 1;
		getMoreNews.apply(this, ["", moreLastBlogsPage, moreNewsLimit, '/api/blogs/morelastblogs', ".last-blogs-wrapper"]);
	});
});

let getMoreNews = function (categoryName,page,limit,url,target) {
    const params = `?categoryUrl=${categoryName}&page=${page}&limit=${limit}`;
    $.ajax({
        url: `${url + params}`,
        type: "GET",
		success: function (data) {
			$(target).append(data);
			console.log($(".numberOfPosts").last().val());
			if ($(".numberOfPosts").last().val() < moreNewsLimit) {
				$(".wrapper-btn-more").attr("hidden", "true");
			}
            
        }
    });
};