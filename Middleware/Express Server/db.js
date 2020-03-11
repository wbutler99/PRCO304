var schemas = require("./schemas");

//DB functions for customer

async function GetCustomer(username)
{
    return await schemas.Customer.findOne({"username": username});
}

async function GetCustomerEmail(email)
{
    return await schemas.Customer.findOne({"email": email});
}

async function UpdateCustomer(username, customer)
{
    return await schemas.Customer.updateOne({"username": username}, customer);
}

//DB functions for staff

async function GetStaff(username)
{
    return await schemas.Staff.findOne({"username": username});
}

async function UpdateStaff(username, staff)
{
    return await schemas.Staff.updateOne({"username": username}, staff);
}

module.exports.GetCustomer = GetCustomer;
module.exports.GetCustomerEmail = GetCustomerEmail;
module.exports.UpdateCustomer = UpdateCustomer;
module.exports.GetStaff = GetStaff;
module.exports.UpdateStaff = UpdateStaff;
