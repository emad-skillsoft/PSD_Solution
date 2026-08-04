// Document Object Model (DOM)

function registerValidation() {
    var txtFirstName = window.document.getElementById("first-name");
    if (txtFirstName.value.length < 10) {
        alert("First name must be at least 10 characters long.");
        return false;
    }
    else
    {
        var registerSection = document.getElementById("registerSection");
        var registerSentSection = document.getElementById("register-sent");

        registerSection.style.display = "none";
        registerSentSection.style.display = "block";

        return false;
    }


} 