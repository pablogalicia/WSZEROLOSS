$(function () {

    $('.translate').click(function () {
        var lang = $(this).attr('id');
        $('.lang').each(function (index, element) {
            $(this).text(arrleng[lang][$(this).attr('key')])
        })
    })
});




