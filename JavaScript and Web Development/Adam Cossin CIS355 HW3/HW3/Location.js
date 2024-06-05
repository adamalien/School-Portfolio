const res = require('express/lib/response');
const request = require('request')

//function that takes in a list of locations and returns an object containing their respective coordinates
function generateLocations(addrList, callback){
    //initialize boolean variable to 'false' to be used later to check if all async calls have completed
    let valid = false;
    //initialize empty arrays of location Objects and urls
    let locationsObj = [];
    let urlArr = [];
    //beginning of url
    let pre = 'https://api.mapbox.com/geocoding/v5/mapbox.places/'
    //goes through the locations and populates the url array for each location
    for(let i = 0; i< addrList.length; i++){
        let search_text = addrList[i];
        //creates url for current addrList location
        urlArr[i] = pre+search_text+".json?access_token=pk.eyJ1IjoiYWRhbWFsaWVuIiwiYSI6ImNrenBzdjljdDBzZGUyeXM4dXhsczZwZ3oifQ.lNdJQmGQLVk81Pqk8bywQA";
    }
    //goes through the urls and makes calls for each one. once these calls are completed, the final object is passed to the callback function
    for(let j = 0; j<urlArr.length; j++){
        //makes a request for current url
        request({url: urlArr[j]},(error,response)=>{
            //initialize empty location object
            let location = {};
            //if there's an error, log it and send it to the cb
            if(error){
                console.log(error)
                callback({error:error},undefined)
            }
            else{
                //parse the data from the response as a JSON object
                const data = JSON.parse(response.body)
                //if the data contains key 'features', then it is valid, if it doesn't, it's invalid
                if(!data.features){
                    console.log("Invalid Location.")
                    callback({error:'Invalid Location'},undefined)
                }
                else{
                    //set lat, lon, name, and idx of location object
                    let lat=data.features[0].center[1]
                    let lon=data.features[0].center[0]
                    let name = data.features[0].place_name
                    location.idx = j;
                    location.lat = lat;
                    location.lon = lon;
                    location.name = name;
                    //push location object to locationsObj array
                    locationsObj[j] = location;
                    //loop to check that each async call has been completed
                    for(let x = 0; x < addrList.length; x++){
                        //if the locationsObj for the current element is valid, then valid=true, otherwise valid=false, so the loop breaks, and the async calls continue
                        if(locationsObj[x]){
                            valid = true;
                        }
                        else{
                            valid = false;
                            break;
                        }
                    }
                }
                //when valid DOES equal true, pass the locationsObj object to the callback
                if(valid == true){
                    callback(undefined,{locationsObj:locationsObj})
                }
            }
        })
    }
}
//export to be used in TripMaker.js
module.exports = generateLocations