"use strict";

const CustomConnection = new signalR.HubConnectionBuilder()
    .withUrl("/Notification")
    .configureLogging(signalR.LogLevel.Information)
    .build();

var connectionId = "";
var message = "";
var messageBroadCast = "";
//CustomConnection.start().catch(err => console.error(err.toString())).then(function () {
//});

//CustomConnection
//    .start()
//    .then(() => console.log("tesst"))
//    .then(() => getcustomConnectionId())
//    .catch(err => console.error(err.toString()));
CustomConnection.start().catch(err => console.error(err.toString()));

function getcustomConnectionId() {
    CustomConnection.invoke('getConnectionId')
        .then(function (connectionId) {
            CustomConnection.invoke('SendNotification', connectionId, message)
        });
}

function SendNotification() {
    CustomConnection.invoke('SendNotification', this.connectionId, message)
        .catch(err => console.log(err));
}

//Signal method invoked from server
CustomConnection.on("SendNotification", (message, connectionId) => {
    //debugger;
    //alert(message);
    success(message);
});

//var connection = new signalR.HubConnectionBuilder().withUrl("/Notification").build();

//connection.on("ReciveNotification", function (user, message) {
//    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    //var encodedMsg = user + " says " + msg;
//    //var li = document.createElement("li");
//    //li.textContent = encodedMsg;
//    //document.getElementById("messagesList").appendChild(li);
//    alert(message);
//    success();
//    info();
//    error();
//    warning();
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendNotification", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

function success(message) {
    toastr.success(message, {
        "showDuration": 30000,
    })
};

function info() {
    toastr.info('Lorem ipsum dolor sit amet, consetetur sadipscing elitr.')
};

function error() {
    toastr.error('Lorem ipsum dolor sit amet, consetetur sadipscing elitr.')
};

function warning() {
    toastr.warning('Lorem ipsum dolor sit amet, consetetur sadipscing elitr.')
};