using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
                _commands.Add(command);
        }

        public string ExecuteCommand(Player player, string[] text)
        {
            if(text.Length == 0)
            {
                return "No command entered!";
            }
            string commandId = text[0].ToLower();

            Command command = FindCommand(commandId);
            if (command != null)
            {
                return command.Execute(player, text);  
            }
            return $"Unknown command: {commandId}";
        }
        // Method to search for the correct command
        private Command FindCommand(string id)
        {
            foreach (Command cmd in _commands)
            {
                if (cmd.AreYou(id))
                {
                    return cmd;
                }
            }
            return null; 
        }
    }
}
