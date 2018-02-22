using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pragueparking
{
    class Program
    {

        static void Main(string[] args)
        {

            //string[] parkingLot = new string[100];
            //for (int i = 0; i < 100; i++) parkingLot[i] = "";
            //SeedArray(ref parkingLot);

            ParkingLot parkingLot = new ParkingLot();
            parkingLot.Add(new Car("BIL111"), 1);
            parkingLot.Add(new MC("MC222"), 3);
            parkingLot.Add(new Bike("12"), 3);
            parkingLot.Add(new Bike("19"), 8);
            parkingLot.Add(new Trike("TRI333"), 10);
            parkingLot.Add(new Car("BIL222"), 20);

            do
            {
                int option = Menu();

                switch (option)
                {
                    case -1:
                        {
                            Console.WriteLine("Type a number of the menu options. First press Enter");
                            Console.ReadLine();
                            break;
                        }
                    case 1: AddVehicle(ref parkingLot); break;
                    case 2: RemoveVehicle(ref parkingLot); break;
                    case 3: SearchVehicle(parkingLot); break;
                    case 4: MoveVehicle(ref parkingLot); break;
                    //case 5: PrintState(parkingLot.Content()); break;
                    case 5: WriteLot(parkingLot);break;

                }
            } while (1 == 1);
        }


        private static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("1. Add Vehicle ");
            Console.WriteLine("2. Remove Vehicle ");
            Console.WriteLine("3. Search Vehicle ");
            Console.WriteLine("4. Move Vehicle ");
            Console.WriteLine("5. Print parkinglot ");

            int option;
            if (int.TryParse(Console.ReadLine(),out option))
            {
                if ((option > 0) && (option < 6)) return option;
            } 
            return -1;
        }

        private static string GetRegNo()
        {
            string regno = "";
            bool format = false;

            do
            {
                Console.Write("Reg number: ");
                regno = Console.ReadLine().ToUpper();
                format = Regex.IsMatch(regno, pattern: "^[A-Z0-9]*$");
                if (!format) Console.WriteLine("Reg number must contains > 4 signs of letter A-Z and numbers 0-9");

            } while ((regno.Length < 2) || !Regex.IsMatch(regno, pattern: "^[A-Z0-9]*$"));

            Console.WriteLine(regno);
            return regno;

        }

        private static string GetVehicleType()
        {
            string type = "";
            do
            {
                Console.Write("Vehicle type (C = car, M = mc, B=Bike, T=Trike): ");
                type = Console.ReadLine();
                type = type.ToUpper();

            } while (!(type == "C" || type == "M" || type == "B" || type == "T"));

            return type;

        }

        private static int GetSlotNo()
        {
            int spot = 0;
            do
            {
                Console.Write("Move to spot number: ");
                spot = int.Parse(Console.ReadLine());

            } while (spot < 1 || spot > 100);

            return spot - 1;

        }

 
        private static void MoveVehicle(ref ParkingLot parkingLot)
        {
            string regno = GetRegNo();
            int slot = GetSlotNo();
            bool b = parkingLot.Move(regno, slot);
            if (b) Console.WriteLine("Moved to spot " + (slot + 1));
            else Console.WriteLine("Can't move vehicle");
            Console.ReadLine();

        }

        private static void SearchVehicle(ParkingLot parkingLot)
        {
            string regno = GetRegNo();
            int plats = parkingLot.Search(regno);
            if(plats < 0) Console.WriteLine("Regno not found in parkinglot");
            else Console.WriteLine("Vehicle found at " + (plats + 1));
            Console.ReadLine();
        }

        private static void RemoveVehicle(ref ParkingLot lot)
        {
            string reg = GetRegNo();
            int plats = lot.Remove(reg);
            if (plats == -1) Console.WriteLine("Regno not found in parkinglot");
            else Console.WriteLine("Vehicle removed from " + (plats + 1));
            Console.ReadLine();
        }

        private static void AddVehicle(ref ParkingLot lot)
        {
            string regno = GetRegNo();
            string type = GetVehicleType();
            Vehicle vehicle;

            switch (type)
            {
                case "C": vehicle = new Car(regno); break;
                case "M": vehicle = new MC(regno); break;
                case "B": vehicle = new Bike(regno); break;
                case "T": vehicle = new Trike(regno); break;
                default: vehicle = new Car(regno); break;
            }

            int i = lot.Add(vehicle);

            if (i == -1) Console.WriteLine("Regno already exists in parkinglot");
            else Console.WriteLine("Vehicle spot is " + (i + 1));

            Console.ReadLine();
        }


        static void WriteLot(ParkingLot plot)
        {
            Console.WriteLine(plot.Content());
            Console.ReadLine();
        }


        //static string CreateVehicleReg(Random r)
        //{
        //    string reg = "";
        //    char c;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        c = (char)(r.Next(65, 90));
        //        Task.Delay(2000);
        //        reg = reg.Insert(reg.Length, c.ToString());
        //    }
        //    for (int i = 0; i < 3; i++)
        //    {
        //        c = (char)r.Next(48, 57);
        //        Task.Delay(2000);
        //        reg = reg.Insert(reg.Length, c.ToString());
        //    }
        //    return reg;
        //}


    }
}
