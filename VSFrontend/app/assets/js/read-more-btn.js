var textElemStartHeight  = 105;
var arrOfTextElemsStatus = [];

$(document).ready(function(){

  var arrOfTextElems       = $('.infoblock__text');
  var html = '<div class="infoblock__text-cover"></div>\
              <div class="infoblock__text-btns-wrapper">\
                <button class="infoblock__text-btn" onclick="toggleInfoBlock(this)" data-close="">... читати далі</button>\
              </div>';

  for (var i=0; i<arrOfTextElems.length; i++) {
    arrOfTextElemsStatus.push(false);
    if ( $(arrOfTextElems[i]).outerHeight() > textElemStartHeight ) {
      $(arrOfTextElems[i]).append(html);
      $(arrOfTextElems[i]).css('height',textElemStartHeight);
    }
  }

});

function toggleInfoBlock(_this) {
  var THIS           = _this;
  var arrOfTextElems = $('.infoblock__text');

  for (var i=0; i<arrOfTextElems.length; i++) {

    if ( $(arrOfTextElems[i])[0] == $(THIS).parent().parent('.infoblock__text')[0] ) {

      if ( arrOfTextElemsStatus[i] == false) {
        // якщо блок закритий
        // проанімувати розкриття
        var tempStartHeight = $(THIS).parent().parent('.infoblock__text').css('height');
        $(THIS).parent().parent('.infoblock__text').css('height','auto');
        var tempFinishHeight = $(THIS).parent().parent('.infoblock__text').outerHeight() + 30;
        $(THIS).parent().parent('.infoblock__text').css('height',tempStartHeight);
        $(THIS).parent().parent('.infoblock__text').css({'height':tempFinishHeight});
        // замінити текст кнопки
        $(THIS).text('згорнути');
        // прибрати засвітлення
        $(THIS).parent().siblings('.infoblock__text-cover').css('display','none');
        // змінити прапор
        arrOfTextElemsStatus[i] = true;

        // якщо відкрито 2+ блоків - додати кнопку "закрити все"
        var count = 0;
        for(var i=0; i<arrOfTextElemsStatus.length; i++) {
          if ( arrOfTextElemsStatus[i] == true ) count++;
          // якщо відкрито 2+ блоків
          if ( count > 1 ) {
            for (var j=0; j<arrOfTextElemsStatus.length; j++) {
              // якщо блок розкритий
              if ( arrOfTextElemsStatus[j] == true) {
                // якщо в блоці ще нема кнопки "згорнути все"
                if ( $(arrOfTextElems[j]).find('button[data-closeall]').length == 0 ) {
                  $(arrOfTextElems[j]).children('.infoblock__text-btns-wrapper')
                                      .append('<button class="infoblock__text-btn" onclick="closeAllInfoBlocks()" data-closeall="">згорнути все</button>');
                }
              }
            }
            return
          }
        }

        return
      } else {
        // якщо блок розкритий
        // проанімувати закриття
        $(THIS).parent().parent('.infoblock__text').css('height', textElemStartHeight);
        // додати засвітлення
        $(THIS).parent().siblings('.infoblock__text-cover').css('display','block');
        // замінити текст кнопки
        $(THIS).text('... читати далі');
        // змінити прапор
        arrOfTextElemsStatus[i] = false;
        // якщо поруч є кнопка "згорнути все" - прибрати її
        $(arrOfTextElems[i]).find('button[data-closeall]').remove();
      }
    }
  }
}

function closeAllInfoBlocks() {
  var arrOfTextElems    = $('.infoblock__text'),
      arrOfClosebtns    = ('button[data-close]'),
      arrOfCloseAllBtns = ('button[data-closeall]');

  // видалити усі кнопки "згорнути все"
  $(arrOfCloseAllBtns).remove();
  // у кнопок "згорнути" замінити текст
  $(arrOfClosebtns).text('... читати далі');
  // повернути блокам початкову висоту
  $(arrOfTextElems).css('height',textElemStartHeight);
  // показати засвітлення
  $(arrOfClosebtns).parent().siblings('.infoblock__text-cover').css('display','block');
  // записати зміни в масиві станів
  for( var i=0; i<arrOfTextElemsStatus.length; i++ ) {
    arrOfTextElemsStatus[i] = false;
  }
}