using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Item : GameObject
    {
        // Constructor for the Item.
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {

        }

        // Verification Tasks
        // Only override this because items need "a" in front
        public override string ShortDescription
        {
            get { return "a " + Name + " (" + FirstId + ")"; }
        }

        // Override LongDescription to combine short description + description
        public override string FullDescription
        {
            get { return ShortDescription + " - " + base.FullDescription; }
        }

    }
}