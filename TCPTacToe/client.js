var net = require('net');
var readline = require('readline');

var client = new net.Socket();
client.connect(11001, '172.18.31.113]', function() {});

client.on('data', (data) => {
   console.log(data.toString());
});

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.on('line', (input) => {
   client.write(input);
});
