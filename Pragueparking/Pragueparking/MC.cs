using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    class MC : Vehicle
    {
        private int size = 2;

        public override int Size
        {
            get { return size; }
            set { size = value; }
        }

        public MC(string regno) : base(regno)
        {

        }

        public override string ToString()
        {
            //return base.ToString() + " Size: " + Size;
            return "MC " + Size + " " + base.ToString();
        }

    }
}
