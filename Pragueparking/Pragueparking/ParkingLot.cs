using System;
using System.Collections.Generic;
using System.Text;

namespace Pragueparking
{
    class ParkingLot
    {
        private ParkingSlot[] parkingSlots = new ParkingSlot[100];

        public int FreeSlots { get; set; }

        private int freeSizeUnits;

        public ParkingLot()
        {
            FreeSlots = 100;
            freeSizeUnits = 400;
            for (int i = 0; i < parkingSlots.Length; i++) parkingSlots[i] = new ParkingSlot();
        }

        public int Add(Vehicle vehicle)
        {
            if (freeSizeUnits < vehicle.Size) return -1;
            if (Search(vehicle.Regno) > -1) return -1;

            for (int i = 0; i < parkingSlots.Length; i++)
            {
                int to = Add(vehicle, i);
                if (to > -1)  return to;
            }
            return -1;
        }

        public int Add(Vehicle vehicle, int i)
        {
            if (parkingSlots[i].FreeSize >= vehicle.Size)
            {
                parkingSlots[i].Add(vehicle);
                freeSizeUnits -= vehicle.Size;
                return i;
            }
            return -1;
        }

        public int Remove(string reg)
        {
            int plats;
            plats = Search(reg);
            if (plats >= 0)
            {
                parkingSlots[plats].Remove(reg);
            }
            return plats;
        }

        public int Search(string reg)
        {
            for (int i = 0; i < 100; i++)
            {
                if (parkingSlots[i].Search(reg))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Move(string regno, int slot)
        {
            int from = Search(regno);
            if (from > -1)
            {
                Vehicle v = parkingSlots[from].Remove(regno);
                if (v == null) return false;
                else
                {
                    int to = Add(v, slot);
                    if (to == -1)
                    {
                        to = Add(v, from);
                        return false; 
                    }
                    return true;
                }

            }
            return false;
        }

        public string Content()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parkingSlots.Length; i++)
            {
                if (parkingSlots[i].FreeSize < 4)
                {
                    string s = "\n" + (i+1) + ": ";
                    sb.Append(s);
                    sb.Append(parkingSlots[i].Content());
                }

            }
            return sb.ToString();
        }
        public void Optimize()
        {
        }

    }
}
