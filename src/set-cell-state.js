module.exports = (cell, state) => {
  cell.state = state
  require('./update-cell-color')(cell)
  return cell
}
