var express = require("express");
var mongoose = require("mongoose");
var db = require("./db");
var schemas = require("./schemas");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var path = require("path");
var crypto = require("crypto");
var router = express.Router();

var app = express();

var session;

app.use(session({secret: "Shops!", resave : false, saveUninitialized : true}));
//app.use(cookieParser());
app.use(function(req, res, next){
    res.header("Access-Control-Allow-Origin", "*");
    next();
});
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true}));

app.get('/', function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/Index.html"));
});

app.get("/CustomerLogin", function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerLogin.html"));
});

app.get("/Signup", function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerSignup.html"));
});

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


    //Check to see if username chosen is already in use
    db.GetCustomer(newUsername).then(function(user){
        if(user.status == 200){
            response.status(403);
            response.send("A user with that username already exists");
        }
    });

    db.GetCustomerEmail(newEmail).then(function(user){
        if(user.status == 200){
            response.status(403);
            response.send("A user with that email address already exists");
        }
    });

    //Hashing and salting algorithms called on password

    var newUser = new schemas.User({
        username: newUsername,
        password: newPassword,
        email: newEmail
    });

    newUser.save();
    sessionData = newUser.username;
    response.status(200);
    response.send("New user created!");
})

app.listen(9000, function() {
    console.log("Listening on 9000");
});