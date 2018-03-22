const fs = require('fs');

var ns = fs.readFileSync('nodes.txt').toString().split('\n');

var nodes = {};

ns.forEach(function(item) {
   if (item.length > 0) {
      var parts = item.split(' ');
      var ws0 = parts[1].split(',');
      var ws1 = parts[2].split(',');

      var nn = {
         winState: [{
            T: parseInt(ws0[0]),
            X: parseInt(ws0[1]),
            O: parseInt(ws0[2])
         },
         {
            T: parseInt(ws1[0]),
            X: parseInt(ws1[1]),
            O: parseInt(ws1[2])
         }],

         children: [[], []]
      };

      var ch = [parts[3].split(','), parts[4].split(',')];

      for (var t = 0; t < 2; t++) {
         for (var c = 0; c < ch[t].length; c++)
            if (ch[t][c].length > 0)
               nn.children[t].push(ch[t][c]);
      }

      nodes[parts[0]] = nn;
   }
});

for (var key in nodes) {
   var n = nodes[key];

   if (key == '19645')
      console.log(n);

   for (var i = 0; i < n.children[0].length; i++) {
      n.children[0][i] = nodes[n.children[0][i]];
   }

   for (var i = 0; i < n.children[1].length; i++) {
      n.children[1][i] = nodes[n.children[1][i]];
   }
}

module.exports = {
   QueryTree: function
};
