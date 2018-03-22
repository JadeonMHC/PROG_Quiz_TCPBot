module.exports = {
   BoardPos: function(row, col) {
      this.row = row;
      this.col = col;
   },

   Board: function() {
      this.segs = [
         [' ', ' ', ' '],
         [' ', ' ', ' '],
         [' ', ' ', ' ']
      ];

      this.WinState = function() {
         var segs = this.segs;
         for (var i = 0; i < 3; i++) {
             if (segs[i][0] != ' ' && segs[i][0] == segs[i][1] && segs[i][1] == segs[i][2])
                 return segs[i][0];

             if (segs[0][i] != ' ' && segs[0][i] == segs[1][i] && segs[1][i] == segs[2][i])
                 return segs[0][i];
         }

         if (segs[1][1] != ' ') {
             if (segs[0][0] == segs[1][1] && segs[1][1] == segs[2][2] ||
                 segs[2][0] == segs[1][1] && segs[1][1] == segs[0][2])
                 return segs[1, 1];
         }

         if (this.OpenCount() == 0)
             return 'T';

         return ' ';
      };

      this.OpenCount = function() {
         var tr = 0;

         for (var r = 0; r < 3; r++) {
            for (var c = 0; c < 3; c++) {
               if (this.segs[r][c] == ' ')
                  tr++;
            }
         }

         return tr;
      };

      this.nthOpen = function(n) {
          var oc = 0;

          for (var r = 0; r < 3; r++) {
              for (var c = 0; c < 3; c++) {
                  if (this.segs[r][c] == ' ') {
                      if (oc == n)
                          return new module.exports.BoardPos(r, c);
                      oc++;
                  }
              }
          }

          return null;
      };

      this.theta = function(v) {
          if (v == 'X')
              return 1;
          else if (v == 'O')
              return 2;
          else
              return 0;
      };

      this.GetBoardState = function() {
          var tr = 0;

          for (var r = 2; r >= 0; r--) {
              for (var c = 2; c >= 0; c--) {
                  tr *= 3;
                  tr += this.theta(this.segs[r][c]);
              }
          }

          return tr;
      };
   }
};
