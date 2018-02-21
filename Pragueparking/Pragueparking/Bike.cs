using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    class Bike : Vehicle
    {
        public override int Size { get; set; }
      
        public Bike(string regno) : base(regno)
        {
            Size = 1;
        }

        public override string ToString()
        {
            //return base.ToString() + " Size: " + Size;
            return "Bike " + Size + " " + base.ToString();
        }

    }
}
