using System;
using System.Collections.Generic;

namespace Program.cs
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            // Check if the current bag matches the ID
            if (AreYou(id))
            {
                return this;
            }

            // Look for the item in the bag's inventory
            GameObject foundItem = _inventory.Fetch(id);
            if (foundItem != null)
            {
                return foundItem;
            }

            return null; // Return null if the item is not found
        }

        public override string FullDescription
        {
            get
            {
                return $"In the {Name} you can see:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
