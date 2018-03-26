namespace TestTicTacToePlayers
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartTournament = new System.Windows.Forms.Button();
            this.nudGameCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPauseResumeAll = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnAddPlayerTypeFromDLL3 = new System.Windows.Forms.Button();
            this.lbPlayers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartTournament
            // 
            this.btnStartTournament.Location = new System.Drawing.Point(368, 343);
            this.btnStartTournament.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartTournament.Name = "btnStartTournament";
            this.btnStartTournament.Size = new System.Drawing.Size(166, 35);
            this.btnStartTournament.TabIndex = 1;
            this.btnStartTournament.Text = "Start Tournament";
            this.btnStartTournament.UseVisualStyleBackColor = true;
            this.btnStartTournament.Click += new System.EventHandler(this.btnStartTournament_Click);
            // 
            // nudGameCount
            // 
            this.nudGameCount.Location = new System.Drawing.Point(77, 348);
            this.nudGameCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudGameCount.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.nudGameCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGameCount.Name = "nudGameCount";
            this.nudGameCount.Size = new System.Drawing.Size(164, 26);
            this.nudGameCount.TabIndex = 2;
            this.nudGameCount.ThousandsSeparator = true;
            this.nudGameCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 350);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Games:";
            // 
            // btnPauseResumeAll
            // 
            this.btnPauseResumeAll.Location = new System.Drawing.Point(368, 421);
            this.btnPauseResumeAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPauseResumeAll.Name = "btnPauseResumeAll";
            this.btnPauseResumeAll.Size = new System.Drawing.Size(166, 35);
            this.btnPauseResumeAll.TabIndex = 28;
            this.btnPauseResumeAll.Text = "Pause All";
            this.btnPauseResumeAll.UseVisualStyleBackColor = true;
            this.btnPauseResumeAll.Click += new System.EventHandler(this.btnPauseResumeAll_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(368, 466);
            this.btnCancelAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(166, 35);
            this.btnCancelAll.TabIndex = 29;
            this.btnCancelAll.Text = "Cancel All";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // btnAddPlayerTypeFromDLL3
            // 
            this.btnAddPlayerTypeFromDLL3.Location = new System.Drawing.Point(8, 12);
            this.btnAddPlayerTypeFromDLL3.Name = "btnAddPlayerTypeFromDLL3";
            this.btnAddPlayerTypeFromDLL3.Size = new System.Drawing.Size(157, 44);
            this.btnAddPlayerTypeFromDLL3.TabIndex = 23;
            this.btnAddPlayerTypeFromDLL3.Text = "Load Roster";
            this.btnAddPlayerTypeFromDLL3.UseVisualStyleBackColor = true;
            this.btnAddPlayerTypeFromDLL3.Click += new System.EventHandler(this.btnAddPlayerTypeFromDLL3_Click);
            // 
            // lbPlayers
            // 
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.ItemHeight = 20;
            this.lbPlayers.Location = new System.Drawing.Point(8, 62);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(526, 264);
            this.lbPlayers.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 652);
            this.Controls.Add(this.lbPlayers);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnPauseResumeAll);
            this.Controls.Add(this.btnAddPlayerTypeFromDLL3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudGameCount);
            this.Controls.Add(this.btnStartTournament);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Test ITicTacToePlayer bots";
            ((System.ComponentModel.ISupportInitialize)(this.nudGameCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartTournament;
        private System.Windows.Forms.NumericUpDown nudGameCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPauseResumeAll;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button btnAddPlayerTypeFromDLL3;
        private System.Windows.Forms.ListBox lbPlayers;
    }
}

