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