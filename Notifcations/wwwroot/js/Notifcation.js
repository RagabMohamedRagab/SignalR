"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationUserHub?userId=" + userId).build();
connection.on("sendToUser", function (Text) {

 /// here 
});

connection.start().catch(function (err) {
    return console.error(err.toString());
})