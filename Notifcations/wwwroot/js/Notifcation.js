"use strict"
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationUserHub?userId=" + userId).build();
connection.on("sendToUser", function (text) {
    var parent = document.getElementById("box");
    var div1 = document.createElement("div")// <div class="notifications-item"></div>
    div1.classList.add("notifications-item");
    parent.appendChild(div1);
    var div2 = document.createElement("div") // <div class="text"></div>
    div2.classList.add("text");
    div1.appendChild(div2);
    var p = document.createElement("p"); // <p><p/>
    p.textContent = text;
    div2.appendChild(p);
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});
$("#send").click(function () {
alert("Ok")
});
