using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask
{
    public class Counter
    {
        private int _count;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Ticks
        {
            get
            {
                return _count;
            }
        }


        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            try
            {
                checked
                {
                    _count++;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow detected: " + e.Message);
            }
        }
        public void Reset()
        {
            _count = 0;
        }

        public void ResetByDefault()
        {
            unchecked
            {
                _count = (int)2147483647447;
            }
        }


    }
}
