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
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // gameTxtLbl
            // 
            gameTxtLbl.BorderStyle = BorderStyle.Fixed3D;
            gameTxtLbl.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gameTxtLbl.ForeColor = SystemColors.ButtonHighlight;
            gameTxtLbl.Location = new Point(11, 9);
            gameTxtLbl.Name = "gameTxtLbl";
            gameTxtLbl.Size = new Size(777, 376);
            gameTxtLbl.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaptionText;
            textBox1.Location = new Point(230, 407);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(349, 31);
            textBox1.TabIndex = 2;
            // 
            // Start
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(gameTxtLbl);
            Name = "Start";
            Text = "Start";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gameTxtLbl;
        private TextBox textBox1;
    }
}