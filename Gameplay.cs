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
    public partial class Gameplay : Form
    {
        private Area CurrentArea;
        private string OptionOne;
        private string OptionTwo;
        //Dictionary containing all areas of the game
        private Dictionary<string, Area> dictArea = new Dictionary<string, Area>();
        public Gameplay()
        {
            InitializeComponent();
            this.CenterToScreen(); //To center the game to the screen
        }

        private void Gameplay_Load(object sender, EventArgs e) { CreateGame(); } //Moving {} so it takes less space

        private void DisplayGame(string addText, bool clear = false)
        {
            //Function to take the text to be added as a parameter, along with a boolean value to determine whether or not the display needs to be cleared first
            if (clear)
            {
                gameTxtLbl.Text = string.Empty;
            }
            //New text is added to existing text
            gameTxtLbl.Text += addText;
        }

        private void CreateGame()
        {
            var player = new Player();
            player.playerName = "Kunshu";

            dictArea.Add("Village", new Area("Village",
                "Village Mart",
                "Stranger: Oh, hello! What can I help you with?",
                "1. Inquire about the place",
                "2. Pickpocket"));
        }

        private void StartGame()
        {
            DisplayGame($"{CurrentArea.areaDisplay}, {CurrentArea.areaDescription}", true);
            this.Text = $"{CurrentArea.areaDisplay} - {CurrentArea.areaDescription}";
            OptionOne = CurrentArea.optionOne;
            OptionTwo = CurrentArea.optionTwo;
        }
    }
}
