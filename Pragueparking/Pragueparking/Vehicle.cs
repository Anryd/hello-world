using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    abstract class Vehicle
    {
        public abstract int Size { get; set; }
        public string Regno { get; set; }
        public DateTime Anktid { get; set; }

        public Vehicle(string regno)
        {
            Regno = regno;
            Anktid = DateTime.Now;
        }

        public override string ToString()
        {
            //return "Regno: " + Regno + "\t Arrival time: " + Anktid.ToString();
            return Regno + " " + Anktid.ToString();
        }
    }
}
