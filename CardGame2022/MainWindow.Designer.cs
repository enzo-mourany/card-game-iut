namespace CardGame2022
{
    partial class MainWindow
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
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.entryTextBox = new System.Windows.Forms.TextBox();
            this.rowOneLabel = new System.Windows.Forms.Label();
            this.rowTwoLabel = new System.Windows.Forms.Label();
            this.rowThreeLabel = new System.Windows.Forms.Label();
            this.rowFourLabel = new System.Windows.Forms.Label();
            this.playerOneHandLabel = new System.Windows.Forms.Label();
            this.playerTwoHandLabel = new System.Windows.Forms.Label();
            this.playerOneScoreLabel = new System.Windows.Forms.Label();
            this.playerTwoScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageListBox
            // 
            this.messageListBox.CausesValidation = false;
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.ItemHeight = 25;
            this.messageListBox.Location = new System.Drawing.Point(1114, 46);
            this.messageListBox.Margin = new System.Windows.Forms.Padding(4);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(814, 804);
            this.messageListBox.TabIndex = 1;
            // 
            // entryTextBox
            // 
            this.entryTextBox.Location = new System.Drawing.Point(1114, 877);
            this.entryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.entryTextBox.Name = "entryTextBox";
            this.entryTextBox.Size = new System.Drawing.Size(814, 31);
            this.entryTextBox.TabIndex = 0;
            this.entryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntryTextBox_KeyDown);
            // 
            // rowOneLabel
            // 
            this.rowOneLabel.AutoSize = true;
            this.rowOneLabel.Location = new System.Drawing.Point(28, 46);
            this.rowOneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowOneLabel.Name = "rowOneLabel";
            this.rowOneLabel.Size = new System.Drawing.Size(0, 25);
            this.rowOneLabel.TabIndex = 2;
            this.rowOneLabel.Visible = false;
            // 
            // rowTwoLabel
            // 
            this.rowTwoLabel.AutoSize = true;
            this.rowTwoLabel.Location = new System.Drawing.Point(28, 88);
            this.rowTwoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowTwoLabel.Name = "rowTwoLabel";
            this.rowTwoLabel.Size = new System.Drawing.Size(0, 25);
            this.rowTwoLabel.TabIndex = 3;
            this.rowTwoLabel.Visible = false;
            // 
            // rowThreeLabel
            // 
            this.rowThreeLabel.AutoSize = true;
            this.rowThreeLabel.Location = new System.Drawing.Point(28, 135);
            this.rowThreeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowThreeLabel.Name = "rowThreeLabel";
            this.rowThreeLabel.Size = new System.Drawing.Size(0, 25);
            this.rowThreeLabel.TabIndex = 4;
            this.rowThreeLabel.Visible = false;
            // 
            // rowFourLabel
            // 
            this.rowFourLabel.AutoSize = true;
            this.rowFourLabel.Location = new System.Drawing.Point(28, 179);
            this.rowFourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowFourLabel.Name = "rowFourLabel";
            this.rowFourLabel.Size = new System.Drawing.Size(0, 25);
            this.rowFourLabel.TabIndex = 5;
            this.rowFourLabel.Visible = false;
            // 
            // playerOneHandLabel
            // 
            this.playerOneHandLabel.AutoSize = true;
            this.playerOneHandLabel.Location = new System.Drawing.Point(28, 498);
            this.playerOneHandLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerOneHandLabel.Name = "playerOneHandLabel";
            this.playerOneHandLabel.Size = new System.Drawing.Size(0, 25);
            this.playerOneHandLabel.TabIndex = 6;
            this.playerOneHandLabel.Visible = false;
            // 
            // playerTwoHandLabel
            // 
            this.playerTwoHandLabel.AutoSize = true;
            this.playerTwoHandLabel.Location = new System.Drawing.Point(28, 619);
            this.playerTwoHandLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerTwoHandLabel.Name = "playerTwoHandLabel";
            this.playerTwoHandLabel.Size = new System.Drawing.Size(0, 25);
            this.playerTwoHandLabel.TabIndex = 7;
            this.playerTwoHandLabel.Visible = false;
            // 
            // playerOneScoreLabel
            // 
            this.playerOneScoreLabel.AutoSize = true;
            this.playerOneScoreLabel.Location = new System.Drawing.Point(28, 883);
            this.playerOneScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerOneScoreLabel.Name = "playerOneScoreLabel";
            this.playerOneScoreLabel.Size = new System.Drawing.Size(0, 25);
            this.playerOneScoreLabel.TabIndex = 8;
            this.playerOneScoreLabel.Visible = false;
            // 
            // playerTwoScoreLabel
            // 
            this.playerTwoScoreLabel.AutoSize = true;
            this.playerTwoScoreLabel.Location = new System.Drawing.Point(542, 883);
            this.playerTwoScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerTwoScoreLabel.Name = "playerTwoScoreLabel";
            this.playerTwoScoreLabel.Size = new System.Drawing.Size(0, 25);
            this.playerTwoScoreLabel.TabIndex = 9;
            this.playerTwoScoreLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2006, 994);
            this.Controls.Add(this.playerTwoScoreLabel);
            this.Controls.Add(this.playerOneScoreLabel);
            this.Controls.Add(this.playerTwoHandLabel);
            this.Controls.Add(this.playerOneHandLabel);
            this.Controls.Add(this.rowFourLabel);
            this.Controls.Add(this.rowThreeLabel);
            this.Controls.Add(this.rowTwoLabel);
            this.Controls.Add(this.rowOneLabel);
            this.Controls.Add(this.entryTextBox);
            this.Controls.Add(this.messageListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "6 nimmt! (IUT version)";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox messageListBox;
        private System.Windows.Forms.TextBox entryTextBox;
        private System.Windows.Forms.Label rowOneLabel;
        private System.Windows.Forms.Label rowTwoLabel;
        private System.Windows.Forms.Label rowThreeLabel;
        private System.Windows.Forms.Label rowFourLabel;
        private System.Windows.Forms.Label playerOneHandLabel;
        private System.Windows.Forms.Label playerTwoHandLabel;
        private System.Windows.Forms.Label playerOneScoreLabel;
        private System.Windows.Forms.Label playerTwoScoreLabel;
    }
}

