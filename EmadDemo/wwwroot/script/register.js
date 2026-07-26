/// <reference path="jquery.min.js" />
/// <reference path="_namespace.js" />

treyresearch.register = (function () {

    /****************************************************************************/
    /*                                  Form Animation                          */
    /****************************************************************************/
    var section = document.getElementById("registerSection");
    var form = section.querySelector("form");
    var sent = document.getElementById("register-sent");

    var formSubmitting = function (event) {
        event.preventDefault();
        form.classList.add("sending");
    };

    var animationEnded = function () {
        section.style.display = "none";
        sent.style.display = "block";
    };

    form.addEventListener("submit", formSubmitting, false);
    form.addEventListener("MSAnimationEnd", animationEnded, false);
    

    /****************************************************************************/

    var submitValidation=function() {
        //window.alert("hi from button");

        //////////////////////////////////////
        //Validate first must not greater than
        //10 charaters
        var firstNameObj = window.document.getElementById("first-name");
        //window.alert(firstNameObj.value.length);

        if (firstNameObj.value.length > 10) {
            window.alert("Sorry, first name cannot exceed 10 Letters");
            return false;
        }
        else {
            return true;
        }

    }

    var submitValidationJQuery = function () {
        
        //window.alert("hi from button");

        //////////////////////////////////////
        //Validate first must not greater than
        //10 charaters
        //var firstNameObj = window.document.getElementById("first-name");
        //window.alert(firstNameObj.value.length);

        var firstNameObj = $("#first-name");

        if (firstNameObj.val().length > 10) {
            window.alert("Sorry, first name cannot exceed 10 Letters");
            return false;
        }
        else {
            sessionStorage.clear();
            return true;
        }

    }

    var readProfileImage = function() {
        var reader = FileReader();

        reader.onload = function (e) {
            
            var imgObj = document.getElementById("profileImage");

            imgObj.src = e.target.result;
        };

        reader.onerror = function () {
            alert("cannot load binary file");
        };

        var fileObj = document.getElementById("profileImageFile");
        

        reader.readAsDataURL(fileObj.files[0]);
    }

    /****************************************************************************/


    var load = function () {
        var firstName = sessionStorage.getItem("firstName");
        $("#first-name").val(firstName ? firstName : "");

        var website = sessionStorage.getItem("website");
        $("#website").val(website ? website : "");






    }
    var addSessionEventHandlers = function () {
        $("#first-name").change(function () {
            //alert($(this).val());
            sessionStorage.setItem("firstName", $(this).val());
        });
        $("#website").change(function () {
            //alert($(this).val());
            sessionStorage.setItem("website", $(this).val());
        });
    }

    ///////////////////////////////////////
    //calling Initializers
    load();
    addSessionEventHandlers();




    ////////////////////////////////////////////
    //returning object of register to be used
    //by the page
    return {
        submitValidation: submitValidation,
        submitValidationJQuery: submitValidationJQuery,
        readProfileImage:readProfileImage
    }

})();



