using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventuresOf___
{
    public partial class Title : Form
    {
        public Title()
        {
            InitializeComponent();
            this.CenterToScreen(); //To center the game to the screen
        }

        private void Title_Load(object sender, EventArgs e)
        {
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var gameplay = new Gameplay();
            gameplay.FormClosed += Gameplay_FormClosed;
            gameplay.Show();
            this.Hide();
        }

        private void Gameplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
