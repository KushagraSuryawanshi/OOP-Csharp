using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string description) : base(ids) 
        {
            _name = name;
            _description = description;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return $"a {_name} ({FirstId})"; }
        }
        
        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}
