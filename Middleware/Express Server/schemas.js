var mongoose = require("mongoose");

var Customer = mongoose.model("Customer", {
    username: String,
    customerHashedPassword: String,
    email: String,
    firstName: String,
    lastName: String,
    DOB: Date,
    addressLineOne: String,
    addressLineTwo: String,
    postcode: String
});

var Staff = mongoose.model("Staff", {
    username: String,
    staffHashedPassword: String,
    staffSalt:String,
    email: String,
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

module.exports.Customer = Customer;
module.exports.Staff = Staff;