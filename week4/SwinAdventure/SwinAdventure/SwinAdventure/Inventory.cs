using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        // Fields
        private List<Item> _items; //Aggregation relationship

        //Constructor
        public Inventory()
        {
            _items = new List<Item>();
        }

        //Methods
        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item? Take(string id)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].AreYou(id))
                {
                    Item item = _items[i];
                    _items.RemoveAt(i);
                    return item;
                }
            }
            return null;
        }

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

        //Property
        public string ItemList
        {
            get
            {
                string result = "The List of items in this inventory:\n"; //verification task
                foreach (Item item in _items)
                {
                    result = result + "\t" + item.ShortDescription + "\n";
                }
                return result;
            }
        }
    }
}