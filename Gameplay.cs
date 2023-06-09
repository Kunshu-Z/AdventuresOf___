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

        //Method to start the game. Calls CreateGame which creates all the dictionary entries, then calls Go to execute the game at the area named "Starting"
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
        //Each new dictArea uses the structure of the constructor in Area.CS (string areaname, string areadisplay, string areadescription, string optionone, string optiontwo)
        //NOTE: Some formatting of the buttons will be off due to certain sections having more text in the buttons + using Auto Size for buttons on form.
        private void CreateGame()
        {
            //Location one - Neutral
            dictArea.Add("Starting", new Area("Starting",
                "Village Hut",
                $"...\n...\n*Inaudible noise*\n{Program.playerName}: Ugh, what happened?\nWhere am I?\n*Stands up*\nI gotta ask someone what this place is" +
                $"\nLast time I remember, I was out in the fields before a beast appeared out of the ground\n...\nWhy are some people giving me a strange glance...\n" +
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

            dictArea.Add("Attack The Man", new Area("Attack The Man",
                "Village Road",
                $"{Program.playerName} runs up behind the bulky figure, each step taken only lowering their self esteem...\n" +
                $"Suddenly, the bulky man stops and so do you...\n" +
                $"It's clear that this man was threatening you, or perhaps warning you...\n" +
                $"...\nYou slowly back away and turn around into the Saber guild",
                "Continue",
                "--|--"));

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
                $" who attacked each other in a bloody civil war, {Program.playerName} realizes the dangers and needs a weapon.\n" +
                $"{Program.playerName}: Excuse me miss receptionist, I might not be a member of the guild but do you have any weapons I could use for my journey?\n" +
                $"Receptionist: Certainly, we have 2 lost weapons in our posession, they weren't claimed by their owners so you may have one.\n" +
                $"She points to a slightly rusted sword (a saber to be exact) and an unremarkable bow and a quiver of 20 arrows.",
                "Choose the Sword",
                "Choose the Bow"));

            dictArea.Add("Weapon: Saber", new Area("Weapon: Saber",
                "Road to Saber BattleField",
                $"{Program.playerName} picks up the sword, takes a minimap, thanks the receptionist, and goes on their merry way to the Old Battlefield due west from the village.",
                "Continue",
                "--|--"));

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
                "Bash its face\nwith the shield",
                "Slash the face\nwith your sword"));

            dictArea.Add("Roll (Saber)", new Area("Roll (Saber)",
                "Saber BattleField",
                "You roll into the attack, almost like you phase through the needle. You now stand closer to the beast\n" +
                "The left of the beast's face is nearing you, something must be done.",
                "Bash its face\nwith the shield",
                "Slash the face\nwith your sword"));

            dictArea.Add("Shield Attack (Saber)", new Area("Shield Attack (Saber)",
                "Saber BattleField",
                "The beast is stunned, ithe two shield needles dislodged into the beast's face and the neck is exposed!\n" +
                "Time slows, perhaps due to simply being in the moment, you should probably attack...",
                "Stab its neck",
                "Slash at its\nclosest leg"));

            dictArea.Add("Slash Attack (Saber)", new Area("Slash Attack (Saber)",
                "Saber BattleField",
                "You slash at its face twice.\n" +
                "The skin is hard and scaly but you manage to get a cut in.\n" +
                "The beast turns its head away but then...\n" +
                "Time slows right as its left eye is facing you, perhaps due to simply being in the moment...\nYou should probably attack.",
                "Stab its eye",
                "Slash at its\nclosest leg"));

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

            //BOW SECTION
            dictArea.Add("Weapon: Bow", new Area("Weapon: Bow",
                "Road to Saber BattleField",
                $"{Program.playerName} picks up the bow and arrows, takes a minimap, thanks the receptionist, and goes on their merry way to the Old Battlefield due west from the village.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour One (Bow)", new Area("Hour One (Bow)",
                "Road to Saber BattleField",
                "Hour One\nOn the road you pass a traveler who says not a single word, just a stare - a glare even - into your eyes, then keeps walking on.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Two (Bow)", new Area("Hour Two (Bow)",
                "Road to Saber BattleField",
                "Hour Two\nYou get tired and rest beside a tree trunk, a few deer graze on some grass a few trees down.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three (Bow)", new Area("Hour Three (Bow)",
                "Road to Saber BattleField",
                "Hour Three\nYou get back up and continue, you come across an abandoned wooden barrel, nothing was inside.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three & a Half (Bow)", new Area("Hour Three & a Half (Bow)",
                "Saber BattleField",
                $"Hour Three & a Half\nYou come to a clearing, two old swords thrust in the ground long ago after the battles here, to mark the battleground.\n" +
                $"It's a quiet place with little vegetation, almost only dirt with old weapons lain about. Grim.\n" +
                $"(Maybe this is where that beast is, I never really got a good look at it)\nYou start searching around for anything, anything at all.\n" +
                $"... nothing\n... nothing\n...something?...nothing",
                "Continue",
                "--|--"));

            dictArea.Add("Encounter (Bow)", new Area("Encounter (Bow)",
                "Saber BattleField",
                $"{Program.playerName}: There's nothing here! Just rusty old swords and shields.\n" +
                $"You pick a shield to inspect it, holding it up to your face you suddenly feel a large thud on the face of the shield.\n" +
                $"A sharp needle pierced the shield, bewildered, you look up and see a huge beast a tail with needles at the end, \na face like a lizard, almost draconic, " +
                $"a body like a horse, with plates of armor, it's legs were like a huge cat with talons like an eagle." +
                $"Don't just stand there! Do something!",
                "Fight the Beast",
                "Run away in fear"));

            dictArea.Add("Fight (Bow)", new Area("Fight (Bow)",
                "Saber BattleField",
                $"Foolish choice, but it was your choice, this is your story after all.\n{Program.playerName} drops the shield, takes out their bow, and readies and arrow." +
                $"The beast charges into {Program.playerName}, making them fall over\nThe beast fires a needle from it's tail, it misses.\n" +
                $"It tries again, it won't miss this time.",
                "Pull up the shield",
                "Panic and Roll"));

            dictArea.Add("Shield (Bow)", new Area("Shield (Bow)",
                "Saber BattleField",
                $"...\nWhat shield?\n{Program.playerName}: Crap\n" +
                $"A fired needle gets stuck in your leg, it's very painful\n" +
                $"The beast then rears onto its hind legs and prepares to slash at you with its bird-like claws.\n" +
                $"Time slows, perhaps due to simply being in the moment, you should probably attack...",
                "Quickly fire an arrow\ninto its exposed neck",
                "Get up and and\npush into\nit while its unstable"));

            dictArea.Add("Roll (Bow)", new Area("Roll (Bow)",
                "Saber BattleField",
                "You roll into the attack, almost like you phase through the needle. You now stand closer to the beast\n" +
                "The left of the beast's face is nearing you, something must be done.",
                "Fire an arrow into the beast's eye",
                "Jump and kick the beast's face\nthen fire an arrow into its eye"));

            dictArea.Add("Push Beast (Bow - Shield)", new Area("Push Beast (Bow - Shield)",
                "Saber BattleField",
                $"{Program.playerName} rushes to the beast's belly and pushes into it with all their might!\n" +
                $"The beast slowly falls onto its back and the armor on its back digs into the beast's skin.\n" +
                $"Suddenly a needle fires from the beast's tail.\n" +
                $"{Program.playerName} catches it!? Some wicked reflexes were suddenly instilled within our hero.\n" +
                $"So now there's a needle in your hand, what to do I wonder?",
                "Run up to the beast's\nleft eye and stab it",
                "Stab the beast's left\neye while the\nnarrator ridicules it"));

            dictArea.Add("Stab Eye (Bow - Shield)", new Area("Stab Eye (Bow - Shield)",
                "Saber BattleField",
                $"You run up to the beast's left eye and stab it deep, nearly to the brain" +
                "The beast roars then makes no more movement\n" +
                "And then...\nThe beast stands up again!\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up with the needle still in its left and back down to charge into you!\n" +
                "You must grab onto the beast, but which side?",
                "Left side",
                "LEFT SIDE"));

            dictArea.Add("Stab Eye w/Narrator (Bow - Shield)", new Area("Stab Eye w/Narrator (Bow - Shield)",
                "Saber BattleField",
                $"You run up to the beast's left eye and stab it deep indeed, nearly to the brain" +
                "The beast roars then makes no more movement, what an embarrassment\n" +
                "And then...\nThe beast stands up again instead of taking the L!\n" +
                "Suddenly the beasts's shoddy armor breaks off, revealing off brand black wings.\n" +
                "The beast flies up with the needle still in its left eye and back down to charge into you (which it won't)!\n" +
                "You must grab onto the beast, but which side? (I'd suggest going Left)",
                "Left side",
                "LEFT SIDE"));

            dictArea.Add("Fire Arrow (Bow - Shield)", new Area("Fire Arrow (Bow - Shield)",
                "Saber BattleField",
                $"Though {Program.playerName}'s leg was pierced, their arms are still strong, they ready the bow and an arrow.\n" +
                "The arrow is loosed and it pierces the beast's neck, it falls onto its back in pain and you run near its face to stab an arrow into its eye." +
                "The eye is thick but it works, the arrow stabbed through, but you let go!.\n" +
                "The beast roars then makes no more movement\n" +
                "And then...\nThe beast stands up again!\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up with the arrow still in its left and back down to charge into you!\n" +
                "You must grab onto the beast, but which side?",
                "Left side",
                "LEFT SIDE"));

            dictArea.Add("Fire Arrow (Bow - Roll)", new Area("Fire Arrow (Bow - Roll)",
                "Saber BattleField",
                $"You draw the arrow and fire -\n" +
                "It missed the mark... (you were at point blank by the way)\n" +
                "Frustrated you grab an arrow from your quiver and stab at the beast like a madman.\n" +
                "The arrow in your hand suddenly disappeared...\nInto the beast's left eye!" +
                "And then...\nThe beast stands up again!\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up with the arrow still in its left and back down to charge into you!\n" +
                "You must grab onto the beast, but which side?",
                "Left side",
                "LEFT SIDE"));

            dictArea.Add("Jump Kick (Bow - Roll)", new Area("Jump Kick (Bow - Roll)",
                "Saber BattleField",
                $"You messed up your order of operations...\n" +
                "You were meant to kick off the beast's face, then fire the arrow in the air looking all cool...\n" +
                "Instead you shot the arrow first into the beast's eye and pushed the arrow deeper by kicking it in.\n" +
                "the change in expected surface area you were meant to kick off of made you slip into the air." +
                "The beast by the way fell over from the pain.\n" +
                $"For a moment {Program.playerName} believed the beast to be dead." +
                "And then...\nThe beast stands up again!\n" +
                "Suddenly the beasts's armor breaks off, revealing splendid black wings.\n" +
                "The beast flies up with the arrow still in its left and back down to charge into you!\n" +
                "You must grab onto the beast, but which side?",
                "Left side",
                "LEFT SIDE"));

            dictArea.Add("Left Side (Bow - Roll, Jump Kick)", new Area("Left Side (Bow - Rolll, Jump Kick)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the arrow in its eye was stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push the arrow even more while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Left Side (Bow - Roll, Arrow)", new Area("Left Side (Bow - Rolll, Arrow)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the arrow in its eye was stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push the arrow even more while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Left Side (Bow - Shield, Push)", new Area("Left Side (Bow - Shield, Push)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the needle in its eye was stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push the needle even more while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Left Side (Bow - Shield, Arrow)", new Area("Left Side (Bow - Shield, Arrow)",
                "Saber BattleField",
                $"{Program.playerName} dodges to their right and grab on its left where the arrow in its eye was stuck\n" +
                $"The beast flies east of the battlefield. Back to the village! You realize this beast must be killed now.\n" +
                $"You push the arrow even more while struggling to hold on, the beast falls a little but still has some strength to fly.\n" +
                $"For a split second\nYou and the beast starts falling into the market place, it roars and then...\n" +
                $"THUD!!!\nStalls are squashed under the beast and needles fly into the sky in a final reflex from its tail; everyone in the village ducks for cover.\n" +
                $"The beast is dead, yet {Program.playerName} lives\n" +
                $"A sinister bony cackle is heard faintly, is this another villain?\n" +
                $"{Program.playerName} didn't care, right now they were a hero.",
                "Continue",
                "--|--"));

            dictArea.Add("Run Away", new Area("Run Away",
                "Road to Saber BattleField",
                $"The absolutely terrified {Program.playerName} starts running away from the battle field, back the way they came.\n" +
                $"You run a short distance but then the beast gives chase.\n" +
                $"The beast's armor then breaks off and reveals splendid black wings.\n" +
                $"The beast jumps high into the air and swoops down.\n" +
                $"It will soon swoop back down and grab you but there's still time! Do Something!",
                "Lie flat on the ground",
                "Keep running in\na straight line"));

            dictArea.Add("Lie Flat", new Area("Lie Flat",
                "Road to Saber BattleField",
                "You lie flat on the ground and wait for the flying beast to pass over you..." +
                $"It did not.\nIt picks {Program.playerName} up by its talons like a gull catches its fish\n" +
                $"You're binded and can't move any of your limbs while in the beast's grasp so you can only do one thing.",
                "Wait",
                "--|--"));

            dictArea.Add("Run Straight", new Area("Run Straight",
                "Road to Saber BattleField",
                "You keep running, hoping that you could just keep on till you find some better cover." +
                $"You did not.\nIt picks {Program.playerName} up by its talons like a gull catches its fish\n" +
                $"You're binded and can't move any of your limbs while in the beast's grasp so you can only do one thing.",
                "Wait",
                "--|--"));

            dictArea.Add("Wait", new Area("Wait",
                "Road to Saber BattleField",
                $"Your fate being determined by how much an almagamation of a beast is holding you is quite embarrassing.\n" +
                $"The beast nears the village at speeds way faster than you walked, it took only 5 minutes compared to your three and a half hours.",
                "Continue",
                "--|--"));

            dictArea.Add("Return to Village", new Area("Return to Village",
                "Saber Village",
                $"The beast now hovers over the village, villagers terrified and saber guards emerging from their posts.\n" +
                $"{Program.playerName}: HEY! GUARDS! HELP!\n" +
                $"The guards use their arrows at the beast and the beast roars.\n" +
                $"The arrows pierce the beast's neck, causing it to loosen its grip on you. You have enough time to take your arms out.\n" +
                $"You notice an arrow you can reach close to the beast's belly, you could cause some real damage with it!",
                "Twist the arrow out",
                "Push the arrow\nin deeper"));

            dictArea.Add("Twist Arrow", new Area("Twist Arrow",
                "Saber Village",
                $"You twist the arrow and yank the arrow out from the beast.\n" +
                $"Then, in desparation to reach solid ground you repeatedly stab the beast to the point it has little strength to stay afloat.\n" +
                $"The guards then fire a large harpoon into the beast to bring it down, and with a crash it fell into the market square.\n" +
                $"{Program.playerName}, stunned, gets up and feels dizzy, they can hear a voice in their head.",
                "Continue",
                "--|--"));

            dictArea.Add("Push Arrow", new Area("Push Arrow",
                "Saber Village",
                $"You push the arrow deeper into the beast.\n" +
                $"The beast - weakened - had little strength to stay afloat.\n" +
                $"The guards then fire a large harpoon into the beast to bring it down, and with a crash it fell into the market square.\n" +
                $"{Program.playerName}, stunned, gets up and feels dizzy, they can hear a voice in their head.",
                "Continue",
                "--|--"));

            dictArea.Add("Mysterious Figure", new Area("Mysterious Figure",
                "...",
                $"...\nThe Voice: Coward\n{Program.playerName} hazily asks: Who... said that?\n" +
                $"The voice then comes from behind.\nThe voice: COWARD!\n" +
                $"{Program.playerName}: Is this because I ran? What else was I meant to do? That beast was huge!\n" +
                $"Suddenly the voice sounded calm\nThe voice: That beast, was my beast...\n" +
                $"{Program.playerName}: That beast tried to kill me, so it was self defence!\n" +
                $"The voice: What was taken, must be compensated...\n" +
                $"Suddenly a menacing skeletal figure appears right in front of {Program.playerName}...",
                "Continue",
                "--|--"));

            dictArea.Add("Awakening", new Area("Awakening",
                "...",
                $"The voice: I need a new beast...\nThe voice: This world is full of cowards, but none as much as you.\n" +
                $"The skeletal figure then plunges his hand into your chest, implanting something that causes your body to change rapidly.\n" +
                $"{Program.playerName}'s body grew to large proportions, their limbs changing into various animal parts - claws and the like.\n" +
                $"{Program.playerName} tried to scream but all that came out was...\n" +
                $"A roar...",
                "Continue",
                "--|--"));

            dictArea.Add("Weapon Selection (SoF)", new Area("Weapon Selection (SoF)",
                "Saber Guild",
                $"{Program.playerName} chooses to go to the Sea of Wheat, no description was provided in the map legend for this place so it's shrouded in mystery,\n" +
                $"{Program.playerName} doesn't really see any danger in this place but needs a weapon just in case.\n" +
                $"{Program.playerName}: Excuse me miss receptionist, I might not be a member of the guild but do you have any weapons I could use for my journey?\n" +
                $"Receptionist: Certainly, we have 2 lost weapons in our posession, they weren't claimed by their owners so you may have one.\n" +
                $"She points to a slightly rusted sword (a saber to be exact) and an unremarkable bow and a quiver of 20 arrows.",
                "Choose the Sword",
                "Choose the Bow"));

            dictArea.Add("Weapon: Saber (SoF)", new Area("Weapon: Saber (SoF)",
                "Road to Sea of Wheat",
                $"{Program.playerName} picks up the sword, takes a minimap, thanks the receptionist, and goes on their merry way to the Sea of Wheat due east from the village.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour One (SoF - Saber)", new Area("Hour One (SoF - Saber)",
                "Road to Sea of Wheat",
                "Hour One\nOn the road you pass an old manor, abandoned and desolate.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Two (SoF - Saber)", new Area("Hour Two (SoF - Saber)",
                "Road to Sea of Wheat",
                "Hour Two\nYou get tired and rest beside a tree trunk, the sun shines still in the early afternoon.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three (SoF - Saber)", new Area("Hour Three (SoF - Saber)",
                "Road to Sea of Wheat",
                "Hour Three\nYou get back up and continue, you come across an abandoned wooden ale keg, only some putrid smelling water inside",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three & a Half (SoF - Saber)", new Area("Hour Three & a Half (SoF - Saber)",
                "Sea of Wheat",
                "Hour Three & a Half\nYou come to what seems to be a literal Sea of Wheat.\n" +
                "It's a quiet place with only wheat as far as the eye can see...\n" +
                "(Is this really just a farm?)\n...\n" +
                "Suddenly you surge with anger." +
                $"{Program.playerName}: Three and a half hours for a farm? Really!?" +
                $"{Program.playerName} needs to let that anger loose, but how?",
                "Slash at the wheat",
                "Tear the wheat\nfrom their roots"));

            dictArea.Add("Weapon: Bow (SoF)", new Area("Weapon: Bow (SoF)",
                "Road to Sea of Wheat",
                $"{Program.playerName} picks up the bow and arrows, takes a minimap, thanks the receptionist, and goes on their merry way to the Sea of Wheat due east from the village.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour One (SoF - Bow)", new Area("Hour One (SoF - Bow)",
                "Road to Sea of Wheat",
                "Hour One\nOn the road you pass an old manor, abandoned and desolate.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Two (SoF - Bow)", new Area("Hour Two (SoF - Bow)",
                "Road to Sea of Wheat",
                "Hour Two\nYou get tired and rest beside a tree trunk, the sun shines still in the early afternoon.",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three (SoF - Bow)", new Area("Hour Three (SoF - Bow)",
                "Road to Sea of Wheat",
                "Hour Three\nYou get back up and continue, you come across an abandoned wooden ale keg, only some putrid smelling water inside",
                "Continue",
                "--|--"));

            dictArea.Add("Hour Three & a Half (SoF - Bow)", new Area("Hour Three & a Half (SoF - Bow)",
                "Sea of Wheat",
                "Hour Three & a Half\nYou come to what seems to be a literal Sea of Wheat.\n" +
                "It's a quiet place with only wheat as far as the eye can see...\n" +
                "(Is this really just a farm?)\n...\n" +
                "Suddenly you surge with anger." +
                $"{Program.playerName}: Three and a half hours for a farm? Really!?" +
                $"{Program.playerName} needs to let that anger loose, but how?",
                "Shoot arrows at\nliterally nothing",
                "Tear the wheat\nfrom their roots"));

            dictArea.Add("Encounter (SoF)", new Area("Encounter (SoF)",
                "Sea of Wheat",
                $"After at least an hour of rampaging through the Sea of Wheat, suddenly all the golden wheat turns white, a burning white, and then.\n" +
                $"HEY! COME HERE\nA tall figure starts moving towards you in the Sea of White\n" +
                $"The heat intensifies as he gets closer\n" +
                $"{Program.playerName}: Wh- who are you!?" +
                $"The figure: Me? They call me many names - The Piercer, The Puncturer, The Poker - no one has ever known my true name, and neither will you, I've given up that life." +
                $"The P: Tresspasser, why are you destroying my crops? I've been living here for so long, are you not afraid?\nTo meet the man I once was?\n" +
                $"{Program.playerName}: I don't even know who you are.\n" +
                $"The P: Then maybe I should give you a taste of my power!",
                "Continue",
                "--|--"));

            dictArea.Add("Battle Against The P (SoF)", new Area("Battle Against The P (SoF)",
                "Sea of Wheat",
                $"{Program.playerName}: With what? You have no weapons! You're wearing nothing but a loincloth!\n" +
                $"Suddenly, The P lunges towards you and penetrates your arm with an unseen weapon.\n" +
                $"The P: Leave. Now.\n" +
                $"{Program.playerName}'s arm is literally burning! There is no other option, you must leave.",
                "Leave",
                "Now"));

            dictArea.Add("Retreat (SoF)", new Area("Retreat (SoF)",
                "Road to Sea of Wheat",
                $"There's no way you'd ever be able to beat someone like him.\n" +
                $"You keep on walking in the direction you came from, your arm still in pain from a burning sensation.\n" +
                $"Slowly, the forest became darker... Whispers from the woods came from either side, echoing in your mind.\n" +
                $"Darker and darker thoughts pop into {Program.playerName}'s mind...\n" +
                $"{Program.playerName} felt useless, they couldn't find the beast, they couldn't beat the man in the Sea of Wheat.\n" +
                $"They couldn't even muster up the courage to fight that man outside the Saber Guild...\n" +
                $"They wanted to destroy everything... So that they'll be on top.",
                "Continue",
                "--|--"));

            dictArea.Add("Mysterious Figure (SoF)", new Area("Mysterious Figure (SoF)",
                "Near Saber Village",
                $"{Program.playerName} was nearing the village gate until they notice a black tar slowly bubbling up from the ground...\n" +
                $"A skeletal figure appears from the tar, holding a scythe of some sort...\n" +
                $"{Program.playerName}, taken aback from this is completely speechless.\n" +
                $"The figure emanates a dark aura that makes the whispers intensify, they're no longer whispers... They're screams...\n" +
                $"They want you to join the figure\nThey promise power.",
                "Join the skeletal figure",
                "Refuse the figure"));

            dictArea.Add("Corruption (Dark Path)", new Area("Corruption (Dark Path)",
                "...",
                $"There is no refusing power...\nYou want this power...\n" +
                $"To defeat your enemies\nTo go even further beyond mortal comprehension...\n" +
                $"...\n" +
                $"The Figure: Hmm... before I give you this power... What do you intend to do with it?\n" +
                $"{Program.playerName}: This place... This land is cruel... I want to... Destroy it all and make it a better place...\n" +
                $"The Figure: Ahh... Very well then... You'll... Be able to destroy at the very least.\n" +
                $"{Program.playerName}: Wait wha-?",
                "Continue",
                "--|--"));

            dictArea.Add("Awakening (Dark Path)", new Area("Awakening (Dark Path)",
                "...",
                $"The skeletal figure then plunges his hand into your chest, implanting something that causes your body to change rapidly.\n" +
                $"{Program.playerName}'s body grew to large proportions, their limbs changing into various animal parts - claws and the like.\n" +
                $"{Program.playerName} tried to scream but all that came out was...\n" +
                $"A roar",
                "Continue",
                "--|--"));

            dictArea.Add("Pickpocket", new Area("Pickpocket",
                "Village Mart",
                $"Stranger: Hey! What are you doing?! GET BACK HERE!\n*After reaching a safe space within the village...*\n{Program.playerName}: Right, looks like I'm away from him\n" +
                $"Now that I have some money, I guess I should get some food.\nI'm starving...",
                "Continue",
                "--|--"));

            dictArea.Add("Dragon's Den", new Area("Dragon's Den",
                "Dragon's Den",
                $"*Enters Restaurant...*\n" +
                $"Waiter: Welcome to the Dragon's Den! What would you like to have today?\n" +
                $"{Program.playerName}: Just give me the cheapest meal you have.\n" +
                $"Waiter: Right, that's one Dragon style BLT. It will be ready shortly.\n" +
                $"*After having the food*\n" +
                $"Waiter: Right, your total comes to 500G.\n",
                "Pay the bill",
                "Dine n' Dash!"));

            dictArea.Add("No Gold?", new Area("No Gold?",
                "Saber Village",
                $"Thank you for eating at Dragon's Den! Have a nice day!\n" +
                $"{Program.playerName}: Well, now I'm out of gold...\n" +
                $"Random strangers from afar: Man, I'm all out of gold, and we're running out of food to eat\n" +
                $"Why don't you go to the guild? I've heard they give those with no gold a benefit\n" +
                $"{Program.playerName}: (Huh, the Guild?)\n" +
                $"Random strangers from afar: Woah really? I'll go there now!\n" +
                $"{Program.playerName}: I've gotta find out where this guild is...\n" +
                $"*Approches Stranger*" +
                $"{Program.playerName}: Excuse me, but do you know where I would have to go for the Saber Guild?\n" +
                $"Stranger: Sure I do, it's just down that road over there.",
                "Continue",
                "--|--"));
            
            dictArea.Add("Dine n' Dash", new Area("Dine n' Dash",
                "Saber Village",
                $"Waiter: HEY! YOU'RE NOT GETTING AWAY WITH THIS!\n" +
                $"GUARDS! THAT PERSON IS RUNNING AWAY WITHOUT HAVING PAID FOR THEIR MEAL! GET THEM!\n" +
                $"{Program.playerName}: (DARN! Now I have the guards on my tail)\n" +
                $"Distant voice: I thought you were gonna throw away those potions. They're far too dangerous to sell.\n" +
                $"{Program.playerName}: I'm starting to get exhausted...",
                "Turn yourself in",
                "Grab and throw a\npotion on the guards"));

            dictArea.Add("Prison", new Area("Prison",
                "Saber Village Prison",
                $"Guards: GET THEM!\n" +
                $"The guards grab {Program.playerName} and sends them to prison.\n" +
                $"In their cell... {Program.playerName} is bombarded with whispers from an unknown source..." +
                $"\n{Program.playerName} notices a black tar oozing up from the floor...\n" +
                $"A skeletal figure appears from the tar, holding a scythe of some sort...\n" +
                $"{Program.playerName}, taken aback from this is completely speechless.\n" +
                $"The figure emanates a dark aura that makes the whispers intensify, they're no longer whispers... They're screams...\n" +
                $"They want you to join the figure\nThey promise power.",
                "Join the skeletal figure",
                "Refuse the figure"));

            dictArea.Add("Potion Throw", new Area("Potion Throw",
                "Saber Village?",
                $"*{Program.playerName} Grabs and throws potion to the guards*\n" +
                $"Front Guard: ARGH! CAN'T SEE ANYTHING! SOMEONE GET THEM!\n" +
                $"{Program.playerName} was nearing the village gate until they notice a black tar slowly bubbling up from the ground...\n" +
                $"A skeletal figure appears from the tar, holding a scythe of some sort...\n" +
                $"{Program.playerName}, taken aback from this is completely speechless.\n" +
                $"The figure emanates a dark aura that makes the whispers intensify, they're no longer whispers... They're screams...\n" +
                $"They want you to join the figure\nThey promise power.",
                "Join the skeletal figure",
                "Refuse the figure"));

            dictArea.Add("End", new Area("End",
                "???",
                $"???: You may have completed one journey for now, {Program.playerName}. However, there are many paths which lie ahead of you...",
                "Restart",
                "End Game"));
        }

        //Method to start the game at the starting point by setting the CurrentArea to "Starting" then calling StartGame method to display the text
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

        //Method to change the button text to the respective scenario
        private void ChangeOptions()
        {
            button1.Text = CurrentArea.optionOne;
            button2.Text = CurrentArea.optionTwo;
        }

        //Method for if button1 is clicked, it will process case 1 under the ProcessOption method
        //NOTE: When clicked, it will first check the CurrentArea, then based off the present CurrentArea, it will change the next CurrentArea accordingly
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessOption(1);
        }

        //Method for if button2 is clicked, it will process case 2 under the ProcessOption method
        //NOTE: When clicked, it will first check the CurrentArea, then based off the present CurrentArea, it will change the next CurrentArea accordingly
        private void button2_Click(object sender, EventArgs e)
        {
            ProcessOption(2);
        }

        private void ProcessOption(int option)
        {
            switch (option)
            {
                //Case 1 for if the user selects button1 (Left button)
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
                    else if (CurrentArea.areaName == "Attack The Man")
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
                        CurrentArea = dictArea["Weapon: Saber"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon: Saber")
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
                    else if (CurrentArea.areaName == "Weapon: Bow")
                    {
                        CurrentArea = dictArea["Hour One (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour One (Bow)")
                    {
                        CurrentArea = dictArea["Hour Two (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Two (Bow)")
                    {
                        CurrentArea = dictArea["Hour Three (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three (Bow)")
                    {
                        CurrentArea = dictArea["Hour Three & a Half (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (Bow)")
                    {
                        CurrentArea = dictArea["Encounter (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Encounter (Bow)")
                    {
                        CurrentArea = dictArea["Fight (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fight (Bow)")
                    {
                        CurrentArea = dictArea["Shield (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Shield (Bow)")
                    {
                        CurrentArea = dictArea["Fire Arrow (Bow - Shield)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Push Beast (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Stab Eye (Bow - Shield)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Roll (Bow)")
                    {
                        CurrentArea = dictArea["Fire Arrow (Bow - Roll)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fire Arrow (Bow - Roll)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Roll, Arrow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fire Arrow (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Shield, Arrow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Eye (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Shield, Push)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Eye w/Narrator (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Shield, Push)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Jump Kick (Bow - Roll)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Roll, Jump Kick)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Run Away")
                    {
                        CurrentArea = dictArea["Lie Flat"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Lie Flat")
                    {
                        CurrentArea = dictArea["Wait"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Run Straight")
                    {
                        CurrentArea = dictArea["Wait"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Wait")
                    {
                        CurrentArea = dictArea["Return to Village"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Return to Village")
                    {
                        CurrentArea = dictArea["Twist Arrow"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Twist Arrow")
                    {
                        CurrentArea = dictArea["Mysterious Figure"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Push Arrow")
                    {
                        CurrentArea = dictArea["Mysterious Figure"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Mysterious Figure")
                    {
                        CurrentArea = dictArea["Awakening"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon Selection (SoF)")
                    {
                        CurrentArea = dictArea["Weapon: Saber (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon: Saber (SoF)")
                    {
                        CurrentArea = dictArea["Hour One (SoF - Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour One (SoF - Saber)")
                    {
                        CurrentArea = dictArea["Hour Two (SoF - Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Two (SoF - Saber)")
                    {
                        CurrentArea = dictArea["Hour Three (SoF - Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three (SoF - Saber)")
                    {
                        CurrentArea = dictArea["Hour Three & a Half (SoF - Saber)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon: Bow (SoF)")
                    {
                        CurrentArea = dictArea["Hour One (SoF - Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour One (SoF - Bow)")
                    {
                        CurrentArea = dictArea["Hour Two (SoF - Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Two (SoF - Bow)")
                    {
                        CurrentArea = dictArea["Hour Three (SoF - Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three (SoF - Bow)")
                    {
                        CurrentArea = dictArea["Hour Three & a Half (SoF - Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (SoF - Saber)")
                    {
                        CurrentArea = dictArea["Encounter (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (SoF - Bow)")
                    {
                        CurrentArea = dictArea["Encounter (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Encounter (SoF)")
                    {
                        CurrentArea = dictArea["Battle Against The P (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Battle Against The P (SoF)")
                    {
                        CurrentArea = dictArea["Retreat (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Retreat (SoF)")
                    {
                        CurrentArea = dictArea["Mysterious Figure (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Mysterious Figure (SoF)")
                    {
                        CurrentArea = dictArea["Corruption (Dark Path)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Corruption (Dark Path)")
                    {
                        CurrentArea = dictArea["Awakening (Dark Path)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Pickpocket")
                    {
                        CurrentArea = dictArea["Dragon's Den"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Dragon's Den")
                    {
                        CurrentArea = dictArea["No Gold?"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "No Gold?")
                    {
                        CurrentArea = dictArea["Road to Saber Guild"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Dine n' Dash")
                    {
                        CurrentArea = dictArea["Prison"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Prison")
                    {
                        CurrentArea = dictArea["Corruption (Dark Path)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Potion Throw")
                    {
                        CurrentArea = dictArea["Corruption (Dark Path)"];
                        StartGame();
                    }
                    //Ending
                    else if (CurrentArea.areaName == "Left Side (Saber - Shield, Stab)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Saber - Shield, Slash)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Saber - Sword, Slash)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Saber - Sword, Stab)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Bow - Roll, Arrow)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Bow - Shield, Arrow)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Bow - Shield, Push)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Bow - Shield, Push)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Left Side (Bow - Roll, Jump Kick)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Right Side (Saber - Shield, Stab)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Right Side (Saber - Shield, Slash)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Right Side (Saber - Sword, Slash)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Awakening")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Awakening (Dark Path)")
                    {
                        CurrentArea = dictArea["End"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "End")
                    {
                        CurrentArea = dictArea["Starting"];
                        StartGame();
                    }
                    break;

                //Case 2 for if the user selects button2 (Right button)
                case 2:
                    if (CurrentArea.areaName == "Village")
                    {
                        CurrentArea = dictArea["Pickpocket"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Road to Saber Guild")
                    {
                        CurrentArea = dictArea["Attack The Man"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon Selection")
                    {
                        CurrentArea = dictArea["Weapon: Bow"];
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
                    else if (CurrentArea.areaName == "Fight (Bow)")
                    {
                        CurrentArea = dictArea["Roll (Bow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Roll (Bow)")
                    {
                        CurrentArea = dictArea["Jump Kick (Bow - Roll)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Shield (Bow)")
                    {
                        CurrentArea = dictArea["Push Beast (Bow - Shield)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Jump Kick (Bow - Roll)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Roll, Jump Kick)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Push Beast (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Stab Eye w/Narrator (Bow - Shield)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Eye w/Narrator (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Shield, Push)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Stab Eye (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Shield, Push)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fire Arrow (Bow - Shield)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Shield, Arrow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Fire Arrow (Bow - Roll)")
                    {
                        CurrentArea = dictArea["Left Side (Bow - Roll, Arrow)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Encounter (Saber)")
                    {
                        CurrentArea = dictArea["Run Away"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Encounter (Bow)")
                    {
                        CurrentArea = dictArea["Run Away"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Run Away")
                    {
                        CurrentArea = dictArea["Run Straight"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Return to Village")
                    {
                        CurrentArea = dictArea["Push Arrow"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Map Selection")
                    {
                        CurrentArea = dictArea["Weapon Selection (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Weapon Selection (SoF)")
                    {
                        CurrentArea = dictArea["Weapon: Bow (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (SoF - Saber)")
                    {
                        CurrentArea = dictArea["Encounter (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (SoF - Bow)")
                    {
                        CurrentArea = dictArea["Encounter (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Battle Against The P (SoF)")
                    {
                        CurrentArea = dictArea["Retreat (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (SoF - Saber)")
                    {
                        CurrentArea = dictArea["Encounter (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Hour Three & a Half (SoF - Bow)")
                    {
                        CurrentArea = dictArea["Encounter (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Battle Against The P (SoF)")
                    {
                        CurrentArea = dictArea["Retreat (SoF)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Mysterious Figure (SoF)")
                    {
                        CurrentArea = dictArea["Corruption (Dark Path)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Dragon's Den")
                    {
                        CurrentArea = dictArea["Dine n' Dash"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Dine n' Dash")
                    {
                        CurrentArea = dictArea["Potion Throw"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Prison")
                    {
                        CurrentArea = dictArea["Corruption (Dark Path)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "Potion Throw")
                    {
                        CurrentArea = dictArea["Corruption (Dark Path)"];
                        StartGame();
                    }
                    else if (CurrentArea.areaName == "End")
                    {
                        this.Close();
                    }
                    break;
            }
        }
    }
}
