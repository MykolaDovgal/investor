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

    $.fn.datepicker.language['ua'] = {
        days: ["Неділя", "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота"],
        daysShort: ["Нед", "Пон", "Вів", "Сер", "Чет", "П'ят", "Суб"],
        daysMin: ['Нд', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        months: ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень', 'Червень', 'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'],
        monthsShort: ['Січ', 'Лют', 'Бер', 'Квіт', 'Трав', 'Чер', 'Лип', 'Серп', 'Вер', 'Жов', 'Лсит', 'Гру'],
        today: 'Сьогодні',
        clear: 'Очистити',
        dateFormat: 'DD dd.mm.yyyy',
        timeFormat: 'hh:ii'
    }
    console.log($('.date').val());
    var inputDate = new Date(moment($('.date').val(), 'DD.MM.YYYY').toDate());
    
    $("#my-datepicker").datepicker({
        language: "ua",
        maxDate: new Date(),
        
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
        },
        onRenderCell: function (date, cellType) {
            if (!isNaN(inputDate) && moment(date).format("YYYY-MM-DD") === moment(inputDate).format("YYYY-MM-DD")) {
                return {
                    classes: '-selected-'
                }
            }
        }
    });
    
    if (!isNaN(inputDate))$("#my-datepicker").data('datepicker').date = inputDate;
    inputDate = isNaN(inputDate) ? new Date() : inputDate;
    var weekday = new Array(7);
    weekday[0] = "Неділя";
    weekday[1] = "Понеділок";
    weekday[2] = "Вівторок";
    weekday[3] = "Середа";
    weekday[4] = "Четвер";
    weekday[5] = "П'ятниця";
    weekday[6] = "Субота";
    
    var day = weekday[inputDate.getDay()];
    var currentDate = moment(inputDate).format("DD.MM.YYYY");
    $("#my-datepicker").val(day + ' ' + currentDate);

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