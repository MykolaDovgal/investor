﻿var nicknames = [];
var emails = [];
$(document).ready(function () {
	getNicknames();
	getEmails();
});

let getNicknames = function(route, result) {
	$.ajax({
		url: `/api/account/nicknames`,
		type: "GET",
		success: function(data) {
			nicknames = data;
			console.log(nicknames);
		}
	});
}

let getEmails = function (route, result) {
	$.ajax({
		url: `/api/account/emails`,
		type: "GET",
		success: function (data) {
			emails = data;
			console.log(emails);
		}
	});
}

var myLanguage = {
	errorTitle: "Не вдалося надіслати форму!",
	requiredFields: "Ви не заповнили всі обов’язкові поля",
	badTime: "Введено некоректний час",
	badEmail: "Введено некоректний email",
	badTelephone: "Введено неправильний номер телефону",
	badSecurityAnswer: "Ви ввели неправильну відповідь на секретне запитання",
	badDate: "Введено некоректну дату",
	lengthBadStart: "Введене значення повинне бути між ",
	lengthBadEnd: " символи",
	lengthTooLongStart: "Введене значення більше ніж ",
	lengthTooShortStart: "Введене значення менше ніж ",
	notConfirmed: "Введені значення не можуть бути підтверджені",
	badDomain: "Некоректне ім’я домену",
	badUrl: "Некоректне URL значення",
	badCustomVal: "Введено некоректне значення",
	andSpaces: " і пробіли ",
	badInt: "Введене значення не є коректним числом",
	badSecurityNumber: "Your social security number was incorrect",
	badUKVatAnswer: "Incorrect UK VAT Number",
	badStrength: "Пароль є занадто слабким",
	badNumberOfSelectedOptionsStart: "Виберіть принаймні ",
	badNumberOfSelectedOptionsEnd: " відповіді",
	badAlphaNumeric: "Введені значення мають бути лише алфавітними символами ",
	badAlphaNumericExtra: " і ",
	wrongFileSize: "Файл, який ви намагаєтесь завантажити занадто великий (макс. %s)",
	wrongFileType: "Тільки файли типу %s  є дозволеними",
	groupCheckedRangeStart: "Будь ласка, виберіть між ",
	groupCheckedTooFewStart: "Будь ласка, виберіть принаймні ",
	groupCheckedTooManyStart: "Будь ласка, виберіть максимум з ",
	groupCheckedEnd: " item(s)",
	badCreditCard: "Номер кредитної карти є некоректним",
	badCVV: "The CVV number was not correct",
	wrongFileDim: "Некоретне розширення зображення,",
	imageTooTall: "зображення не може бути вище, ніж",
	imageTooWide: "зображення не може бути ширше, ніж",
	imageTooSmall: "зображення занадто мале",
	min: "мін",
	max: "макс",
	imageRatioNotAccepted: "Співвідношення зображення не є прийнятним"
};

$.validate({
	language: myLanguage,
	modules: "security",
	onModulesLoaded: function () {
		var optionalConfig = {
			fontSize: "12pt",
			padding: "7px",
			bad: "",
			weak: "",
			good: "",
			strong: ""
		};

		$('input[name="pass_confirmation"]').displayPasswordStrength(optionalConfig);
	}
});

$.formUtils.addValidator({
	name: 'unique_nickname',
	validatorFunction: function (value, $el, config, language, $form) {
		console.log(nicknames, value);
		return nicknames.indexOf(value) === -1;
	},
	errorMessage: 'Такий нік вже існує',
	errorMessageKey: 'badNickname'
});

$.formUtils.addValidator({
	name: 'unique_email',
	validatorFunction: function (value, $el, config, language, $form) {
		return emails.indexOf(value) === -1;
	},
	errorMessage: 'Такий email вже використаний',
	errorMessageKey: 'badEmailAddress'
});


var resultsrc = "";
var Cropper = (function () {


	function popupResult(result) {
		if (result.src) {
			console.log(result);
			$("#img-upload").attr("style", "background-image: url(" + result.src + ");");
		}
    }

    var $uploadCrop = $("#upload-demo").croppie({
        viewport: {
            width: 100,
            height: 100,
            type: "circle"
        },
        enableExif: true
    });

	function Upload() {		
		function readFile(input) {
			if (input.files && input.files[0]) {
				var reader = new FileReader();
				reader.onload = function (e) {
					$(".upload-demo").addClass("ready");
					$uploadCrop.croppie("bind", {
						url: e.target.result
					}).then(function () {

					});
				}
				reader.readAsDataURL(input.files[0]);
			}
			else {
				swal("Sorry - you're browser doesn't support the FileReader API");
			}
		}

		

        $(document).ready(function () {
            const tmp = $('input[name="CropPoints"]').val();
            if (tmp) {
                $uploadCrop.croppie("bind", {
                    url: $("#userPhoto").attr("src"),
                    points: JSON.parse(tmp)
                }).then(function () {
                });  
            }
			
			
		});
		

		$("#upload").on("change", function () { readFile(this); });
		$(".upload-result").on("click", function (ev) {
			$uploadCrop.croppie("result", {
				type: "canvas",
				size: "viewport"
			}).then(function (resp) {
				popupResult({
					src: resp
				});
				$("#cropped").attr("src", resp);
				});
		});
	}


	function init() {
		Upload();
	}

	return {
		init: init
	}

})();


Cropper.init();

//$(document).ready(function () {
//	$('.cr-image').attr('src',);
//	console.log('hello2');
//});