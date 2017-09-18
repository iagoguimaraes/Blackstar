
//adicionar no documento: <div class="loading"><div></div></div>

function StartLoading() {
    $('.loading').show();
}
function StopLoading() {
    $('.loading').hide();
}

$(document).bind("ajaxSend", function () {
    StartLoading();
}).bind("ajaxComplete", function () {
    StopLoading();
});

$(document).ready(function () {
    $('.loading').remove();
    $('body').prepend('<div class="loading"><div></div></div>');
});