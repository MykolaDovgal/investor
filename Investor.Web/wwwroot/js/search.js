let searchMoreResultPage = 2;
const searchMoreResultCount = 5;
let searchCategoryUrlQuery = "";
let searchDateQuery = "";
let searchTextQuery = "";


$(document).ready(function () {
    $('.my-datepicker').datepicker({
        language: 'ua',
        onSelect: function (formattedDate, date, inst) {
            console.log(date);
            searchDateQuery = date && date !== "null" ? date.toUTCString() : "";
            console.log(searchDateQuery);
        }
    });

    $("#postTextQuery").blur(function() {
        searchTextQuery = $(this).val();
    });

    $("#searchBtn").click(function (e) {
        searchMoreResultPage = 1;
        getSearchResult(
            searchCategoryUrlQuery,
            searchTextQuery,
            searchDateQuery,
            searchMoreResultPage,
            searchMoreResultCount);

    });

    $(".dropdown-item").click(function (e) {
        $("#dropdownMenu2").text($(this).text());
        searchCategoryUrlQuery = $(this).data("categoryUrl");
    });

    $("#moreSearchResult").click(function (e) {
        e.preventDefault();
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
            searchMoreResultPage += 1;
        }
    });
};

let getSearchResult = function (categoryUrl, queryText, date, page, count) {

    const params = `?categoryUrl=${categoryUrl}&query=${queryText}&date=${date}&page=${page}&count=${count}`;
    $.ajax({
        url: `/api/search/posts${params}`,
        type: "GET",
        success: function (data) {
            $("#searchResultContainer").empty();
            $("#searchResultContainer").append(data);
            $(".title-page-search").text(`Результати пошуку за запитом "${queryText}"`);
        }
    });
};