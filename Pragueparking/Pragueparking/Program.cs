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
                            Console.WriteLine("Type a number of the menu options");
                            Console.ReadLine();
                            break;
                        }
                    case 1: AddVehicle(ref parkingLot); break;
                    case 2: RemoveVehicle(ref parkingLot); break;
                    case 3: SearchVehicle(); break;
                    //case 4: MoveVehicleFunction(parkingLot); break;
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

            int option = int.Parse(Console.ReadLine());

            if ((option > 0) && (option < 6)) return option;
            else return -1;
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

        private static void MoveVehicleFunction(string[] a)
        {
            string regno = GetRegNo();

            //SearchVehicle(a, regno);

        }

        private static void SearchVehicle()
        {
            throw new NotImplementedException();
        }

        private static void RemoveVehicle(ref ParkingLot lot)
        {
            string reg = GetRegNo();
            int plats = lot.Remove(reg);
            //RemoveVehicle(ref a, reg);
            //PrintState(lot.Content());
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

            if (i != -1) Console.WriteLine("Vehicle spot is " + (i + 1));

            Console.ReadLine();
            //PrintState(lot.Content());
        }



        private static void MoveVehicle(ref string[] a, int from, int to)
        {
            string tempLot = a[to];
            a[to] = a[from];
            a[from] = tempLot;
        }

        //private static void MoveVehicle(ref string[] a, string reg, int to)
        //{
        //    int i = SearchVehicle(a, reg);
        //    if (i > -1)
        //    {
        //        if (a[to].EndsWith(":")) //Mottagande ruta med en befintlig mc
        //        {
        //            if (a[i].EndsWith(":"))  //Flyttar en mc till en ruta med en befintlig mc
        //            {
        //                a[to] = a[to] + reg;
        //                a[i] = "";
        //            }
        //            else  //I rutan för aktuell mc finns ytterligare en mc 
        //            {
        //                string[] var = a[i].Split(':');

        //                if (var[0].Equals(reg))
        //                {
        //                    a[i] = var[1] + ":";
        //                }
        //                else
        //                {
        //                    a[i] = var[0] + ":";
        //                }

        //                a[to] = a[to] + reg;
        //            }
        //        }
        //        else  //Byter plats på innehållet i två rutor
        //        {
        //            MoveVehicle(ref a, i, to);
        //        }
        //    }
        //}




 

        static void WriteLot(ParkingLot plot)
        {
            Console.WriteLine(plot.Content());
            Console.ReadLine();
        }

        //static void PrintState(ParkingSlot[] a)
        //{
        //    int index = 0;
        //    for (int i = 0; i < 50; i++)
        //    {
        //        for (int x = 0; x < 2; x++)
        //        {
        //            Console.CursorLeft = x * 50;
        //            if (index < 9) Console.Write(" ");
        //            if (index < 99) Console.Write(" ");
        //            if (!(a[index].FreeSize == 4))
        //            {
        //                Console.Write("{0}: ", index + 1);
        //                for (int s = 0; s < a[index].Content().Count; s++)
        //                {
        //                    if (a[index].Content().ElementAt(s).GetType() == typeof(Car))
        //                    {
        //                        Console.ForegroundColor = ConsoleColor.Yellow;
        //                    }

        //                    Console.Write("{0} ", a[index].Content().ElementAt(s).Regno);
        //                    Console.ForegroundColor = ConsoleColor.White;
        //                    if (s == 1)
        //                        Console.WriteLine();
        //                }
        //            }
        //            if (a[index].FreeSize == 4) Console.Write("{0}: [Spot Empty]", index + 1);
        //            index++;
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.ReadLine();
        //}

        //public void SeedArray(ParkingLot lot)
        //{
        //    Random rd = new Random(DateTime.Now.Millisecond);
        //    int index = rd.Next(0, 100);
        //    Vehicle vec;
        //    ParkingSlot[] spots = lot.Content();
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (spots[index].FreeSize == 4)
        //        {
        //            Task.Delay(2000);
        //            vec = new Car(CreateVehicleReg(rd));
        //            spots[index].Add(vec);
        //            spots[index].FreeSize = 0;
        //            lot.FreeSlots -= 1;
        //            index = rd.Next(0, 100);
        //        }
        //        else
        //            i--;
        //    }
        //    for (int i = 0; i < 4; i++)
        //    {
        //        index = rd.Next(0, 100);
        //        if (spots[index].FreeSize >= 2)
        //        {
        //            Task.Delay(2000);
        //            vec = new MC(CreateVehicleReg(rd));
        //            spots[index].Add(vec);
        //            spots[index].FreeSize -= 2;
        //            index = rd.Next(0, 100);
        //            lot.FreeSlots -= 1;
        //        }
        //        else
        //        {
        //            i--;
        //        }
        //    }
        //    for (int i = 0; i < 4; i++)
        //    {
        //        index = rd.Next(0, 100);
        //        if (spots[index].FreeSize >= 3)
        //        {
        //            Task.Delay(2000);
        //            vec = new Trike(CreateVehicleReg(rd));
        //            spots[index].Add(vec);
        //            spots[index].FreeSize -= 3;
        //            index = rd.Next(0, 100);
        //            lot.FreeSlots -= 1;
        //        }
        //        else
        //        {
        //            i--;
        //        }
        //    }
        //    for (int i = 0; i < 4; i++)
        //    {
        //        index = rd.Next(0, 100);
        //        if (spots[index].FreeSize >= 1)
        //        {
        //            Task.Delay(2000);
        //            vec = new Bike("Nr." + i);
        //            spots[index].Add(vec);
        //            spots[index].FreeSize -= 1;
        //            index = rd.Next(0, 100);
        //            lot.FreeSlots -= 1;
        //        }
        //        else
        //        {
        //            i--;
        //        }
        //    }
        //}
        static string CreateVehicleReg(Random r)
        {
            string reg = "";
            char c;
            for (int i = 0; i < 3; i++)
            {
                c = (char)(r.Next(65, 90));
                Task.Delay(2000);
                reg = reg.Insert(reg.Length, c.ToString());
            }
            for (int i = 0; i < 3; i++)
            {
                c = (char)r.Next(48, 57);
                Task.Delay(2000);
                reg = reg.Insert(reg.Length, c.ToString());
            }
            return reg;
        }


    }
}
