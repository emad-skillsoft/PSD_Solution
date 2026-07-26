/// <reference path="jquery.min.js" />
(function() {
    var worker = new Worker("script/ServicesWebWorker.js");
    worker.onmessage = function (event) {
        alert(event.data);

    }

    worker.onerror = function(event) {
        console.log(event.message,event);
    };

    $("#callServices").click(function () {
        worker.postMessage("Sub");
    });
    
})();