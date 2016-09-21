// generate board
global.board = require('./generate-board')(28)

// spawn player
var player = require('./set-cell-state')(board[1][1], 'player')

require('./move-in-direction')(player, 2)
