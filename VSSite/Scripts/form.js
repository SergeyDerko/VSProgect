////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/* ↓↓↓ phone input - only for numbers ↓↓↓ */
$('#contactPhone').keypress(function(e){
  e = e || event;
  if (e.ctrlKey || e.altKey || e.metaKey) return;
  var chr = getChar(e);
  if (chr == null) return;
  if (chr < '0' || chr > '9') {
    return false;
  }
  function getChar(event) {
    if (event.which == null) {
      if (event.keyCode < 32) return null;
      return String.fromCharCode(event.keyCode) // IE
    }
    if (event.which != 0 && event.charCode != 0) {
      if (event.which < 32) return null;
      return String.fromCharCode(event.which) // остальные
    }
    return null; // специальная клавиша
  }
});
/* ↑↑↑ /phone input - only for numbers ↑↑↑ */

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/* ↓↓↓ клік на кнопку ↓↓↓ */

var markerIsEmailValid = false;

$('#submitBtn').click(function(e) {

  // валідація пошти
  var tempEmail = $('#email').val();
  if ( !isEmailValid(tempEmail) ) {
    showValidationMessage('#email');
    markerIsEmailValid = false;
    e.preventDefault();
    return
  } else {
    markerIsEmailValid = true;
  }

  // валідація назви компанії
  if ( $('#companyName').val().length < 2 ) {
      showValidationMessage('#companyName');
      e.preventDefault();
    return
  }

  // валідація прізвища/імені власника
  if ( $('#ownerName').val().length < 2 ) {
      showValidationMessage('#ownerName');
      e.preventDefault();
    return
  }

  // валідація обраного файлу лого
  if ( $('#logo').val().length == 0 ) {
      showValidationMessage('#logo');
      e.preventDefault();
    return
  }

  // валідація обраного файлу фото
  if ( $('#ownerFoto').val().length == 0 ) {
      showValidationMessage('#ownerFoto');
      e.preventDefault();
    return
  }

  // валідація інформації про власника
  if ( $('#ownerBiography').val().length < 10 ) {
      showValidationMessage('#ownerBiography');
      e.preventDefault();
    return
  }

  // валідація інформації про історію виникнення бізнесу
  if ( $('#businessHistory').val().length < 40 ) {
      showValidationMessage('#businessHistory');
      e.preventDefault();
    return
  }

  // валідація інформації про суть бізнесу
  if ( $('#businessCore').val().length < 40 ) {
      showValidationMessage('#businessCore');
      e.preventDefault();
    return
  }

  // валідація назви міста
  if ( $('#city').val().length < 2 ) {
      showValidationMessage('#city');
      e.preventDefault();
      return;
  }

  // валідація довжини телефону
  if ( $('#contactPhone').val().length < 11 ) {
      showValidationMessage('#contactPhone');
      e.preventDefault();
    return
  }

  // валідація наявності посилання на сторінку власника в соцмережі
  if ( $('#linkToOwnerSocialNetworkingWebsite').val().length < 11 ) {
      showValidationMessage('#linkToOwnerSocialNetworkingWebsite');
      e.preventDefault();
    return
  }

  // валідація на поставлену пташку
  if ( $('#loveToUkraine:checked').length != 1 ) {
      showValidationMessage('#loveToUkraine');
      e.preventDefault();
    return
  }

  // тут код для відправки форми
});

/* ↑↑↑ /клік на кнопку ↑↑↑ */

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/* ↓↓↓ перевірка правильності на input'ах ↓↓↓ */

// якщо пошта коректна - прибрати повідомлення
$('#email').keyup(function(){
  var tempEmail = $('#email').val();
  if ( isEmailValid(tempEmail) ) {
    $('#email-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#email').css({'box-shadow':'none','border-color':'lightgrey'});
    markerIsEmailValid = true;
  }
  controlValidation ();
});

