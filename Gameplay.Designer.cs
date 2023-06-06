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
            gameTxtLbl.Location = new Point(11, 13);
            gameTxtLbl.Name = "gameTxtLbl";
            gameTxtLbl.Size = new Size(777, 322);
            gameTxtLbl.TabIndex = 0;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(101, 338);
            button1.Name = "button1";
            button1.Size = new Size(6, 6);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(533, 338);
            button2.Name = "button2";
            button2.Size = new Size(6, 6);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Gameplay
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(gameTxtLbl);
            Name = "Gameplay";
            Text = "Gameplay";
            Load += Gameplay_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gameTxtLbl;
        private Button button1;
        private Button button2;
    }
}