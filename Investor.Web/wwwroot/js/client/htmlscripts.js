var nicknames = [];
var emails = [];
$(document).ready(function () {
	//getNicknames();
	//getEmails();
});

//let getNicknames = function(route, result) {
//	$.ajax({
//		url: `/api/account/nicknames`,
//		type: "GET",
//		success: function(data) {
//			nicknames = data;
//			console.log(nicknames);
//		}
//	});
//}

//let getEmails = function (route, result) {
//	$.ajax({
//		url: `/api/account/emails`,
//		type: "GET",
//		success: function (data) {
//			emails = data;
//			console.log(emails);
//		}
//	});
//}

//$.formUtils.addValidator({
//	name: 'unique_nickname',
//	validatorFunction: function (value, $el, config, language, $form) {
//		console.log(nicknames, value);
//		return nicknames.indexOf(value) === -1;
//	},
//	errorMessage: 'Такий нік вже існує',
//	errorMessageKey: 'badNickname'
//});

//$.formUtils.addValidator({
//	name: 'unique_email',
//	validatorFunction: function (value, $el, config, language, $form) {
//		return emails.indexOf(value) === -1;
//	},
//	errorMessage: 'Такий email вже використаний',
//	errorMessageKey: 'badEmailAddress'
//});


//var resultsrc = "";


//$(document).ready(function () {
//	$('.cr-image').attr('src',);
//	console.log('hello2');
//});