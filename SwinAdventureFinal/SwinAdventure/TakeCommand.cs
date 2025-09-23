// TakeCommand.cs - Handles pickup/take commands
using System;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "take", "pickup" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length < 2)
                return "What do you want to take?";

            string itemName = text[1];
            Item item = null;
            string source = "room";

            // Check for "take [item] from [container]"
            if (text.Length >= 4 && text[2] == "from")
            {
                string containerName = text[3];
                GameObject? container = player.Locate(containerName);

                if (container == null && player.Location != null)
                    container = player.Location.Inventory.Fetch(containerName);

                if (container == null)
                    return $"I can't find any {containerName}";

                if (containerName == "room" || container == player.Location)
                {
                    if (player.Location == null)
                    {
                        return "You are nowhere!";
                    }
                    item = player.Location.Inventory.Take(itemName);
                    source = player.Location.Name;
                }
                else if (container is Bag bag)
                {
                    item = bag.Inventory.Take(itemName);
                    source = container.Name;
                }
                else
                {
                    return $"I can't take anything from the {container.Name}";
                }
            }
            else
            {
                // Default to taking from current location
                if (player.Location != null)
                {
                    item = player.Location.Inventory.Take(itemName);
                    source = player.Location.Name;
                }
            }

            if (item == null)
                return $"I can't find any {itemName}";

            player.Inventory.Put(item);
            return $"You have taken the {item.Name} from the {source}";
        }
    }
}