$(document).ready(function(){
  // setInterval - щоб пункти меню не з'їжджалися докупи в центрі (через картинку лампоки, яка періодично не встигає
  // відмалюватися)
  setInterval(function(){
    navPositioning()
  },4);


  //hover-ефект
  $('.main-navigation-link').on({
    mouseenter: function(){
      // запалювання лампочки
      $('.light-glaring').css('opacity','1');
      // підсвічування тла
      $('.index-section__bg-content-cover').css('background-color','rgba(0,0,0,.4)');
    },
    mouseleave: function(){
      // виключення лампочки
      $('.light-glaring').css('opacity','0');
      // затемнення тла
      $('.index-section__bg-content-cover').css('background-color','rgba(0,0,0,.5)');
    }
  });
});

$(window).resize(function(){
  navPositioning()
});



function navPositioning() {
  var lightbulbWidth = $('.lightbulb').width(),

      bodyWidth      = $('body').width();

  var tempLeft = bodyWidth/2 - $('.main-navigation-list-item:eq(0)').width()/2 + 'px';
  $('.main-navigation-list-item:eq(0)').css('left', tempLeft);

  tempLeft = (lightbulbWidth/2 + bodyWidth/2) + 15 + 'px';
  $('.main-navigation-list-item:eq(1)').css('left', tempLeft);

  tempLeft = (lightbulbWidth/2 - lightbulbWidth*0.06 + bodyWidth/2) + 15 + 'px';
  $('.main-navigation-list-item:eq(2)').css('left', tempLeft);

  tempLeft = (lightbulbWidth/2 - lightbulbWidth*0.24 + bodyWidth/2) + 15 + 'px';
  $('.main-navigation-list-item:eq(3)').css('left', tempLeft);

  var tempRight = (bodyWidth/2 + lightbulbWidth/2) + 15 + 'px';
  $('.main-navigation-list-item:eq(4)').css('right', tempRight);

  tempRight = (lightbulbWidth/2 - lightbulbWidth*0.06 + bodyWidth/2) + 15 + 'px';
  $('.main-navigation-list-item:eq(5)').css('right', tempRight);

  tempRight = (lightbulbWidth/2 - lightbulbWidth*0.24 + bodyWidth/2) + 15 + 'px';
  $('.main-navigation-list-item:eq(6)').css('right', tempRight);
}