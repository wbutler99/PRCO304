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

