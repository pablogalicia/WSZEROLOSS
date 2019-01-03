$(function () {
    getmenu();
    $("#menu").html('<ul>'
    + ' <li class="active">'
    +' <a href="#" title="Dashboard"><i class="fa fa-lg fa-fw fa-home"></i> <span class="menu-item-parent">Dashboard</span></a>'
    +' <ul>'
    +' <li class="active">'
    +' <a href="index.html" title="Dashboard"><span class="menu-item-parent">Analytics Dashboard</span></a>'
    +' </li>'
    +' <li class="">'
    +' <a href="dashboard-social.html" title="Dashboard"><span class="menu-item-parent">Social Wall</span></a>'
    +' </li>'
    +' </ul>'
    +' </li>'
    +' </ul>');
});


function getmenu() {
    $.ajax({
        async: false,
        type: 'POST',
        url: '../WSLinPro.asmx/dataMenu',
        data:idrol=1,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            console.log(response);
        },
        error: function (e) {
            console.log("Error en Nivel");

        }
    });
}


