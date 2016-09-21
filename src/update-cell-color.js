var colors = {
  player: 'white'
}

module.exports = (cell) => {
  cell.node.style.backgroundColor = colors[cell.state]
}
