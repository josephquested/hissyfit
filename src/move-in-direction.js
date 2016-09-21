var setCellState = require('./set-cell-state')

module.exports = (cell, direction) => {
  var newCell = require('./get-cell-by-direction')(cell, direction)
  setCellState(newCell, 'player')
  // setCellState(newCell, 'empty') // set the 'empty' color in update-cell-color 
}
