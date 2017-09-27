
(function (d, s, id) {
	var js, fjs = d.getElementsByTagName(s)[0];
	if (d.getElementById(id)) return;
	js = d.createElement(s); js.id = id;
	js.src = "//connect.facebook.net/uk_UA/sdk.js#xfbml=1&version=v2.10&appId=124034454921732";
	fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));


function openWinFb() {
	myWin = open("http://www.facebook.com/sharer.php?u=http://solidbrain.com.ua/", "displayWindow", "width=520,height=300,left=350,top=170,status=no,toolbar=no,menubar=no");
}

window.twttr = (function (d, s, id) {
	var js, fjs = d.getElementsByTagName(s)[0],
		t = window.twttr || {};
	if (d.getElementById(id)) return t;
	js = d.createElement(s);
	js.id = id;
	js.src = "https://platform.twitter.com/widgets.js";
	fjs.parentNode.insertBefore(js, fjs);

	t._e = [];
	t.ready = function (f) {
		t._e.push(f);
	};

	return t;
}(document, "script", "twitter-wjs"));

