window.onload = function(){
    $.get("http://localhost:9000/Customer").then(function(customer){
        $("#username").append(customer.username);
        $("#DOB").append(customer.DOB.split('T')[0]);

        $("#email").val(customer.email);
        $("#firstName").val(customer.firstName);
        $("#lastName").val(customer.lastName);
        $("#addressLineOne").val(customer.addressLineOne);
        $("#addressLineTwo").val(customer.addressLineTwo);
        $("#postcode").val(customer.postcode);
    });

    $("#updateForm").submit(function(){
        var newEmail = $("#email").val();
        var newFirstName = $("#firstName").val();
        var newLastName = $("#lastName").val();
        var newAddressLineOne = $("#addressLineOne").val();
        var newAddressLineTwo = $("#addressLineTwo").val();
        var newPostcode = $("#postcode").val();
        var post = $.post("http://localhost:9000/Customer/Update", {
            "email" : newEmail,
            "firstname" : newFirstName,
            "lastName" : newLastName,
            "addressLineOne" : newAddressLineOne,
            "addressLineTwo" : newAddressLineTwo,
            "postcode" : newPostcode
        })
        .always(function(){});
        alert("Updating your account...")
        post.done(function(data, text, res){
            if(res.status == 200)
            {
                alert("Account updated successfully!");
                window.location.href = "account.html";
            }
            else
            {
                alert("Oops! Something went wrong. Please try again.");
            }
        });
    });
}