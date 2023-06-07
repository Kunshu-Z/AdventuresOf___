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

            dictArea.Add("Hour One (Saber)", new Area("Hour One (Saber)",
                "Road to Saber BattleField",
                "Hour One\nOn the road you pass a traveler who says not a single word, just a stare - a glare even - into your eyes, then keeps walking on.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Two (Saber)", new Area("Hour Two (Saber)",
                "Road to Saber BattleField",
                "Hour Two\nYou get tired and rest beside a tree trunk, a few deer graze on some grass a few trees down.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three (Saber)", new Area("Hour Three (Saber)",
                "Road to Saber BattleField",
                "Hour Three\nYou get back up and continue, you come across an abandoned wooden barrel, nothing was inside.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three & a Half (Saber)", new Area("Hour Three & a Half (Saber)",
                "Saber BattleField",
                $"Hour Three & a Half\nYou come to a clearing, two old swords thrust in the ground long ago after the battles here, to mark the battleground.\n" +
                $"It's a quiet place with little vegetation, almost only dirt with old weapons lain about. Grim.\n" +
                $"(Maybe this is where that beast is, I never really got a good look at it)\nYou start searching around for anything, anything at all.\n" +
                $"... nothing\n... nothing\n...something?...nothing",
                "Continue",
                "--|--"));

            dictArea.Add("Encounter (Saber)", new Area("Encounter (Saber)",
                "Saber BattleField",
                $"{Program.playerName}: There's nothing here! Just rusty old swords and shields.\n" +
                $"You pick a shield to inspect it, holding it up to your face you suddenly feel a large thud on the face of the shield.\n" +
                $"A sharp needle pierced the shield, bewildered, you look up and see a huge beast a tail with needles at the end, \na face like a lizard, almost draconic, " +
                $"a body like a horse, with plates of armor, it's legs were like a huge cat with talons like an eagle." +
                $"Don't just stand there! Do something!",
                "Fight the Beast",
                "Run away in fear"));

            dictArea.Add("Fight (Saber)", new Area("Fight (Saber)",
                "Saber BattleField",
                $"Foolish choice, but it was your choice, this is your story after all.\n{Program.playerName} brandishes their saber and the impaled shield, they ready the weapon." +
                $"The beast charges into {Program.playerName}, making them fall over\nThe beast fires a needle from it's tail, it misses.\n" +
                $"It tries again, it won't miss this time.",
                "Pull up the shield",
                "Panic and Roll"));

            dictArea.Add("Shield (Saber)", new Area("Shield (Saber)",
                "Saber BattleField",
                "Another needle is lodged into the shield\nThe left of the beast's face is nearing you, something must be done.",
                "Bash its face with the shield",
                "Slash the face with your sword"));

            dictArea.Add("Roll (Saber)", new Area("Roll (Saber)",
                "Saber BattleField",
                "You roll into the attack, almost like you phase through the needle. You now stand closer to the beast\n" +
                "The left of the beast's face is nearing you, something must be done.",
                "Bash its face with the shield",
                "Slash the face with your sword"));

            dictArea.Add("Shield Attack (Saber)", new Area("Shield Attack (Saber)",
                "Saber BattleField",
                "The beast is stunned, ithe two shield needles dislodged into the beast's face and the neck is exposed!\n" +
                "Time slows, perhaps due to simply being in the moment, you should probably attack...",
                "Stab its neck",
                "Slash at its closest leg"));

            dictArea.Add("Slash Attack (Saber)", new Area("Slash Attack (Saber)",
                "Saber BattleField",
                "You slash at its face twice.\n" +
                "The skin is hard and scaly but you manage to get a cut in.\n" +
                "The beast turns its head away but then...\n" +
                "Time slows right as its left eye is facing you, perhaps due to simply being in the moment...\nYou should probably attack.",
                "Stab its eye",
                "Slash at its closest leg"));

            dictArea.Add("Stab Attack (Saber - Shield)", new Area("Stab Attack (Saber - Shield)",
                "Saber BattleField",
                "You stab its neck and past the roof of it's mouth, to the brain. You drag the blade along, causing even more pain.\n" +
                "The beast is now in a rage, gurgling roars pierce your ears.\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up and back down to charge into you!\n" +
                "You must grab onto the beast or else it'll just keep firing needles from the air, out of your reach.  Which side will you grab on from?",
                "Left Side",
                "Right side"));

            dictArea.Add("Stab Eye (Saber - Sword)", new Area("Stab Eye (Saber - Sword)",
                "Saber BattleField",
                "You stab your sword into its eye.\n" +
                "The eye is thick but it works, the sword stabbed through, but you let go!.\n" +
                "The beast roars then makes no more movement\n" +
                "And then...\nThe beast stands up again!\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up with the sword still in its left and back down to charge into you!\n" +
                "You must grab onto the beast, but which side?",
                "Left side",
                "LEFT SIDE"));

            dictArea.Add("Slash Leg (Saber - Shield)", new Area("Slash Leg (Saber - Shield)",
                "Saber BattleField",
                "Well you could've done more damage to it the other way but this is fine too.\n" +
                "You slash at its leg, causing a large gash to appear.\n" +
                "Suddenly overcome by bloodlust, you slash at the beast some more even getting your sword, then giving a final stab in its eye\n" +
                "The beast is now in a rage, gurgling roars pierce your ears.\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up and back down to charge into you!\n" +
                "You must grab onto the beast or else it'll just keep firing needles from the air, out of your reach.\nWhich side will you grab on from?",
                "Left Side",
                "Right Side"));

            dictArea.Add("Slash Leg (Saber - Sword)", new Area("Slash Leg (Saber - Sword)",
                "Saber BattleField",
                "Well you could've done more damage to it the other way but this is fine too.\n" +
                "You slash at its leg, causing a large gash to appear.\n" +
                "Suddenly overcome by bloodlust, you slash at the beast some more even getting your sword, then giving a final stab in its eye\n" +
                "The beast is now in a rage, gurgling roars pierce your ears.\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up and back down to charge into you!\n" +
                "You must grab onto the beast or else it'll just keep firing needles from the air, out of your reach.\nWhich side will you grab on from?",
                "Left Side",
                "Right Side"));

            dictArea.Add("Left Side (Saber - Shield, Stab)", new Area("Left Side (Saber - Shield, Stab)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the needles were stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push in the needles while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Right Side (Saber - Shield, Stab)", new Area("Right Side (Saber - Shield, Stab)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their left and grab on the beast's right\n" +
                $"The beast does a barrel roll! {Program.playerName} was flung onto it's left side where the needles are!\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now." +
                $"You push in the needles while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Left Side (Saber - Sword, Stab)", new Area("Left Side (Saber - Sword, Stab)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the sword in its eye was stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push the sword even more while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Left Side (Saber - Shield, Slash)", new Area("Left Side (Saber - Shield, Slash)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the needles were stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push in the needles while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Right Side (Saber - Shield, Slash)", new Area("Right Side (Saber - Shield, Slash)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their left and grab on the beast's right\n" +
                $"The beast does a barrel roll! {Program.playerName} was flung onto it's left side where the needles are!\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now." +
                $"You push in the needles while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Left Side (Saber - Sword, Slash)", new Area("Left Side (Saber - Sword, Slash)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push in the sword while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Right Side (Saber - Sword, Slash)", new Area("Right Side (Saber - Sword, Slash)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their left and grab on the beast's right\n" +
                $"The beast does a barrel roll! {Program.playerName} was flung onto it's left side where the sword was stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now." +
                $"You push in the sword while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Run Away (Saber)", new Area("Run Away (Saber)",
                "Road to Saber BattleField",
                $"The absolutely terrified {Program.playerName} starts running away from the battle field, back the way they came.\n" +
                $"You run a short distance but then the beast gives chase.\n" +
                $"The beast's armor then breaks off and reveals splendid black wings.\n" +
                $"The beast jumps high into the air and swoops down.\n" +
                $"It will soon swoop back down and grab you but there's still time! Do Something!",
                "Lie flat on the ground",
                "Keep running in a straight line"));

            dictArea.Add("Lie Flat (Saber)", new Area("Lie Flat (Saber)",
                "Road to Saber BattleField",
                "You lie flat on the ground and wait for the flying beast to pass over you..." +
                $"It did not.\nIt picks {Program.playerName} up by its talons like a gull catches its fish\n" +
                $"You're binded and can't move any of your limbs while in the beast's grasp so you can only do one thing.",
                "Wait",
                "--|--"));

            dictArea.Add("Run Straight (Saber)", new Area("Run Straight (Saber)",
                "Road to Saber BattleField",
                "You keep running, hoping that you could just keep on till you find some better cover." +
                $"You did not.\nIt picks {Program.playerName} up by its talons like a gull catches its fish\n" +
                $"You're binded and can't move any of your limbs while in the beast's grasp so you can only do one thing.",
                "--|--",
                "Wait"));

            dictArea.Add("Wait (Saber)", new Area("Wait (Saber)",
                "Road to Saber BattleField",
                $"Your fate being determined by how much an almagamation of a beast is holding you is quite embarrassing.\n" +
                $"The beast nears the village at speeds way faster than you walked, it took only 5 minutes compared to your three and a half hours.",
                "Continue",
                "--|--"));

            dictArea.Add("Return to Village (Saber)", new Area("Return to Village (Saber)",
                "Saber Village",
                $"The beast now hovers over the village, villagers terrified and saber guards emerging from their posts.\n" +
                $"{Program.playerName}: HEY! GUARDS! HELP!\n" +
                $"The guards use their arrows at the beast and the beast roars.\n" +
                $"The arrows pierce the beast's neck, causing it to loosen its grip on you. You have enough time to take your arms out.\n" +
                $"You notice an arrow you can reach close to the beast's belly, you could cause some real damage with it!",
                "Twist the arrow out",
                "Push the arrow in deeper"));

            dictArea.Add("Twist Arrow (Saber)", new Area("Twist Arrow (Saber)",
                "Saber Village",
                $"You twist the arrow and yank the arrow out from the beast.\n" +
                $"Then, in desparation to reach solid ground you repeatedly stab the beast to the point it has little strength to stay afloat.\n" +
                $"The guards then fire a large harpoon into the beast to bring it down, and with a crash it fell into the market square.\n" +
                $"{Program.playerName}, stunned, gets up and feels dizzy, they can hear a voice in their head.",
                "Continue",
                "--|--"));

            dictArea.Add("Push Arrow (Saber)", new Area("Push Arrow (Saber)",
                "Saber Village",
                $"You push the arrow deeper into the beast.\n" +
                $"The beast - weakened - had little strength to stay afloat.\n" +
                $"The guards then fire a large harpoon into the beast to bring it down, and with a crash it fell into the market square.\n" +
                $"{Program.playerName}, stunned, gets up and feels dizzy, they can hear a voice in their head.",
                "Continue",
                "--|--"));

            dictArea.Add("Awakening (Saber)", new Area("Awakening (Saber)",
                "...",
                $"...\nThe Voice: Coward\n{Program.playerName} hazily asks: Who... said that?\n" +
                $"The voice then comes from behind.\nThe voice: COWARD!\n" +
                $"{Program.playerName}: Is this because I ran? What else was I meant to do? That beast was huge!\n" +
                $"Suddenly the voice sounded calm\nThe voice: That beast, was my beast...\n" +
                $"{Program.playerName}: That beast tried to kill me, so it was self defence!" +
                $"The voice: What was taken, must be compensated...\n" +
                $"Suddenly a menacing skeletal figure appears right in front of {Program.playerName}\n" +
                $"The voice: I need a new beast...\nThe voice: This world is full of cowards, but none as much as you.\n" +
                $"The skeletal figure then plunges his hand into your chest, implanting something that causes your body to change rapidly." +
                $"{Program.playerName}'s body grew to large proportions, their limbs changing into various animal parts - claws and the like." +
                $"{Program.playerName} tried to scream but all that came out was..." +
                $"A roar...",
                "Continue",
                "--|--"));

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
                        CurrentArea = dictArea["Hour One (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour One (Saber)")
                    {
                        CurrentArea = dictArea["Hour Two (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Two (Saber)")
                    {
                        CurrentArea = dictArea["Hour Three (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three (Saber)")
                    {
                        CurrentArea = dictArea["Hour Three & a Half (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (Saber)")
                    {
                        CurrentArea = dictArea["Encounter (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Encounter (Saber)")
                    {
                        CurrentArea = dictArea["Fight (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fight (Saber)")
                    {
                        CurrentArea = dictArea["Shield (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Shield (Saber)")
                    {
                        CurrentArea = dictArea["Shield Attack (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Shield Attack (Saber)")
                    {
                        CurrentArea = dictArea["Stab Attack (Saber - Shield)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Slash Attack (Saber)")
                    {
                        CurrentArea = dictArea["Stab Eye (Saber - Sword)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Attack (Saber - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Saber - Shield, Stab)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Slash Leg (Saber - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Saber - Shield, Slash)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Slash Leg (Saber - Sword)")
                    {
                        CurrentArea = dictArea["Left Side (Saber - Sword, Slash)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Eye (Saber - Sword)")
                    {
                        CurrentArea = dictArea["Left Side (Saber - Sword, Stab)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Run Away (Saber)")
                    {
                        CurrentArea = dictArea["Lie Flat (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Lie Flat (Saber)")
                    {
                        CurrentArea = dictArea["Wait (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Wait (Saber)")
                    {
                        CurrentArea = dictArea["Return to Village (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Return to Village (Saber)")
                    {
                        CurrentArea = dictArea["Twist Arrow (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Twist Arrow (Saber)")
                    {
                        CurrentArea = dictArea["Awakening (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Push Arrow (Saber)")
                    {
                        CurrentArea = dictArea["Awakening (Saber)"];
                        StartGame();
                    }
                    break;

                case 2:
                    if (CurrentArea.areaName == "Village")
                    {
                        CurrentArea = dictArea["Pickpocket"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fight (Saber)")
                    {
                        CurrentArea = dictArea["Shield (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Shield (Saber)")
                    {
                        CurrentArea = dictArea["Slash Attack (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Roll (Saber)")
                    {
                        CurrentArea = dictArea["Shield Attack (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Shield Attack (Saber)")
                    {
                        CurrentArea = dictArea["Slash Leg (Saber - Shield)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Slash Attack (Saber)")
                    {
                        CurrentArea = dictArea["Slash Leg (Saber - Sword)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Attack (Saber - Shield)")
                    {
                        CurrentArea = dictArea["Right Side (Saber - Shield, Stab)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Slash Leg (Saber - Shield)")
                    {
                        CurrentArea = dictArea["Right Side (Saber - Shield, Slash)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Slash Leg (Saber - Sword)")
                    {
                        CurrentArea = dictArea["Right Side (Saber - Sword, Slash)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Eye (Saber - Sword)")
                    {
                        CurrentArea = dictArea["Left Side (Saber - Sword, Stab)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Encounter (Saber)")
                    {
                        CurrentArea = dictArea["Run Away (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Run Away (Saber)")
                    {
                        CurrentArea = dictArea["Run Straight (Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Run Straight (Saber)")
                    {
                        CurrentArea = dictArea["Wait (Saber)"];
                        StartGame();
                    }

                    else if (CurrentArea.areaName == "Return to Village (Saber)")
                    {
                        CurrentArea = dictArea["Push Arrow (Saber)"];
                        StartGame();
                    }
                    break;
            }
        }
    }
}
