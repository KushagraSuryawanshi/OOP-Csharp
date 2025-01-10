using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"}) 
        {

        }
        public override string Execute(Player p, string[] text)
        {
            if(text.Length!=3 && text.Length!=5)
            {
                return "I don’t know how to look like that";
            }

            if (text[0].ToLower()!= "look")
            {
                return "Error in look input";
            }

            if(text[1].ToLower()!= "at")
            {
                return "What do you want to look at?";
            }

            IHaveInventory container;

            if(text.Length == 3)
            {
                container = p as IHaveInventory;
            }
            else if(text.Length == 5)
            {
                if(text[3].ToLower()!= "in")
                {
                    return "“What do you want to look in?";
                }

                container = FetchContainer(p, text[4]);

                if (container == null)
                {
                    return $"I can't find the {text[4]}";
                }
            }
            else
            {
                return "I don't know how to look like that";
            }

            string itemId = text[2];
            string result = LookAtIn(itemId, container);

            if (result == null)
            {
                if (text.Length == 3)
                {
                    return $"I can't find the {itemId}";
                }
                else
                {
                    return $"I can't find the {itemId} in the {container.Name}";
                }
            }

            return result;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject obj = p.Locate(containerId);
            IHaveInventory container = obj as IHaveInventory;

            if (container == null)
            {
                return null;
            }

            return container;   
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject item = container.Locate(thingId);

            if (item != null)
            {
                return item.FullDescription;
            }

            return null;
        }
    }
}
