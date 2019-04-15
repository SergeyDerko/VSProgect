$(document).mouseleave(function(e){
  e = e || window.event;
  e = jQuery.event.fix(e);

  // якщо мишка вийшла за верхню межу екрана
  if (e.clientY <= 0) {

    if (!sessionStorage.getItem('popupComplimentWasShown')) {
      // поява підкладки
      $('.popups-section').css('display','block');

      setTimeout(function(){
        // поява спливаючого вікна
        $('#popup-compliment').css('top','20px');
        // відмальовування потрібної кількості орнаментів
        var popupHeight     = $('#popup-compliment').outerHeight(),
            ornamentHeight  = $('.small-popup__background-image').outerHeight(),
            ornamentsAmount = Math.ceil(popupHeight / ornamentHeight);
        for (var i=0; i<ornamentsAmount-1; i++) {
          $('.small-popup__background').append('<img class="small-popup__background-image" src="assets/img/ornament.jpg", alt="ornament.jpg">');
        }

      },50);


      // запис в sessionStorage
      sessionStorage.setItem('popupComplimentWasShown',true);
    }

  }
});

$('#popup-compliment__close-button').click( function() { closeComplimentPopup() } );

function closeComplimentPopup () {
  $('#popup-compliment').remove();
  $('.popups-section').css('display','none');
}