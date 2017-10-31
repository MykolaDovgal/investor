/***data***/
var data = new Date();
var weekday = new Array(7);
weekday[0] = "Неділя";
weekday[1] = "Понеділок";
weekday[2] = "Вівторок";
weekday[3] = "Середа";
weekday[4] = "Четвер";
weekday[5] = "П'ятниця";
weekday[6] = "Субота";
var day = weekday[data.getDay()];

var currentDate = data.toLocaleDateString();

$("#data").html('<span class="day">' + day + '</span><span class="current-date">' + currentDate + '</span>');

$("#my-datepicker").val(day + ' ' + currentDate);
/***/

$(".carousel-popular-theme").owlCarousel({
    margin: 10,
    loop: true,
    lazyLoad: true,
    dots: true,
    nav: true,
    slideBy: 3,
    responsiveClass: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 3
        }
    }
});

$(".carousel-editorial-choice").owlCarousel({
    margin: 10,
    loop: true,
    lazyLoad: true,
    dots: true,
    nav: true,
    slideBy: 3,
    responsiveClass: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 3
        }
    }
});

$(".carousel-top-blog").owlCarousel({
    margin: 10,
    loop: true,
    lazyLoad: true,
    dots: true,
    nav: true,
    slideBy: 3,
    responsiveClass: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 2
        },
        1000: {
            items: 3
        }
    }
});



$(document).on('change', '.btn-file :file', function () {
    var input = $(this),
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.trigger('fileselect', [label]);
});

$('.btn-file :file').on('fileselect', function (event, label) {

    var input = $(this).parents('.input-group').find(':text'),
        log = label;

    if (input.length) {
        input.val(log);
    } else {
        if (log) alert(log);
    }

});
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#img-upload').attr('style', 'background-image: url(' + e.target.result + ');');
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgInp").change(function () {
    readURL(this);
});

/***preview registration***/
$('.input-value').keyup(function () {
    var $this = $(this);
    var text = $this.val();
    $('.' + $this.attr('id') + '').html($this.val());

    if (text.length > 1) {
        $('.' + $this.attr('id') + '').prev('i').removeClass('d-none');
    } else if (text.length < 1) {
        $('.' + $this.attr('id') + '').prev('i').addClass('d-none');
    }

    var name = $('#input-value-name').val();
    if (name.length < 1) {
        $('.input-value-name').html('Ім’я');
    }


    var lastname = $('#input-value-lastname').val();
    if (lastname.length < 1) {
        $('.input-value-lastname').html('Прізвище');
    }

    var autobiography = $('#input-value-autobiography').val();
    if (autobiography.length < 1) {
        $('.input-value-autobiography').html('Ваша біографія');
    }
});
/***end preview registration***/

/***number of description lines***/
$('.item-blog-news').each(function () {
    var blog = $(this);
    var heightTitle = blog.find('.title-news').height();

    if (heightTitle < 23) {
        blog.find('.text-news').removeClass('brief-description');
    }
});
/***end number of description lines***/

/***blog number of description lines***/
$('.item-all-news').each(function () {
    var blog = $(this);
    var heightTitle = blog.find('.title-news').height();

    if (heightTitle < 23) {
        blog.find('.text-news').removeClass('brief-description');
    }
});
/***end number of description lines***/

/***remove disable class***/
$('.btn-edit').click(function () {
    var nameData = $(this).parents('.block-edit').data('edit');
    var findForm = $('.edit-' + nameData).find('.form-control');

    $('.edit-' + nameData).find('button[type="button"]').attr('hidden', 'hidden');
    $('.edit-' + nameData).find('button[type="submit"]').removeAttr('hidden');


    if ($(findForm).hasClass("disabled")) {
        findForm.removeClass('disabled');
        findForm.removeAttr('disabled readonly');
    }

});
/*******************/

var myLanguage = {
    errorTitle: 'Не вдалося надіслати форму!',
    requiredFields: 'Ви не заповнили всі обов’язкові поля',
    badTime: 'Введено некоректний час',
    badEmail: 'Введено некоректний email',
    badTelephone: 'Введено неправильний номер телефону',
    badSecurityAnswer: 'Ви ввели неправильну відповідь на секретне запитання',
    badDate: 'Введено некоректну дату',
    lengthBadStart: 'Введене значення повинне бути між ',
    lengthBadEnd: ' символи',
    lengthTooLongStart: 'Введене значення більше ніж ',
    lengthTooShortStart: 'Введене значення менше ніж ',
    notConfirmed: 'Введені значення не можуть бути підтверджені',
    badDomain: 'Некоректне ім’я домену',
    badUrl: 'Некоректне URL значення',
    badCustomVal: 'Введено некоректне значення',
    andSpaces: ' і пробіли ',
    badInt: 'Введене значення не є коректним числом',
    badSecurityNumber: 'Your social security number was incorrect',
    badUKVatAnswer: 'Incorrect UK VAT Number',
    badStrength: 'Пароль є занадто слабким',
    badNumberOfSelectedOptionsStart: 'Виберіть принаймні ',
    badNumberOfSelectedOptionsEnd: ' відповіді',
    badAlphaNumeric: 'Введені значення мають бути лише алфавітними символами ',
    badAlphaNumericExtra: ' і ',
    wrongFileSize: 'Файл, який ви намагаєтесь завантажити занадто великий (макс. %s)',
    wrongFileType: 'Тільки файли типу %s  є дозволеними',
    groupCheckedRangeStart: 'Будь ласка, виберіть між ',
    groupCheckedTooFewStart: 'Будь ласка, виберіть принаймні ',
    groupCheckedTooManyStart: 'Будь ласка, виберіть максимум з ',
    groupCheckedEnd: ' item(s)',
    badCreditCard: 'Номер кредитної карти є некоректним',
    badCVV: 'The CVV number was not correct',
    wrongFileDim: 'Некоретне розширення зображення,',
    imageTooTall: 'зображення не може бути вище, ніж',
    imageTooWide: 'зображення не може бути ширше, ніж',
    imageTooSmall: 'зображення занадто мале',
    min: 'мін',
    max: 'макс',
    imageRatioNotAccepted: 'Співвідношення зображення не є прийнятним'
};

$.validate({
    language: myLanguage,
    modules: 'security',
    onModulesLoaded: function () {
        var optionalConfig = {
            fontSize: '12pt',
            padding: '7px',
            bad: '',
            weak: '',
            good: '',
            strong: ''
        };

        $('input[name="Password"]').displayPasswordStrength(optionalConfig);
    }
});


