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
        private List<Path> _paths;

        public Location(string name, string description) : base(new string[] { name.ToLower() }, name, description)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Inventory Inventory
        {
            get {  return _inventory; }
        }

        // Method to add a path to the location
        public void AddPath(Path path)
        {
            _paths.Add(path); 
        }

        // Method to get a path by its direction
        public Path GetPath(string direction)
        {
            foreach (Path path in _paths)
            {
                if (path.AreYou(direction)) 
                {
                    return path;
                }
            }
            return null; 
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
