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
    shopId: String
});

var Shop = mongoose.model("Shop", {
    shopId: String,
    storeName: String,
    addressLineOne: String,
    addressLineTwo: String,
    postcode: String,

});

var Delivery = mongoose.model("Delivery", {

});

var Stock = mongoose.model("Stock", {

});

module.exports.Customer = Customer;
module.exports.Staff = Staff;
module.exports.Shop = Shop;
module.exports.Stock = Stock;
module.exports.Delivery = Delivery;