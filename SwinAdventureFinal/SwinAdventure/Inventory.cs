using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    // Inventory class to manage a collection of items
    public class Inventory
    {
        private List<Item> _items;

        // Constructor initializes an empty inventory
        public Inventory()
        {
            _items = new List<Item>();
        }

        // HasItem method checks if an item with the specified ID exists in the inventory
        public bool HasItem(string id)
        {
            return _items.Any(item => item.AreYou(id));
        }

        // Take method removes and returns an item from the inventory if it exists
        public Item? Take(string id)
        {
            Item? itemToTake = Fetch(id);
            
            if (itemToTake != null)
            {
                _items.Remove(itemToTake);
                return itemToTake;
            }
            
            return null;
        }

        // Put method adds an item to the inventory
        public void Put(Item item)
        {
            _items.Add(item);
        }

        // Fetch method returns an item from the inventory without removing it
        public Item? Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            
            return null;
        }

        // ItemList property returns a string listing all items in the inventory
        public string ItemList
        {
            get
            {
                if (_items.Count == 0)
                {
                    return "You are not carrying anything.";
                }
                
                string result = "You are carrying:";
                foreach (Item item in _items)
                {
                    result += $"\n{item.ShortDescription}";
                }
                
                return result + "\n";  // Add the missing newline at the end
            }
        }
    }
}