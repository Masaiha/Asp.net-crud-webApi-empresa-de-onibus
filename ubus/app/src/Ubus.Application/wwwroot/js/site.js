// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

$("#content").click(function (e) {
    e.preventDefault();
    if (window.innerWidth < 768 && $("#wrapper").hasClass("toggled")) {
        $("#wrapper").toggleClass("toggled").hide(300);
    }
});
