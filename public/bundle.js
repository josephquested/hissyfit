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
module.exports = (cell, direction) => {
  var rowIndex = cell.node.parentNode.rowIndex
  var cellIndex = cell.node.cellIndex

  switch (direction) {
    case 0:
      return board[rowIndex - 1][cellIndex]
    case 1:
      return board[rowIndex][cellIndex + 1]
    case 2:
      return board[rowIndex + 1][cellIndex]
    case 3:
      return board[rowIndex][cellIndex - 1]
    default:
      return cell
  }
}

},{}],3:[function(require,module,exports){
(function (global){
// generate board
global.board = require('./generate-board')(28)

// spawn player
var player = require('./set-cell-state')(board[1][1], 'player')

require('./move-in-direction')(player, 2)

}).call(this,typeof global !== "undefined" ? global : typeof self !== "undefined" ? self : typeof window !== "undefined" ? window : {})
},{"./generate-board":1,"./move-in-direction":4,"./set-cell-state":5}],4:[function(require,module,exports){
var setCellState = require('./set-cell-state')

module.exports = (cell, direction) => {
  var newCell = require('./get-cell-by-direction')(cell, direction)
  setCellState(newCell, 'player')
  // setCellState(newCell, 'empty') // set the 'empty' color in update-cell-color 
}

},{"./get-cell-by-direction":2,"./set-cell-state":5}],5:[function(require,module,exports){
module.exports = (cell, state) => {
  cell.state = state
  require('./update-cell-color')(cell)
  return cell
}

},{"./update-cell-color":6}],6:[function(require,module,exports){
var colors = {
  player: 'white'
}

module.exports = (cell) => {
  cell.node.style.backgroundColor = colors[cell.state]
}

},{}]},{},[3]);
