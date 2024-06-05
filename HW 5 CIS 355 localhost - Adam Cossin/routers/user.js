//import statements
const express = require("express")
const User = require("../models/user")
const bcrypt = require('bcrypt')
const router = new express.Router()
const authenticateUser = require('../middleware/middleware')

//route that creates a new user
router.post('/users/register',async (req,res)=>{
    //gets fields from req.body
    let username = req.body.user_name;
    let password = req.body.password;
    let name = req.body.name;
    //default balance set to 100
    let balance = 100;
    //if there is a balance supplied in req.body, sets the balance to the supplied value
    if(req.body.balance){
        balance = req.body.balance;
    }
    try {
        //hashes the user's password to store a hashed version on the database
        password = await bcrypt.hash(password,8);
        //searches through users to see if this username has already been used by an existing user
        const search = await User.findOne({user_name:username});
        //if the username already matches an existing user, sends an error message
        if(search){
            res.send({message:"Error: username already exists!"})
        }
        //otherwise, creates a new user based on the relevant fields, saves them to the database, and sends their info back as a response
        else{
            const user = new User({name:name,user_name:username,balance:balance,password:password});
            const u = await user.save();
            res.send(u);
        }
    //catches any errors
    }catch(e){
        res.send(e);
    }
})
//route that allows a user to log in. if they have the correct username + password, the user will be logged in and a session will be created with their id
router.post('/users/login',async (req,res)=>{
    //gets the username and password from req.body
    let username = req.body.user_name;
    let password = req.body.password;
    //finds the user who matches the username
    const user = await User.findOne({user_name:username});
    //if the user is not found, displays an error message
    if(!user){
        res.send({message:"Error: user could not be located!"})
        return;
    }
    //checks if the password that the user supplied matches their hashed password from the database
    const isMatch = await bcrypt.compare(password,user.password);
    //if the passwords matched, creates a session with the user's id and sends a message
    if(isMatch){
        req.session.user_id = user._id;
        res.send({message:"Successfully logged in. Welcome "+user.name})
    }
    //otherwise, means the login failed, so displays an error message
    else{
        res.send({message:"Error logging in. Incorrect username/password"});
    }
})
//route that displays a user based on the session's user_id
router.get('/users/me',authenticateUser, async (req,res)=>{
    //finds the user who has the user_id from req.session. this result will include the user's items as well
    const u = await User.findById(req.session.user_id).populate('items')
    res.send(u);
})
//route that will logout the currently logged-in user
router.post('/users/logout',authenticateUser, async(req,res)=>{
    //finds the user who has the id matching the session_id
    const u = await User.findById(req.session.user_id)
    //destroys the session and displays a message
    req.session.destroy(()=>{
        res.send({message:"Successfully logged out "+u.name})
    })
})
//route that will delete a user based on the session's user_id (a user can only delete themselves & they must be logged in to do so)
router.delete('/users/me',authenticateUser, async(req,res)=>{
    //finds the user who has the id matching the session_id along with their items and their session & deletes the user
    const u = await User.findByIdAndDelete(req.session.user_id);
    if(!u){
        //if the user cannot be located, sends this error message
        res.send({message:"User could not be located."})
    }
    else{
        //otherwise, destroys their session and displays a message
        req.session.destroy(()=>{
            res.send({message:"Successfully deleted "+u.name+"'s profile."})
        })
    }
})
//route that displays a summary of all users with their items
router.get('/summary',async(req,res)=>{
    //finds all users and their items array and displays them as long as there is no error
    const users = await User.find({}).populate('items');
    if(!users){
        res.send("Error! No users!")
    }
    else{
        res.send(users);
    }
})
//exports this router
module.exports=router