const request = require('request')

//function that takes in a pair of lat/lon coordinates
function getWeather(lat,lon,cb) {
    const weatherKey = '1bc8e41b226c302e06c6da7a4a18c91d'
    const units = 'imperial'
    //sets up url to pass to the request
    const url = `https://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${lon}&appid=${weatherKey}&units=${units}`
    
    //make a request with the url for the destination location's lat/lon
    request({url: url}, (error, response) => {
        if(error){
            console.log(error)
            cb({error:error},undefined)
        }
        else{
            //parse the response.body as JSON
            const data = JSON.parse(response.body)
            //if the data doesn't contain a 'main' key, it's invalid, so return an error
            if(!data.main){
                console.log(data.message)
                cb({error:data.message},undefined)
            }
            else{
                //get the temp from the api and pass it to the callback
                const temp = data.main.temp
                //console.log('It is currently ' + temp + ' degrees in ' + data.name)
                cb(undefined,{temp:temp,real:data.main.feels_like})
            }
        }
    })
}

//export to be used in Trip.js/TripMaker.js
module.exports = getWeather