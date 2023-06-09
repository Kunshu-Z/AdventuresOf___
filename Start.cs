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
    public partial class Start : Form
    {
        Player player = new Player();
        public Start()
        {
            InitializeComponent();
            this.CenterToScreen(); //To center the game to the screen
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerName.Text))
            {
                Program.playerName = "?";
            }
            else
            {
                Program.playerName = PlayerName.Text;
            }
            var title = new Title();
            title.FormClosed += Title_FormClosed;
            title.Show();
            this.Hide();
        }

        private void Title_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
