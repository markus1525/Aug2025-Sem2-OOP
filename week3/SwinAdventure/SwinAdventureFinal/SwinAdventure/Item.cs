using System;

namespace SwinAdventure;

// The "Item" class inherits from "GameObject".
public class Item : GameObject
{
    // Constructor for the Item.
    public Item(string[] idents, string name, string desc) : base(idents, name, desc)
    {
        // 'base(idents, name, desc)' passes the parameters up to the parent GameObject constructor.
    }

    // A read-only property that formats a short description.
    // Returns a string like "a bronze sword (sword)".
    public override string ShortDescription
    {
        get { return $"a {Name} ({FirstId})"; }
    }

    // A read-only property to get the item's full description.
    public override string FullDescription
    {
        get { return Description; }
    }
}
