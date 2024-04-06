namespace TicTacToeMinimax
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            label2 = new Label();
            labelWins = new Label();
            labelLosses = new Label();
            labelDraws = new Label();
            exit = new Button();
            newGame = new Button();
            playerNameTextBox = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(109, 94);
            button1.TabIndex = 0;
            button1.Tag = "0";
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(138, 12);
            button2.Name = "button2";
            button2.Size = new Size(109, 94);
            button2.TabIndex = 1;
            button2.Tag = "1";
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 192, 192);
            button3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(264, 12);
            button3.Name = "button3";
            button3.Size = new Size(109, 94);
            button3.TabIndex = 2;
            button3.Tag = "2";
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(255, 192, 192);
            button4.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(12, 117);
            button4.Name = "button4";
            button4.Size = new Size(109, 94);
            button4.TabIndex = 5;
            button4.Tag = "3";
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 192, 192);
            button5.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(139, 117);
            button5.Name = "button5";
            button5.Size = new Size(109, 94);
            button5.TabIndex = 4;
            button5.Tag = "4";
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(255, 192, 192);
            button6.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(264, 117);
            button6.Name = "button6";
            button6.Size = new Size(109, 94);
            button6.TabIndex = 3;
            button6.Tag = "5";
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(255, 192, 192);
            button7.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = Color.Black;
            button7.Location = new Point(12, 222);
            button7.Name = "button7";
            button7.Size = new Size(109, 94);
            button7.TabIndex = 8;
            button7.Tag = "6";
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(255, 192, 192);
            button8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button8.ForeColor = Color.Black;
            button8.Location = new Point(138, 222);
            button8.Name = "button8";
            button8.Size = new Size(109, 94);
            button8.TabIndex = 7;
            button8.Tag = "7";
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(255, 192, 192);
            button9.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.Black;
            button9.Location = new Point(264, 222);
            button9.Name = "button9";
            button9.Size = new Size(109, 94);
            button9.TabIndex = 6;
            button9.Tag = "8";
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(192, 255, 192);
            label2.Location = new Point(207, 335);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 10;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // labelWins
            // 
            labelWins.AutoSize = true;
            labelWins.BackColor = Color.FromArgb(192, 255, 192);
            labelWins.Location = new Point(12, 337);
            labelWins.Name = "labelWins";
            labelWins.Size = new Size(58, 15);
            labelWins.TabIndex = 11;
            labelWins.Text = "labelWins";
            // 
            // labelLosses
            // 
            labelLosses.AutoSize = true;
            labelLosses.BackColor = Color.FromArgb(192, 255, 192);
            labelLosses.Location = new Point(12, 365);
            labelLosses.Name = "labelLosses";
            labelLosses.Size = new Size(66, 15);
            labelLosses.TabIndex = 12;
            labelLosses.Text = "labelLosses";
            // 
            // labelDraws
            // 
            labelDraws.AutoSize = true;
            labelDraws.BackColor = Color.FromArgb(192, 255, 192);
            labelDraws.Location = new Point(12, 390);
            labelDraws.Name = "labelDraws";
            labelDraws.Size = new Size(64, 15);
            labelDraws.TabIndex = 13;
            labelDraws.Text = "labelDraws";
            // 
            // exit
            // 
            exit.BackColor = Color.FromArgb(192, 192, 255);
            exit.Location = new Point(295, 390);
            exit.Name = "exit";
            exit.Size = new Size(82, 36);
            exit.TabIndex = 14;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = false;
            exit.Click += close_Click;
            // 
            // newGame
            // 
            newGame.BackColor = Color.FromArgb(192, 192, 255);
            newGame.Location = new Point(207, 390);
            newGame.Name = "newGame";
            newGame.Size = new Size(82, 36);
            newGame.TabIndex = 15;
            newGame.Text = "New Game";
            newGame.UseVisualStyleBackColor = false;
            newGame.Click += newGame_Click;
            // 
            // playerNameTextBox
            // 
            playerNameTextBox.AutoSize = true;
            playerNameTextBox.BackColor = Color.FromArgb(192, 255, 192);
            playerNameTextBox.Location = new Point(207, 360);
            playerNameTextBox.Name = "playerNameTextBox";
            playerNameTextBox.Size = new Size(112, 15);
            playerNameTextBox.TabIndex = 17;
            playerNameTextBox.Text = "playerNameTextBox";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(389, 438);
            ControlBox = false;
            Controls.Add(playerNameTextBox);
            Controls.Add(newGame);
            Controls.Add(exit);
            Controls.Add(labelDraws);
            Controls.Add(labelLosses);
            Controls.Add(labelWins);
            Controls.Add(label2);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tic Tac Toe";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Label label2;
        private Label labelWins;
        private Label labelLosses;
        private Label labelDraws;
        private Button exit;
        private Button newGame;
        private Label playerNameTextBox;
    }
}