const getUrlFragment = function(url){
    const fragmentPosition = url.indexOf("#"); 
    if (fragmentPosition !== -1) {
        return url.slice(fragmentPosition + 1,url.length);
    }
    else {
        return undefined;
    }
}

let getContent = function (e) {
	var url = location.hash.replace("#", "");
	if (url.startsWith("/post/")) {
		getPartialView(`admin${url}`, function () { initTypeahead(); $("#updateFormSubmit").data("action", "UpdateNews"); });
	}
	else if (url.startsWith("/blog/")) {
		getPartialView(`admin${url}`, function () { initTypeahead(); $("#updateFormBlogSubmit").data("action", "UpdateBlog"); });
	}
	else if (url.startsWith("/createpost")) {
		getPartialView(`admin${url}`, function () { initTypeahead(); $("#updateFormBlogSubmit").data("action", "UpdateBlog"); });
	}
	else if(url !== ""){
		getPartialView(`admin${url}`, initialTable);
	}

	tablesUpdetedData = {};
}

window.addEventListener("popstate", getContent, false);

//window.addEventListener("pushstate",
//	function (e) {	
//		var a = $(`a[href="/admin${location.hash}"]`);
//	    console.log(location.hash);
//	    console.log(a);
//        a.click();
//    },
//    false);
window.addEventListener("load", getContent, false);

