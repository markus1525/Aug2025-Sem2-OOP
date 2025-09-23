// MoveCommand.cs - Handles movement commands
using System;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length < 2)
                return "Where do you want to go?";

            if (player.Location == null)
                return "You are nowhere!";

            string direction = text[1];
            Path path = player.Location.GetPath(direction);

            if (path == null)
                return $"I can't go {direction}";

            // Move the player
            player.Location = path.Destination;

            return $"You head {direction.ToUpper()}\n" +
                   $"You go through {path.Description}.\n" +
                   $"You have arrived in the {path.Destination.Name}";
        }
    }
}
