window.onload = function(){
    $("#signUpForm").submit(function(web){
        web.preventDefault();
        var username = $("#username").val();
        var password = $("#password").val();
        var email = $("#email").val();
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
        alert("Request has started!")
        var post = $.ajax({
            url:"http://localhost:44308/api/Customers",
            type: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: registrationDetails,
            success: function(data, textStatus, xhr){
                window.location.href = "Index.html"
                console.log(data)
            },
            fail: function(){
                alert("request failed")
            }
        });
        alert("Signing you up...");

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