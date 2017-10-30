let searchMoreResultPage = 1;
const searchMoreResultCount = 5;
let searchCategoryUrlQuery = "";
let searchDateQuery = "";
let searchTextQuery = "";


$(document).ready(function () {
    $('.my-datepicker').datepicker({
        language: 'ua',
        onSelect: function (formattedDate, date, inst) {
            searchMoreResultPage = 1;
            searchDateQuery = date && date !== "null" ? date.toUTCString() : "";
            getSearchResult(
                searchCategoryUrlQuery,
                searchTextQuery,
                searchDateQuery,
                searchMoreResultPage,
                searchMoreResultCount);
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
            searchMoreResultCount);
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
            searchMoreResultCount);
    });

    $("#moreSearchResult").click(function (e) {
        e.preventDefault();
        searchMoreResultPage += 1;
        getMoreSearchResult.apply(this, [searchCategoryUrlQuery,
            searchTextQuery,
            searchDateQuery,
            searchMoreResultPage,
            searchMoreResultCount]);
    });
});


let getMoreSearchResult = function (categoryUrl, queryText, date, page, count) {

    const params = `?categoryUrl=${categoryUrl}&query=${queryText}&date=${date}&page=${page}&count=${count}`;
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

let getSearchResult = function (categoryUrl, queryText, date, page, count) {

    console.log(` ${categoryUrl}  ${queryText}   ${date}   ${page}   ${count}`);
    const params = `?categoryUrl=${categoryUrl}&query=${queryText}&date=${date}&page=${page}&count=${count}`;
    $.ajax({
        url: `/api/search/posts${params}`,
        type: "GET",
		success: function (data) {
			$(".wrapper-btn-more").removeAttr("hidden");
            $("#searchResultContainer").empty();
			$("#searchResultContainer").append(data);
			console.log($(".numberOfPosts").last().val());
			$(".title-page-search").text(`Результати пошуку за запитом "${queryText}"`);
			if ($(".numberOfPosts").last().val() < searchMoreResultCount) {
				$(".wrapper-btn-more").attr("hidden", "true");
			}
        }
    });
};