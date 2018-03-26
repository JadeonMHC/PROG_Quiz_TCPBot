using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeBase;
using SampleTicTacToeBots;
using System.Reflection;
using System.Diagnostics;
namespace TestTicTacToePlayers
{
    public partial class Form1 : Form
    {
        List<Type> TypeList = new List<Type>();
        int GameCount;
        List<TournamentForm> TFList = new List<TournamentForm>();
        public Form1()
        {
            InitializeComponent();
        }

        public static bool InterfaceFilter(Type typeObj, Object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }

        private void btnAddPlayerTypeFromDLL3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            string p = "";

            if (File.Exists("LastLoc.txt")) {
                p = File.ReadAllText("LastLoc.txt");

                if (Directory.Exists(p)) {
                    fbd.SelectedPath = p;
                }
                else {
                    File.Delete("LastLoc.txt");
                }
            }

            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                if (fbd.SelectedPath != p)
                    File.WriteAllText("LastLoc.txt", fbd.SelectedPath);

                foreach (string FileName in files)
                {
                    try
                    {
                        Assembly myAssembly = Assembly.UnsafeLoadFrom(FileName);
                        int count = 0;
                        foreach (Type T in myAssembly.GetTypes())
                        {
                            if (T.GetInterfaces().Contains(typeof(ITicTacToePlayer)))
                            {
                                TypeList.Add(T);
                                lbPlayers.Items.Add(T);
                                count++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnStartTournament_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < TypeList.Count; a++) {
                for (int b = a + 1; b < TypeList.Count; b++) {
                    ITicTacToePlayer p1 = (ITicTacToePlayer)Activator.CreateInstance(TypeList[a]);
                    ITicTacToePlayer p2 = (ITicTacToePlayer)Activator.CreateInstance(TypeList[b]);

                    
                }
            }

            //P1 = (ITicTacToePlayer)Activator.CreateInstance((Type)(cmbPlayer1.SelectedItem));
            //P2 = (ITicTacToePlayer)Activator.CreateInstance((Type)(cmbPlayer2.SelectedItem));
        }
        
        private void btnPauseResumeAll_Click(object sender, EventArgs e)
        {
            if (btnPauseResumeAll.Text == "Pause All")
            {
                foreach (TournamentForm tournamentform in TFList)
                {
                    tournamentform.Pause();
                }
                btnPauseResumeAll.Text = "Resume All";
            }
            else
            {
                foreach (TournamentForm tournamentform in TFList)
                {
                    tournamentform.Resume();
                }
                btnPauseResumeAll.Text = "Pause All";
            }
        }
        
        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            foreach (TournamentForm tournamentform in TFList)
            {
                tournamentform.Cancel();
            }
        }
    }
}
