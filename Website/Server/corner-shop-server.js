var express = require("express");
var mongoose = require("mongoose");
var db = require("./db");
var schemas = require("./schemas");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var router = express.Router();

var app = express();

app.use(session({secret: "Shops!", resave : false, saveUninitialized : true}));
//app.use(cookieParser());
app.use(function(req, res, next){
    res.header("Access-Control-Allow-Origin", "*");
    next();
});
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true}));
app.use(express.static(__dirname + '/Client/HTML'));

router.get('/', function(request, response){
    response.sendFile("/Index.html");
});

app.listen(9000, function() {
    console.log("Listening on 9000");
});