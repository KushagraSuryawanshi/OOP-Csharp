using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string id in idents)
            {
                AddIdentifier(id);
            }
        }

        public bool AreYou(string identifier)
        {
            return _identifiers.Contains(identifier.ToLower());  
        }

        public string FirstId
        {
            get
            {
                if(_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public void AddIdentifier(string identifier)
        {
            _identifiers.Add(identifier.ToLower());
        }
        
        public void PrivilegeEscalation(string pin)
        {
            if(pin == "9447")
            {
                _identifiers[0] = "Class 1-6-EN310-WED-10:30";
            }
        }

    }
}
