var express = require("express");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var path = require("path");
var router = express.Router();

var app = express();

app.use(function(req, res, next){
    res.header("Access-Control-Allow-Origin", "*");
    next();
});
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true}));
app.use(router);

//Routes to serve files for the website.

router.get('/', function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/Index.html"));
});

router.get("/CustomerLogin", function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerLogin.html"));
    response.sendFile(path.join(__dirname + "/Client/Javascript/CustomerLogin.js"));
});

router.get("/Signup", function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerSignup.html"));
    response.sendFile(path.join(__dirname + "/Client/Javascript/signup.js"));
});

app.listen(9001, function() {
    console.log("Listening on 9001");
});