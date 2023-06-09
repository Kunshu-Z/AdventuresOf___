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
            //If statement for if the player inputs nothing for their name, the game will give them the username "?"
            if (string.IsNullOrEmpty(PlayerName.Text))
            {
                Program.playerName = "?";
            }
            //If the player has inputted something for their name, the game will use that input
            else
            {
                Program.playerName = PlayerName.Text;
            }
            //Creates new variable named title to open Title form and hide the Starting form
            var title = new Title();
            title.FormClosed += Title_FormClosed;
            title.Show();
            this.Hide();
        }
        //Method to close the Starting form after Title form is opened
        private void Title_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
