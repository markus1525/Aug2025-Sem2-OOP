// PutCommand.cs - Handles put/drop commands
using System;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length < 2)
                return "What do you want to put down?";

            string itemName = text[1];
            Item item = player.Inventory.Take(itemName);

            if (item == null)
                return $"I can't find any {itemName}";

            // Check for "put [item] in [container]"
            if (text.Length >= 4 && text[2] == "in")
            {
                string containerName = text[3];
                GameObject? container = player.Locate(containerName);

                if (container == null && player.Location != null)
                    container = player.Location.Inventory.Fetch(containerName);

                if (container == null)
                {
                    player.Inventory.Put(item); // Put it back
                    return $"I can't find any {containerName}";
                }

                if (containerName == "room" || container == player.Location)
                {
                    player.Location.Inventory.Put(item);
                    return $"You have put the {item.Name} in the {player.Location.Name}";
                }
                else if (container is Bag bag)
                {
                    bag.Inventory.Put(item);
                    return $"You have put the {item.Name} in the {container.Name}";
                }
                else
                {
                    player.Inventory.Put(item); // Put it back
                    return $"I can't put anything in the {container.Name}";
                }
            }
            else
            {
                // Default to putting in current location
                if (player.Location != null)
                {
                    player.Location.Inventory.Put(item);
                    return $"You have put the {item.Name} in the {player.Location.Name}";
                }
                else
                {
                    player.Inventory.Put(item); // Put it back
                    return "You are nowhere to put things!";
                }
            }
        }
    }
}