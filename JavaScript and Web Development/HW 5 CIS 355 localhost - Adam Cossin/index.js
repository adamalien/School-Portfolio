//Author:Adam Cossin
//CIS 355 HW 5
//Date: 4/21/22
//Description: App that works as a marketplace using MongoDB to store/update data and includes user authentication to ensure that only eligible users can access certain routes
require('dotenv').config()
const express = require("express")
const path = require('path')
const mongoose = require('mongoose')
const bcrypt = require('bcrypt')
const productRouter = require("./routers/product")
const userRouter = require("./routers/user")
const session = require('express-session')
const MongoStore = require('connect-mongo')

const app = express()
const port = process.env.PORT
app.listen(port)

const url = process.env.MONGO_URL;
//connects to the database and console.log's a message to confirm it is connected
mongoose.connect(url,{
    useNewUrlParser: true,
    useUnifiedTopology: true
},()=>console.log("Connected to DB"))

app.set('views',path.join(__dirname,'views'))
app.set('view engine','ejs')
app.use(session({
    secret: process.env.SESSION_KEY,
    resave: false,
    saveUninitialized: false,
    store: MongoStore.create({
        mongoUrl: url
    })
}))
app.use(express.urlencoded({extended: true}))
app.use(express.static('public'))
app.use(express.json())
app.use(productRouter)
app.use(userRouter)