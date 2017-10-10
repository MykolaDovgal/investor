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


$(document).ready(function() {
    $.fn.datepicker.language['ua'] = {
        days: ["Неділя", "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота"],
        daysShort: ["Нед", "Пон", "Вів", "Сер", "Чет", "П'ят", "Суб"],
        daysMin: ['Нд', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        months: ['Січень', 'Лютий', 'Березень', 'Квітень', 'Травень', 'Червень', 'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень'],
        monthsShort: ['Січ', 'Лют', 'Бер', 'Квіт', 'Трав', 'Чер', 'Лип', 'Серп', 'Вер', 'Жов', 'Лсит', 'Гру'],
        today: 'Сьогодні',
        clear: 'Очистити',
        dateFormat: 'DD dd.mm.yyyy',
        timeFormat: 'hh:ii',
        firstDay: 1
    } 
});




var currentDate = data.toLocaleDateString();

$("#data").html('<span class="day color-white-70">' + day + '</span><span class="current-date color-white-70">' + currentDate + '</span>');
/***/

$(".carousel-popular-theme").owlCarousel({
    margin: 10,
    loop: true,
    lazyLoad: true,
    dots: true,
    nav: true,
    slideBy: 3,
    // items:3,
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
    // items:3,
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


