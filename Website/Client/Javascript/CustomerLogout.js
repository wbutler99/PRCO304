window.onload = function(){
    $("#logout").click(function(){
        $.post("http://localhost:9000/Customer/Logout").then(function(data){
            alert(data);
            window.location.href = "Index.html";
        });
    });
}