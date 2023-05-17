namespace AdventuresOf___
{
    partial class Gameplay
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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // gameTxtLbl
            // 
            gameTxtLbl.BorderStyle = BorderStyle.Fixed3D;
            gameTxtLbl.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gameTxtLbl.ForeColor = SystemColors.ButtonHighlight;
            gameTxtLbl.Location = new Point(8, 8);
            gameTxtLbl.Margin = new Padding(2, 0, 2, 0);
            gameTxtLbl.Name = "gameTxtLbl";
            gameTxtLbl.Size = new Size(544, 160);
            gameTxtLbl.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(71, 203);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(397, 203);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(104, 31);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // Gameplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(560, 270);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(gameTxtLbl);
            Margin = new Padding(2);
            Name = "Gameplay";
            Text = "Gameplay";
            Load += Gameplay_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label gameTxtLbl;
        private Button button1;
        private Button button2;
    }
}