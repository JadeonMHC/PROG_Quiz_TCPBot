using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeBase;


namespace TestTicTacToePlayers
{
    public partial class TicTacToeTeacher : Form
    {
        int TurnIndex = 0;
        char CurSymbol = 'X';
        Char[,] Board = new Char[3, 3];
        List<TicTacToeMove> TurnList = new List<TicTacToeMove>();
        List<TicTacToeMove> WinLineMoves;
        PictureBox[,] PB = new PictureBox[3, 3];
        int PBSize = 90;
        int PBMargin = 3;
        public TicTacToeTeacher()
        {
            InitializeComponent();
            CreatePBs();
            TTT.ClearBoard(Board);
            ShowBoard();
        }
        void CreatePBs()
        {
            PictureBox pb;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    pb = new PictureBox();
                    pb.Height = pb.Width = PBSize;
                    pb.BackColor = Color.AliceBlue;
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Top = PBMargin + PBSize * r;
                    pb.Left = PBMargin + PBSize * c;
                    pb.Tag = new TicTacToeMove(r, c);
                    pb.Click += Pb_Click;
                    pb.Margin = new Padding(3);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    PB[r, c] = pb;
                    pnlBoard.Controls.Add(pb);
                }
            }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            TicTacToeMove move = (TicTacToeMove)pb.Tag;
            if (pb.Image == null)
            {
                if (TTT.SymbolForTurnIndex(TurnIndex) == 'X')

                    pb.Image = Properties.Resources.ImageX;
                else
                {
                    pb.Image = Properties.Resources.imageO;
                }
                TurnList.Add(move);
                TTT.ApplyMove(Board, TTT.SymbolForTurnIndex(TurnIndex), move);
                if (TTT.Winner(Board, out WinLineMoves) != ' ')
                {
                    ls.Items.Add(TTT.SymbolForTurnIndex(TurnIndex) + " won");
                    pnlBoard.Enabled = false;
                }
                else
                {
                    TurnIndex++;
                    if (TTT.SymbolForTurnIndex(TurnIndex) == 'X')
                    {
                        List<TicTacToeMove> traplist = TTT.TrappingMovesforX(Board);
                        if(traplist.Count > 0)
                        {
                            foreach(var trapmove in traplist)
                            {
                                ls.Items.Add($"Trapping move for X {trapmove.ToString()}");
                            }
                        }
                    }
                }

            }
            else
            {
                Console.Beep();
                //System.Media.SystemSounds.Exclamation.Play();
            }
        }

        void ShowBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    switch (Board[r, c])
                    {
                        case 'X':
                            PB[r, c].Image = Properties.Resources.ImageX;
                            break;
                        case 'O':
                            PB[r, c].Image = Properties.Resources.imageO;
                            break;
                        case ' ':
                            PB[r, c].Image = null;
                            break;
                        default:
                            throw new Exception($"ShowBoard: Board contains invalid character: {PB[r, c]}");
                    }
                }
            }


        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            TTT.ClearBoard(Board);
            TurnIndex = 0;
            ShowBoard();
            pnlBoard.Enabled = true;
        }
    }
}
