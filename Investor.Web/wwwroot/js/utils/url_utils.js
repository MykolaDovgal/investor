const getUrlFragment = function(url){
    const fragmentPosition = url.indexOf("#"); 
    if (fragmentPosition !== -1) {
        return url.slice(fragmentPosition + 1,url.length);
    }
    else {
        return undefined;
    }
}