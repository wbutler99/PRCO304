var express = require("express");
var mongoose = require("mongoose");
var db = require("./db");
var schemas = require("./schemas");
var bodyParser = require("body-parser");
var cookieParser = require("cookie-parser");
var session = require("express-session");
var http = require("http");
var bcrypt = require("bcrypt");

//Initial setup

var app = express();

var customerSession;
var staffSession;
var uri = "mongodb://localhost:27017/CSSDB";
var saltRounds = 10;

app.use(session({secret: "Shops!", resave : false, saveUninitialized : true}));
//app.use(cookieParser());
app.use(function(req, res, next){
    res.header("Access-Control-Allow-Origin", "*");
    next();
});
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true}));

//Endpoints for Customer

app.get("/Customer", function(request, response){
    var username = customerSession;

    db.GetCustomer(username).then(function(customer){
        customer.customerHashedPassword = undefined;
        response.setHeader("Content-Type", "application/json");
        response.status(200);
        response.send(customer);
    });
})

app.post("/Customer/Signup", function(request, response){
    var newUsername = request.body.username;
    var newPassword = request.body.password;
    var newEmail = request.body.email;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newDateOfBirth = request.body.dateOfBirth;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;

    var repeatCheckUsername = 0;
    var repeatCheckEmail = 0;

    var salt = bcrypt.genSaltSync(saltRounds);
    var hash = bcrypt.hashSync(newPassword, salt);

    var newCustomer = new schemas.Customer({
        username: newUsername,
        customerHashedPassword: hash,
        email: newEmail,
        firstName: newFirstName,
        lastName: newLastName,
        DOB: newDateOfBirth,
        addressLineOne: newAddressLineOne,
        addressLineTwo: newAddressLineTwo,
        postcode: newPostcode
    });

    newCustomer.save();
    console.log("New User: " + newUsername + " created!");
    response.status(200);
    response.send("Sign up complete. Please log in to continue.");
    
});

app.post("/Customer/Login", function(request, response){
    var inputUsername = request.body.username;
    var inputPassword = request.body.password;

    db.GetCustomer(inputUsername).then(function(authuser){
        var hash = authuser.customerHashedPassword;
        bcrypt.compare(inputPassword, hash, function(err, result){
            if (result == true)
            {
                console.log("Successful login by: " + inputUsername);
                customerSession = inputUsername;
                response.status(200);
                response.send("Welcome " + inputUsername);
            }
            else
            {
                console.log("Attempted login by: " + inputUsername);
                response.status(401);
                response.send("Login failed. Check your credentials and try again.");
            }
        });
    });
});

app.post("/Customer/Update", function(request, response){
    var newEmail = request.body.email;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;

    var updatedCustomer = {
        $set:
        {
            email : newEmail,
            firstName : newFirstName,
            lastName : newLastName,
            addressLineOne : newAddressLineOne,
            addressLineTwo : newAddressLineTwo,
            postcode : newPostcode
        }
    }

    db.UpdateCustomer(customerSession, updatedCustomer).then(function(res){
        response.sendStatus(200);
    });
});

app.post("/Customer/UpdatePassword", function(request, response){
    var oldPassword = request.body.oldPassword;
    var newPassword = request.body.newPassword;

    db.GetCustomer(customerSession).then(function(customer){
        var password = customer.customerHashedPassword;
        bcrypt.compare(oldPassword, password, function(err, result){
            if(result == true)
            {
                var salt = bcrypt.genSaltSync(saltRounds);
                var hash = bcrypt.hashSync(newPassword, salt);
                var updatedCustomer = {
                    $set:
                    {
                        customerHashedPassword : hash
                    }
                }

                db.UpdateCustomer(customerSession, updatedCustomer).then(function(res){
                    response.sendStatus(200);
                })
            }
            else
            {
                response.status(401);
                response.send("Authentication failed. Please check your credentials and try again.");
            }
        });
    });
});

app.get("/Customer/Logout", function(request, response){
    console.log("Successful log out by: " + customerSession);
    customerSession = undefined;
    response.status(200);
    response.send("Log out Successful.");
});

//Endpoints for staff

app.get("/Staff", function(request, response){
    var username = staffSession;

    db.GetStaff(username).then(function(staff){
        staff.staffHashedPassword = undefined;
        response.setHeader("Content-Type", "application/json");
        response.status(200);
        response.send(staff);
    });
});

