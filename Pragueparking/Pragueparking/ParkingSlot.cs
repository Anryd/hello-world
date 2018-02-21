using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    class ParkingSlot
    {
        public int Size { get; set; }

        private List<Vehicle> vehicles;

        private int freeSize;

        public int FreeSize
        {
            get { return freeSize; }
            set { freeSize = value; }
        }

        public ParkingSlot()
        {
            Size = 4;
            FreeSize = 4;
            vehicles = new List<Vehicle>();
        }

        internal void Add(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            FreeSize = FreeSize - vehicle.Size;
        }

        public Vehicle Remove(string reg)
        {
            Vehicle tmp = null;

            foreach (Vehicle aVehicle in vehicles)
            {
                if (aVehicle.Regno == reg)
                {
                    tmp = aVehicle;
                    this.freeSize = tmp.Size + this.freeSize;
                    vehicles.Remove(tmp);
                    return tmp;
                }
            }

            return tmp;
        }
        public bool Search(string regNr)
        {
            foreach (Vehicle aVehicle in vehicles)
            {
                if (aVehicle.Regno == regNr)
                {
                    return true;
                }
            }
            return false;
        }

        public string Content()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var vehicle in vehicles)
            {
                sb.Append(vehicle.ToString() + "\t");
            }
            return sb.ToString();
        }
    }
}
