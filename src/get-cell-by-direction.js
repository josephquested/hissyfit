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
