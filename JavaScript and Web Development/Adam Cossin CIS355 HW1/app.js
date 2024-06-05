//CIS355 HW1
//Author: Adam Cossin
//Description: Creates a platform where users can be added/removed and can add/buy items. The data is written to and then read from a 'users.json' file

//set up const variables to access minimist, fs and console-table-printer packages
const minimist = require('minimist');
const fs = require('fs');
const {printTable, Table} = require('console-table-printer');
//reads in the user-passed value from the console (after 'node app.js --')
let args = minimist(process.argv.slice(2),{});

//function to write to JSON file
function writeUsers(users){
    let JSONstr =JSON.stringify(users,null,2);
    fs.writeFileSync('./users.json',JSONstr);
}

//function to read in JSON file
function readUsers(){
    let inputFile = fs.readFileSync('users.json').toString();
    let users =JSON.parse(inputFile);
    return users;
}

//function to add a new user object to the users.json file if the username is unique, otherwise, returns a message
function addUser(args){
    //reads in document
    let users = readUsers();
    //creates a new user object
    let user = {};
    //loop to make sure that if the username isn't unique, it isn't added to the users.json file
    for(let i = 0; i<users.length; i++){
       if(users[i].user_name == args.username.toString()){
            console.log("The username is already taken. Please choose a different one.");
            return;
        }
        else{
            continue;
        }
    }
    //sets the current 'user' object's username to the user-passed value for 'username'
    user.user_name = args.username;
    //sets the current 'user' object's name to the user-passed value for 'name'
    user.name = args.name;
    //sets the current 'user' object's username to the user-passed value for 'username'
    if ('balance' in args){
        user.balance = args.balance;
    }
    else{
        user.balance = 100;
    }
    //creates an empty array 'items' for current user
    user.items = [];
    //pushes the current user into the users file
    users.push(user);
    //updates the users file to include the new user
    writeUsers(users);
}

//function to delete a user if the given username already exists
function deleteUser(args){
    let users = readUsers();
    //loop to check if the username exists, and if it does, deletes the object associated with that username, otherwise, displays an error message in console
    for(let i = 0; i< users.length; i++){
        if(users[i].user_name == args.username.toString()){
            users.splice(i,1);
            writeUsers(users);
        }
        else{
            console.log("Error: this user does not exist to be deleted!");
        }
    }
}

//creates a random integer number to be used later for ID
function randomID(){
    let users = readUsers();
    let num = Math.floor(Math.random()*100);
    return num;
}

//function to add an item to a specified user
function addItem(args){
    let users = readUsers();
    //create an item object
    let item = {};
    //use randomID function to get a random number for this item's ID
    item.id = randomID();
    //get a name and a price for this item object from user input
    item.name = args.name;
    item.price = args.price;

    //loop to put the user entered item into the items array for the user entered username(if it exists)
    for(let i = 0; i< users.length; i++){
        //initialize j
        let j = 0;
        //if the user specified username's object currently has no items in its' array, it adds the user entered item to its' array
        if(users[i].user_name == args.owner&&users[i].items.length==0){
            //this specific user's 'item' array will be updated with the values that the user entered for name and price
            users[i].items[j]=item;
            writeUsers(users);
            break;
        }
        //if the user specified username's object currently has items in its' array, it adds the user entered item to the next element in its' array
        else if(users[i].user_name == args.owner&&users[i].items.length!=0){
            j++;
            users[i].items[j] = item;
            writeUsers(users);
            break;
        }
    }
}

//function that allows a user to buy an item, updates items array of the buyer and seller accordingly, and updates the buyer and seller's balances accordingly
function buyItem(args){
    let users = readUsers();
    //creates an empty user and item object for storing temp info
    let user = {};
    let item = {};
    //creates two boolean variables to later update to true if user was found and if item was found respectively
    let foundUser = false;
    let foundItem = false;
    //first loop checks that the buyer's username exists
    for(let i = 0; i < users.length; i++){
        if(users[i].user_name == args.buyer){
            //assigns the current user object to the temp user object
            user = users[i];
            //sets foundUser to true since the user was found
            foundUser = true;
            //exits loop
            break;
        }
    }

    //second loop that checks if the buyer already owns the item, and if they do, returns an error message
    for(let i = 0; i < user.items.length; i++){
        if(user.items[i].id == args.itemid){
            console.log("You already own this item!");
            return;
        }
        else{
            
        }
    }

    //third loop checks that the item id exists, if the buyer has sufficient funds, reduces the buyer's balance by the price of the item, increases the seller's balance by the price of the item, and transfers ownership of the item
    if(foundUser == true){
        for(let i = 0; i<users.length; i++){
            for(let j = 0; j<users[i].items.length; j++){
                if(users[i].items[j].id==args.itemid){
                    foundItem = true;
                    //stores current user's item at current index into a new item object with 'id', 'name', and 'price' fields
                    item.id=args.itemid;
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

//function that creates 'username', 'name', 'balance', and 'items for sale' columns, then loops through to add each individiual user's data to a new table row
function viewUsers(){
    let users = readUsers();
    //create a new table with a title and specific column headers (and sets column header alignments)
    let t = new Table({
        title: '--User Log--',
        columns:[
            {name:"user_name", alignment: "left"},
            {name:"name", alignment:"left"},
            {name:"balance", alignment:"left"}
        ]
    })
    //loops through to add each user's respective data to a new row where each piece of data goes into the correct column
    for(let i = 0; i<users.length;i++){
        t.addRow({user_name: users[i].user_name, name: users[i].name, balance: "$"+users[i].balance, 'Items for sale': users[i].items.length})
    }
    //prints table to console
    t.printTable();
}

//function that creates 'id', 'name', 'seller', and 'price' columns in a table, then loops through to add each individual user's item array data to a new table row
function viewProducts(){
    let users = readUsers();
    //create a new table with a title and specific column headers (and sets column header alignments)
    let t = new Table({
        title: '--Product Log--',
        columns:[
            {name:"id", alignment: "left"},
            {name:"name", alignment:"left"},
            {name:"seller", alignment:"left"}
        ]
    })
    //loops through users and their items to add the respective 'id', 'name', 'seller', and 'price' to the correct columns in the table
    for(let i = 0; i<users.length;i++){
        for(let j = 0; j<users[i].items.length; j++){
            t.addRow({id: users[i].items[j].id, name: users[i].items[j].name, seller: users[i].user_name, 'price': "$"+users[i].items[j].price})
        }
    }
    //prints table to console
    t.printTable();
}

//if statements to run each function if the user calls it in console
if('addUser' in args){
    addUser(args);
}
if('deleteUser' in args){
    deleteUser(args);
}
if('addItem' in args){
    addItem(args);
}
if(args.view=="users"){
    viewUsers();
}
if(args.view=="products"){
    viewProducts();
}
if(args.view=="all"){
    viewUsers();
    viewProducts();
}
if('buy' in args){
    buyItem(args);
}
