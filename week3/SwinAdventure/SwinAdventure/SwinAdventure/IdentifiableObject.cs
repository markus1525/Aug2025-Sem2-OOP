using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        //Collection class to store identifiers

        private List<string> _identifiers;

        // Constructor: Initializes the object with an array of identifiers.
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string id in idents)
            {
                AddIdentifier(id);
            }
        }

        // Checks if a given 'id' is in the list (case-insensitive).
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        // Add FirstId property
        // Gets the first identifier, or an empty string if the list is empty.
        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                }
            }
        }

        // AddIdentifier Method
        // Adds a new identifier to the list in lowercase.
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        // RemoveIdentifier Method
        // Removes an identifier from the list.
        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }

        // PrivilegeEscalation Method
        // Replaces the first ID if the correct PIN is provided.
        public void PrivilegeEscalation(string pin)
        {
            if (pin == "4881" && _identifiers.Count > 0)
            {
                _identifiers[0] = "TUTE01";
            }
        }
    }
}