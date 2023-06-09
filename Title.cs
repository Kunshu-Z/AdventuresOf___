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
            //Method to add the player's name from Start.CS into the title textbox
            PlayerName.Text = "Adventures of " + Program.playerName;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Creates new variable named gameplay to open Gameplay form and hide the Title form
            var gameplay = new Gameplay();
            gameplay.FormClosed += Gameplay_FormClosed;
            gameplay.Show();
            this.Hide();
        }
        //Method to close the Title form after Gameplay form is opened
        private void Gameplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        //Method to close the Title form after player has selected "Quit"
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
