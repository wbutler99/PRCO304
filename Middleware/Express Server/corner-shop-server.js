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

var session;
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


app.get("/CustomerAuth", function(request, response){
    session = request.session;
    session.username = request.body.username;
    response.sendFile(path.join(__dirname + "/Client/HTML/Home.html"));
});

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

    // //Check to see if username chosen is already in use
    // repeatCheckUsername = db.GetCustomer(newUsername).then(function(result){
    //     if(result == null)
    //     {
    //         return 0;
    //     }
    //     else if(result.username == newUsername){
    //         return 1;
    //     }
    //     else 
    //     {
    //         return 0;
    //     }
    // });
    // //Check to see if email chosen is already used for an account
    // repeatCheckEmail = db.GetCustomerEmail(newEmail).then(function(result){
    //     if(result == null)
    //     {
    //         return 0;
    //     }
    //     else if(result.email == newEmail){
    //         return 1;
    //     }
    //     else
    //     {
    //         return 0;
    //     }
    // });
    if(repeatCheckEmail)
    {
        response.status(403);
        response.send("A user with that email address already exists");
    }
    else if(repeatCheckUsername)
    {
        response.status(403);
        response.send("A user with that username already exists");
    }
    else
    {
        //Hashing and salting algorithms called on password
        // var saltString = security.genRandomString(16);
        // var hashedData = security.sha512(newPassword, saltString);
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
        response.send("Sign up complete. Please log in to continue");
    }
    //console.log(response);
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
                response.status(200);
                response.send("Welcome " + inputUsername);
            }
            else
            {
                console.log("Attempted login by: " + inputUsername);
                response.status(401);
                response.send("Login failed. Check your credentials and try again.")
            }
        });
    });
});

app.listen(9000, async function() {
    await mongoose.connect(uri, {useNewUrlParser: true, useUnifiedTopology: true});
    console.log("Connected to DB");

    console.log("Listening on 9000");
});