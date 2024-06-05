//import statements
const express = require("express")
const Product = require("../models/product")
const User = require("../models/user")
const authenticateUser = require('../middleware/middleware')

const router = new express.Router()
//route that adds a new product
router.post('/products',authenticateUser, async(req,res)=>{
    //gets the new product from the request's body and stores it in p
    let p = new Product(req.body)
    //finds the user who has the user._id from the session
    const user = await User.findById(req.session.user_id);
    //sets the product's owner to the currently logged-in user
    p.owner = user._id;
    //saves the product to the database
    const product = await p.save();
    //as long as it successfully saved, sends back the product info in the response
    if(product){
        res.send(product)
    //otherwise, displays an error message
    }else{
        res.send({message:"Error: product could not be added!"})
    }
})
//route that gets all the products
router.get('/products',async(req,res)=>{
    //finds all products in the database and displays them as long as there is no error
    const products = await Product.find({});
    if(!products){
        res.send({message:"Error: no products found!"})
    }else{
        res.send(products);
    }
})
//route that lets a user buy an item based on passed username and item id
router.post('/products/buy',authenticateUser, async(req,res)=>{
    //stores productID info from the request
    let productID = req.body.productID;
    //first, find the buyer in the list of users to see if they are eligible to buy the item
    const buyer = await User.findById(req.session.user_id).populate('items');
    //loop to check through the buyer's items to make sure that they don't already own the item that they are trying to buy
    for(let item of buyer.items){
        //if they do own the item already, displays an error message
        if(item._id.equals(productID)){
            res.send({message:"Oops, "+buyer.name+" already owns this item!"})
            return;
        }
    }
    //finds the product on the database based on the productID
    const product = await Product.findById(productID);
    //checks that the buyer's balance is sufficient to cover the cost of the item. if it isn't, displays an error message
    if(buyer.balance < product.price){
        res.send({message:"Oops, "+buyer.name+" has insufficient funds"})
        return;
    }
    //otherwise, the item is ready to be bought/sold
    else{
        //finds the seller from the 'owner' field on the product
        const seller = await User.findById(product.owner).populate('items');
        //updates the seller's balance to reflect the cost of the product they sold
        seller.balance = seller.balance+product.price;
        //gets the index of the product form the seller's items array
        let index = seller.items.indexOf(product);
        //removes the item from the seller's items array
        seller.items.splice(index,1);
        //updates the buyer's balance to reflect the fact that they bought the item
        buyer.balance = buyer.balance - product.price;
        //adds the item to the buyer's items array
        buyer.items.push(product);
        //changes the 'owner' field of the product to now contain the buyer's ID
        product.owner = buyer._id;
        //resaves the seller, buyer, and product so that the info is updated on the database
        seller.save();
        buyer.save();
        product.save();
        //sends a success message
        res.send({message:"Transaction successful"})
    }
})
//route that deletes a product based on the passed id
router.delete('/products/:id',authenticateUser, async (req,res)=>{
    //searches for the product (based on the passed id) in the database
    const search = await Product.findById(req.params.id)
    //as long as the owner of the product is the currently logged-in user, the product can be deleted
    if(search.owner == req.session.user_id){
        //deletes the product based on the id
        const product = await Product.findByIdAndDelete(req.params.id);
        //if there is no product to be found, displays an error message
        if(!product){
            res.send({message:"Error: Product could not be located"})
        //otherwise, displays a successfully deleted message
        }else{
            res.send({message:"Successfully deleted "+product.name})
        }
    //if the owner's ID does not match the id of the currently logged-in user, displays an error message
    }else{
        res.send({message:"You are not authorized to perform this operation"})
    }
})
//exports this router
module.exports=router