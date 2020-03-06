window.onload = function(){
    $("#signUpForm").submit(function(web){
        web.preventDefault();

        var localUrl = "http://localhost:9000/Customer/Signup"

        var username = $("#username").val();
        var password = $("#password").val();
        var confirmPassword = $("#confirmPassword").val();
        var email = $("#email").val();
        var confirmEmail = $("#confirmEmail").val();
        var firstName = $("#firstName").val();
        var lastName = $("#lastName").val();
        var DOB = new Date($("#DOB").val());
        var addressOne = $("#addressOne").val();
        var addressTwo = $("#addressTwo").val();
        var postcode = $("#postcode").val();

        if (email != confirmEmail){
            alert("Make sure that your email matches your confirmation email!")
        }
        else if (password != confirmPassword){
            alert("Make sure that your password matches your confirmation password!")
        }
        else{
            var post = $.post(localUrl, {            
                "username" : username,
                "password" : password,
                "email" : email,
                "firstName" : firstName,
                "lastName" : lastName,
                "dateOfBirth" : DOB,
                "addressLineOne" : addressOne,
                "addressLineTwo" : addressTwo,
                "postcode" : postcode
            }).always(function(){});


        }
        

        post.done(function(data, text, res){
            console.log("Post Done!")
            if(res.status == 200){
                alert("Sign up complete.");
                //window.location.href = "http://localhost:9001/Home";
                console.log(data)
            }
            else if(res.status == 404){
                alert("A user with that username or email already exists. Please use a different username or email.");
            }
            else{
                alert("Oops! Something went wrong. Please try again.");
            }
        });

    })
};