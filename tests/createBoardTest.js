var test = require('tape')

module.exports = () => {
  test('createBoard test', (t) => {
    var actual = require('../src/createBoard.js')(3)
    var expected = [
      [{state: null}, {state: null}, {state: null}],
      [{state: null}, {state: null}, {state: null}],
      [{state: null}, {state: null}, {state: null}],
    ]
    t.same(actual, expected);
    t.end()
  })
}
