var express = require("express");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var path = require("path");
var router = express.Router();

var app = express();

var productData;
var customerProductData;

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

router.get("/Products/View/:productName", function(request, response){
    productData = request.params.productName;
    response.sendFile(path.join(__dirname + "/Client/HTML/Product.html"));
});

router.get("/Customer/Products/View/:productName", function(request, response){
    customerProductData = request.params.productName;
    response.sendFile(path.join(__dirname + "/Client/HTML/CustomerProduct.html"));
});

app.get("/Product", function(request, response){
    response.status(200);
    response.send(productData);
})

app.get("/Customer/Product", function(request, response){
    response.status(200);
    response.send(customerProductData);
})

app.listen(9001, function() {
    console.log("Listening on 9001");
});