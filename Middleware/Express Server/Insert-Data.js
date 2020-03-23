var mongoose = require("mongoose");

var schemas = require("./schemas");

var uri = "mongodb://localhost:27017/CSSDB";

mongoose.connect(uri, {useNewUrlParser: true});

var newProduct = new schemas.Product({"name" : "Walker's Crisps", "stockType" : "Crisps", "Description" : "Individual packs of crisps"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Milk", "stockType" : "Milk", "Description" : "2 pints of milk"});

newProduct.save();

console.log("new product saved");

var newShop = new schemas.Shop({"storeName" : "Devon Road Corner Shop", "addressLineOne" : "36 Devon Road", "addressLineTwo" : "Plymouth", "postcode" : "PL6 5RT"});

newShop.save();

console.log("new shop saved");

var newShop = new schemas.Shop({"storeName" : "Alma Road Spar", "addressLineOne" : "56 Alma Road", "addressLineTwo" : "Plymouth", "postcode" : "PL4 7GH"});

newShop.save();

console.log("new shop saved");