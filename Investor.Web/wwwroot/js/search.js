let searchMoreResultPage = 1;
const searchMoreResultCount = 10;
let searchCategoryUrlQuery = "";
let searchDateQuery;


$(document).ready(function () {
    $('.my-datepicker').datepicker({
        language: 'ua',
        onSelect: function(formattedDate, date, inst) {
            searchDateQuery = +date;
        }
    });

    $("#searchBtn").click(function (e) {
        console.log("click");
        let t = $("#postTextQuery");
        let k = t.val();
        getSearchResult(
            searchCategoryUrlQuery,
            k,
            searchDateQuery,
            searchMoreResultPage,
            searchMoreResultCount);

    });

    $(".dropdown-item").click(function(e) {
        $("#dropdownMenu2").val($(this).data("categoryUrl"));
        searchCategoryUrlQuery = $(this).data("categoryUrl");
    });
});


let getSearchResult = function (categoryUrl,queryText,date,page,count) {

    const params = `?categoryUrl=${categoryUrl}&query=${queryText}&date=${date}&page=${page}&count=${count}`;
    $.ajax({
        url: `/api/search/posts${params}`,
        type: "GET",
        success: function (data) {
            $("#searchResultContainer").empty();
            $("#searchResultContainer").append(data);
            //searchMoreResultPage += 1;
        }
    });
};