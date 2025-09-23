// InventoryCommand.cs - Shows player inventory
using System;

namespace SwinAdventure
{
    public class InventoryCommand : Command
    {
        public InventoryCommand() : base(new string[] { "inventory", "inv", "i" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            return player.FullDescription;
        }
    }
}