/***data***/
var data=new Date();
var weekday=new Array(7);
weekday[0]="Неділя";
weekday[1]="Понеділок";
weekday[2]="Вівторок";
weekday[3]="Середа";
weekday[4]="Четвер";
weekday[5]="П'ятниця";
weekday[6]="Субота";
var day = weekday[data.getDay()];

var currentDate = data.toLocaleDateString();

$("#data").html('<span class="day color-white-70">'+day+'</span><span class="current-date color-white-70">'+currentDate+'</span>');
/***/

$(".carousel-popular-theme").owlCarousel({
  margin:10,
  loop:true,
  lazyLoad:true,
  dots: true,
  nav: true,
  slideBy: 3,
 // items:3,
  responsiveClass:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:3
        }
    }
});    

$(".carousel-editorial-choice").owlCarousel({
  margin:10,
  loop:true,
  lazyLoad:true,
  dots: true,
  nav: true,
  slideBy: 3,
 // items:3,
  responsiveClass:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:3
        }
    }
});  


