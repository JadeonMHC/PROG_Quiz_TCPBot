using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBase
{
    public struct TicTacToeMove
    {
        public int Row;
        public int Col;
        public TicTacToeMove(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public override string ToString()
        {
            return $"[{Row.ToString()},{Col.ToString()}]";
        }
    }
    public delegate void BotSpeakDelegate(string PoliteComment);
    public interface ITicTacToePlayer
    {
        //would like to force constructor will take one argument of type char to indicate whether player is 'X' or 'O'
        //unfortunately no way of specifying this in the interface:(
        //so we will specify player symbol in StartTournament
        string ModelName { get; } //will return the bot model name e.g. JonTTTv5, KyleEliminator, InvincibleBrandonK
        string Strategy { get; }
        char Symbol { get; } //returns 'X' or 'O' 
        void StartTournament(string Opponent, int GameCount, char Symbol); //tells bot that they are going to be playing in a xxx number of game tournament against so and so
        void StartNewGame(int GameIndex); //tells bot game xxx is about to start

        TicTacToeMove MakeYourMove(char[,] Board);
        //Board will assume to be a 3x3 char array for example
        //'X' ' ' 'O' [0,0] [0,1] [0,2]
        //'X' 'O' ' ' [1,0] [1,1] [1,2]
        //' ' ' ' 'O' [2,0] [2,1] [2,2]
        //first index is for row, second is for column
        //this would be passed to player 'X' and player X might wisely respond with the TicTacToeMove with row = 
        void GameOver(char Winner); //if Winner is anything beside 'X' or 'O' it means nobody won (Tie, or "Cat's game")
        void TournamentOver(int ScoreX, int ScoreO, int ScoreTie);

        event BotSpeakDelegate BotSpeak; //totally up to the bot when and if to actually raise such BotSpeak events

    }
    //We could have used this pair of methods instead of the one where we pass the board
    //TicTacToeMove MakeYourMove();
    //void OpponentMoved(TicTacToeMove opponentmove);

}

