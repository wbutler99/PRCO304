var mongoose = require("mongoose");

var Customer = mongoose.model("Customer", {
    username: {
        type: String,
        unique: true
    },
    customerHashedPassword: String,
    email: {
        type: String,
        unique: true
    },
    firstName: String,
    lastName: String,
    DOB: Date,
    addressLineOne: String,
    addressLineTwo: String,
    postcode: String
});

var Staff = mongoose.model("Staff", {
    username: {
        type: String,
        unique: true
    },
    staffHashedPassword: String,
    email: {
        type: String,
        unique: true,
    },
    firstName: String,
    lastName: String,
    DOB: Date,
    addressLineOne: String,
    addressLineTwo: String,
    postcode: String,
    jobRole: String,
    sortCode: String,
    accountNo: String,
    shopName: String
});

var Shop = mongoose.model("Shop", {
    storeName: {
        type: String,
        unique: true
    },
    addressLineOne: String,
    addressLineTwo: String,
    postcode: String,
});

var Delivery = mongoose.model("Delivery", {
    deliveryName: String,
    shopName: String,
    deliveryDate: Date,
    deliveryType: String,
});

var DeliveryItem = mongoose.model("DeliveryItem", {
    deliveryName: String,
    productName: String,
    quantity: Number
});

var Product = mongoose.model("Product", {
    name: {
      type: String,
      unique: true
    },
    stockType: String,
    description: String,
});

var Stock = mongoose.model("Stock", {
    productName: String,
    storeName: String,
    quantity: Number
});

module.exports.Customer = Customer;
module.exports.Staff = Staff;
module.exports.Shop = Shop;
module.exports.Stock = Stock;
module.exports.Delivery = Delivery;
module.exports.DeliveryItem = DeliveryItem;
module.exports.Product = Product;
