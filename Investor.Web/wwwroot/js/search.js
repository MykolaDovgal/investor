let searchMoreResultPage = 1;
const searchMoreResultCount = 5;
let searchCategoryUrlQuery = "";
let searchDateQuery = "";
let searchTextQuery = "";
let searchTagQuery = "";


$(document).ready(function () {
	searchTagQuery = $(".title-page-search").data("tag");
	searchCategoryUrlQuery = $(".title-page-search").data("category-url");
	searchTextQuery = $(".title-page-search").data("query");

    $(".my-datepicker").datepicker({
        language: "ua",
        onSelect: function (formattedDate, date, inst) {
            searchMoreResultPage = 1;
            searchDateQuery = date && date !== "null" ? date.toUTCString() : "";
            getSearchResult(
                searchCategoryUrlQuery,
                searchTextQuery,
                searchDateQuery,
                searchMoreResultPage,
				searchMoreResultCount,
				searchTagQuery);
        }
    });

    $("#postTextQuery").blur(function () {
		searchTextQuery = $(this).val();
    });

    $("#searchForm").submit(function (e) {
		e.preventDefault();
        searchMoreResultPage = 1;
        getSearchResult(
            searchCategoryUrlQuery,
            $("#postTextQuery").val(),
            searchDateQuery,
            searchMoreResultPage,
			searchMoreResultCount,
			searchTagQuery);
    });

    $(".dropdown-item").click(function (e) {
        $("#dropdownMenu2").text($(this).text());
        searchMoreResultPage = 1;
        searchCategoryUrlQuery = $(this).data("categoryUrl");
        getSearchResult(
            searchCategoryUrlQuery,
            searchTextQuery,
            searchDateQuery,
            searchMoreResultPage,
			searchMoreResultCount,
			searchTagQuery);
    });

    $("#moreSearchResult").click(function (e) {
		e.preventDefault();
        searchMoreResultPage += 1;
        getMoreSearchResult.apply(this, [searchCategoryUrlQuery,
            searchTextQuery,
            searchDateQuery,
            searchMoreResultPage,
			searchMoreResultCount,
			searchTagQuery]);
    });
});


let getMoreSearchResult = function (categoryUrl, queryText, date, page, count, tag) {
    const params = `?categoryUrl=${categoryUrl}&query=${queryText}&date=${date}&page=${page}&count=${count}&tag=${tag}`;
    $.ajax({
        url: `/api/search/posts${params}`,
        type: "GET",
        success: function (data) {
			$("#searchResultContainer").append(data);
			console.log($(".numberOfPosts").last().val());
			if ($(".numberOfPosts").last().val() < searchMoreResultCount) {
				$(".wrapper-btn-more").attr("hidden", "true");
			}
        }
    });
};

let getSearchResult = function (categoryUrl, queryText, date, page, count, tag) {

    if (tag) {
        window.location.href = `/search/searchbytag?tag=${tag}&categoryUrl=${categoryUrl}`;
    } else {
        window.location.href = `/search/posts?categoryUrl=${categoryUrl}&query=${queryText}&date=${date}&page=${page}&count=${count}`;
    }

};