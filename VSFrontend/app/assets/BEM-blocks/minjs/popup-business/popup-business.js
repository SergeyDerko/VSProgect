$(document).ready(function(){

  $('.popup-business__close').click(function() {
    $(this).parent().css('display','block');
    $('.popups-section').css('display','none');
    $('.popup-business__gmaps').css({'border':'1px solid transparent', 'height':'0px'});
  });

  $('.popup-business__item_btn').click(function(){
    $('.popup-business__gmaps').css({'border':'1px solid grey', 'height':'300px'});
  });

});