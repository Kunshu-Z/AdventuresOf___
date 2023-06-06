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
                $"...\n...\n*Inaudible noise*\n{Program.playerName}: Ugh, what happened?\nWhere am I?\n*Stands up*\nI gotta ask someone what this place is" +
                $"Last time I remember, I was out in the fields before a beast appeared out of the ground\n...\nWhy are some people giving me a strange glance...\n" +
                $"I gotta ask someone about this place\n*Approaches person*",
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
                "Stranger: Oh, you're a newcomer huh? Well, this is Saber Village.\nWe're currently in the market area, so it's not the best place to get information here. Go and visit the Saber Guild just down the road, they'll help you out.",
                "Go over to the Saber Guild",
                "Insult the man"));

            dictArea.Add("Road to Saber Guild", new Area("Road to Saber Guild",
                "Village Road",
                $"{Program.playerName}: Thanks stranger, I'll head over to the guild right now!\nStranger: You're welcome, take care now.\n" +
                $"You walk to the building with the huge sign down the road and walk to the door.\nSuddenly a large bulky man bursts through, shoving you to the ground.\n" +
                $"{Program.playerName}: Arrgh watch i- WOAH YOU'RE HUGE!!!\nMan: Hmph...\nIt was so sudden, the man just starts walking away\n" +
                $"Your self esteem suddenly dropped to a new low, will you let this man just walk away after what he did?",
                "Go to Guild",
                "Attack the man"));

            dictArea.Add("Saber Guild", new Area("Saber Guild",
                "Saber Guild Building",
                $"{Program.playerName}: No point in fighting that guy, I've got things to do, starting with my current area.\n" +
                $"                     (To the sky for the Sabers)\nReceptionist: Ad caelum pro gladiis, welcome to the Saber guild.\n" +
                $"{Program.playerName}: Um ok so do you have a map or something around here?\n*The Receptionist points to a wall with a highly embellished grand continental map \n" +
                $"- with complementary minimaps you can take below - *\nReceptionist: Right there\n{Program.playerName}: Oh ok thanks then\n",
                "Continue",
                "--|--"));

            dictArea.Add("Map Selection", new Area("Map Selection",
                "Saber Guild",
                $"{Program.playerName} inspects the map carefully, an open field where you may have blacked out.\nYou find two open fields on the map; Old Saber battlefield and the Sea of Wheat\n" +
                $"Clearly an open abandoned battlefield may have some beasts roaming around but who knows,\n maybe the Sea of Wheat might have some clues, it's a small world after all.",
                "Go to Old Saber Battlefield",
                "Go to Sea of Wheat"));

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
                    else if (CurrentArea.areaName == "Inquiry")
                    {
                        CurrentArea = dictArea["Road to Saber Guild"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Road to Saber Guild")
                    {
                        CurrentArea = dictArea["Saber Guild"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Saber Guild")
                    {
                        CurrentArea = dictArea["Map Selection"];
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
