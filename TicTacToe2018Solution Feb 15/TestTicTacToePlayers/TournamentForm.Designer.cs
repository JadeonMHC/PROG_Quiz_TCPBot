namespace TestTicTacToePlayers
{
    partial class TournamentForm
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
            this.txtGamesPerSecond = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtGamesPerSecond
            // 
            this.txtGamesPerSecond.Location = new System.Drawing.Point(222, 490);
            this.txtGamesPerSecond.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGamesPerSecond.Name = "txtGamesPerSecond";
            this.txtGamesPerSecond.Size = new System.Drawing.Size(192, 29);
            this.txtGamesPerSecond.TabIndex = 34;
            // 
            // TournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 561);
            this.Controls.Add(this.txtGamesPerSecond);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TournamentForm";
            this.Text = "TournamentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGamesPerSecond;
    }
}