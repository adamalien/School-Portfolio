//import statements
const mongoose = require('mongoose')
//create a productSchema which will serve as a model for our products with relevant fields
const productSchema = new  mongoose.Schema({
    name:{type:String, required:true, unique:true},
    price:{type:Number, min:0, required:true},
    owner:{type:mongoose.Schema.Types.ObjectId, ref:'User'}
})
//creates the model to be exported
const Product = mongoose.model('Product',productSchema,'products')
//exports the model
module.exports = Product