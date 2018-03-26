using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using TicTacToeBase;
namespace TestTicTacToePlayers
{
    public partial class TournamentForm : Form
    {
        ITicTacToePlayer P1, P2;

        int GameCount;
        int GameIndex;
        decimal TotalTurnCount;
        decimal AverageTurnCount;
        int GamesPerSecond;
        char[,] Board = new char[3, 3];
        char[,] BoardCopy = new char[3, 3]; //copy to pass to the players
        ITicTacToePlayer StartPlayer, TurnPlayer;
        int P1Score = 0, P2Score = 0, TieScore = 0;
        Stopwatch sw = new Stopwatch();

        IProgress<ProgressInfo> progress; //used to report progress (initialized in constructor, because you can't do it here in C#)
        bool RequestCancel = false;
        bool RequestPause = false;

        public delegate void TournamentCompletedDelegate(TournamentForm sender, int GameCount, int P1Wins, int P2Wins, int Ties, TimeSpan TimeToComplete);
        public event TournamentCompletedDelegate TournamentCompleted;
        public TournamentForm(ITicTacToePlayer P1, ITicTacToePlayer P2, int GameCount = 1)
        {
            this.P1 = P1;
            this.P2 = P2;
            this.GameCount = GameCount;
            InitializeComponent();
            this.Show();


            progress = new Progress<ProgressInfo>(ShowGameResults); // initialize the IProgress<ProgressInfo> progress object to a new Progress<ProgressInfo> object which uses ShowGameResults to show progress when the .Report method is called
            var progressIndicator = new Progress<ProgressInfo>(ShowGameResults);
            //end progress stuff
            StartTournament();

        }
        public void Cancel()
        {
            RequestPause = false; //if paused, resume so we can cancel!
            RequestCancel = true;
        }
        public void Pause()
        {
            RequestPause = true;
            btnPauseResume.Text = "Resume";
        }
        

        private async void StartTournament()
        {
            RunningButtons();
            P1.StartTournament(P2.ModelName, (int)GameCount, 'X'); //P1 will be 'X'
            P2.StartTournament(P1.ModelName, (int)GameCount, 'O'); //P2 will be 'O'
            P1Score = 0; P2Score = 0; TieScore = 0; TotalTurnCount = 0;
            sw.Restart();

            Task T = new Task(PlayAllGamesInTask);
            T.Start();
            await T;
             IdleButtons();
            sw.Stop();
            TournamentCompleted?.Invoke(this, GameCount, P1Score, P2Score, TieScore,sw.Elapsed); //main form needs to listen for this event!
        }

        void PlayAllGamesInTask()
        {
            for (GameIndex = 0; GameIndex < GameCount; ++GameIndex)
            {
                PlayGameP1vsP2();
                while (RequestPause)
                {
                    System.Threading.Thread.Sleep(100); //this is a simple low-cost way pause - just take little naps waking up only to see if the user wants us to get up and at it again!
                }
                if (RequestCancel == true) //break out of loop if user requested cancel
                    break;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void PlayGameP1vsP2()
        {
            ClearBoard();
            StartPlayer = GameIndex % 2 == 0 ? P1 : P2;
            TurnPlayer = StartPlayer;
            TicTacToeMove move;
            bool GameOver = false;
            int TurnIndex = 0;
            P1.StartNewGame(GameIndex);
            P2.StartNewGame(GameIndex);
            char W = ' ';
            while (!GameOver)
            {
                TotalTurnCount++;
                //char[,] BoardClone = (char[,])Board.Clone(); //
                Array.Copy(Board, BoardCopy, 9); //copy rather than clone to conserve on memory allocation
                //player takes turn
                move = TurnPlayer.MakeYourMove(BoardCopy);
                if (Board[move.Row, move.Col] == ' ')
                {
                    Board[move.Row, move.Col] = TurnPlayer.Symbol;
                }
                else
                {
                    throw new Exception($"TurnPlayer {TurnPlayer.ModelName} ({TurnPlayer.Symbol}) tried to play on a square that was already taken");
                }
                //check for winner if taken at least 5 turns
                if (TurnIndex > 3)
                {
                    W = Winnner();
                    if (W == 'X')
                    {
                        P1Score++;
                        GameOver = true;
                    }
                    else if (W == 'O')

                    {

                        P2Score++;
                        GameOver = true;
                    }
                    else
                    {
                        if (TurnIndex == 8)
                        {
                            TieScore++;
                            GameOver = true;
                        }

                    }
                }
                if (TurnPlayer == P1)
                    TurnPlayer = P2;
                else
                    TurnPlayer = P1;
                TurnIndex++;
            }
            //game is over - show results, but for larger tournaments 

            P1.GameOver(W);
            P2.GameOver(W);

            if (GameIndex < 10 || (GameIndex < 10000 && (GameIndex + 1) % 1000 == 0) || (GameIndex < 1000000 && (GameIndex + 1) % 10000 == 0) || (GameIndex < 10000000 && (GameIndex + 1) % 100000 == 0) || ((GameIndex + 1) % 1000000 == 0) || GameIndex + 1 == GameCount || RequestCancel || RequestPause)
            {
                ProgressInfo PI = new ProgressInfo();
                PI.P1Score = P1Score;
                PI.P2Score = P2Score;
                PI.TieScore = TieScore;
                PI.GameIndex = GameIndex;
                PI.TotalTurnCount = TotalTurnCount;
                progress.Report(PI);
            }
        }

        private void ClearBoard()
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                {
                    Board[r, c] = ' ';
                }
        }

        private char Winnner()
        {
            if (Board[0, 0] == 'X' && Board[0, 1] == 'X' && Board[0, 2] == 'X')
                return 'X';
            if (Board[1, 0] == 'X' && Board[1, 1] == 'X' && Board[1, 2] == 'X')
                return 'X';
            if (Board[2, 0] == 'X' && Board[2, 1] == 'X' && Board[2, 2] == 'X')
                return 'X';
            if (Board[0, 0] == 'X' && Board[1, 0] == 'X' && Board[2, 0] == 'X')
                return 'X';
            if (Board[0, 1] == 'X' && Board[1, 1] == 'X' && Board[2, 1] == 'X')
                return 'X';
            if (Board[0, 2] == 'X' && Board[1, 2] == 'X' && Board[2, 2] == 'X')
                return 'X';
            if (Board[0, 0] == 'X' && Board[1, 1] == 'X' && Board[2, 2] == 'X')
                return 'X';
            if (Board[0, 2] == 'X' && Board[1, 1] == 'X' && Board[2, 0] == 'X')
                return 'X';

            if (Board[0, 0] == 'O' && Board[0, 1] == 'O' && Board[0, 2] == 'O')
                return 'O';
            if (Board[1, 0] == 'O' && Board[1, 1] == 'O' && Board[1, 2] == 'O')
                return 'O';
            if (Board[2, 0] == 'O' && Board[2, 1] == 'O' && Board[2, 2] == 'O')
                return 'O';
            if (Board[0, 0] == 'O' && Board[1, 0] == 'O' && Board[2, 0] == 'O')
                return 'O';
            if (Board[0, 1] == 'O' && Board[1, 1] == 'O' && Board[2, 1] == 'O')
                return 'O';
            if (Board[0, 2] == 'O' && Board[1, 2] == 'O' && Board[2, 2] == 'O')
                return 'O';
            if (Board[0, 0] == 'O' && Board[1, 1] == 'O' && Board[2, 2] == 'O')
                return 'O';
            if (Board[0, 2] == 'O' && Board[1, 1] == 'O' && Board[2, 0] == 'O')
                return 'O';

            return ' '; //no winner 

        }


    }
}