app.post("/Admin/Signup", function(request, response){
    var newUsername = request.body.username;
    var newPassword = request.body.password;
    var newEmail = request.body.emailAddress;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newDateOfBirth = request.body.DOB;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;
    var newJobRole = request.body.jobRole;
    var newAccountNo = request.body.accountNo;
    var newSortCode = request.body.sortCode;
    var newShopName = request.body.storeName;

    var salt = bcrypt.genSaltSync(saltRounds);
    var hash = bcrypt.hashSync(newPassword, salt);

    var newStaff = new schemas.Staff({
        username: newUsername,
        staffHashedPassword: hash,
        email: newEmail,
        firstName: newFirstName,
        lastName: newLastName,
        DOB: newDateOfBirth,
        addressLineOne: newAddressLineOne,
        addressLineTwo: newAddressLineTwo,
        postcode: newPostcode,
        jobRole: newJobRole,
        sortCode: newSortCode,
        accountNo: newAccountNo,
        storeName: newShopName
    });

    newStaff.save(); //TODO: Add fail response for unique elements
    console.log("New Staff Member: " + newUsername + " created!");
    response.status(200);
    response.send("Sign up complete. Please log in to continue");
});

app.post("/Manager/Staff/Signup", function(request, response){
    var newUsername = request.body.username;
    var newPassword = request.body.password;
    var newEmail = request.body.emailAddress;
    var newFirstName = request.body.firstName;
    var newLastName = request.body.lastName;
    var newDateOfBirth = request.body.DOB;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;
    var newJobRole = request.body.jobRole;
    var newAccountNo = request.body.accountNo;
    var newSortCode = request.body.sortCode;
    var newShopName;

    db.GetStaff(staffSession).then(function(manager){
        newShopName = manager.storeName;
    });

    var salt = bcrypt.genSaltSync(saltRounds);
    var hash = bcrypt.hashSync(newPassword, salt);

    var newStaff = new schemas.Staff({
        username: newUsername,
        staffHashedPassword: hash,
        email: newEmail,
        firstName: newFirstName,
        lastName: newLastName,
        DOB: newDateOfBirth,
        addressLineOne: newAddressLineOne,
        addressLineTwo: newAddressLineTwo,
        postcode: newPostcode,
        jobRole: newJobRole,
        sortCode: newSortCode,
        accountNo: newAccountNo,
        shopName: newShopName
    });

    newStaff.save(); //TODO: Add fail response for unique elements
    console.log("New Staff Member: " + newUsername + " created!");
    response.status(200);
    response.send("Sign up complete. Please log in to continue");
});

app.post("/Staff/Login", function(request, response){
    var inputUsername = request.body.username;
    var inputPassword = request.body.password;

    db.GetStaff(inputUsername).then(function(authuser){
        var hash = authuser.staffHashedPassword;
        bcrypt.compare(inputPassword, hash, function(err, result){
            if (result == true)
            {
                console.log("Successful Staff login by: " + inputUsername);
                staffSession = inputUsername;
                response.status(200);
                response.send(authuser);
            }
            else
            {
                console.log("Attempted Staff login by: " + inputUsername);
                response.status(401);
                response.send("Login failed. Check your credentials and try again.");
            }
        });
    });
});

app.post("/Staff/Web/Update", function(request, response){
    var newEmail = request.body.email;
    var newAddressLineOne = request.body.addressLineOne;
    var newAddressLineTwo = request.body.addressLineTwo;
    var newPostcode = request.body.postcode;

    var updatedStaff = {
        $set:
        {
            email : newEmail,
            addressLineOne : newAddressLineOne,
            addressLineTwo : newAddressLineTwo,
            postcode : newPostcode
        }
    }

    db.UpdateCustomer(staffSession, updatedStaff).then(function(res){
        response.sendStatus(200);
    });
});

