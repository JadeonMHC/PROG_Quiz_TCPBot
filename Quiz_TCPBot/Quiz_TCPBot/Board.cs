using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_TCPBot
{
    class Board
    {
        public char[,] segs;

        public Board()
        {
            segs = new char[3, 3];

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    segs[r, c] = ' ';
                }
            }
        }

        public char WinState()
        {
            if (OpenCount() == 0)
                return 'T';

            if (segs[1, 1] != ' ')
            {
                if (segs[0, 0] == segs[1, 1] && segs[1, 1] == segs[2, 2])
                    return segs[1, 1];
                if (segs[2, 0] == segs[1, 1] && segs[1, 1] == segs[0, 2])
                    return segs[1, 1];
            }

            for (int i = 0; i < 3; i++)
            {
                if (segs[0, i] == segs[1, i] && segs[1, i] == segs[2, i] && segs[1, i] != ' ')
                    return segs[1, i];

                if (segs[i, 0] == segs[i, 1] && segs[i, 1] == segs[i, 2] && segs[i, 1] != ' ')
                    return segs[i, 1];
            }

            return ' ';
        }

        public int OpenCount()
        {
            int tr = 0;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (segs[r, c] == ' ')
                        tr++;
                }
            }

            return tr;
        }
    }
}
