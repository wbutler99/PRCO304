var mongoose = require("mongoose");

var schemas = require("./schemas");

var uri = "mongodb://localhost:27017/CSSDB";

mongoose.connect(uri, {useNewUrlParser: true});

var newProduct = new schemas.Product({"name" : "Runner's Crisps", "stockType" : "Crisps", "description" : "Individual packs of crisps", "price" : "£0.60"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Milk", "stockType" : "Milk", "description" : "2 pints of milk", "price" : "£1.00"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Tomato Soup", "stockType" : "Canned", "description" : "A tin of tomato soup", "price" : "£0.55"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Ravioli", "stockType" : "Canned", "description" : "A tin of Ravioli", "price" : "£0.55"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Cola", "stockType" : "Drinks", "description" : "A 300ml can of cola", "price" : "£1.55"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Lemonade", "stockType" : "Drinks", "description" : "A 300ml can of lemonade", "price" : "£1.25"});

newProduct.save();

console.log("new product saved");

var newProduct = new schemas.Product({"name" : "Orangeade", "stockType" : "Drinks", "description" : "A 300ml can of orangeade", "price" : "£1.25"});

newProduct.save();

console.log("new product saved");

var newShop = new schemas.Shop({"storeName" : "Devon Road Corner Shop", "addressLineOne" : "36 Devon Road", "addressLineTwo" : "Plymouth", "postcode" : "PL6 5RT"});

newShop.save();

console.log("new shop saved");

var newShop = new schemas.Shop({"storeName" : "Alma Road Spar", "addressLineOne" : "56 Alma Road", "addressLineTwo" : "Plymouth", "postcode" : "PL4 7GH"});

newShop.save();

console.log("new shop saved");

var newStock = new schemas.Stock({"productName": "Milk", "storeName" : "Alma Road Spar", "quantity" : 5});

newStock.save();

console.log("new stock saved");

var newStock = new schemas.Stock({"productName": "Lemonade", "storeName" : "Alma Road Spar", "quantity" : 15});

newStock.save();

console.log("new stock saved");

var newStock = new schemas.Stock({"productName": "Cola", "storeName" : "Alma Road Spar", "quantity" : 1});

newStock.save();

console.log("new stock saved");

var newStock = new schemas.Stock({"productName": "Runner's Crisps", "storeName" : "Alma Road Spar", "quantity" : 4});

newStock.save();

console.log("new stock saved");

var newStock = new schemas.Stock({"productName": "Tomato Soup", "storeName" : "Devon Road Corner Shop", "quantity" : 50});

newStock.save();

console.log("new stock saved");

var newStock = new schemas.Stock({"productName": "Ravioli", "storeName" : "Devon Road Corner Shop", "quantity" : 50});

newStock.save();

console.log("new stock saved");

var newStock = new schemas.Stock({"productName": "Milk", "storeName" : "Devon Road Corner Shop", "quantity" : 10});

newStock.save();

console.log("new stock saved");

var newDeliveryItem = new schemas.DeliveryItem({"deliveryName" : "Grocery Alma Road", "productName" : "Cola", "quantity" : 20});

newDeliveryItem.save();

console.log("new delivery item saved");

var newDeliveryItem = new schemas.DeliveryItem({"deliveryName" : "Grocery Alma Road", "productName" : "Runner's Crisps", "quantity" : 50});

newDeliveryItem.save();

console.log("new delivery item saved");

var newDeliveryItem = new schemas.DeliveryItem({"deliveryName" : "Grocery Alma Road", "productName" : "Ravioli", "quantity" : 50});

newDeliveryItem.save();

console.log("new delivery item saved");

var newDeliveryItem = new schemas.DeliveryItem({"deliveryName" : "Grocery Alma Road", "productName" : "Tomato Soup", "quantity" : 50});

newDeliveryItem.save();

console.log("new delivery item saved");

var newReservation = new schemas.Reservation({"storeName" : "Alma Road Spar", "name" : "William Butler", "productName" : "Milk"});

newReservation.save();

console.log("new reservation saved.");