$('document').ready(function () {
    $('#btn').click(function () {
        $('#text').text("Welcome to my jquery");
        $('#text').addClass("redtext");
    });

    $("#hidebtn").click(function () {
        $("#text").toggle(1000);
    });
});