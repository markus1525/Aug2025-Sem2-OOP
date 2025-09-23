using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Item
    {
        //Collection class to store identifiers
        private List<string> _identifiers;

        // Add private fields
        private string _name;
        private string _description;

        // Constructor for the Item.
        public Item(string[] idents, string name, string desc)
        {
            _identifiers = new List<string>();
            for (int i = 0; i < idents.Length; i++)
            {
                AddIdentifier(idents[i]);
            }
            _name = name;
            _description = desc;
        }

        //Methods
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public void PrivilegeEscalation(string pin)
        {
            _identifiers[0] = "TUTE01";
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                return "";
            }
        }

        // A read-only property to get the item's name.
        public string Name
        {
            get { return _name; }
        }

        // A read-only property that formats a short description.
        public string ShortDescription
        {
            get { return "a " + _name + " (" + _identifiers[0] + ")"; }
        }

        // A read-only property to get the item's full description.
        public string LongDescription
        {
            get { return _description; }
        }
    }
}