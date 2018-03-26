using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBase
{
    public static class TTT //helper class for various TTT operations
    {
        public static void ClearBoard(char[,] Board) //clears out the 3x3 char Board
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    Board[r, c] = ' ';
                }
        }
        public static char Winner(char[,] Board, out List<TicTacToeMove> WinLineMoves) //checks for winner and returns 'X' or 'O' or ' ' (no winner)
                                                                                       //also supplies the list of moves that constitutes the win (in the one unique case where it is possible to have 2 diagonal winlines at the same time it will only return one of the diagonal lines!)
        {
            WinLineMoves = new List<TicTacToeMove>();
            TicTacToeMove[] MovesArray;
            for (int r = 0; r < 3; r++) //rows
            {
                if (Board[r, 0] != ' ' && Board[r, 0] == Board[r, 1] && Board[r, 0] == Board[r, 2])
                {
                    MovesArray = new TicTacToeMove[] { new TicTacToeMove(r, 0), new TicTacToeMove(r, 1), new TicTacToeMove(r, 2) };
                    WinLineMoves.AddRange(MovesArray);
                    return Board[r, 0];
                }
            }
            for (int c = 0; c < 3; c++) //cols
            {
                if (Board[0, c] != ' ' && Board[0, c] == Board[1, c] && Board[0, c] == Board[2, c])
                {
                    MovesArray = new TicTacToeMove[] { new TicTacToeMove(0, c), new TicTacToeMove(1, c), new TicTacToeMove(2, c) };
                    WinLineMoves.AddRange(MovesArray);
                    return Board[0, c];
                }
            }
            if (Board[0, 0] != ' ' && Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2]) //topleft to bottomright diag
            {
                MovesArray = new TicTacToeMove[] { new TicTacToeMove(0, 0), new TicTacToeMove(1, 1), new TicTacToeMove(2, 2) };
                WinLineMoves.AddRange(MovesArray);
                return Board[0, 0];
            }
            if (Board[0, 2] != ' ' && Board[0, 2] == Board[1, 1] && Board[0, 2] == Board[2, 0]) //topright to bottomleft diag
            {
                MovesArray = new TicTacToeMove[] { new TicTacToeMove(2, 2), new TicTacToeMove(1, 1), new TicTacToeMove(2, 0) };
                WinLineMoves.AddRange(MovesArray);
                return Board[0, 2];
            }

            return ' '; //no winner (either incomplete or a draw)
        }

        public static List<TicTacToeMove> AllAvailableMoves(char[,] Board)
        {
            List<TicTacToeMove> MoveList = new List<TicTacToeMove>();
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    if (Board[r, c] == ' ')
                    {
                        MoveList.Add(new TicTacToeMove(r, c));
                    };
                }
            return MoveList;
        }

        public static void ApplyMove(char[,] Board, char TurnPlayerSymbol, TicTacToeMove newmove) //likely not that helpful since caller might as well do it themselves
        {
            if (Board[newmove.Row, newmove.Col] != ' ')
                throw new Exception($"TTT ApplyMove Exception - Cannot apply move  {newmove.ToString()} by '{TurnPlayerSymbol}' to board as it is already occupied by '{Board[newmove.Row, newmove.Col]}' ");
            Board[newmove.Row, newmove.Col] = TurnPlayerSymbol;
        }
        public static char[,] CloneBoard(char[,] Board) //return cloned board 
        {
            char[,] newboard = new char[3, 3]; //create new board
            Array.Copy(Board, newboard, 9); //copy from existing
            return newboard;

        }
        public static char[,] NewBoardWithMoveApplied(char[,] Board, char TurnPlayerSymbol, TicTacToeMove newmove) //return cloned board with new move applied to cloned board
        {
            char[,] newboard = new char[3, 3];//create new board
            Array.Copy(Board, newboard, 9); //copy from existing
            newboard[newmove.Row, newmove.Col] = TurnPlayerSymbol; //apply new move
            return newboard;
        }
        public static char SymbolForTurnIndex(int TurnIndex)
        {
            if (TurnIndex % 2 == 0)
                return 'X';
            else
                return 'O';
        }

        public static List<TicTacToeMove> TrappingMovesforX(char[,] B)
        {
            List<TicTacToeMove> trappingmoves = new List<TicTacToeMove>();
            foreach (TicTacToeMove possiblemove in AllAvailableMoves(B))
            {
                if (IsTrappingMoveForX(B, possiblemove))
                {
                    trappingmoves.Add(possiblemove);
                }
            }
            return trappingmoves;
        }

        public static bool IsTrappingMoveForX(char[,] B, TicTacToeMove ProposedMove)
        {
            //a recursive method to determine if a move is a trapping move -i.e. does or will allow the player making the move to win at some point
            //B - assume in an unfinished game state
            //ProposedMove - assume a valid new move 
            char[,] NewBoard = NewBoardWithMoveApplied(B, 'X', ProposedMove);
            List<TicTacToeMove> WinMoves;
            if (Winner(NewBoard, out WinMoves) == 'X')
                return true;
            if (AllAvailableMoves(NewBoard).Count == 0) //if this is the last move of the game and it is not a winning move, it is not a trapping move!
                return false;
            foreach (TicTacToeMove MoveForO in AllAvailableMoves(NewBoard))
            {
                char[,] FutureBoard = NewBoardWithMoveApplied(NewBoard, 'O', MoveForO);
                if (Winner(FutureBoard, out WinMoves) == 'O') //proposed move is certainly not a trapping move for X!
                    return false;
                bool FoundTrappingMove = false;
                foreach (var XMove in TTT.AllAvailableMoves(FutureBoard)) //note that since O made last move, there is still at least on tile remaining for X, since X has one more move than O - **this is important to remember if this method is converted to check for a trapping move for ANY player
                {
                    if (IsTrappingMoveForX(FutureBoard, XMove))
                    {
                        FoundTrappingMove = true;
                        break; //no sense looking for more
                    }
                }
                if (!FoundTrappingMove)
                {
                    return false; // O has a safe move
                }
            } //next possible move for O
            //if we reach here, we must have found a trapping move for each possible move for O, so we can return true
            return true;
        }
    }
}
