window.onload = function(){
    $("#signUpForm").submit(function(web){
        web.preventDefault();

        var localUrl = "http://localhost:44308/api/Customers/Insert"
        var serverUrl = "http://web.socem.plymouth.ac.uk/fyp/wbutler/"

        var username = $("#username").val();
        var password = $("#password").val();
        var confirmPassword = $("#confirmPassword").val();
        var email = $("#email").val();
        var confirmEmail = $("#confirmEmail").val();
        var firstName = $("#firstName").val();
        var lastName = $("#lastName").val();
        var DOB = new Date($("#DOB").val());
        var addressOne = $("#addressOne").val();
        var addressTwo = $("#adressTwo").val();
        var postcode = $("#postcode").val();
        var registrationDetails = {
            "username" : username,
            "customerPassword" : password,
            "emailAddress" : email,
            "firstName" : firstName,
            "lastName" : lastName,
            "dateOfBirth" : DOB,
            "addressLineOne" : addressOne,
            "addressLineTwo" : addressTwo,
            "postCode" : postcode
        }
        if (email != confirmEmail){
            alert("Make sure that your email matches your confirmation email!")
        }
        else if (password != confirmPassword){
            alert("Make sure that your password matches your confirmation password!")
        }
        else{
            var post = $.ajax({
                url:localUrl,
                type: "POST",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                body: registrationDetails,
                success: function(data, textStatus, xhr){
                    window.location.href = "Index.html"
                    console.log(data)
                },
                fail: function(){
                    alert("request failed")
                }
            });
        }

        

        // post.done(function(data, text, res){
        //     console.log("Post Done!")
        //     if(res.status == 200){
        //         alert("Sign up complete.");
        //         window.location.href = "Index.html";
        //     }
        //     else if(res.status == 409){
        //         alert("A user with that username or email already exists. Please use a different username or email.");
        //     }
        //     else{
        //         alert("Oops! Something went wrong. Please try again.");
        //     }
        // });

    })
};