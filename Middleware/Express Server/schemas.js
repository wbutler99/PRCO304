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
    storeName: String
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
    storeName: String,
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
    price: String
});

var Stock = mongoose.model("Stock", {
    productName: String,
    storeName: String,
    quantity: Number
});

var Reservation = mongoose.model("Reservation", {
    name: String,
    productName: String,
    storeName: String
});

var Shift = mongoose.model("Shift", {
    storeName: String,
    date: Date,
    username: String,
});

var Holiday = mongoose.model("Holiday", {
    holidayReference : {
        type: String,
        unique: true
    },
    storeName : String,
    username : String,
    date : Date,
    status : String,
    reason : String
});

module.exports.Customer = Customer;
module.exports.Staff = Staff;
module.exports.Shop = Shop;
module.exports.Stock = Stock;
module.exports.Delivery = Delivery;
module.exports.DeliveryItem = DeliveryItem;
module.exports.Product = Product;
module.exports.Reservation = Reservation;
module.exports.Shift = Shift;
module.exports.Holiday = Holiday;