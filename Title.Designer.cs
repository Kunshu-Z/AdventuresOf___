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
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 16F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = SystemColors.ButtonHighlight;
            titleLabel.Location = new Point(225, 75);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(350, 38);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Adventures of ___";
            titleLabel.Click += titleLabel_Click;
            // 
            // startButton
            // 
            startButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(335, 169);
            startButton.Name = "startButton";
            startButton.Size = new Size(128, 46);
            startButton.TabIndex = 2;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // quitButton
            // 
            quitButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            quitButton.Location = new Point(335, 264);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(128, 46);
            quitButton.TabIndex = 3;
            quitButton.Text = "Quit";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // Title
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(quitButton);
            Controls.Add(startButton);
            Controls.Add(titleLabel);
            Name = "Title";
            Text = "Title";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button startButton;
        private Button quitButton;
    }
}