// CommandProcessor.cs - Processes and routes commands
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>
            {
                new LookCommand(),
                new MoveCommand(),
                new InventoryCommand(),
                new TakeCommand(),
                new PutCommand(),
                new QuitCommand()
            };
        }

        public string Process(string input, Player player)
        {
            string[] words = input.ToLower().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return "I don't understand";

            Command? command = _commands.FirstOrDefault(cmd => cmd.AreYou(words[0]));

            if (command == null)
                return $"I don't understand {words[0]}";

            return command.Execute(player, words);
        }
    }
}