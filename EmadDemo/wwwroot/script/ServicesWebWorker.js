postMessage("Web Worker Started");
self.onmessage = function(event) {
    switch (event.data) {
        case "Add":
            postMessage("Done Adding");
            break;
        case "Sub":
            postMessage("I'm working on your request");
            for (var i = 0; i < 90000000; i++) {
                var j = i;

            };
            postMessage("Done Subtracting");
            break;

    }
}