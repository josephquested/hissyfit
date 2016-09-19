var PORT = process.env.port || 3000

var express = require('express')
var app = express()

app.use(express.static(__dirname + '/public'));

app.listen(PORT)
console.log(`hissyfit active on port ${PORT}`)