// якщо назва конпанії є - прибрати повідомлення
$('#companyName').keyup(function(e){
  if ( $('#companyName').val().length > 1 ) {
    $('#companyName-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#companyName').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо є прізвище/ім'я - прибрати повідомлення
$('#ownerName').keyup(function(e){
  if ( $('#ownerName').val().length > 1 ) {
    $('#ownerName-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#ownerName').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо вказано шдях до файлу лого - прибрати повідомлення
$('#logo').change(function(e){
  if ( $('#logo').val().length > 1 ) {
    $('#logo-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#logo').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо вказано шдях до файлу фото - прибрати повідомлення
$('#ownerFoto').change(function(e){
  if ( $('#ownerFoto').val().length > 1 ) {
    $('#ownerFoto-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#ownerFoto').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо є інформація про власника - прибрати повідомлення
$('#ownerBiography').keyup(function(e){
  if ( $('#ownerBiography').val().length > 9 ) {
    $('#ownerBiography-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#ownerBiography').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо є інформація про історію виникнення бізнесу - прибрати повідомлення
$('#businessHistory').keyup(function(e){
  if ( $('#businessHistory').val().length > 39 ) {
    $('#businessHistory-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#businessHistory').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо є інформація про суть бізнесу - прибрати повідомлення
$('#businessCore').keyup(function(e){
  if ( $('#businessCore').val().length > 39 ) {
    $('#businessCore-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#businessCore').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо є назва міста - прибрати повідомлення
$('#city').keyup(function(e){
  if ( $('#city').val().length > 1 ) {
    $('#city-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#city').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо є телефон - прибрати повідомлення
$('#contactPhone').keyup(function(e){
  if ( $('#contactPhone').val().length > 10 ) {
    $('#contactPhone-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#contactPhone').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо посилання на сторінку власника в соцмережі є - прибрати повідомлення
$('#linkToOwnerSocialNetworkingWebsite').keyup(function(e){
  if ( $('#linkToOwnerSocialNetworkingWebsite').val().length > 10 ) {
    $('#linkToOwnerSocialNetworkingWebsite-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#linkToOwnerSocialNetworkingWebsite').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

// якщо пташка поставлена - прибрати повідомлення
$('#loveToUkraine-label').click(function(){
  if ( $('#loveToUkraine:checked').length == 1 ) {
    $('#loveToUkraine-error-info').css({'height': '0'});
    // підсвітка input'а
    $('#loveToUkraine').css({'box-shadow':'none','border-color':'lightgrey'});
  }
  controlValidation ();
});

/* ↑↑↑ /перевірка правильності на input'ах ↑↑↑ */

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/* ↓↓↓ FUNCTIONS DECLARATIONS ↓↓↓ */

function isEmailValid (email) {

  // повинен бути 1 символ @
  var temp = calculateCharsInStr(email, '@');
  if ( temp != 1 ) return false;

  // повинен бути мінімум 1 символ .
  var temp = calculateCharsInStr(email, '.');
  if ( temp < 1 ) return false;

  // символи @ та . не повинні бути крайніми
  if ( email.charAt(0)  == '@' ||
       email.charAt(0)  == '.' ||
       email.charAt( email.length-1 ) == '@' ||
       email.charAt( email.length-1 ) == '.' ) return false;

  // комбінація символів @. не допустима
  if ( email.indexOf('@.') != -1 ) return false;

  // після символу @ обов'язково повинен бути символ .
  var tempArr = email.split('@');
  if ( tempArr[1].indexOf('.') == -1 ) return false

  return true
}

function calculateCharsInStr(str, char) {
  var pos = count = 0;
  while (true) {
    var foundPos = str.indexOf(char, pos);
    if (foundPos == -1) break;
    count++;
    pos = foundPos + 1;
  }
  return count;
}

function showValidationMessage (obj) {
  // якщо повідомлення уже є - вийти
  var message = $(obj + '-error-info');
  if ( $(message).css('height') != '0px' ) return;

  // підсвітка input'а
  $(obj).css({'box-shadow':'0 0 5px red','border-color':'red'}).focus();
  $(document).scrollTop( $(obj).position().top + 50 );

  // показати повідомлення, вийти
  $(message).css({'height':'auto','min-height':'30px'});
  var tempHeight = $(message).css('height');
  $(message).css({'height': '0px','min-height':'0px'});
  $(message).css({'height':tempHeight});
}

function controlValidation () {
  // фінальна валідація на усе + поява подяки
  if ( markerIsEmailValid                                      &&
    $('#companyName').val().length > 1                         &&
    $('#ownerName').val().length > 1                           &&
    $('#logo').val().length > 1                                &&
    $('#ownerFoto').val().length > 1                           &&
    $('#ownerBiography').val().length > 9                      &&
    $('#businessHistory').val().length > 39                    &&
    $('#businessCore').val().length > 39                       &&
    $('#city').val().length > 1                                &&
    $('#contactPhone').val().length > 10                       &&
    $('#linkToOwnerSocialNetworkingWebsite').val().length > 10 &&
    $('#loveToUkraine:checked').length == 1 ) {

    var message = $('#thanksgiving');
    if ( $(message).css('height') != '0px' ) return;

    // показати повідомлення
    $(message).css({'height':'auto','min-height':'30px'});
    var tempHeight = $(message).css('height');
    $(message).css({'height': '0px','min-height':'0px'});
    $(message).css({'height':tempHeight});

    // підсвітка кнопки
    setTimeout(function(){
      $('#submitBtn').css({'background-color':'green','border-color':'green'});
      $(document).scrollTop( $('#submitBtn').position().top + 100 );
    },500);
  }
}

// function isNumeric(n) {
//   return !isNaN( parseFloat(n) ) && isFinite(n);
// }
/* ↑↑↑ /FUNCTIONS DECLARATIONS ↑↑↑ */

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////