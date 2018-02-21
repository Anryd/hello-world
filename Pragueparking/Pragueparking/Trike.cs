using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    class Trike : Vehicle
    {
        public override int Size { get; set; }

        public Trike(string regno) : base(regno)
        {
            Size = 3;
        }

        public override string ToString()
        {
            //return base.ToString() + " Size: " + Size;
            return "Trike " + Size + " " + base.ToString();
        }

    }
}
