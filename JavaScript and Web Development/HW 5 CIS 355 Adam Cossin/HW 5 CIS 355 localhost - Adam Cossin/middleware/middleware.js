const User = require("../models/user")
async function authenticateUser(req,res,next){
    if(!req.session.user_id){
        res.send({message: "This page requires you to be logged in"})
    }
    else{
        try {
            const user = await User.findById(req.session.user_id)
            req.user = user
            next()
        }
        catch(e){
            res.send(e)
        }
        
    }
}

module.exports = authenticateUser;