$(document).ready(function () {
    var down = false;

    $('#bell').click(function (e) {

        var color = $(this).text();
        if (down) {

            $('#box').css('height', '0px');
            $('#box').css('opacity', '0');
            down = false;
        } else {

            $('#box').css('height', 'auto');
            $('#box').css('opacity', '1');
            down = true;

        }

    });
    $("#img").click(function () {
        $("#val").text("");
    });

    $("#send").click(function () {
        var $nMesg = $("#val");
        $.ajax({
            url: "Notifcation/GetCountNotifcation",
            type: "Get",
                 success: function (result) {
                console.log(result);
            },
            error: function (result) {
                console.log(result);
            }
        });
    })

});











var connect = new signalR.HubConnectionBuilder().WithUrl("/chathub").build();
// Get All Notifaction For User;





connect.start();
// Send Notifcation to another User