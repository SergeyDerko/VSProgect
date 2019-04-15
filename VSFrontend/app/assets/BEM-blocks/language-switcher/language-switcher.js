$(document).ready(function(){

  // $('.language-switcher__shutter').click(function(){
  //   if ( $('.language-switcher').attr('data-language') == 'ua' ) {

  //     $(this).css('left','0%');
  //     $('.language-switcher').attr('data-language', 'en');
  //   } else {
  //     $(this).css('left','33.33%');
  //     $('.language-switcher').attr('data-language', 'ua');
  //   }

  // });

  $('.language-switcher__shutter-ua').click(function(){
    $('.language-switcher__shutter-ua').css('height','.1px');
    $('.language-switcher__shutter-en').css('height','100%');
    $('.language-switcher').attr('data-language', 'ua');
  });

  $('.language-switcher__shutter-en').click(function(){
  	$('.language-switcher__shutter-ua').css('height','100%');
    $('.language-switcher__shutter-en').css('height','.1px');
    $('.language-switcher').attr('data-language', 'en');
  });

});