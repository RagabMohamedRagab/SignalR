"use strict"
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
// Disabled Send button until connections is established
$("#btnSendMessage").prop("disabled", true);
connection.start().then(function () {
    $("#btnSendMessage").prop("disabled", false);
    console.log("Connection is established ChatHub");
}).catch(function (error) {
    return console.error(error.toString());
});
// Funcatinlity Client  to Server
$("#btnSendMessage").click(function (e) {
    var user = $("#txtUser").val();
    var mesg = $("#txtMessage").val();
    // To Server
    connection.invoke("SendMessageToAllUsers", user, mesg).catch(function (erro) {
        return console.error(erro.toString());
    });
    // clear message val
    $("#txtMessage").val('');
    // Focus again 
    $("#txtMessage").focus();
    e.preventDefault();
});
// Response Server to client
connection.on("ReceiveMessage", function (user, text) {
    var connect = `<br/>${user}-<br>${text}`;
    $("#messagesList").append(`<li>${connect}</li>`);
});

