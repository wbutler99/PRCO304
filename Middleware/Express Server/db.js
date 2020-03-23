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

//DB functions for shop

async function GetShops()
{
    return await schemas.Shop.find();
}

async function GetShop(name)
{
    return await schemas.Shop.findOne({"storeName" : name});
}

//DB functions for products

async function GetProducts()
{
    return await schemas.Product.find();
}

async function GetProduct(name)
{
    return await schemas.Product.findOne({"name" : name});
}

async function SearchProducts(search)
{
    return await schemas.Product.find({$text: {$search: search}});
}

//DB functions for stock

async function GetStock(shop)
{
    return await schemas.Stock.find({"storeName" : shop});
}

module.exports.GetCustomer = GetCustomer;
module.exports.GetCustomerEmail = GetCustomerEmail;
module.exports.UpdateCustomer = UpdateCustomer;
module.exports.GetStaff = GetStaff;
module.exports.UpdateStaff = UpdateStaff;
module.exports.GetShops = GetShops;
module.exports.GetShop = GetShop;
module.exports.GetProduct = GetProduct;
module.exports.SearchProducts = SearchProducts;
module.exports.GetStock = GetStock;
module.exports.GetProducts = GetProducts;
