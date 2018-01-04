const getUrlFragment = function(url){
    const fragmentPosition = url.indexOf("#"); 
    if (fragmentPosition !== -1) {
        return url.slice(fragmentPosition + 1,url.length);
    }
    else {
        return undefined;
    }
}


window.addEventListener("popstate",
    function (e) {
        var a = $(`a[href="/admin${location.hash}"]`);
        a.click();
    },
    false);

window.addEventListener("pushstate",
    function (e) {
        var a = $(`a[href="/admin${location.hash}"]`);
        a.click();
    },
    false);

window.addEventListener("load",
    function (e) {
        var a = $(`a[href="/admin${location.hash}"]`);
        a.click();
    },
    false);