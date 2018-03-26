using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeBase;
namespace SampleTicTacToeBots
{

    public class test
    {
        private int myprivatecounter;

        public int Counter => myprivatecounter; //new weird syntax
        //does same as:
        //public int Counter
        //{ get { return myprivatecounter; } }
    }
    public class DumbRandomTicTacToeBot : ITicTacToePlayer
    {
        private  Random R = new Random();
        private string modelName = "dumbo";
        private char mSymbol;
        public string ModelName => modelName;//uses the new expression whatchamacallit syntax
                                             //public string ModelName
                                             //{
                                             //    get => modelName;
                                             //    set => modelName = value;
                                             //}


        public char Symbol => mSymbol;

        public string Strategy => "Each move is completely random (no attempt to win or block)";

        public event BotSpeakDelegate BotSpeak;

        public void GameOver(char Winner)
        {
            // throw new NotImplementedException();
        }

        public TicTacToeMove MakeYourMove(char[,] Board)
        {
            int row = 0, col = 0;
            int randIndex;
            int CountMe = 0, CountThem = 0, CountEmpty = 0;
            //first check the board to see if it makes sense

            //count the number of empty spots

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    switch (Board[r, c])
                    {
                        case 'X':
                            if (mSymbol == 'X')
                                CountMe++;
                            else
                                CountThem++;
                            break;

                        case 'O':
                            if (mSymbol == 'O')
                                CountMe++;
                            else
                                CountThem++;
                            break;
                        default:
                            CountEmpty++;
                            break;
                    }

                }

            //figure out my move;
            randIndex = R.Next(0, CountEmpty);
            bool done = false;
            int counter = 0;
            for (int r = 0; r < 3; r++) 
            {
                for (int c = 0; c < 3; c++)
                {
                    if (Board[r, c] != 'X' && Board[r, c] != 'O') //if the spot is empty
                    {
                        if (counter == randIndex)
                        {
                            row = r;
                            col = c;
                            done = true; //flag to get out of the outside loop
                            break; //this of course only breaks out of the inside loop
                        }
                        counter++;
                    }
                }
                if (done) break; //have to break out of both loops
            }
            return new TicTacToeMove(row, col);
        }

        public void StartNewGame(int GameIndex)
        {
            //throw new NotImplementedException();
        }

        public void StartTournament(string Opponent, int GameCount, char Symbol)
        {
            mSymbol = Symbol;
        }

        public void TournamentOver(int ScoreX, int ScoreO, int ScoreTie)
        {
            BotSpeak?.Invoke("Yeah, I was getting tired");
        }
    }
}
