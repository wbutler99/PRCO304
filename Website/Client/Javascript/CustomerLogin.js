window.onload = function(){
    $("#errorBox").css("visibility", "hidden");
    $("#logInForm").submit(function(web){
        web.preventDefault();
        var username = $("#username").val();
        var password = $("#password").val();

        var loginDetails = {
            "username" : username,
            "password" : password
        };
        var post = $.post("http://localhost:44308/api/Customers/login", {loginDetails}).always(function(){});
        alert("Logging you in...");
        post.done(function(data, text, res){
            //alert(res.status);
            if(res.status == 200)
            {
                alert("Welcome " + data.username + "!");
                $.get("http://localhost:9000/CustomerAuth", {username});
                
                
            }
            else
            {
                alert("Log in Failed. Please check your credentials and try again.");
                //$("#errorBox").css("visibility", "visible");
            }
        });
    });
}



