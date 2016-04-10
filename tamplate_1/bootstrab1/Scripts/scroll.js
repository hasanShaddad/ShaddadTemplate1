$(document).ready(function () {
    $('ul.headerbuttonul').find('a').click(function () {
      
        var $href = this.hash.substr(0);
        var $anchor = $($href).offset();
      
        $('html, body').animate({ scrollTop: $anchor.top }, 1500, 'easeInOutExpo');
    });



    //jQuery to collapse the navbar on scroll


    $(window).scroll(function () {
        if ($(".navbar").offset().top > 50) {
            $(".navbar-fixed-top").addClass("cbp-af-header-shrink");
        } else {
            $(".navbar-fixed-top").removeClass("cbp-af-header-shrink");
        }
    });


});