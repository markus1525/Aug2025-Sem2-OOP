using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Player : GameObject
    {
        // Fields
        private Inventory _inventory;

        // Constructor
        public Player(string name, string desc)
            : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        // Property
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        // Locate method to find a GameObject around the player
        public GameObject? Locate(string id)
        {
            // First check if they're looking for the player themselves
            if (AreYou(id))
            {
                return this;
            }

            // Then check the player's inventory for the item
            return _inventory.Fetch(id);
        }

        // Override FullDescription to include player info and inventory
        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}\n" +
                "You are carrying:\n" + _inventory.ItemList;
            }
        }

        // Override SaveToFile to save player info including inventory
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(_inventory.ItemList);
        }

        // Override LoadFromFile to load player info and display it
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string? ItemDescriptionList = reader.ReadLine();

            // display the information to Console
            Console.WriteLine("Player Information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(ItemDescriptionList);
        }
    }
}