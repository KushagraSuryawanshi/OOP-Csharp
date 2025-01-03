using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string description) : base(new string[] {"me", "inventory"}, name, description)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}. You are carrying:\n{_inventory.ItemList}";
            }
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }   
    }
}
