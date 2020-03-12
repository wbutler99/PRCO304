var express = require("express");
var mongoose = require("mongoose");
var db = require("./db");
var schemas = require("./schemas");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var bcrypt = require("bcrypt");
var router = express.Router();

var app = express();

var customerSession;
var staffSession;
var uri = "mongodb://localhost:27017/CSSDB";
var saltRounds = 10;

app.use(session({secret: "Shops!", resave : false, saveUninitialized : true}));
//app.use(cookieParser());
app.use(function(req, res, next){
    res.header("Access-Control-Allow-Origin", "*");
    next();
});
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true}));

app.get("/Customer", function(request, response){
    var username = customerSession;

    db.GetCustomer(username).then(function(customer){
        customer.customerHashedPassword = undefined;
        response.setHeader("Content-Type", "application/json");
        response.status(200);
        response.send(customer);
    });
})

app.post("/Customer/Signup", function(request, response){
    var newUsername = request.body.username;
    var newPassword = request.body.password;
    var newEmail = request.body.email;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newDateOfBirth = request.body.dateOfBirth;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;

    var repeatCheckUsername = 0;
    var repeatCheckEmail = 0;

    var salt = bcrypt.genSaltSync(saltRounds);
    var hash = bcrypt.hashSync(newPassword, salt);

    var newCustomer = new schemas.Customer({
        username: newUsername,
        customerHashedPassword: hash,
        email: newEmail,
        firstName: newFirstName,
        lastName: newLastName,
        DOB: newDateOfBirth,
        addressLineOne: newAddressLineOne,
        addressLineTwo: newAddressLineTwo,
        postcode: newPostcode
    });

    newCustomer.save();
    //app.session = newCustomer.username;
    //sessionData = newCustomer.username; TODO: FIX SESSION DATA!!
    console.log("New User: " + newUsername + " created!");
    response.status(200);
    response.send("Sign up complete. Please log in to continue.");
    
});

app.post("/Customer/Login", function(request, response){
    var inputUsername = request.body.username;
    var inputPassword = request.body.password;

    db.GetCustomer(inputUsername).then(function(authuser){
        var hash = authuser.customerHashedPassword;
        bcrypt.compare(inputPassword, hash, function(err, result){
            if (result == true)
            {
                console.log("Successful login by: " + inputUsername);
                customerSession = inputUsername;
                response.status(200);
                response.send("Welcome " + inputUsername);
            }
            else
            {
                console.log("Attempted login by: " + inputUsername);
                response.status(401);
                response.send("Login failed. Check your credentials and try again.");
            }
        });
    });
});

app.post("/Customer/Update", function(request, response){
    var newEmail = request.body.email;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;

    var updatedCustomer = {
        $set:
        {
            email : newEmail,
            firstName : newFirstName,
            lastName : newLastName,
            addressLineOne : newAddressLineOne,
            addressLineTwo : newAddressLineTwo,
            postcode : newPostcode
        }
    }

    db.UpdateCustomer(customerSession, updatedCustomer).then(function(res){
        response.sendStatus(200);
    });
});

app.post("/Customer/UpdatePassword", function(request, response){
    var oldPassword = request.body.oldPassword;
    var newPassword = request.body.newPassword;

    db.GetCustomer(customerSession).then(function(customer){
        var password = customer.customerHashedPassword;
        bcrypt.compare(oldPassword, password, function(err, result){
            if(result == true)
            {
                var salt = bcrypt.genSaltSync(saltRounds);
                var hash = bcrypt.hashSync(newPassword, salt);
                var updatedCustomer = {
                    $set:
                    {
                        customerHashedPassword : hash
                    }
                }

                db.UpdateCustomer(customerSession, updatedCustomer).then(function(res){
                    response.sendStatus(200);
                })
            }
            else
            {
                response.status(401);
                response.send("Authentication failed. Please check your credentials and try again.");
            }
        });
    });
});



app.get("/Staff", function(request, response){
    var username = staffSession;

    db.GetStaff(username).then(function(staff){
        staff.staffHashedPassword = undefined;
        response.setHeader("Content-Type", "application/json");
        response.status(200);
        response.send(staff);
    })
});

app.post("/Staff/Signup", function(request, response){
    var newUsername = request.body.username;
    var newPassword = request.body.password;
    var newEmail = request.body.emailAddress;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newDateOfBirth = request.body.DOB;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;
    var newJobRole = request.body.jobRole;
    var newAccountNo = request.body.accountNo;
    var newSortCode = request.body.sortCode;
    var newShopId = request.body.shopId;

    var salt = bcrypt.genSaltSync(saltRounds);
    var hash = bcrypt.hashSync(newPassword, salt);

    var newStaff = new schemas.Staff({
        username: newUsername,
        staffHashedPassword: hash,
        email: newEmail,
        firstName: newFirstName,
        lastName: newLastName,
        DOB: newDateOfBirth,
        addressLineOne: newAddressLineOne,
        addressLineTwo: newAddressLineTwo,
        postcode: newPostcode,
        jobRole: newJobRole,
        sortCode: newSortCode,
        accountNo: newAccountNo,
        shopId: newShopId
    });

    newStaff.save();
    console.log("New Staff Member: " + newUsername + " created!");
    response.status(200);
    response.send("Sign up complete. Please log in to continue");
});

app.post("/Staff/Login", function(request, response){
    var inputUsername = request.body.username;
    var inputPassword = request.body.password;

    db.GetStaff(inputUsername).then(function(authuser){
        var hash = authuser.staffHashedPassword;
        bcrypt.compare(inputPassword, hash, function(err, result){
            if (result == true)
            {
                console.log("Successful Staff login by: " + inputUsername);
                staffSession = inputUsername;
                response.status(200);
                response.send("Welcome " + inputUsername);
            }
            else
            {
                console.log("Attempted Staff login by: " + inputUsername);
                response.status(401);
                response.send("Login failed. Check your credentials and try again.");
            }
        });
    });
});

app.post("Staff/Web/Update", function(request, response){
    var newEmail = request.body.email;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;

    var updatedStaff = {
        $set:
        {
            email : newEmail,
            addressLineOne : newAddressLineOne,
            addressLineTwo : newAddressLineTwo,
            postcode : newPostcode
        }
    }

    db.UpdateCustomer(staffSession, updatedStaff).then(function(res){
        response.sendStatus(200);
    });
});

app.post("Staff/UpdatePassword", function(request, response){
    var oldPassword = request.body.oldPassword;
    var newPassword = request.body.newPassword;

    db.GetStaff(staffSession).then(function(staff){
        var password = staff.staffHashedPassword;
        bcrypt.compare(oldPassword, password, function(err, result){
            if(result == true)
            {
                var salt = bcrypt.genSaltSync(saltRounds);
                var hash = bcrypt.hashSync(newPassword, salt);
                var updatedStaff = {
                    $set:
                    {
                        staffHashedPassword : hash
                    }
                }

                db.UpdateCustomer(staffSession, updatedStaff).then(function(res){
                    response.sendStatus(200);
                })
            }
            else
            {
                response.status(401);
                response.send("Authentication failed. Please check your credentials and try again.");
            }
        });
    });
});

app.post("Staff/Desktop/Update", function(request, response){

});

app.listen(9000, async function() {
    await mongoose.connect(uri, {useNewUrlParser: true, useUnifiedTopology: true});
    console.log("Connected to DB");

    console.log("Listening on 9000");
});