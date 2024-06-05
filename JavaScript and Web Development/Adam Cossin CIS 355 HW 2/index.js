//Author: Adam Cossin
//CIS 355 HW 2
//Description: Create routes for local server that allow users to register and/or login to their account. From there, they can
//buy items as long as their balance is sufficient and they don't already own the item. Their profile will display the items they own
//and the items that they can/can't buy from the 'marketplace'

//importing necessary modules and setting necessary parameters
const express = require("express");
const req = require("express/lib/request");
const res = require("express/lib/response");
const fs = require("fs");
const path = require('path');
const app = express();
const port = 3000;
app.listen(port);
app.set('views',path.join(__dirname,'views'))
app.set('view engine','ejs')
app.use(express.urlencoded({extended: true}))
app.use(express.static('public'))

//function to write to JSON file
function writeUsers(users){
    let JSONstr = JSON.stringify(users,null,2);
    fs.writeFileSync('users.json',JSONstr);
}
//function to read in JSON file
function readUsers(){
    let inputFile = fs.readFileSync('users.json').toString();
    let users = JSON.parse(inputFile);
    return users;
}
//home route which renders index.ejs
app.get('/',(req,res)=>{
    res.render('index.ejs',{title:"Homepage"})
})
//route for registering (when user clicks register button)
app.post('/register',(req,res)=>{
    //reads in the users from file
    let users = readUsers();
    //creates an empty user object
    let user = {};
    //sets username, name, and balance from their relevant fields on the form
    let username = req.body.username;
    let name = req.body.name;
    let balance = req.body.stBalance;
    //declare addUser function which passes in username
    function addUser(username){
        //checks for username. if the field was left blank, displays a message to the console
        if(username==""){
            console.log("Please enter a valid username!");
            res.redirect('/');
            return;
        }
        //checks for name. if the field was left blank, displays a message to the console
        if(name==""){
            console.log("Please enter a valid name!");
            res.redirect('/');
            return;
        }
        //loop to go through all users
        for(let i = 0; i<users.length; i++){
            //if the username is found in the current object, redirects to the home page (meaning the user already exists and cannot be created again)
            if(users[i].user_name == username){
                //display an error message to console
                console.log("User already exists, please pick another username!");
                res.redirect('/');
                return;
            }
            else{
                //continues the loop to check through all users
                continue;
            }
        }
        //'fills in' the info for the empty user object
        user.user_name = username;
        user.name = name;
        //if the user didn't enter a balance when they registered, gives a default balance of 100
        if(balance!=""){
            user.balance = balance;
        }
        else{
            user.balance = 100;
        }
        //initialize an empty items array for the user
        user.items = [];
        //adds the user to the users file
        users.push(user);
        //udpates the users file
        writeUsers(users);
        //redirects the newly created user to their profile
        res.redirect('/user/'+username)
    }
    //function call
   addUser(username);
})
//processes get request to render the user's profile page
app.get('/user/:username', (req,res)=>{
    //read in users
    let users = readUsers();
    //create a new user object(empty)
    let user = {};
    //loop that gets the username from the passed username and matches it to a user object from 'users.json'
    for(let i = 0; i < users.length; i++){
        if(users[i].user_name ===req.params.username){
            //populates the empty user object with user with matching username
            user = users[i];
            break;
        }
    }
    //show user's profile while passing relevant info
    res.render('profile.ejs',{username:user.user_name,name:user.name,balance:user.balance,items:user.items.length, user:user, users:readUsers()});
})
//route for logging in an existing user (when user clicks log in button)
app.post('/login', (req,res)=>{
    //reads in existing users from file
    let users = readUsers();
    let user = {};
    //gets username from 'eUsername' field on form
    let username = req.body.eUsername;
    //loop to go through all users
    for(let i = 0; i<users.length; i++){
        //checks that the user's username already exists (and is not empty) to be logged in
        if(users[i].user_name == username && username!=""){
            //if this is true, redirects to user's profile
            user = users[i];
            res.redirect('/user/'+username)
            return;
        }
        else{
            //continues through the loop to check all users
            continue;
        }
    }
    //if this is reached, it means the user was not found, so a message is printed to the console, and the user is redirected to the home page
    console.log("user not found");
    res.redirect('/');
})
//function that takes in buyer's username and item id of item to buy, allows the user to buy the item, updates items array of the buyer and seller accordingly, 
//and updates the buyer and seller's balances accordingly
function buyItem(usern, choice){
    let users = readUsers();
    //creates an empty user and item object for storing temp info
    let user = {};
    let item = {};
    //creates two boolean variables to later update to true if user was found and if item was found respectively
    let foundUser = false;
    let foundItem = false;
    //first loop checks that the buyer's username exists
    for(let i = 0; i < users.length; i++){
        if(users[i].user_name === usern){
            //assigns the current user object to the temp user object
            user = users[i];
            //sets foundUser to true since the user was found
            foundUser = true;
            //exits loop
            break;
        }
    }

    //second loop checks that the item id exists, if the buyer has sufficient funds, reduces the buyer's balance by the price of the item, 
    //increases the seller's balance by the price of the item, and transfers ownership of the item
    if(foundUser == true){
        for(let i = 0; i<users.length; i++){
            for(let j = 0; j<users[i].items.length; j++){
                if(users[i].items[j].id==choice){
                    foundItem = true;
                    //stores current user's item at current index into a new item object with 'id', 'name', and 'price' fields
                    item.id=choice;
                    item.name=users[i].items[j].name;
                    item.price=users[i].items[j].price;
                    //checks that the user can afford the item
                    if(user.balance >= item.price){
                        //updates the seller's balance
                        users[i].balance +=item.price;
                        //adds the item into the buyer's items array
                        user.items.push(item);
                        //subtracts the item price from the buyer's balance
                        user.balance -=item.price;
                        //removes the item from the seller's items array
                        users[i].items.splice(j,1);
                        console.log("Transactaion successful. Thanks for your order!");
                        //updates the users.json file
                        writeUsers(users);
                        return;
                    }
                    else{
                        //since user.balance is not greater than or equal to item.price, there are insufficient funds, and prints this to the console
                        console.log("Insufficient funds!");
                        return;
                    }
                }
                else{
                    //makes sure that all of the user's items are checked for the id, not just the first element in the array
                    continue;
                }
            }
        }
    }
    //sends error message if passed username isn't found
    if(foundUser == false){
        console.log("Error: user does not exist!");
        return;
    }
    //sends error message if passed item id isn't found
    else if(foundItem == false){
        console.log("Error: item not found!");
        return;
    }
}
//buy route to process when a user tries to buy an item
app.post('/buy', (req,res) =>{
    //gets the user's username from hidden text field on profile
   let xyz = req.body.thisUser;
   //gets the item id from the respective radio button that the user selected to purchase
   let abc = req.body.radBtn;
   //function call
   buyItem(xyz, abc);
   //redirects to their profile page (which will be updated if the purchase was successful, otherwise looks the same)
   res.redirect('/user/'+xyz);
})