using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        // Difficulty affects how many resources you gain
        enum Difficulty {Easy = 3, Medium = 2, Hard = 1};

        static void Main(string[] args)
        {
            // ============================================
            // Nuclear Shelter Survival Game
            // Inspired by: 60 Seconds
            //
            // This is a console based survival game where:
            // - Player explores a house/hospital to collect items
            // - Then survives day by day in a shelter
            //
            // Important systems:
            // - Menu system
            // - Movement system
            // - Inventory system
            // - Random events & survival mechanics
            //
            // ============================================
            // I chose this theme because i saw CaseOh playing it yesterday,
            // and i really enjoyed it, so i wanted to make 60 seconds for myself in unity at first,
            // but then we got this assignment and chose to make it in a console app.

            // quick note. I used Console.Readline() A lot to make sure the player can read the text and then press enter the continue.

            // House data/images. Here i stored the images of the house.
            // i made a array in a array. So i can easily type the images with Console.Writeline()
            // i just need to input the [room][height] and thats it.

            string[][] firstFloor = {
                [
                    " _____________________________________ ",
                    "/__|       |       |_)|0 0|(_|        |",
                    "|__|       |       |_)|0 0|(_|        |",
                    "|  |       |       |_)|0 0|(_|        |",
                    "|()|       |                          |",
                    "|  |             __                   |",
                    "|  |        /   |  |        _______   |",
                    "|{}|       |    |  |       (_______)  |",
                    "|{}|       |    |  |                  |",
                    "|  |       |    |  |         _____    |",
                    "|__|_______|    |  |________|_(_)_|___|",
                    "|__________|    |_____________________|",
                    "|  |_O_|   |    |  |_____|   _________|",
                    "|          |    |    ' '      | | | | |",
                    "|__        |   /              | | | | |",
                    "|  |       |                  | | | | |",
                    "|z |    ___|    |            _|_|_|_|_|",
                    "|  |   |   | () |_____________________|",
                    "|__|___|___|____|_____________________|",
                ],
                [ 
                    " _____________________________________ ",
                    "/__|       |       |_)|0 0|(_|        |",
                    "|__|       |       |_)|0 0|(_|        |",
                    "|  |       |       |_)|0 0|(_|        |",
                    "|()|       | ()                       |",
                    "|  |       |     __                   |",
                    "|  |       |    |  |        _______   |",
                    "|{}|       |    |  |       (_______)  |",
                    "|{}|       |    |  |                  |",
                    "|  |       |    |  |         _____    |",
                    "|__|_______|    |  |________|_(_)_|___|",
                    "|__________|    |_____________________|",
                    "|  |_O_|   |    |  |_____|   _________|",
                    "|          |    |    ' '      | | | | |",
                    "|__        |    |             | | | | |",
                    "|  |       |    |             | | | | |",
                    "|z |    ___|    |            _|_|_|_|_|",
                    "|  |   |   |    |_____________________|",
                    "|__|___|___|____|_____________________|",
                ],
                [ 
                    " _____________________________________ ",
                    "/__|       |       |_)|0 0|(_|        |",
                    "|__|       |       |_)|0 0|(_|        |",
                    "|  |       |       |_)|0 0|(_|        |",
                    "|()|       |                          |",
                    "|  |       |     __                   |",
                    "|  |       |    |  |        _______   |",
                    "|{}|       |    |  |       (_______)  |",
                    "|{}|       |    |  |                  |",
                    "|  |       |    |  |         _____    |",
                    "|__|_______|    |  |________|_(_)_|___|",
                    "|__________|    |_____________________|",
                    "|  |_O_|   |    |  |_____|   _________|",
                    "|          |    |    ' '      | | | | |",
                    "|__   ()  /     |             | | | | |",
                    "|  |            |             | | | | |",
                    "|z |    ___|    |            _|_|_|_|_|",
                    "|  |   |   |    |_____________________|",
                    "|__|___|___|____|_____________________|",
                ],
                [ 
                    " _____________________________________ ",
                    "/__|       |       |_)|0 0|(_|        |",
                    "|__|       |       |_)|0 0|(_|        |",
                    "|  |       |       |_)|0 0|(_|        |",
                    "|()|       |                          |",
                    "|  |       |     __                   |",
                    "|  |       |    |  |        _______   |",
                    "|{}|       |    |  |       (_______)  |",
                    "|{}|       |    |  |                  |",
                    "|  |       |    |  |         _____    |",
                    "|__|_______|    |  |________|_(_)_|___|",
                    "|__________|    |_____________________|",
                    "|  |_O_|   |    |  |_____|   _________|",
                    "|          |    |    ' '      | | | | |",
                    "|__        |   /              | | | | |",
                    "|  |       |          ()      | | | | |",
                    "|z |    ___|    |            _|_|_|_|_|",
                    "|  |   |   |    |_____________________|",
                    "|__|___|___|____|_____________________|",
                ],
                [ 
                    " _____________________________________ ",
                    "/__|       |       |_)|0 0|(_|        |",
                    "|__|       |       |_)|0 0|(_|        |",
                    "|  |       |       |_)|0 0|(_|        |",
                    "|()|       |                          |",
                    "|  |             __                   |",
                    "|  |  ()    /   |  |        _______   |",
                    "|{}|       |    |  |       (_______)  |",
                    "|{}|       |    |  |                  |",
                    "|  |       |    |  |         _____    |",
                    "|__|_______|    |  |________|_(_)_|___|",
                    "|__________|    |_____________________|",
                    "|  |_O_|   |    |  |_____|   _________|",
                    "|          |    |    ' '      | | | | |",
                    "|__        |    |             | | | | |",
                    "|  |       |    |             | | | | |",
                    "|z |    ___|    |            _|_|_|_|_|",
                    "|  |   |   |    |_____________________|",
                    "|__|___|___|____|_____________________|",
                ],
                [ 
                    " _____________________________________ ",
                    "/__|       |       |_)|0 0|(_|        |",
                    "|__|       |       |_)|0 0|(_|        |",
                    "|  |       |       |_)|0 0|(_|        |",
                    "|()|       |                          |",
                    "|  |       |     __         ()        |",
                    "|  |       |    |  |        _______   |",
                    "|{}|       |    |  |       (_______)  |",
                    "|{}|       |    |  |                  |",
                    "|  |       |    |  |         _____    |",
                    "|__|_______|    |  |________|_(_)_|___|",
                    "|__________|    |_____________________|",
                    "|  |_O_|   |    |  |_____|   _________|",
                    "|          |    |    ' '      | | | | |",
                    "|__        |    |             | | | | |",
                    "|  |       |    |             | | | | |",
                    "|z |    ___|    |            _|_|_|_|_|",
                    "|  |   |   |    |_____________________|",
                    "|__|___|___|____|_____________________|",
                ]

            }; 
            string[][] secondFloor = {
            [
                    " _____________________________________ ",
                    "/   |  | |         |    |( ) ( )|     |",
                    "|   |  |0|         |    |       |     |",
                    "|___|  |_|        /     |       |     |",
                    "|        |              |_______|     |",
                    "|.       |         |                  |",
                    "|0 )     |         |                  |",
                    "|________|         |                  |",
                    "|                  |      _______     |",
                    "|                __|_____|_(___)_|____|",
                    "|               |                     |",
                    "|________       |_____________________|",
                    "|________|      |  |_____|   _________|",
                    "|___''   |      |    ' '      | | | | |",
                    "|   |   /      /              | | | | |",
                    "|() | <<                      | | | | |",
                    "|___|    |  ()  |            _|_|_|_|_|",
                    "|___..___|      |_____________________|",
                    "|________|______|_____________________|",
            ],
            [
                    " _____________________________________ ",
                    "/   |  | |         |    |( ) ( )|     |",
                    "|   |  |0|         |    |       |     |",
                    "|___|  |_|         |    |       |     |",
                    "|        |         |    |_______|     |",
                    "|.       |  ()     |                  |",
                    "|0 )     |         |                  |",
                    "|________|         |                  |",
                    "|                  |      _______     |",
                    "|                __|_____|_(___)_|____|",
                    "|               |                     |",
                    "|________       |_____________________|",
                    "|________|      |  |_____|   _________|",
                    "|___''   |      |    ' '      | | | | |",
                    "|   |    |      |             | | | | |",
                    "|() | << |      |             | | | | |",
                    "|___|    |      |            _|_|_|_|_|",
                    "|___..___|      |_____________________|",
                    "|________|______|_____________________|",
            ],
            [
                    " _____________________________________ ",
                    "/   |  | |         |    |( ) ( )|     |",
                    "|   |  |0|         |    |       |     |",
                    "|___|  |_|         |    |       |     |",
                    "|        |         |    |_______|     |",
                    "|.       |         |                  |",
                    "|0 )     |         |                  |",
                    "|________|         |                  |",
                    "|                  |      _______     |",
                    "|                __|_____|_(___)_|____|",
                    "|               |                     |",
                    "|________       |_____________________|",
                    "|________|      |  |_____|   _________|",
                    "|___''   |      |    ' '      | | | | |",
                    "|   |   /       |             | | | | |",
                    "|() | <<        |             | | | | |",
                    "|___| () |      |            _|_|_|_|_|",
                    "|___..___|      |_____________________|",
                    "|________|______|_____________________|",
            ],
            [
                    " _____________________________________ ",
                    "/   |  | |         |    |( ) ( )|     |",
                    "|   |  |0|         |    |       |     |",
                    "|___|  |_|         |    |       |     |",
                    "|        |         |    |_______|     |",
                    "|.       |         |                  |",
                    "|0 )     |         |                  |",
                    "|________|         |                  |",
                    "|                  |      _______     |",
                    "|                __|_____|_(___)_|____|",
                    "|               |                     |",
                    "|________       |_____________________|",
                    "|________|      |  |_____|   _________|",
                    "|___''   |      |    ' '      | | | | |",
                    "|   |    |     /              | | | | |",
                    "|() | << |            ()      | | | | |",
                    "|___|    |      |            _|_|_|_|_|",
                    "|___..___|      |_____________________|",
                    "|________|______|_____________________|",
            ],
            [
                    " _____________________________________ ",
                    "/   |  | |         |    |( ) ( )|     |",
                    "|   |  |0|         |    |       |     |",
                    "|___|  |_|         |    |       |     |",
                    "|        |         |    |_______|     |",
                    "|.  ()  /          |                  |",
                    "|0 )               |                  |",
                    "|________|         |                  |",
                    "|                  |      _______     |",
                    "|                __|_____|_(___)_|____|",
                    "|               |                     |",
                    "|________       |_____________________|",
                    "|________|      |  |_____|   _________|",
                    "|___''   |      |    ' '      | | | | |",
                    "|   |    |      |             | | | | |",
                    "|() | << |      |             | | | | |",
                    "|___|    |      |            _|_|_|_|_|",
                    "|___..___|      |_____________________|",
                    "|________|______|_____________________|",
            ],
            [
                    " _____________________________________ ",
                    "/   |  | |         |    |( ) ( )|     |",
                    "|   |  |0|         |    |       |     |",
                    "|___|  |_|        /     |       |     |",
                    "|        |              |_______|     |",
                    "|.       |         |                  |",
                    "|0 )     |         |       ()         |",
                    "|________|         |                  |",
                    "|                  |      _______     |",
                    "|                __|_____|_(___)_|____|",
                    "|               |                     |",
                    "|________       |_____________________|",
                    "|________|      |  |_____|   _________|",
                    "|___''   |      |    ' '      | | | | |",
                    "|   |    |      |             | | | | |",
                    "|() | << |      |             | | | | |",
                    "|___|    |      |            _|_|_|_|_|",
                    "|___..___|      |_____________________|",
                    "|________|______|_____________________|",
            ],
            };
            string[][] sheltherRoom = {
            [
                 "_____________________________________",
                 "|                      [x]          |",
                 "|  ___________                      |",
                @"|  |  \/  /  |            __________|",
                @"|  | x \_/\  |            |         |",
                @"|  |___/___\_|            |_________|",
                @"|                         |         |",
                @"|                ___      |_________|",
                @"|               ('_')     |         |",
                @"|               /)^(\     |_________|",
                @"|              ' |_| '    |         |",
                @"|            |---------|  |_________|",
                @"|____________|__/___\__|__|_________|",

            ],
            [ // shelther but with a gun.(style points)
                 "_____________________________________",
                 "|                      [x]          |",
                 "|  ___________                      |",
                @"|  |  \/  /  |            __________|",
                @"|  | x \_/\  |            |         |",
                @"|  |___/___\_|            |_________|",
                @"|                         |         |",
                @"|        __      ___      |_________|",
                @"|  _____/__|_   ('_')     |         |",
                @"|      '|__|    /)^(\     |_________|",
                @"|              ' |_| '    |         |",
                @"|            |---------|  |_________|",
                @"|____________|__/___\__|__|_________|",

            ],
            };
            
            // game state variables

            int day = 0; // Tracks current survival day

            int width = 120; // To make the menu and text in the center
            int height = 25; // The height of the menu

            int pos = 0; // Current room index
            int fakePos = 0; // made this int because i made the pos from the first layer the same as the second, but the item randomizer method didint like that so now it knows if its the room from upstairs or downstairs

            int chosenDifficulty = (int)Difficulty.Medium; // Basic difficulty
            int selected = 0;  // Menu selection index
            int layerOn = 1; // 1 == ground level, 5 == basement.

            //player status values
            int thirst = 0;
            int hunger = 0;
            int crazy = 0;
            int tired = 0;
            int infected = 0;

            // Game States

            bool death = false;
            bool shelterDialogue = false;
            bool menuLoaded = false;
            bool houseLoaded = false;
            bool startShelterPart = false;

            // Easily display amount of certain items.

            int amountBandage = 0;
            int amountWater = 0;
            int amountSoup = 0;

            // Collection of all the items in the game.

            string[] items = {"Water Bottle", "Can of Soup", "Water Bottle", "Can of Soup", "Gun", "Bandage", "Dust",};

            List<int> emptyRoom = new List<int>();  // to make sure there is only 1 item in each room.
            List<string> inventory = new List<string>(); // inventory.

            string drawIcon = " "; // so i could debug the height and width easily and see what it was doing.

            string[] menuButtons = { "Play", "Settings", "Exit" }; // for the menu text.

            Menu();

            void Menu()
            {
                // reset values.

                death = false;
                menuLoaded = true;
                Console.Clear();

                for (int i = 0; i < height; i++) // drawing the menu
                {
                    Console.WriteLine("");

                    for (int j = 0; j < width; j++) // same here
                    {

                        if (j == (width / 2 - 1) && i == 3 && selected != 1) // finding the middle and checking if the height is correct
                        {
                            Console.Write(menuButtons[selected]);
                            j++;

                        }
                        else if (j == (width / 2 - 2) && i == 3 && selected == 1) // because play, exit are 4 character and settings is 8 characters.
                        {
                            Console.Write(menuButtons[selected]);
                            j++;
                        }
                        else // when not at the text position it draws " "
                        {
                            Console.Write(drawIcon);

                        }
                    }
                }
            }

            while (true) // main game loop
            {
                ConsoleKey lastInput = Console.ReadKey(true).Key; // finds the input of the keyboard. So no need of string input = console.readline();

                if (menuLoaded && houseLoaded) // basic game safe guard thing so it doesnt overlap and bug. This has happend took 1 hour to fix :(
                {
                    houseLoaded = false; 
                }

                // menu input

                if (!death) // when alive
                {
                    if (!houseLoaded) // and the house is not loaded
                    {
                        switch (lastInput) // switch case just cuz
                        {
                            case ConsoleKey.Enter: // select the text your on.
                                {
                                    loadSelected(); // calls method
                                    menuLoaded = false; // menu is not loaded anymore
                                    break;
                                }
                            case ConsoleKey.W: // go up in index
                                {
                                    selected++;

                                    if (selected == 3) // when your at play and press w it goes to exit so this just brings you back
                                    {
                                        selected = 0;
                                    }

                                    Menu(); // redraws menu
                                    break;
                                }
                            case ConsoleKey.S: // same as the w case
                                selected--;

                                if (selected == -1)
                                {
                                    selected = 2;
                                }

                                Menu();
                                break;
                        }
                    }
                    // house input

                    else // if the house is loaded
                    {
                        switch (lastInput)
                        {
                            case ConsoleKey.E: //confirm
                                {
                                    if (pos > 1 && fakePos != 10) // if not in the hall
                                    {
                                        if (!emptyRoom.Contains(fakePos)) // so it checks if the position the player is in the emptyRoom list, if its not in the list it randomizes the object
                                        {
                                            inventory.Add(RandomizeObject());  // RandomizeObject returns a int of a object and the index of the item in the inventory. I am happy of this script :)
                                        }
                                    }
                                    else if (fakePos == 10) // if your player is in the room with the shelther and e is pressed.
                                    {
                                        RenderHouse(); // redraws house
                                        shelterDialogue = true;
                                        Console.WriteLine(" ");
                                        Console.WriteLine("Do you want to enter the shelter? [y], [n]"); // ask for input
                                        string input = Console.ReadLine();

                                        if (input == "y") // checks the input
                                        {
                                            StartSecondPhase();
                                        }
                                        else if (input == "n") // also if it the input doesnt match with the players input it does this statement.
                                        {
                                            shelterDialogue = false;
                                            RenderHouse(); // redraws
                                        }
                                    }

                                    break;
                                }
                            case ConsoleKey.W: // basic input. if w is pressed and in the hall pos = 1.
                                {
                                    if (pos == 0)
                                    {
                                        pos = 1;
                                    }

                                    break;
                                }
                            case ConsoleKey.S: // same for the w but reversed.
                                {
                                    if (pos == 1)
                                    {
                                        pos = 0;
                                    }
                                    break;
                                }
                            case ConsoleKey.D: //  this script just makes sure you go to the right. And you cant ofc go to the right if your already on the right side.
                                {
                                    if (pos == 0)
                                    {
                                        pos = 3;
                                    }
                                    else if (pos == 2)
                                    {
                                        pos = 0;
                                    }
                                    else if (pos == 4)
                                    {
                                        pos = 1;
                                    }
                                    else if (pos == 1)
                                    {
                                        pos = 5;
                                    }
                                    else if (pos == 3 && layerOn == 1) // go downstairs
                                    {
                                        layerOn = 5;
                                        pos = 3;
                                    }
                                    else if (pos == 3 && layerOn == 5) // go upstairs
                                    {
                                        layerOn = 1;
                                        pos = 3;
                                    }

                                    fakePos = pos * layerOn; // so it doesnt layer on each other.

                                    break;
                                }
                            case ConsoleKey.A: // same for d but then reversed ofc.
                                {
                                    if (pos == 0)
                                    {
                                        pos = 2;
                                    }
                                    else if (pos == 3)
                                    {
                                        pos = 0;
                                    }
                                    else if (pos == 1)
                                    {
                                        pos = 4;
                                    }
                                    else if (pos == 5)
                                    {
                                        pos = 1;
                                    }

                                    fakePos = pos * layerOn;
                                    break;
                                }

                        }
                        if (!startShelterPart && !menuLoaded) // so if nothing is loaded than it loads the house. Also a safe to prevent bugs.
                        {
                            RenderHouse();
                        }
                       
                    }
                }

            }

            // loads the selected method.

            void loadSelected()
            {
                Console.Clear();

                switch (selected)
                {
                    case (0): // play
                        {
                            menuLoaded = false;
                            houseLoaded = true; 
                            LoadGame();
                            break;
                        }
                    case (1): // settings
                        {
                            LoadSettings();
                            break;
                        }
                    case (2): // exit
                        {
                            break;
                        }

                }
            }

            // settings method

            void LoadSettings()
            {
                Console.Clear();

                Console.WriteLine($"Chose between these difficulties.");
                Console.WriteLine("Easy, Medium, Hard. [1] [2] [3]");

                string input = Console.ReadLine();

                //check what th user input and react based of that.
                if (input == "1") 
                {
                    chosenDifficulty = (int)Difficulty.Easy;

                    Console.WriteLine("You have set your difficulty to easy.");
                }
                else if (input == "2")
                {
                    chosenDifficulty = (int)Difficulty.Medium;

                    Console.WriteLine("You have set your difficulty to medium.");
                }
                else if (input == "3")
                {
                    chosenDifficulty = (int)Difficulty.Hard;

                    Console.WriteLine("You have set your difficulty to hard.");
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                    LoadSettings();
                }

                Console.ReadLine();

                menuLoaded = true;
                houseLoaded = false;
                selected = 0;
                Console.Clear();
                Menu(); // back to menu
            }

            // This is just to redraw the shelter and make sure nothing goes wrong i hope.
            void StartSecondPhase()
            {
                houseLoaded = false;
                startShelterPart = true;
                Console.Clear();

                int room = 0;

                if (inventory.Contains("Gun"))
                {
                    room = 1;
                }
                for (int i = 0; i < 13; i++)
                {
                    Console.WriteLine(sheltherRoom[room][i]);
                }

                StartDay();
            }

            // the real game starts here.
            
            void StartDay()
            {
                // + 1 every main status effect.
                day++;

                thirst += 1;
                hunger += 1;
                crazy += 1;
                tired += 1;

                // displays the status of the player
                Console.WriteLine("");
                Console.WriteLine($"Day: {day}");
                Console.WriteLine("");
                Console.WriteLine("Player Status");
                Console.WriteLine($"Thirst: {thirst}");
                Console.WriteLine($"Hunger: {hunger}");

                // checks the status and displays if a status goes above the max
                if (crazy > 10)
                {
                    Console.WriteLine($"Crazy!");
                }
                if (tired > 5)
                {
                    Console.WriteLine($"Tired!");
                }
                if (infected >= 1) // can be cured by bandage and makes infected 0 so it doesnt do this statement anymore
                {
                    infected++;
                    Console.WriteLine("Infected!");
                }

                if (hunger > 5)
                {
                    Console.WriteLine("You need to eat or you will die.");
                    Console.ReadLine();
                }

                if (thirst > 2)
                {
                    Console.WriteLine("You need to drink or you will die.");
                    Console.ReadLine();
                }

                // If one of these values is true then you died
                if (hunger > 6 || thirst > 3 || infected == 4)
                {
                    Console.WriteLine("You died");
                    death = true;
                    Console.ReadLine();
                    EndGame(); // ends the game.
                }
                else // if not died then it displays the dialogue
                {
                    Dialogue();
                }
            }

            // main interaction.
            
            void Dialogue()
            {
                //resets count.
                amountWater = 0;
                amountSoup = 0; 
                amountBandage = 0;

                Random rnd = new Random();
                int sequence = rnd.Next(1,6); // randomize interaction.

                Console.WriteLine("");
                Console.WriteLine("Do u want to explore?, Or check the fridge? [1] [2]"); 
                string input = Console.ReadLine();

                if (input == "1" && tired < 5) // if not tired then.
                {
                    Explore(sequence);
                }
                else if (input == "2") // check the fridge
                {
                    for (int i = 0; i < inventory.Count; i++) // checking and counting items. Dont know if there is a better way for this but this worked first try :)
                    {
                        // just adds the amount it finds.
                        if (inventory[i] == "Water Bottle")
                        {
                            amountWater++;
                        }
                        else if (inventory[i] == "Can of Soup")
                        {
                            amountSoup++;
                        }
                        else if (inventory[i] == "Bandage")
                        {
                            amountBandage++;
                        }
                    }

                    // displays your inventory.
                    Console.WriteLine($"You have {amountWater} Water bottles, {amountSoup} can(s) of soup and {amountBandage} bandage(s).");
                    Console.WriteLine("");
                    Console.WriteLine("Do you want to eat or drink or fast or use bandage? [e] [d] [ed] [f] [b]");
                    string input2 = Console.ReadLine();

                    // checks if input is correct and have enough of the item you choose.
                    if (input2 == "e" && amountSoup > 0) 
                    {
                        inventory.Remove("Can of Soup"); // removes the item from the INVENTORY
                        tired = 0;
                        hunger = 0;
                        Console.WriteLine($"Your hunger is now: {hunger}"); // displays hunger.
                    }
                    else if (input2 == "d" && amountWater > 0)
                    {
                        inventory.Remove("Water Bottle");
                        tired = 0;
                        thirst = 0;
                        Console.WriteLine($"Your thirst is now: {thirst}");
                    }
                    else if (input2 == "ed" && amountSoup > 0  && amountWater > 0) // for both drinking and eating
                    {
                        inventory.Remove("Water Bottle");
                        inventory.Remove("Can of Soup");
                        tired = 0;
                        hunger = 0;
                        thirst = 0;
                        Console.WriteLine($"Your thirst is now: {thirst}, and your hunger is: {hunger}");
                    }
                    else if (input2 == "b" && amountBandage > 0) // applies bandage, and cures infection.
                    {
                        infected = 0;
                        Console.WriteLine("You used a bandage.");
                    }

                    Console.WriteLine("");
                    Sequence(sequence);
                }
                else // wrong input
                {
                    Dialogue(); 
                }
            }

            // interaction.

            void Sequence(int rndNumber) // rndNumber is the randomized interaction.
            {
                if (rndNumber < 4) // normal
                {
                    Console.WriteLine("Nothing happend... yet.");
                    Console.ReadLine();
                    StartSecondPhase();

                }
                else if (rndNumber == 4) // trust
                {
                    Random rnda = new Random();

                    int human = 3; // human 3 == human, human 2 == 50/50, human 1 == mutant big no no

                    int rand = rnda.Next(0, 4);

                    if (rand == 0)
                    {
                        human = 3;
                        Console.WriteLine("100% human");
                    }    
                    else if (rand == 1)
                    {
                        human = 2;
                        Console.WriteLine("50% human/ 50% mutant");
                    }
                    else
                    {
                        human = 1;
                        Console.WriteLine("100% Mutant");
                    }

                    Console.WriteLine("Someone is knocking on the shelter. Do you open the shelter? [y] [n]");
                    string input = Console.ReadLine();

                    // checks input
                    if (input == "y")
                    {
                        Random rnd = new Random();
                        if (rnd.Next(1, 7) == 4 && human <= 2 || human == 1)  // checks if the randomize matches 4 and if human is 2 or below, or human == 1 means that its a mutant so insta kill no luck.
                        {
                            Console.WriteLine("It was a mutant. He killed you..");
                            death = true;
                            Console.ReadLine();
                            EndGame();
                        }
                        else
                        {
                            // so i can keep track and display it to the player.
                            int gainedW = rnd.Next(0, 3 * chosenDifficulty); 
                            int gainedS = rnd.Next(0, 3 * chosenDifficulty);

                            // adds what you gained.
                            for (int i = 0; i < gainedW; i++)
                            {
                                inventory.Add("Water Bottle");
                            }
                            for (int i = 0; i < gainedS; i++)
                            {
                                inventory.Add("Can of Soup");
                            }

                            //displays it.
                            Console.WriteLine($"You gained: {gainedW} Water bottle and {gainedS} soup.");
                            Console.ReadLine();
                            StartSecondPhase();
                        }
                    }
                    else 
                    {
                        // and if you did not open it.
                        Console.WriteLine("You chose to keep the shelter closed.");
                        Console.ReadLine();
                        StartSecondPhase();
                    }

                }
                else if (rndNumber == 5) // shower infected
                {
                    Console.WriteLine("Your shower is infected, Do risk the chance of cathing a disease by fixing it or leave it. [1] [2]");
                    string input = Console.ReadLine();
                    
                    if (input == "1") // you chose to clean it
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(0,4);

                        if (num == 1) // bad luck
                        {
                            Console.WriteLine("You catched a disease. your hunger and thirst are trough the roof.");
                            thirst = 2;
                            hunger = 5;
                            Console.ReadLine();
                        }
                        else // good luck
                        {
                            inventory.Add("Water Bottle"); // adds a water bottle as reward
                            Console.WriteLine("You fixed it, Good job. You gained 1 Water Bottle.");
                            Console.ReadLine();
                        }
                    }
                    else // if not 1 is pressed then
                    {
                        Console.WriteLine("You decided to leave it alone.");
                        Console.ReadLine();
                    }

                    StartSecondPhase(); // always happens
                }
            }

            //exploration most op method to get good runs

            void Explore(int rndNumber) 
            {
                if (rndNumber <= 3)
                {
                    Console.WriteLine("You went to the neigbours house.");

                    if (rndNumber == 3) // bad luck
                    {
                        Console.WriteLine("You tried to defend yourself against a mutant");
                        Console.WriteLine("But lost.");
                        Console.ReadLine();
                        death = true;
                        EndGame();
                    }
                    else if (rndNumber <= 2) // good luck
                    {
                        Console.WriteLine("You tried to defend yourself against a mutant");
                        Console.WriteLine("And won.");
                        Random rnd = new Random();

                        // same as i said before i made this so i can keep track of what you gained and display it.
                        int gainedW = rnd.Next(1, 2 * chosenDifficulty);
                        int gainedS = rnd.Next(1, 3 * chosenDifficulty);

                        // adds what you got.
                        for (int i = 0; i < gainedW; i++)
                        {
                            inventory.Add("Water Bottle");
                        }
                        for (int i = 0; i < gainedS; i++)
                        {
                            inventory.Add("Can of Soup");
                        }

                        // Displays it.
                        Console.WriteLine($"You gained: {gainedW} Water bottle and {gainedS} soup.");
                        Console.ReadLine();
                        StartSecondPhase();
                    }
                }
                else if (rndNumber >= 4) // crazy good exploration luck cuz this has the best rewards.
                {
                    Console.WriteLine("You went to a hospital.");
                    Console.WriteLine("It is crawling with mutants.");
                    
                    if ( rndNumber == 4) // best case
                    {
                        Console.WriteLine("You somehow dodged every mutant, and found supplies.");

                        Random rnd = new Random();

                        // made this so i can keep track.
                        int gainedW = rnd.Next(1, 3 * chosenDifficulty);
                        int gainedS = rnd.Next(1, 4 * chosenDifficulty);
                        int gainedB = rnd.Next(0, 2 * chosenDifficulty);

                        // adds everything.
                        for (int i = 0; i < gainedW; i++)
                        {
                            inventory.Add("Water Bottle");
                        }
                        for (int i = 0; i < gainedS; i++)
                        {
                            inventory.Add("Can of Soup");
                        }

                        for (int i = 0; i < gainedB; i++)
                        {
                            inventory.Add("Bandage");
                        }

                        //displays it
                        Console.WriteLine($"You gained: {gainedW} Water bottle, {gainedS} soup and {gainedB} bandages.");
                    }
                    else if (rndNumber == 5) {
                        Console.WriteLine("You got hit by a mutant but still survived, and found supplies.");
                        Console.WriteLine("You need to use a bandage or you will get infected in 3 days.");

                        // so it adds that your infected and the if statement in start day now also functions.
                        infected += 1;

                        Random rnd = new Random();

                        // so i can keep track and display it.
                        int gainedW = rnd.Next(1, 3 * chosenDifficulty);
                        int gainedS = rnd.Next(1, 4 * chosenDifficulty);
                        int gainedB = rnd.Next(0, 2 * chosenDifficulty);

                        // adds everything.
                        for (int i = 0; i < gainedW; i++)
                        {
                            inventory.Add("Water Bottle");
                        }
                        for (int i = 0; i < gainedS; i++)
                        {
                            inventory.Add("Can of Soup");
                        }

                        for (int i = 0; i < gainedB; i++)
                        {
                            inventory.Add("Bandage");
                        }

                        //displays it.
                        Console.WriteLine($"You gained: {gainedW} Water bottle, {gainedS} soup and {gainedB} bandages.");
                    }
                    // always happens
                    Console.ReadLine();
                    StartSecondPhase();
                }
            }

            // when you die

            void EndGame()
            {
                Console.Clear(); // clears the console

                ResetVars(); // resets variables.

                Thread.Sleep(1000); // cooldown.
                Menu(); // displays menu again
            }

            void ResetVars() // resets every var that is needed to reset, and clears inventory and rooms.
            {
                pos = 0;
                fakePos = 0;

                layerOn = 1;

                startShelterPart = false;
                menuLoaded = true;
                houseLoaded = false;
                emptyRoom.Clear();
                inventory.Clear();
                thirst = 0;
                hunger = 0;
                crazy = 0;
                tired = 0;
                infected = 0;
                day = 0;
            }

            // loads the house and sets the vars correct.

            void LoadGame()
            {
                menuLoaded = false; 
                houseLoaded = true;

                RenderHouse();
            }

            // renders the house

            void RenderHouse()
            {
                Console.WriteLine("");
                Console.Clear();

                if (layerOn == 1) // normal fllor.
                {
                    for (int j = 0; j < 19; j++) // height
                    {
                        Console.WriteLine(firstFloor[pos][j]); // pos chooses the image your on, and j the height.
                    }
                }
                else // basement
                {
                    for (int j = 0; j < 19; j++) // height
                    {
                        Console.WriteLine(secondFloor[pos][j]); // same logic as the first floor.
                    }
                }

                Console.WriteLine("Inventory: "); //displays the inventory

                for (int i = 0; i < inventory.Count(); i++) // shows what you have in your inventory.
                {
                    Console.Write(inventory[i] + " "); // used write so it stays on the same line.
                }

                Console.WriteLine();
            }

            string RandomizeObject() // randomizes object.
            {
                Random rnd = new Random();
                int chosenItemIndex = rnd.Next(0, items.Length); // goes through item list.
                
                emptyRoom.Add(fakePos); // adds the room where you are so u cant get another item there.
                return items[chosenItemIndex]; // returns the item.
            }
        }
    }
}