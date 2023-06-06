using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdventuresOf___
{
    public partial class Gameplay : Form
    {
        private Area CurrentArea;
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

            dictArea.Add("Weapon Selection", new Area("Weapon Selection",
                "Saber Guild",
                $"{Program.playerName} chooses to go to the Old Saber Battlefield, a remnant of a more chaotic age for the Sabers" +
                $"who attacked each other in a bloody civil war, {Program.playerName} realizes the dangers and needs a weapon.\n" +
                $"{Program.playerName}: Excuse me miss receptionist, I might not be a member of the guild but do you have any weapons I could use for my journey?\n" +
                $"Receptionist: Certainly, we have 2 lost weapons in our posession, they weren't claimed by their owners so you may have one.\n" +
                $"She points to a slightly rusted sword (a saber to be exact) and an unremarkable bow and a quiver of 20 arrows.",
                "Choose the Sword",
                "Choose the Bow"));

            dictArea.Add("Hour One", new Area("Hour One",
                "Road to Saber BattleField",
                "Hour One\nOn the road you pass a traveler who says not a single word, just a stare - a glare even - into your eyes, then keeps walking on.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Two", new Area("Hour Two",
                "Road to Saber BattleField",
                "Hour Two\nYou get tired and rest beside a tree trunk, a few deer graze on some grass a few trees down.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three", new Area("Hour Three",
                "Road to Saber BattleField",
                "Hour Three\nYou get back up and continue, you come across an abandoned wooden barrel, nothing was inside.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three & a Half", new Area("Hour Three & a Half",
                "Saber BattleField",
                $"Hour Three & a Half\nYou come to a clearing, two old swords thrust in the ground long ago after the battles here, to mark the battleground.\n" +
                $"It's a quiet place with little vegetation, almost only dirt with old weapons lain about. Grim.\n" +
                $"(Maybe this is where that beast is, I never really got a good look at it)\nYou start searching around for anything, anything at all.\n" +
                $"... nothing\n... nothing\n...something?...nothing\n{Program.playerName}: There's nothing here! Just rusty old swords and shields.\n" +
                $"You pick a shield to inspect it, holding it up to your face you suddenly feel a large thud on the face of the shield.\n" +
                $"A sharp needle pierced the shield, bewildered, you look up and see a huge beast a tail with needles at the end, \na face like a lizard, almost draconic, " +
                $"a body like a horse, with plates of armor, it's legs were like a huge cat with talons like an eagle." +
                $"Don't just stand there! Do something!",
                "Fight the Beast",
                "Run away in fear"));

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
                    else if (CurrentArea.areaName == "Map Selection")
                    {
                        CurrentArea = dictArea["Weapon Selection"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon Selection")
                    {
                        CurrentArea = dictArea["Hour One"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour One")
                    {
                        CurrentArea = dictArea["Hour Two"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Two")
                    {
                        CurrentArea = dictArea["Hour Three"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three")
                    {
                        CurrentArea = dictArea["Hour Three & a Half"];
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