app.post("/Staff/UpdatePassword", function(request, response){
    var oldPassword = request.body.oldPassword;
    var newPassword = request.body.newPassword;

    db.GetStaff(staffSession).then(function(staff){
        var password = staff.staffHashedPassword;
        bcrypt.compare(oldPassword, password, function(err, result){
            if(result == true)
            {
                var salt = bcrypt.genSaltSync(saltRounds);
                var hash = bcrypt.hashSync(newPassword, salt);
                var updatedStaff = {
                    $set:
                    {
                        staffHashedPassword : hash
                    }
                }

                db.UpdateCustomer(staffSession, updatedStaff).then(function(res){
                    response.sendStatus(200);
                })
            }
            else
            {
                response.status(401);
                response.send("Authentication failed. Please check your credentials and try again.");
            }
        });
    });
});

app.get("/Manager/Staff", function(request, response){
    db.GetStaff(staffSession).then(function(manager){
        var staffShop = manager.storeName;
        db.getShopStaff(staffShop).then(function(staffs){
            response.status(200);
            response.send(staffs);
        });
    }); 
});

app.post("/Staff/Desktop/Update", function(request, response){
    var updateUsername = request.body.username;
    var updatedSortCode = request.body.sortCode;
    var updatedAccountNo = request.body.accountNo;

    var updatedStaff = {
        $set:
        {
            sortCode : updatedSortCode,
            accountNo : updatedAccountNo
        }
    }

    db.UpdateStaff(updateUsername, updatedStaff).then(function(res){
        response.sendStatus(200);
    });
});

app.get("/Staff/Logout", function(request, response){
    console.log("Log out by: " + staffSession);
    staffSession = undefined;
    response.status(200);
    response.send("Log out Successful.");
});

//Endpoints for shops

app.get("/Shop", function(request, response){
    db.GetShops().then(function(shops){
        response.status(200);
        response.send(shops);
    });
});

app.get("/Staff/Shop", function(request, response){
    db.GetStaff(staffSession).then(function(staff){
        staffShop = staff.storeName
        db.GetShop(staffShop).then(function(shop){
            response.status(200);
            response.send(shop);
        });
    });
});

//Endpoints for stock

app.get("/Staff/Stock", function(request, response){
    db.GetStaff(staffSession).then(function(staff){
        var shop = staff.storeName;
        console.log("Stock for shop: " + shop + " Requested.");
        db.GetStock(shop).then(function(stock){
            response.status(200);
            response.send(stock);
        });
    });

});

app.get("/Customer/Stock", function(request, response){
    var shop = request.body.storeName;
    var product = request.body.productName;
    db.GetSpecificStock(shop, product).then(function(stock){
        var quantity = stock.quantity;
        response.status(200);
        response.send(quantity);
    });
});

//Endpoints for products

app.get("/Products", function(request, response){
    db.GetProducts().then(function(products){
        response.status(200);
        response.send(products);
    });
});

app.post("/Products/Search", function(request, response){
    var searchInput = request.body.searchInput;
    console.log("Search request of input: " + searchInput);
    db.SearchProducts(searchInput).then(function(products){
        response.status(200);
        response.send(products);
    });
});

app.get("/Product", function(request, response){
    var productName = request.body.productName;

    db.GetProduct(productName).then(function(product){
        response.status(200);
        response.send(product);
    });
});

//Endpoints for Deliveries

app.get("/Delivery/Shop", function(request, response){
    db.GetStaff(staffSession).then(function(staff){
        staffShop = staff.storeName
        db.GetDelivery(staffShop).then(function(delivery){
            response.status(200);
            response.send(delivery);
        });
    });
});

app.post("/Delivery/Shop/Items", function(request, response){
    var deliveryName = request.body.deliveryName;
    db.GetDeliveryItems(deliveryName).then(function(items){
        response.status(200);
        response.send(items);
    });
});

app.post("/Create/Delivery", function(request, response){
    var newDeliveryName = request.body.deliveryName;
    var newDeliveryDate = request.body.deliveryType;
    var newDeliveryStore = request.body.storeName;
    var newDeliveryType = request.body.deliveryType;

    var newDelivery = new schemas.Delivery({
        deliveryName : newDeliveryName,
        storeName : newDeliveryStore,
        deliveryDate : newDeliveryDate,
        deliveryType : newDeliveryType
    });

    newDelivery.save();

    console.log("New Delivery for: " + newDeliveryStore + " of type: " + newDeliveryType);
    response.sendStatus(200);

})

//Endpoints for Reservations

app.get("/Shop/Reservation", function(request, response){
    db.GetStaff(staffSession).then(function(staff){
        staffShop = staff.storeName
        db.GetReservations(staffShop).then(function(reservations){
            response.status(200);
            response.send(reservations);
        });
    });
});

