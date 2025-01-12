using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2) // If the command is not in the right format
            {
                return "I don't know how to move like that";
            }

            string command = text[0].ToLower();  // Get command (e.g., "move")
            string direction = text[1].ToLower();  // Get direction (e.g., "north")

            // Get the path from the player's current location
            Path path = p.Location.GetPath(direction);

            if (path == null) 
            {
                return $"There is no path to the {direction}";
            }

            if (path.Blocked)  
            {
                return "The path is blocked.";
            }

            /// Move the player to the destination if the path is not blocked
            path.MovePlayer(p);
            return $"You head {direction} and arrive at {p.Location.Name}";
        }
    }
}

