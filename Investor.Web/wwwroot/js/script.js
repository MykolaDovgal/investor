$(document).ready(function () {
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
    
    $("#data").html('<span class="day">'+day+'</span><span class="current-date">'+currentDate+'</span>');
    
    $("#my-datepicker").val(day+' '+currentDate);
    /***/
    function numberPagination() {
        var windowSize = $(window).width();
        if (windowSize > 991) {
            number = 3;
        } else if (windowSize > 375) {
            number = 2;
        } else {
            number = 1;
        }
    }

    numberPagination();
    $(window).on('resize', numberPagination);

    $('.slick-carousel').on('init', function () {
        $('.slick-carousel').css({ visibility: 'visible' });
    });

    /****slider popular theme***/
    var $statusTheme = $('.paging-popular-theme');
    var $slickTheme = $('.carousel-popular-theme');

    $slickTheme.on('init reInit afterChange', function (event, slick, currentSlide, nextSlide) {
        var i = (currentSlide ? currentSlide : 0) + number;
        if (i > slick.slideCount) {
            $statusTheme.text(slick.slideCount + '/' + slick.slideCount);
        } else {
            $statusTheme.text(i + '/' + slick.slideCount);
        }
    });
    $slickTheme.slick({
        infinite: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        arrows: true,
        responsive: [
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 375,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });
    /*******/

    /***slider editorial choice***/
    var $statusChois = $('.paging-editorial-choice');
    var $slickChois = $('.carousel-editorial-choice');

    $slickChois.on('init reInit afterChange', function (event, slick, currentSlide, nextSlide) {
        var i = (currentSlide ? currentSlide : 0) + number;
        if (i > slick.slideCount) {
            $statusChois.text(slick.slideCount + '/' + slick.slideCount);
        } else {
            $statusChois.text(i + '/' + slick.slideCount);
        }
    });

    $slickChois.slick({
        infinite: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        arrows: true,
        responsive: [
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 375,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });
    /********/

    var $slickBlog = $('.carousel-top-blog');
    var $statusBlog = $('.paging-blog');

    $slickBlog.on('init reInit afterChange', function (event, slick, currentSlide, nextSlide) {
        var i = (currentSlide ? currentSlide : 0) + number;
        if (i > slick.slideCount) {
            $statusBlog.text(slick.slideCount + '/' + slick.slideCount);
        } else {
            $statusBlog.text(i + '/' + slick.slideCount);
        }
    });

    $slickBlog.slick({
        infinite: false,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 3,
        arrows: true,
        responsive: [
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 375,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });

});
/*
$(document).on('change', '.btn-file :file', function() {
  var input = $(this),
  label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
  input.trigger('fileselect', [label]);
});

$('.btn-file :file').on('fileselect', function(event, label) {

  var input = $(this).parents('.input-group').find(':text'),
  log = label;

  if( input.length ) {
    input.val(log);
  } else {
    if( log ) alert(log);
  }

});
function readURL(input) {
  if (input.files && input.files[0]) {
    var reader = new FileReader();

    reader.onload = function (e) {
      $('#img-upload').attr('style', 'background-image: url('+e.target.result+');');
    }

    reader.readAsDataURL(input.files[0]);
  }
}

$("#imgInp").change(function(){
  readURL(this);
}); */

/***preview registration***/
$('.input-value').keyup(function () {
    var $this = $(this);
    var text = $this.val();
    $('.' + $this.attr('id') + '').html($this.val());

    if (text.length > 1) {
        $('.' + $this.attr('id') + '').prev('i').removeClass('d-none');
    }
    else if (text.length < 1) {
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

    if (heightTitle < 19) {
        blog.find('.text-news').removeClass('brief-description');
    }
});
/***end number of description lines***/

/***blog number of description lines***/
$('.item-all-news').each(function () {
    var blog = $(this);
    var heightTitle = blog.find('.title-news').height();

    if (heightTitle < 19) {
        blog.find('.text-news').removeClass('brief-description');
    }
});
/***end number of description lines***/

/***remove disable class***/
$('.btn-edit').click(function () {
    var nameData = $(this).parents('.block-edit').data('edit');
    var findForm = $('.edit-' + nameData).find('.form-control');

    var btnUpload = $('.edit-' + nameData).find('.upload-result');
    var fileUpload = $('.edit-' + nameData).find('#upload');

    $('.edit-' + nameData).find('button.btn-edit').attr('hidden', 'hidden');
    $('.edit-' + nameData).find('button[type="submit"]').removeAttr('hidden');

    if ($(findForm).hasClass("disabled")) {
        findForm.removeClass('disabled');
        findForm.removeAttr('disabled readonly');
        btnUpload.removeAttr('disabled');
        fileUpload.removeAttr('disabled');
    }

});
/*****/

$(function ($) {
    var path = window.location.href;
    $('.navbar-nav a').each(function () {
        if (this.href === path) {
            $(this).parent().addClass('active');
        }
    });
});
/*******************/

if ($("div").is(".grid")) {
    $('.grid').masonry({
        itemSelector: '.grid-item'
    });
};