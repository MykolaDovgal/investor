$(document).ready(function(){
    
    $('.nav-item a').click(function () {
        var path = window.location.href;
        //$(this).closest('nav-item').addClass('active-item');
        $('.nav-item a').each(function (index) {
            $('.nav-item a')[index].removeAttribute('active-item');
            });
            if ($(this).is('.nav-item a')) {
                $(this).addClass('active-item');
            }
            else {
                $(this).closest('.nav-item a').addClass('active-item');
            }
    });
});