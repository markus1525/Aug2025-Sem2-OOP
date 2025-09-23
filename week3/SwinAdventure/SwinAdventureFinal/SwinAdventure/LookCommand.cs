// LookCommand.cs - Handles look commands
using System;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length == 1) // Just "look"
            {
                if (player.Location == null)
                {
                    return "You are nowhere!";
                }
                return player.Location.FullDescription;
            }
            else if (text.Length >= 3 && text[1] == "at") // "look at [something]"
            {
                string itemName = text[2];

                // Check for "look at [item] in [container]"
                if (text.Length >= 5 && text[3] == "in")
                {
                    string containerName = text[4];
                    GameObject container = player.Locate(containerName);

                    if (container == null && player.Location != null)
                        container = player.Location.Inventory.Fetch(containerName);

                    if (container == null)
                        return $"I can't find any {containerName}";

                    if (container is Bag bag)
                    {
                        Item item = bag.Inventory.Fetch(itemName);
                        if (item == null)
                            return $"I can't find any {itemName} in the {container.Name}";
                        return item.FullDescription;
                    }
                    else
                    {
                        return $"I can't look in the {container.Name}";
                    }
                }
                else // Just "look at [something]"
                {
                    GameObject? item = player.Locate(itemName);
                    if (item == null && player.Location != null)
                        item = player.Location.Inventory.Fetch(itemName);

                    if (item == null)
                        return $"I can't find any {itemName}";
                    return item.FullDescription;
                }
            }

            return "I don't know how to look like that";
        }
    }
}