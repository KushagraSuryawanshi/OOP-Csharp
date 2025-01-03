using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            return Fetch(id) != null;
        }

        public void Put(Item item)
        {
            _items.Add(item);
        }

        public Item Take(string id)
        {
            Item item = Fetch(id);
            if(item != null)
            {
                _items.Remove(item);
            }
            return item;            
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string itemList = "";
                foreach(Item item in _items)
                {
                    itemList += "\t" + item.ShortDescription + "\n";
                }
                return itemList.TrimEnd();
            }
        }
    }
}
