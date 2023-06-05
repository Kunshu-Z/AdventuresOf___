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

        private void Gameplay_Load(object sender, EventArgs e)
        {
            CreateGame();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            Go();
        }

        private void DisplayGame(string addText, bool clear = false)
        {
            //Function to take the text to be added as a parameter, along with a boolean value to determine whether or not the display needs to be cleared first
            if (clear)
            {
                gameTxtLbl.Text = string.Empty;
            }
            //New text is added to existing text
            gameTxtLbl.Text += addText;
            button1.Text += addText;
        }

        //Method for adding new areas into dictionary
        private void CreateGame()
        {
            var player = new Player();
            player.playerName = "Kunshu";
            //Location one - Neutral
            dictArea.Add("Starting", new Area("Starting",
                "Village Hut",
                $"...\n...\n*Inaudible noise*\n{Program.playerName}: Ugh, what happened?\nWhere am I?\n*Stands up*\nI gotta ask someone what this place is",
                "Continue",
                "--|--"));

            dictArea.Add("Village", new Area("Village",
                "Village Mart",
                "Stranger: Oh, hello! What can I help you with?",
                "Inquire about the place",
                "Pickpocket"));

            //Location two - Light
            dictArea.Add("Inquiry", new Area("Inquiry",
                "Village Mart",
                "Oh, you're a newcomer huh? Well, this is Saber Village.\nWe're currently in the market area, so it's not the best place to get information here. Go and visit the Saber Guild just down the road, they'll help you out.",
                "Go over to the Saber Guild",
                "Insult the man"));

            dictArea.Add("Pickpocket", new Area("Pickpocket",
                "Village Mart",
                $"Stranger: Hey! What are you doing?! GET BACK HERE!\n*After reaching a safe space within the village...*\n{Program.playerName}: Right, looks like I'm away from him",
                "Inquire about the place",
                "Pickpocket"));
        }

        //Method to start the game at the starting point
        private void Go()
        {
            CurrentArea = dictArea["Starting"];
            StartGame();
        }

        private void StartGame()
        {
            //To display the text in the textbox + title of form
            DisplayGame($"{CurrentArea.areaDescription}", true);
            this.Text = $"{CurrentArea.areaDisplay} - {CurrentArea.areaDescription}";
            //Calling ChangeOptions to change the buttons to the respective scenario
            ChangeOptions();
        }

        //Method to change the buttons to the respective scenario
        private void ChangeOptions()
        {
            button1.Text = CurrentArea.optionOne;
            button2.Text = CurrentArea.optionTwo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessOption(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessOption(2);
        }

        private void ProcessOption(int option)
        {
            switch (option) 
            {
                case 1:
                    if (CurrentArea.areaName == "Starting")
                    {
                        CurrentArea = dictArea["Village"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Village")
                    {
                        CurrentArea = dictArea["Inquiry"];
                        StartGame();
                    }
                    break;

                case 2:
                    if (CurrentArea.areaName == "Village")
                    {
                        CurrentArea = dictArea["Pickpocket"];
                        StartGame();
                    }
                    break;
            }
        }
    }
}
