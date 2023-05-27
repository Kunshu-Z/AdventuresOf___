namespace AdventuresOf___
{
    partial class Start
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
            gameTxtLbl = new Label();
            PlayerName = new TextBox();
            Confirm = new Button();
            SuspendLayout();
            // 
            // gameTxtLbl
            // 
            gameTxtLbl.BorderStyle = BorderStyle.Fixed3D;
            gameTxtLbl.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gameTxtLbl.ForeColor = SystemColors.ButtonHighlight;
            gameTxtLbl.Location = new Point(8, 5);
            gameTxtLbl.Margin = new Padding(2, 0, 2, 0);
            gameTxtLbl.Name = "gameTxtLbl";
            gameTxtLbl.Size = new Size(544, 226);
            gameTxtLbl.TabIndex = 1;
            gameTxtLbl.Text = "Light... All I see is light... What is my name?";
            // 
            // PlayerName
            // 
            PlayerName.BackColor = SystemColors.InactiveCaptionText;
            PlayerName.ForeColor = SystemColors.Window;
            PlayerName.Location = new Point(156, 243);
            PlayerName.Margin = new Padding(2);
            PlayerName.Name = "PlayerName";
            PlayerName.Size = new Size(246, 23);
            PlayerName.TabIndex = 2;
            // 
            // Confirm
            // 
            Confirm.BackColor = Color.Black;
            Confirm.ForeColor = SystemColors.ControlLightLight;
            Confirm.Location = new Point(421, 243);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(75, 23);
            Confirm.TabIndex = 3;
            Confirm.Text = "Confirm";
            Confirm.UseVisualStyleBackColor = false;
            Confirm.Click += Confirm_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(560, 270);
            Controls.Add(Confirm);
            Controls.Add(PlayerName);
            Controls.Add(gameTxtLbl);
            Margin = new Padding(2);
            Name = "Start";
            Text = "Start";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gameTxtLbl;
        private TextBox PlayerName;
        private Button Confirm;
    }
}