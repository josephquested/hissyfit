(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
module.exports = (size) => {
  var board = []
  var table = document.createElement('table')
  var tableBody = document.createElement('tbody')

  for (var i = 0; i < size; i++) {
    var tr = document.createElement('tr')
    var row = []

    for (var j = 0; j < size; j++) {
      var td = document.createElement('td')
      row.push({node: td, state: "empty"})
      tr.appendChild(td)
    }
    board.push(row)
    tableBody.appendChild(tr)
  }

  table.appendChild(tableBody)
  document.getElementById('app').appendChild(table)
  return board
}

},{}],2:[function(require,module,exports){
var board = require('./generate-board')(28)

},{"./generate-board":1}]},{},[2]);
