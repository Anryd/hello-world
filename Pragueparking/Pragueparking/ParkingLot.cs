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

            for (int i = 0; i < parkingSlots.Length; i++)
            {
                Add(vehicle, i);
                return i;
                //if (parkingSlots[i].FreeSize >= vehicle.Size)
                //{
                //    parkingSlots[i].Add(vehicle);
                //    freeSizeUnits -= vehicle.Size;
                //    return i;
                //}
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
            if (plats > 0)
            {
                parkingSlots[plats].Remove(reg);
            }
            return plats + 1;
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
        public void Move(string regno, int slot)
        {
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
