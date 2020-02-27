var express = require("express");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var path = require("path");
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

app.listen(9000, function() {
    console.log("Listening on 9000");
});