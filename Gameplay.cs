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
        private int currentOption = 1;
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
        }

        //Method for adding new areas into dictionary
        private void CreateGame()
        {
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

            dictArea.Add("Saber Guild", new Area("Saber Guild",
                "Village Mart",
                $"{Program.playerName}: Thanks stranger, I'll head over to the guild right now!\nStranger: You're welcome, take care now.\n" +
                $"You walk to the building with the huge sign down the road and walk to the door.\nSuddenly a large bulky man bursts through, shoving you to the ground.\n" +
                $"{Program.playerName}: Arrgh watch i- WOAH YOU'RE HUGE!!!\nMan: Hmph...\nIt was so sudden, the man just starts walking away\n" +
                $"Your self esteem suddenly dropped to a new low, will you let this man just walk away after what he did?",
                "Go to Guild",
                "Attack the man"));

            dictArea.Add("Pickpocket", new Area("Pickpocket",
                "Village Mart",
                $"Stranger: Hey! What are you doing?! GET BACK HERE!\n*After reaching a safe space within the village...*\n{Program.playerName}: Right, looks like I'm away from him",
                "Inquire about the place",
                "Pickpocket"));

            dictArea.Add("Test", new Area("Test",
                "Village Mart",
                "Stranger2: Oh, hello! What can I help you with?",
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
            this.Text = $"{CurrentArea.areaDisplay}";
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
            ProcessOption(currentOption);

            if (currentOption == 1)
            {
                currentOption = 1;
                button1.Text = CurrentArea.optionOne; button2.Text = CurrentArea.optionTwo;
            }
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
                        CurrentArea = dictArea["Saber Guild"];
                        StartGame();
                    }
                    break;

                case 2:
                    if (CurrentArea.areaName == "Village")
                    {
                        CurrentArea = dictArea["Inquiry"];
                        StartGame();
                    }
                    break;

                case 3:
                    if (CurrentArea.areaName == "Inquiry")
                    {
                        
                    }
                    break;
            }
        }




    }
}
