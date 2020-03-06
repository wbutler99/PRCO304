var express = require("express");
var mongoose = require("mongoose");
var db = require("./db");
var schemas = require("./schemas");
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

//Routes to serve files for the website.

app.get('/', function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/Index.html"));
});

app.get("/CustomerLogin", function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerLogin.html"));
});

app.get("/Signup", function(request, response){
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerSignup.html"));
});

app.listen(9001, function() {
    console.log("Listening on 9001");
});