using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    class Car : Vehicle
    {
       
        public Car(string regno) : base (regno)
        {
            Size = 4;
        }

        public override int Size { get; set ; }

        public override string ToString()
        {
            //return base.ToString() + " Size: " + Size;
            return "Car " + Size + " " + base.ToString();
        }
    }
}
