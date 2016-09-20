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
