const board = require('./Board.js');

var AllNodes = {};

module.exports = {
   Populate: function() {
      module.exports.GetNode(0);
   },

   GetNode: function(state) {
      if (state in AllNodes) {
         return AllNodes[state];
      } else {
         var n = new module.exports.Node(state);
         AllNodes[state] = n;
         n.GenChildren();

         return n;
      }
   },

   Node: function(s) {
      this.state = s;
      this.children = [[], []];
      this.winState = [
         null,
         null
      ];

      this.GenChildren = function() {
         var cb = this.GetBoard();
         var open = cb.OpenCount();
         var ws = cb.WinState();

         if (ws == ' ') {
            for (var i = 0; i < open; i++) {
               for (var turn = 0; turn < 2; turn++) {
                  var nb = this.GetBoard();
                  var np = nb.nthOpen(i);
                  nb.segs[np.row][np.col] = (turn == 0) ? 'X' : 'O';

                  var nn = module.exports.GetNode(nb.GetBoardState());
                  this.children[turn].push(nn);
               }
            }
         }
      };

      this.GetEndCount = function(turn) {
         if (this.winState[turn % 2] == null) {
            var cb = this.GetBoard();
            var ws = cb.WinState();
            var tr = {};

            tr[' '] = 0;
            tr['T'] = 0;
            tr['X'] = 0;
            tr['O'] = 0;

            if (ws == ' ') {
               this.children[turn % 2].forEach(function(child) {
                  var cc = child.GetEndCount(turn + 1);

                  tr[' '] += cc[' '];
                  tr['T'] += cc['T'];
                  tr['X'] += cc['X'];
                  tr['O'] += cc['O'];
               });
            } else {
               tr[ws] += 1;
            }

            this.winState[turn % 2] = tr;
            return tr;
         } else {
            return this.winState[turn % 2];
         }
      };

      this.GetBoard = function() {
         var tr = new board.Board();

         for (var r = 0; r < 3; r++) {
            for (var c = 0; c < 3; c++) {
               tr.segs[r][c] = this.theta(this.state, (r * 3) + c);
            }
         }

         return tr;
      };

      this.theta = function(state, pos) {
         var v = state / Math.floor(Math.pow(3, pos));
         v %= 3;

         if (v == 1)
            return 'X';
         else if (v == 2)
            return 'O';
         else
            return ' ';
      };
   }
};
