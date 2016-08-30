console.reset = function () {
  return process.stdout.write('\033c');
}

function update () {
  console.log("update");
  tick(update, 500)
  tick(console.reset, 1000)
}

function tick(action, time) {
  setTimeout(function () { action() }, time);
}

tick(update, 500)
