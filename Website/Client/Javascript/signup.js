window.onload = function(){
    $("#signUpForm").submit(function(web){
        web.preventDefault();

        var localUrl = "http://localhost:44391/api/Customers/"
        var serverUrl = "http://web.socem.plymouth.ac.uk/FYP/wbutler/api/Customers/"

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
            "Password" : password,
            "email" : email,
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
            $.ajax({
                type: "POST",
                url: serverUrl,
                contentType: 'application/json; charset=utf-8',
                body: {
                    "username": username, 
                    "customerPassword": password, 
                    "emailAddress": email, 
                    "firstName" : firstName,
                    "lastName" : lastName,
                    "dateOfBirth" : DOB,
                    "addressLineOne" : addressOne,
                    "addressLineTwo" : addressTwo,
                    "postCode" : postcode
                },
                success: function(data, text, res){
                    alert("Account created! Please log in to continue.");
                    $.get("http://localhost:9000/Login");
                },
                failure: function(data, text, res){
                    alert("Sign up failed. Please try again.");
                } 
            });
            //var post = $.post("http://localhost:44391/api/Customers/Insert", {registrationDetails}).always(function(){});


        }
        

        // post.done(function(data, text, res){
        //     console.log("Post Done!")
        //     if(res.status == 200){
        //         alert("Sign up complete.");
        //         window.location.href = "Index.html";
        //         console.log(data)
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