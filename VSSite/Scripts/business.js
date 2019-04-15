var iMenuOpen = false;
$('.search__type-btn').click(function(){
  if (iMenuOpen) {
    $('.search__type-list').css('display','none');
    iMenuOpen = false
  } else {
    $('.search__type-list').css('display','block');
    iMenuOpen = true
  }
});

$('.search__list-item').click(function(){
  var tempArrOfInputs    = $('.search__field');
  var tempArrOfListItems = $('.search__list-item');

  for (var i=0; i<tempArrOfListItems.length; i++) {
    if ( this == tempArrOfListItems[i] ) {
      $(tempArrOfInputs).css('display','none');
      $(tempArrOfInputs[i]).css('display','block');
      var imgSrc = $(this).children('.search__list-item-img-wrapper').children('img').attr('src');
      var imgAlt = $(this).children('.search__list-item-img-wrapper').children('img').attr('alt');
      $('.search__type-btn img').attr({'src':imgSrc,'alt':imgAlt});
    }
  }
  $('.search__type-list').css('display','none');
  iMenuOpen = false
});

$(document).click(function(e) {
  if ( iMenuOpen == true && event.target.className != 'search__type-btn-cover-for-click' ) {
    $('.search__type-list').css('display','none');
    iMenuOpen = false
  }
});

function showBusiness() {
  $('.popups-section').css('display','block');
  $('.popup-business').css('display','block');
}