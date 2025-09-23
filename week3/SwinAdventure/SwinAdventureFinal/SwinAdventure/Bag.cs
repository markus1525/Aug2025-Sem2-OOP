// Bag.cs - A container that can hold other items
using System.Text; // Add this missing using statement

namespace SwinAdventure
{
    public class Bag : Item
    {
        private Inventory _inventory;

        public Bag(string[] identifiers, string name, string description)
            : base(identifiers, name, description)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine(base.FullDescription);
                result.Append("You look in the ");
                result.Append(Name);
                result.AppendLine(" and see:");

                // Format items without the "You are carrying:" prefix
                string items = _inventory.ItemList;
                if (items == "You are not carrying anything.")
                {
                    result.Append("nothing");
                }
                else
                {
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