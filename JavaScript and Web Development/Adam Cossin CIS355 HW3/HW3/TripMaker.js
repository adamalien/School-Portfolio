//CIS 355 HW#3 Author: Adam Cossin
//Description: Design a page for a user to be able to make a basic plan for a trip, including how many stops there are, the distance between stops, and the weather at the final
//destination

//importing required modules
const express = require("express")
const request = require('request')
const path = require('path')
const getWeather = require('./Weather')
const generateLocations = require('./Location')
const generateTrip = require('./Trip')

const app = express()
const port = 3000
app.listen(port)

app.set('views',path.join(__dirname,'views'))
app.set('view engine','ejs')

app.use(express.urlencoded({extended: true}))
app.use(express.static('public'))

//set homepage to render index.ejs file
app.get('/',(req,res)=>{
    res.render('index.ejs')
})

//set /trip route to query the locations entered by the user, and put the list into respective functions
app.get('/trip',(req,res)=>{
    //gets query of locaitons from user
    let input = req.query.location;
    //splits the locations by ','
    let rawlocations = input.split(',');

    if(rawlocations.length<=1){
        res.send("Invalid number of locations entered!");
        return;
    }
    //calls generateLocations with the passed locations and gets back the coordinates for the locations to pass to 'generateTrip'
    generateLocations(rawlocations,(error,response)=>{
        if(error){
            console.log(error)
        }
        else{
            //calls generateTrip with the passed response object from generateLocations, this completes the tripObj which is then rendered to the index.ejs page
            generateTrip(response,(err,rs)=>{
                if(err){
                    console.log(err)
                }
                else{
                    let passedObj = rs.tripObj;
                    //re-renders index.ejs after the tripObj has been created
                    res.render('index.ejs',{passedObj:passedObj})
                }
            })
        }
    })
})

//tester function to test the calls for generateLocations and generateTrip to make sure that the correct objects are being returned
function tester(){
    //example list of locations
    let addrList = ["Empire State Building", "Yankees Stadium", "Washington Monument"]
    //calls generateLocations as previously mentioned and returns the object to be passed to generateTrip
    generateLocations(addrList, (error,response)=>{
        if(error){
            console.log(error)
        }
        else{
            console.log(response)
            //calls generateTrip with response from generateLocations as previously mentioned and returns the final tripObj
            generateTrip(response,(err,rs) =>{
                if(err){
                    console.log(err)
                }
                else{
                    console.log(rs)
                }
            })
        }
    })
}

//function to convert meters to miles (not needed here, but originally wrote here to test)
function metersToMiles(meters){
    let miles = meters/1609
    return Math.round(miles *100)/100
}

//function to convert seconds to appropriate time units (not needed here, but originally wrote here to test)
function time(seconds){
    let hours = Math.floor(seconds/3600);
    let minutes = Math.floor((seconds - (hours*3600))/60);
    let secs = Math.round(seconds - (hours*3600) - (minutes*60));
    let timeStr;
    if (hours!=0){
        timeStr = "Time: " +hours+ " hours "+ minutes.toString().padStart(2,'0')+" minutes "+secs.toString().padStart(2,'0')+" seconds";
    }
    else{
        timeStr = "Time: "+ minutes.toString().padStart(2,'0')+" minutes "+secs.toString().padStart(2,'0')+" seconds";
    }
    return timeStr;
}

//call to tester function (commented out so it wouldn't run every time js file is saved)
//tester()