app.post("/Create/Reservation", function(request, response){
    var product = request.body.productName;
    var shop = request.body.storeName;
    var customerName;
    db.GetCustomer(customerSession).then(function(customer){
        customerName = customer.firstName + " " + customer.lastName;
    });

    var newReservation = new schemas.Reservation({
        name : customerName,
        productName : product,
        storeName : shop
    });

    newReservation.save();
    console.log("New reservation for: " + customerName + " of: " + product);
    response.status(200);
    response.send("Reservation made. Your reservsation will be ready in 2 hours.");
});

app.get("/Customer/Reservation", function(request, response){
    db.GetCustomer(customerSession).then(function(customer){
        var customerName = customer.firstName + " " + customer.lastName;
        db.CustomerGetReservations(customerName).then(function(reservations){
            response.status(200);
            response.send(reservations);
        });
    });
});

//Endpoints for shifts

app.post("/Create/Shift", function(request, response){
    var staffMember = request.body.username;
    var date = request.body.shiftDate;
    var shop;
    db.GetStaff(staffSession).then(function(manager){
        shop = manager.storeName;
    });

    var newShift = new schemas.Shift({
        storeName: shop,
        date: date,
        username: staffMember
    });

    newShift.save();
    console.log("New shift for shop: " + shop + " for staff member: " + staffMember);
    response.status(200);
    response.send("Shift successfully added");
});

app.get("/Staff/Shift", function(request, response){
    db.GetShifts(staffSession).then(function(shifts){
        response.status(200);
        response.send(shifts);
    });
});

app.get("/Shop/Shift", function(request, response){
    db.GetStaff(staffSession).then(function(staff){
        staffShop = staff.storeName
        db.GetShopShifts(staffShop).then(function(shifts){
            response.status(200);
            response.send(shifts);
        });
    });   
});

//Endpoints for Holiday

app.get("/Shop/Holiday", function(request, response){
    db.GetStaff(staffSession).then(function(manager){
        var shop = manager.storeName;
        db.GetShopHoliday(shop).then(function(holidays){
            response.status(200);
            response.send(holidays);
        });
    });
});

app.get("/Staff/Holiday", function(request, response){
    db.GetStaffHoliday(staffSession).then(function(holidays){
        response.status(200);
        response.send(holidays);
    });
});

app.get("/Shop/Holiday/Approve", function(request, response){
    db.GetStaff(staffSession).then(function(manager){
        var shop = manager.storeName;
        db.GetShopHolidayApproval(shop).then(function(holidays){
            response.status(200);
            response.send(holidays);
        });
    });
})

app.post("/Create/Holiday", function(request, response){
    var newHolidayRef = request.body.holidayReference;
    var newHolidayStartDate = request.body.holidayStartDate;
    var newHolidayEndDate = request.body.holidayEndDate;
    var newHolidayUsername = staffSession;
    var newHolidayStatus = "Pending";
    var newHolidayReason = request.body.reason
    var newHolidayStoreName;
    db.GetStaff(staffSession).then(function(staff){
        newHolidayStoreName = staff.storeName;
    });

    var newHoliday = new schemas.Holiday({
        holidayReference : newHolidayRef,
        storeName : newHolidayStoreName,
        username : newHolidayUsername,
        startDate : newHolidayStartDate,
        endDate : newHolidayEndDate,
        status : newHolidayStatus,
        reason : newHolidayReason
    });

    newHoliday.save();
    console.log("New holiday request for shop: " + newHolidayStoreName + " Created by staff member: " + staffSession);
    response.status(200);
    response.send("Holiday Request made. Check back to see if it has been approved.");
    
});

app.post("/Update/Holiday", function(request, response){
    var updatedStatus = request.body.status;
    var updatedReference = request.body.holidayReference;


    var updatedHoliday = {
        $set:
        {
            status : updatedStatus
        }
    }

    db.UpdateHoliday(updatedReference, updatedHoliday).then(function(res){
        response.sendStatus(200);
    });
})

//Listener for requests

app.listen(9000, async function() {
    await mongoose.connect(uri, {useNewUrlParser: true, useUnifiedTopology: true});
    console.log("Connected to DB");

    console.log("Listening on 9000");
});

module.exports.app = app;