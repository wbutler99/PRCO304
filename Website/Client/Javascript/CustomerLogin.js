window.onload = function(){
    $("#errorBox").css("visibility", "hidden");
    $("#logInForm").submit(function(web){
        web.preventDefault();
        var username = $("#username").val();
        var password = $("#password").val();

        var post = $.post("http://localhost:9000/Customer/login", {"username": username, "password": password}).always(function(){});
        alert("Logging you in...");
        post.done(function(data, text, res){
            alert(data);
            if(res.status == 200)
            {
                //alert("Welcome " + data.username + "!");
                //$.get("http://localhost:9001/CustomerAuth", {username});
                window.location.href = "CustomerHome.html";
            }
        });
    });
}



