$(document).ready(function(){

  var bodyWidth;

  $('.language-switcher__shutter-ru').click(function(){

    // змінюємо зовнішній вигляд мовної панелі
  	$('.language-switcher__shutter-ua').css({'width':'50%', 'left':'0%'});
    $('.language-switcher__shutter-en').css({'width':'50%', 'left':'50%'});
    $('.language-switcher__shutter-ru').css({'display':'none'});

    // змінюємо положення московського прапора
    var imageTop  = $('img.language-switcher__img[src="assets/img/ru.png"]').offset().top;
    var imageLeft = $('img.language-switcher__img[src="assets/img/ru.png"]').offset().left;
    bodyWidth     = $('body').outerWidth();

    $('img.language-switcher__img[src="assets/img/ru.png"]').remove();
    $('body').append('<img class="language-switcher__img" src="assets/img/ru.png">');
    $('img.language-switcher__img[src="assets/img/ru.png"]').css({'position'   : 'absolute',
    	                                                            'zIndex'     : 8889,
    	                                                            'top'        : imageTop - 3,
    	                                                            'left'       : imageLeft - 88,
    	                                                            'cursor'     : 'pointer'
    	                                                          });
    setTimeout(function(){
    // переміщуємо московський прапор на центр екрана зверху
    $('img.language-switcher__img[src="assets/img/ru.png"]').css({'transition' : 'left .5s',
                                                                  'left'       : bodyWidth/2})
                                                            // по кліку - приховуємо прапор та показуємо повідомлення
                                                            .bind('click mouseenter', function(){
                                                                      $(this).css({'transition' : 'top .5s',
                                                                                   'top'        : '-100%'});
                                                                      // поява підкладки
                                                                      $('.popups-section').css('display','block');

                                                                      setTimeout(function(){
                                                                        // поява спливаючого вікна
                                                                        $('#popup-no-russian-language-suppurt').css('top','20px');
                                                                        // відмальовування потрібної кількості орнаментів
                                                                        var popupHeight     = $('#popup-no-russian-language-suppurt').outerHeight(),
                                                                            ornamentHeight  = $('.small-popup__background-image').outerHeight(),
                                                                            ornamentsAmount = Math.ceil(popupHeight / ornamentHeight);
                                                                        for (var i=0; i<ornamentsAmount-1; i++) {
                                                                          $('#popup-no-russian-language-suppurt .small-popup__background').append('<img class="small-popup__background-image" src="assets/img/ornament.jpg", alt="ornament.jpg">');
                                                                        }

                                                                      },50);
                                                             });
    },100);
  });

  // навішування обробників на кнопки закриття
  $('#popup-no-russian-language-suppurt__close-button, #popup-no-russian-language-suppurt button.small-popup__button').click( function() { closeNoRussianLanguageSuppurtPopup() } );

  function closeNoRussianLanguageSuppurtPopup () {
    $('#popup-no-russian-language-suppurt').remove();
    $('.popups-section').css('display','none');
  }

});