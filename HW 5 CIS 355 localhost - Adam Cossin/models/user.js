//import statements
const mongoose = require('mongoose')
const Product = require('./product')
//create a userSchema which will serve as a model for our users with relevant fields
const userSchema = new  mongoose.Schema({
    name:{type:String, required:true},
    user_name:{type:String, required:true, unique:true},
    balance:{type:Number, default:100},
    password:{type:String, required:true}
})
//create a virtual field for the user for 'items' so that the items 'owner' field will match a user's '_id' field
userSchema.virtual('items',{
    ref:'Product',
    localField:'_id',
    foreignField:'owner'
})

userSchema.set('toObject',{virtuals:true})
userSchema.set('toJSON',{virtuals:true})
//makes sure that if a user is deleted, their items are deleted along with them
userSchema.post('findOneAndDelete',function(user){
    //if a user is found when 'findOneAndDelete' is called, we delete any products that have a matching owner ID to the user's ID
    if(user){
        Product.deleteMany({owner:user._id},(error,result)=>{
            if(error)
                console.log("error is",error)
            //else
                //console.log("result is",result)
        })
    }
})
//creates the model to be exported
const User = mongoose.model('User',userSchema,'users')
//exports the model
module.exports = User