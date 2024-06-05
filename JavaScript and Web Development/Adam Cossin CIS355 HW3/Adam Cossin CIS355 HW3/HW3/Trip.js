const request = require('request')
const getWeather = require('./Weather')

//function that takes in a list of locations and returns our final tripObj to be displayed on the browser
function generateTrip(locations, callback){
    //beginning of url
    let preDirURL = 'https://api.mapbox.com/directions/v5/mapbox/driving/'
    //initialize array of coordinates, dirURL, and tripObj object
    let coordinates = [];
    let dirURL;
    let tripObj = {};
    //populates coordinates array by getting the coordinates of each location
    for(let i = 0; i<locations.locationsObj.length; i++){
        coordinates[i] = locations.locationsObj[i].lon+","+locations.locationsObj[i].lat
    }
    //when the length of the coordinates array is the same as the original locations passed, then that means all of the coordinates are loaded
    if(coordinates.length == locations.locationsObj.length) {
        //final url to be passed to the request
        dirURL = preDirURL+coordinates.join(';')+"?access_token=pk.eyJ1IjoiYWRhbWFsaWVuIiwiYSI6ImNrenBzdjljdDBzZGUyeXM4dXhsczZwZ3oifQ.lNdJQmGQLVk81Pqk8bywQA"
        //console.log(dirURL);
    }
    //makes a request for the dirURL
    request({url: dirURL},(error,response)=>{
        if(error){
            console.log(error)
            callback({error:error},undefined)
        }
        else{
            //parse the response.body to JSON
            const data = JSON.parse(response.body)
            //if the data doesn't contain 'routes' key, it's invalid, so returns an error
            if(!data.routes){
                console.log("Oops, something went wrong!")
                callback({error:'Oops, something went wrong!'},undefined)
            }
            else{
                //gets total duration of the route
                tripObj.duration = data.routes[0].duration;
                //gets the total distance of the route
                tripObj.distance = data.routes[0].distance;
                //initialize an empty array of 'legs' for the trip
                tripObj.legs = [];
                //loops through the 'waypoints' from the response object from the api
                for(let i = 0; i < data.waypoints.length; i++){
                    //initialize an empty obj
                    let obj = {}
                    //checks if i+1 is valid (meaning there would be a valid start/stop pair)
                    if(i+1 < data.waypoints.length){
                        //populates obj with start and stop for each pair of locations
                        obj.start = locations.locationsObj[i];
                        obj.stop = locations.locationsObj[i+1];
                        //adds the obj to the legs array of the tripObj
                        tripObj.legs.push(obj)
                        //sets distance, duration, and summary for the 'legs' of the tripObj
                        tripObj.legs[i].distance = data.routes[0].legs[i].distance
                        tripObj.legs[i].duration = data.routes[0].legs[i].duration
                        tripObj.legs[i].summary = data.routes[0].legs[i].summary
                    }
                }
                //gets temp values for the last location's lat and lon in order to pass to 'getWeather'
                let lastIndex = locations.locationsObj.length-1;
                let tempLat = locations.locationsObj[lastIndex].lat;
                let tempLon = locations.locationsObj[lastIndex].lon;
                //initialize empty tripObj 'weather' obj
                tripObj.weather = {}
                //calls getWeather and passes the previously initailized lat an lon for the final destination's weather
                getWeather(tempLat, tempLon, (error, response)=>{
                    if(error){
                        console.log(error)
                    }
                    else{
                        //populates the tripObj's 'weather' obj for 'temp' and 'real' values
                        tripObj.weather.temp = response.temp;
                        tripObj.weather.real = response.real;
                    }
                    //console.log(tripObj)
                    //sends the final tripObj to the callback
                    callback(undefined,{tripObj:tripObj})
                })
            }
        }
    })
}
//export to be used in TripMaker.js
module.exports = generateTrip