using System;
using SwinAdventure;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Week 8 - SwinAdventure");

            // Create a player
            Player _testPlayer = new Player("Markus", "an explorer");

            // Create items
            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");

            // add items in the player's inventory
            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

            // Print the player Identifiers
            Console.WriteLine(_testPlayer.AreYou("me"));
            Console.WriteLine(_testPlayer.AreYou("inventory"));

            if (_testPlayer.Locate("torch") != null)
            {
                Console.WriteLine("The object torch exists");
                Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
            }
            else
            {
                Console.WriteLine("The object torch does not exist");
            }

            Console.WriteLine("");

            //write the PlayerObject to a file
            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }
            
            //read from the file
            StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}