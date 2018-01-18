const getUrlFragment = function (url) {
    const fragmentPosition = url.indexOf("#");
    if (fragmentPosition !== -1) {
        return url.slice(fragmentPosition + 1, url.length);
    }
    else {
        return undefined;
    }
}

let getContent = function (e) {
    const url = location.hash.replace("#", "");

    if (url.startsWith("/post/")) {
        getPartialView(`admin${url}`, function () { initTypeahead(); $("#updateFormSubmit").data("action", "UpdateNews"); });
    }
    else if (url.startsWith("/dashboard")) {
        getPartialView(`admin${url}`, initialGoogleAnalyticsDashboard);
    }
    else if (url.startsWith("/createpost")) {
        getPartialView(`admin${url}`, function () { initTypeahead(); $("#updateFormSubmit").data("action", "CreateNews"); });
    }
    else if (url !== "") {
        getPartialView(`admin${url}`, initialTable);
    }

    tablesUpdetedData = {};



    var path = window.location.pathname + window.location.hash;
    $('.nav-item a').each(function () {
        $(this).removeClass('active-item');
    });
    $('.nav-item a').each(function () {
        if ($(this).attr('href') === path) {
            $(this).addClass('active-item');
            $(this).parent().prev('.nav-item a').addClass('active-item');
        }
    });
}

window.addEventListener("popstate", getContent, false);
window.addEventListener("load", getContent, false);

