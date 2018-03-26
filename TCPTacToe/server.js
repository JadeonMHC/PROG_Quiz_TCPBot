const net = require('net');

var clients = [];

String.prototype.hexEncode = function(){
    var hex, i;

    var result = "";
    for (i=0; i<this.length; i++) {
        hex = this.charCodeAt(i).toString(16);
        result += ("000"+hex).slice(-4);
    }

    return result
}

var server = net.createServer((socket) => {
   clients.push(socket);

   socket.game = new Game(socket);

   socket.on('data', function(data) {
      var com = data.toString();

      if (com[0] == 'N') {
         this.game.Start();
      }
      else if (com[0] == 'M') {
         this.game.ClientMove(parseInt(com[2]), parseInt(com[3]));
      }
   });

   socket.on('error', function() {

   });
});

server.listen(11000, '0.0.0.0');

const GS_NOGAME = 0;
const GS_AWAITING_TURN = 1;

function Game(socket) {
   this.socket = socket;
   this.state = GS_NOGAME;

   this.Start = function() {
      this.board = [
         [' ', ' ', ' '],
         [' ', ' ', ' '],
         [' ', ' ', ' ']
      ];

      this.state = GS_AWAITING_TURN;

      if (Rand(0, 2) == 0) {
         this.ServerMove();
      }
      else {
         this.socket.write('T');
      }
   };

   this.ServerMove = function() {
      var index = Rand(0, 40);

      for (var i = 0; index > 0; i++) {
         var r = Math.floor(i / 3) % 3;
         var c = i % 3;

         if (this.board[r][c] == ' ') {
            index--;

            if (index == 0) {
               this.board[r][c] = 'X\n';
               this.socket.write('M ' + r.toString() + c.toString() + '\n');
            }
         }
      }

      var ws = this.WinState();

      if (ws != ' ')
         this.socket.write('O ' + (ws == 'X' ? 'S' : 'C') + '\n');
      else {
         if (this.OpenCount() == 0)
            this.socket.write('O T');
         else
            this.socket.write('T');
      }
   };

   this.ClientMove = function(r, c) {
      if (r >= 0 && r < 3 && c >= 0 && c < 3) {
         if (this.board[r][c] == ' ') {
            this.board[r][c] = 'O';

            var ws = this.WinState();

            if (ws == ' ') {
               if (this.OpenCount() == 0)
                  this.socket.write('O T');
               else
                  this.ServerMove();
            }
            else {
               this.socket.write('O ' + (ws == 'X' ? 'S' : 'C'));
            }
         }
         else {
            this.socket.write('EbbMessage = Place taken\n');
         }
      }
      else {
         this.socket.write('EbbMessage = Index out of range\n');
      }
   };

   this.WinState = function() {
      var segs = this.board;

      if (segs[0][0] == segs[1][1] && segs[1][1] == segs[2][2] && segs[1][1] != ' ')
                return segs[1][1];

      if (segs[2][0] == segs[1][1] && segs[1][1] == segs[0][2] && segs[1][1] != ' ')
          return segs[1][1];

      for (var i = 0; i < 3; i++) {
          if (segs[i][0] == segs[i][1] && segs[i][1] == segs[i][2] && segs[i][0] != ' ')
              return segs[i][0];

          if (segs[0][i] == segs[1][i] && segs[1][i] == segs[2][i] && segs[0][i] != ' ')
              return segs[0][i];
      }

      return ' ';
   };

   this.OpenCount = function() {
      var tr = 0;

      for (var r = 0; r < 3; r++) {
         for(var c = 0; c < 3; c++) {
            if (this.board[r][c] == ' ')
               tr++;
         }
      }

      return tr;
   };
}

function Rand(min, max) {
    return Math.floor(Math.random() * (max - min) ) + min;
}
