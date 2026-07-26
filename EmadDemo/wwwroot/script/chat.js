/// <reference path="jquery.min.js" />
/// <reference path="_namespace.js" />
(function () {
    var socket;

    if (window.WebSocket) {
        alert("Thanks For Contact US .. Press Ok to start Chating");
    }
    else {
        alert("Sorry Serviec is not aviable right Now or\n you need to upgrade browser");
    }

    socket = new WebSocket("ws://localhost:1429/Chat/ChatService.ashx");

    socket.addEventListener("open", function (evt) {
        $("#replyArea").append("connection Opened ..<br/>");
        
    },false);

    socket.addEventListener("close", function (evt) {
        $("#replyArea").append("connection Closed .. " + evt.reason + "<br/>");

    }, false);



    socket.addEventListener("message", function (evt) {
        $("#replyArea").append(evt.data + "<br/>");

    }, false);



    socket.addEventListener("error", function (evt) {

       // $("#replyArea").append("Error .. " + evt.message + "<br/>");

    }, false);


    $("#askBtn").click(function() {
        if (socket.readyState == WebSocket.OPEN) {
            socket.send($("#chatQuestion").val());
        }
        else {
            $("#replyArea").append("Underlaying connection is closed" + "<br/>");
        }
    });


    $("#closeConnection").click(function () {
        if (socket.readyState == WebSocket.OPEN) {
            socket.close();
        }
        else {
            $("#replyArea").append("Underlaying connection already closed" + "<br/>");
        }
    });

})();





