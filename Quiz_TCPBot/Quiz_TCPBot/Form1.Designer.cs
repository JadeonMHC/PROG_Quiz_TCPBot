namespace Quiz_TCPBot {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grd00 = new System.Windows.Forms.Button();
            this.grd01 = new System.Windows.Forms.Button();
            this.grd02 = new System.Windows.Forms.Button();
            this.grd12 = new System.Windows.Forms.Button();
            this.grd11 = new System.Windows.Forms.Button();
            this.grd10 = new System.Windows.Forms.Button();
            this.grd22 = new System.Windows.Forms.Button();
            this.grd21 = new System.Windows.Forms.Button();
            this.grd20 = new System.Windows.Forms.Button();
            this.numGames = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.gvScore = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(58, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(158, 20);
            this.txtServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 64);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(202, 32);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // grd00
            // 
            this.grd00.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd00.Location = new System.Drawing.Point(12, 219);
            this.grd00.Name = "grd00";
            this.grd00.Size = new System.Drawing.Size(64, 59);
            this.grd00.TabIndex = 3;
            this.grd00.Text = "X";
            this.grd00.UseVisualStyleBackColor = true;
            // 
            // grd01
            // 
            this.grd01.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd01.Location = new System.Drawing.Point(82, 219);
            this.grd01.Name = "grd01";
            this.grd01.Size = new System.Drawing.Size(64, 59);
            this.grd01.TabIndex = 4;
            this.grd01.Text = "X";
            this.grd01.UseVisualStyleBackColor = true;
            // 
            // grd02
            // 
            this.grd02.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd02.Location = new System.Drawing.Point(152, 219);
            this.grd02.Name = "grd02";
            this.grd02.Size = new System.Drawing.Size(64, 59);
            this.grd02.TabIndex = 5;
            this.grd02.Text = "X";
            this.grd02.UseVisualStyleBackColor = true;
            // 
            // grd12
            // 
            this.grd12.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd12.Location = new System.Drawing.Point(152, 284);
            this.grd12.Name = "grd12";
            this.grd12.Size = new System.Drawing.Size(64, 59);
            this.grd12.TabIndex = 8;
            this.grd12.Text = "X";
            this.grd12.UseVisualStyleBackColor = true;
            // 
            // grd11
            // 
            this.grd11.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd11.Location = new System.Drawing.Point(82, 284);
            this.grd11.Name = "grd11";
            this.grd11.Size = new System.Drawing.Size(64, 59);
            this.grd11.TabIndex = 7;
            this.grd11.Text = "X";
            this.grd11.UseVisualStyleBackColor = true;
            // 
            // grd10
            // 
            this.grd10.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd10.Location = new System.Drawing.Point(12, 284);
            this.grd10.Name = "grd10";
            this.grd10.Size = new System.Drawing.Size(64, 59);
            this.grd10.TabIndex = 6;
            this.grd10.Text = "X";
            this.grd10.UseVisualStyleBackColor = true;
            // 
            // grd22
            // 
            this.grd22.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd22.Location = new System.Drawing.Point(152, 349);
            this.grd22.Name = "grd22";
            this.grd22.Size = new System.Drawing.Size(64, 59);
            this.grd22.TabIndex = 11;
            this.grd22.Text = "X";
            this.grd22.UseVisualStyleBackColor = true;
            // 
            // grd21
            // 
            this.grd21.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd21.Location = new System.Drawing.Point(82, 349);
            this.grd21.Name = "grd21";
            this.grd21.Size = new System.Drawing.Size(64, 59);
            this.grd21.TabIndex = 10;
            this.grd21.Text = "X";
            this.grd21.UseVisualStyleBackColor = true;
            // 
            // grd20
            // 
            this.grd20.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd20.Location = new System.Drawing.Point(12, 349);
            this.grd20.Name = "grd20";
            this.grd20.Size = new System.Drawing.Size(64, 59);
            this.grd20.TabIndex = 9;
            this.grd20.Text = "X";
            this.grd20.UseVisualStyleBackColor = true;
            // 
            // numGames
            // 
            this.numGames.Location = new System.Drawing.Point(58, 131);
            this.numGames.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numGames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGames.Name = "numGames";
            this.numGames.Size = new System.Drawing.Size(158, 20);
            this.numGames.TabIndex = 12;
            this.numGames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Games:";
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 157);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(204, 32);
            this.btnPlay.TabIndex = 14;
            this.btnPlay.Text = "Play!";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(58, 38);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(158, 20);
            this.numPort.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Port:";
            // 
            // gvScore
            // 
            this.gvScore.FormattingEnabled = true;
            this.gvScore.Location = new System.Drawing.Point(12, 439);
            this.gvScore.Name = "gvScore";
            this.gvScore.Size = new System.Drawing.Size(204, 95);
            this.gvScore.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 546);
            this.Controls.Add(this.gvScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numGames);
            this.Controls.Add(this.grd22);
            this.Controls.Add(this.grd21);
            this.Controls.Add(this.grd20);
            this.Controls.Add(this.grd12);
            this.Controls.Add(this.grd11);
            this.Controls.Add(this.grd10);
            this.Controls.Add(this.grd02);
            this.Controls.Add(this.grd01);
            this.Controls.Add(this.grd00);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button grd00;
        private System.Windows.Forms.Button grd01;
        private System.Windows.Forms.Button grd02;
        private System.Windows.Forms.Button grd12;
        private System.Windows.Forms.Button grd11;
        private System.Windows.Forms.Button grd10;
        private System.Windows.Forms.Button grd22;
        private System.Windows.Forms.Button grd21;
        private System.Windows.Forms.Button grd20;
        private System.Windows.Forms.NumericUpDown numGames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox gvScore;
    }
}

