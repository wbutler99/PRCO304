window.onload = function(){

    $("#updatePasswordForm").submit(function(){
        var oldPassword = $("#oldpassword").val();
        var newPassword = $("#password").val();
        var confirmNewPassword = $("#confirmpassword").val();

        if(newPassword != confirmNewPassword)
        {
            alert("Your new passwords do not match! Please check your credentials and try again.");
        }
        else
        {
            var post = $.post("http://localhost:9000/Staff/UpdatePassword", {
                "oldPassword" : oldPassword,
                "newPassword" : newPassword
            }).always(function(){});
            post.done(function(data, text, res){
                if(res.status == 200)
                {
                    alert("Password updated successfully!");
                    window.location.href = "StaffAccount.html";
                }
                else
                {
                    alert("Oops! Something went wrong. Please try again.");
                }
            });
        }


    });
}