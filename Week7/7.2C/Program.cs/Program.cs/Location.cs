using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class Location: GameObject
    {
        private Inventory _inventory;
        public Location(string name, string description) : base(new string[] { name.ToLower() }, name, description)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get {  return _inventory; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);  
        }

        public override string FullDescription
        {
            get
            {
                return $"{Name}: {base.FullDescription}";  
            }
        }
    }
}
