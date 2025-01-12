using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.cs
{
    public class Path : IdentifiableObject
    {
        private Location _destination;
        private bool _blocked;

        public Path(string[] ids, Location destination, bool blocked = false) : base(ids)
        {
            _destination = destination;
            _blocked = blocked;
        }

        public Location Destination
        {
            get { return _destination; }
        }

        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }

        public bool MovePlayer(Player p)
        {
            if (!_blocked)
            {
                p.Location = _destination;
                return true;
            }
            return false;
        }
    }

}

