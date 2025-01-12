using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class Inventory
    {
        private List<GameObject> _items;

        public Inventory()
        {
            _items = new List<GameObject>();
        }

        public bool HasItem(string id)
        {
            return Fetch(id) != null;
        }

        public void Put(GameObject item)
        {
            _items.Add(item);
        }

        public GameObject Take(string id)
        {
            GameObject item = Fetch(id);
            if(item != null)
            {
                _items.Remove(item);
            }
            return item;            
        }

        public GameObject Fetch(string id)
        {
            foreach (GameObject item in _items)
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
                foreach(GameObject item in _items)
                {
                    itemList += "\t" + item.ShortDescription + "\n";
                }
                return itemList.TrimEnd();
            }
        }
        public List<GameObject> Items
        {
            get { return _items; }
        }
    }
}
