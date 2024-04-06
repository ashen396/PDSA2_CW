namespace PDSA_2_CW
{
    partial class Shortest_Path
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
            this.pnl_background = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_background
            // 
            this.pnl_background.AutoSize = true;
            this.pnl_background.BackColor = System.Drawing.Color.White;
            this.pnl_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_background.Location = new System.Drawing.Point(0, 0);
            this.pnl_background.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_background.Name = "pnl_background";
            this.pnl_background.Size = new System.Drawing.Size(1067, 554);
            this.pnl_background.TabIndex = 0;
            this.pnl_background.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_background_Paint);
            // 
            // Shortest_Path
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnl_background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Shortest_Path";
            this.Text = "Shortest_Path";
            this.Load += new System.EventHandler(this.Shortest_Path_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_background;
    }
}