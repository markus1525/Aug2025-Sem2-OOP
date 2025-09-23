using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    // Enhanced Player class that adds Location tracking to your existing implementation
    public class Player : GameObject
    {
        private Inventory _inventory;
        private Location? _location;

        // Constructor remains the same as your existing implementation
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = null;
        }

        // Keep your existing Inventory property
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        // Add Location property for game world navigation
        public Location? Location
        {
            get { return _location; }
            set { _location = value; }
        }

        // Updated Player.cs FullDescription property
        public override string FullDescription
        {
            get { return $"You are {Name}, {Description}\n{_inventory.ItemList}"; }
        }

        // Update your Locate method to also search the current location:
        public GameObject? Locate(string id)
        {
            if (AreYou(id))
                return this;

            GameObject? item = _inventory.Fetch(id);
            if (item != null)
                return item;

            // Add these lines to search current location:
            if (_location != null)
            {
                if (_location.AreYou(id))
                    return _location;

                return _location.Inventory.Fetch(id);
            }

            return null;
        }
    }
}