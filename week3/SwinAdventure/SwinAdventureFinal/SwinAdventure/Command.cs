// Command.cs - Base class for all commands
using System;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] identifiers) : base(identifiers)
        {
        }

        public abstract string Execute(Player player, string[] text);
    }
}