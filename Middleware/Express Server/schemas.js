var mongoose = require("mongoose");

var Customer = mongoose.model("Customer", {
    customerId: Number,
    username: String,
    customerHashedPassword: String,
    customerSalt: String,
    email: String,
    firstName: String,
    lastName: String,
    DOB: Date,
    addressLineOne: String,
    addressLineTwo: String,
    postcode: String
});

var Staff = mongoose.model("Staff", {
    staffId: Number,
    username: String,
    staffHashedPassword,
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
    accountNo: String
});

