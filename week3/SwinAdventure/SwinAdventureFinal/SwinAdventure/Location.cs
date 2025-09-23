// Location.cs - Represents game locations/rooms
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwinAdventure
{
    public class Location : GameObject
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string name, string description)
            : base(new string[] { "room", "here" }, name, description)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public Path GetPath(string direction)
        {
            return _paths.FirstOrDefault(path => path.AreYou(direction));
        }

        public override string FullDescription
        {
            get
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"You are in the {Name}");
                result.AppendLine(Description);

                // Add exits
                if (_paths.Count > 0)
                {
                    result.Append("There are exits to the ");
                    for (int i = 0; i < _paths.Count; i++)
                    {
                        result.Append(_paths[i].FirstId);
                        if (i < _paths.Count - 2)
                            result.Append(", ");
                        else if (i == _paths.Count - 2)
                            result.Append(", and ");
                    }
                    result.AppendLine(".");
                }

                // Add items - modify to work with your existing inventory format
                string items = _inventory.ItemList;
                if (items != "You are not carrying anything.")
                {
                    result.AppendLine("In this room you can see:");
                    // Extract just the item descriptions from inventory format
                    string[] lines = items.Split('\n');
                    for (int i = 1; i < lines.Length - 1; i++) // Skip first and last line
                    {
                        if (!string.IsNullOrWhiteSpace(lines[i]))
                            result.AppendLine(lines[i]);
                    }
                }

                return result.ToString().TrimEnd();
            }
        }
    }
}