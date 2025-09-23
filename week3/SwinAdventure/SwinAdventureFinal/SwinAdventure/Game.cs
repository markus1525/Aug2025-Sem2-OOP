using System;

namespace SwinAdventure
{
    public class Game
    {
        private Player? _player;
        private CommandProcessor? _commandProcessor;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Create player - using your existing constructor
            _player = new Player("Fred", "the mighty programmer");

            // Create command processor
            _commandProcessor = new CommandProcessor();

            // Setup the game world
            SetupWorld();
        }

        private void SetupWorld()
        {
            // Create locations exactly as specified in requirements
            Location hallway = new Location("Hallway", "This is a long well lit hallway.");
            Location closet = new Location("small Closet", "A small dark closet, with an odd smell");
            Location garden = new Location("small Garden", "There are many small shrubs and flowers growing from well tended garden beds.");

            // Create items using your existing Item constructor
            Item shovel = new Item(new string[] { "shovel" }, "shovel", "A sturdy digging shovel");
            Item sword = new Item(new string[] { "sword", "bronze sword" }, "bronze sword", "A short sword cast from bronze");
            Item computer = new Item(new string[] { "pc", "computer" }, "small computer", "The light from the monitor of this computer illuminates the room");

            // Create bag and gem
            Bag bag = new Bag(new string[] { "bag", "leather bag" }, "leather bag", "A small brown leather bag.");
            Item gem = new Item(new string[] { "gem", "red gem" }, "red gem", "A bright red ruby the size of your fist!");

            // Place items in locations as per requirements
            hallway.Inventory.Put(shovel);
            hallway.Inventory.Put(sword);
            closet.Inventory.Put(computer);
            garden.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            // Create paths between locations
            Path southPath = new Path(new string[] { "south", "s" }, "a door", closet);
            Path northPath = new Path(new string[] { "north", "n" }, "a door", hallway);
            Path eastPath = new Path(new string[] { "east", "e" }, "a small door", garden);
            Path westPath = new Path(new string[] { "west", "w" }, "a small door", closet);
            Path northToHallPath = new Path(new string[] { "north", "n" }, "a small door", hallway);

            // Add paths to locations
            hallway.AddPath(southPath);
            closet.AddPath(northPath);
            closet.AddPath(eastPath);
            garden.AddPath(westPath);
            garden.AddPath(northToHallPath);

            // Set starting location
            _player.Location = hallway;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Swin Adventure!");
            Console.WriteLine($"You have arrived in the {_player.Location.Name}");

            string input;
            do
            {
                Console.Write("Command -> ");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    string result = _commandProcessor.Process(input, _player);

                    if (result == "quit")
                    {
                        Console.WriteLine("Bye.");
                        break;
                    }

                    Console.WriteLine(result);
                }
            }
            while (true);
        }
    }
}