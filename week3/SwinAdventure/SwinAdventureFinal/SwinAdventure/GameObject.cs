using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    // GameObject class that inherits from IdentifiableObject
    // Represents a basic object in the game with a name and description
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        // Constructor that initializes the GameObject with identifiers, name, and description
        public GameObject(string[] ids, string name, string description) : base(ids)
        {
            _name = name;
            _description = description;
        }

        // Name property - returns the name of the GameObject
        public string Name
        {
            get { return _name; }
        }

        // Description property - returns the full description of the GameObject
        public string Description
        {
            get { return _description; }
        }

        // Short Description - returns a brief description of the GameObject
        public virtual string ShortDescription
        {
            get { return $"{_name} ({FirstId})"; }
        }

        // Full Description - returns a complete description of the GameObject
        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}