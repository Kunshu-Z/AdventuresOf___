namespace AdventuresOf___
{
    partial class Title
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
            titleLabel = new Label();
            startButton = new Button();
            quitButton = new Button();
            PlayerName = new TextBox();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 16F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = SystemColors.ButtonHighlight;
            titleLabel.Location = new Point(82, 46);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(242, 26);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Adventures of ___";
            titleLabel.Click += titleLabel_Click;
            // 
            // startButton
            // 
            startButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(234, 101);
            startButton.Margin = new Padding(2);
            startButton.Name = "startButton";
            startButton.Size = new Size(90, 28);
            startButton.TabIndex = 2;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // quitButton
            // 
            quitButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            quitButton.Location = new Point(234, 158);
            quitButton.Margin = new Padding(2);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(90, 28);
            quitButton.TabIndex = 3;
            quitButton.Text = "Quit";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // PlayerName
            // 
            PlayerName.BackColor = SystemColors.InactiveCaptionText;
            PlayerName.Location = new Point(328, 49);
            PlayerName.Margin = new Padding(2);
            PlayerName.Name = "PlayerName";
            PlayerName.Size = new Size(212, 23);
            PlayerName.TabIndex = 4;
            // 
            // Title
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(560, 270);
            Controls.Add(PlayerName);
            Controls.Add(quitButton);
            Controls.Add(startButton);
            Controls.Add(titleLabel);
            Margin = new Padding(2);
            Name = "Title";
            Text = "Title";
            Load += Title_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button startButton;
        private Button quitButton;
        private TextBox PlayerName;
    }
}