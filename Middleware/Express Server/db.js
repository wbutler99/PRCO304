var schemas = require("./schemas");

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

async function GetStaff(username)
{
    return await schemas.Staff.findOne({"username": username});
}

module.exports.GetCustomer = GetCustomer;
module.exports.GetCustomerEmail = GetCustomerEmail;
module.exports.UpdateCustomer = UpdateCustomer;
module.exports.GetStaff = GetStaff;
