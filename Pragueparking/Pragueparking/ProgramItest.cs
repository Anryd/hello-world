//using System;

//namespace PRAGUE_PARKING
//{
//    class ProgramItest
//    {

//        // must be a global variable
//        string[] arParking = new string[100];

//        static void Main(string[] args)
//        {

//            ProgramItest prog = new ProgramItest();

//            // add some vehicles for testing
//            // prog.arParking[0] = "car123";
//            // prog.arParking[1] = "mot123:mot456";
//            // prog.arParking[2] = "mot789:";
//            // prog.arParking[3] = "car456";
//            // prog.arParking[7] = "car555";
//            // prog.arParking[15] = "car982";
//            // prog.arParking[20] = "mot214:mot821";
//            prog.arParking[0] = "mot123:";
//            prog.arParking[1] = "car123";
//            prog.arParking[2] = "mot963:";
//            prog.arParking[3] = "car678";


//            prog.askUserForInput();

//        }

//        void SearchVehicle()
//        {
//            // ask the user to enter a plate number
//            Console.WriteLine();
//            Console.WriteLine("Please enter the license plate number of the vehicle you wish to Find. ");
//            string vlicenseplate = Console.ReadLine();

//            Boolean foundValue = false;

//            // loop through the parking spots
//            for (int i = 0; i < 100; i++)
//            {

//                // check if the string at the current index is equal to the vehicle plate
//                if (arParking[i] == vlicenseplate)
//                {
//                    // if its equal then the vehicle is a car and its found at the current index
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.WriteLine(vlicenseplate + " found at parking spot number: " + i);
//                    Console.ResetColor();
//                    // stop the loop since we already found our car
//                    foundValue = true;
//                    break;

//                }
//                // check if the string at the current index contains a colon ':' which means it contains 2 vehicles
//                else if (arParking[i] != null && arParking[i].Contains(":"))
//                {

//                    // this will create an array by splitting the string in : 
//                    // for example if we have abc:def this split function will return an array of ['abc', 'def']
//                    string[] mcs = arParking[i].Split(':');

//                    // since we can add only 2 motorcycles in a slot this means we have to check only index 0 and 1

//                    // first we check if the given plate exist at index 0
//                    if (mcs[0] == vlicenseplate)
//                    {
//                        // if it exists, this means the vehicle is a motorcycle and found at current index and in slot 0
//                        Console.ForegroundColor = ConsoleColor.DarkRed;
//                        Console.WriteLine(vlicenseplate + " found at parking spot number: " + i + " slot: 0");
//                        Console.ResetColor();
//                        // stop the loop since we already found our vehicle
//                        foundValue = true;
//                        break;
//                    }
//                    // now we check if the given plate exists at index 1
//                    else if (mcs[1] == vlicenseplate)
//                    {
//                        // if it exists, this means the vehicle is a motorcycle and found at current index and in slot 1
//                        Console.ForegroundColor = ConsoleColor.DarkRed;
//                        Console.WriteLine(vlicenseplate + " found at parking spot number: " + i + " slot: 1");
//                        Console.ResetColor();
//                        // stop the loop since we already found our vehicle
//                        foundValue = true;
//                        break;
//                    }
//                }
//            }

//            if (!foundValue)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine(vlicenseplate + " not found.");
//                Console.ResetColor();
//                Console.Clear();
//            }
//            Console.ReadLine();
//        }

//        void parkVehicle()
//        {
//            Console.WriteLine("Choose the vehicle type you wish to park:");
//            Console.WriteLine("1. Motorcycle");
//            Console.WriteLine("2. Car");
//            int userInput = Int32.Parse(Console.ReadLine());

//            Console.WriteLine("\nPlease enter the license plate number of the vehicle you wish to park: ");
//            string vlicenseplate = Console.ReadLine();

//            Boolean vehicleParked = false;

//            for (int i = 0; i < 100; i++)
//            {
//                if (arParking[i] == null) // if all the spot is empty
//                {
//                    if (userInput == 2) // user wants to park a car
//                    {
//                        arParking[i] = vlicenseplate;
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("Your car has been parked at spot number: " + i);
//                        vehicleParked = true;
//                        break;
//                    }
//                    else // user wants to park a motorcycle
//                    {
//                        arParking[i] = vlicenseplate + ":";
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("Your motorcycle has been parked at spot number: " + i + " slot: 0");
//                        vehicleParked = true;
//                        break;
//                    }
//                }
//                else if (arParking[i].Contains(":")) // spot is not empty, already contain a motorcycle
//                {
//                    if (userInput == 1) // user wants to park a motorcycle
//                    {
//                        if (arParking[i].EndsWith(":")) // if the string ends with a : then we can add one more motorcycle
//                        {
//                            arParking[i] = arParking[i] + vlicenseplate;
//                            Console.ForegroundColor = ConsoleColor.Green;
//                            Console.WriteLine("Your motorcycle has been parked at spot number: " + i + " slot: 1");
//                            vehicleParked = true;
//                            break;
//                        }
//                    }
//                }
//            }

//            if (!vehicleParked)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("No empty spot found :-(");
//            }
//            Console.ResetColor();
//            Console.ReadLine();
//        }

//        void dismissVechicle()
//        {
//            Console.WriteLine("\nPlease enter the license plate number of the vehicle you wish to collect: ");
//            string vlicenseplate = Console.ReadLine();

//            Boolean vehicleDismissed = false;

//            for (int i = 0; i < 100; i++)
//            {
//                if (arParking[i] != null)
//                { // check if the parking slot is not empty
//                    if (arParking[i].Contains(":"))
//                    { // check if the parking slot is filled with motorcycles
//                        string[] mcs = arParking[i].Split(':');
//                        if (mcs[0] == vlicenseplate)
//                        {
//                            Console.ForegroundColor = ConsoleColor.Yellow;
//                            Console.WriteLine("Your car has been dismissed from spot number: " + i + " slot: 0");
//                            vehicleDismissed = true;
//                            if (mcs[1].Length == 0)
//                            {
//                                arParking[i] = null;
//                            }
//                            else
//                            {
//                                arParking[i] = mcs[1] + ":";
//                            }
//                        }
//                        if (mcs[1] == vlicenseplate)
//                        {
//                            Console.ForegroundColor = ConsoleColor.Yellow;
//                            Console.WriteLine("Your car has been dismissed from spot number: " + i + " slot: 1");
//                            vehicleDismissed = true;
//                            arParking[i] = mcs[0] + ":";
//                        }
//                    }
//                    else if (arParking[i] == vlicenseplate)
//                    {
//                        arParking[i] = null;
//                        Console.ForegroundColor = ConsoleColor.Yellow;
//                        Console.WriteLine("Your car has been dismissed from spot number: " + i);
//                        vehicleDismissed = true;
//                    }
//                }
//            }

//            if (!vehicleDismissed)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Your vehicle is not found");
//            }
//            Console.ResetColor();
//            Console.ReadLine();

//        }

//        void moveVehicle(string vehiclePlate)
//        {

//            // if a vehicle is not provided, ask the user to enter his vehicle plate
//            string vlicenseplate;
//            if (vehiclePlate == null)
//            {
//                Console.WriteLine("\nPlease enter the license plate number of the vehicle you wish to move: ");
//                vlicenseplate = Console.ReadLine();
//            }
//            else
//            {
//                vlicenseplate = vehiclePlate;
//            }

//            if (vehiclePlate == null)
//            {
//                Console.WriteLine("\nPlease enter the spot number you wish to move to: ");
//            }
//            else
//            {
//                Console.WriteLine("\nPlease enter another spot number: ");
//            }

//            int spotNumber = Int32.Parse(Console.ReadLine());

//            // find location of the vehicle
//            // step 1: find the user vehicle details
//            Boolean vehicleFound = false;
//            Boolean isMotorcycle = false;
//            int vehicleIndex = 0;
//            for (int i = 0; i < 100; i++)
//            {
//                if (arParking[i] != null && arParking[i].Contains(vlicenseplate))
//                { // vehicle found on that spot
//                    vehicleFound = true;
//                    vehicleIndex = i;
//                    if (arParking[i].Contains(":"))
//                    { // the spot contains : this means its a motorcycle
//                        isMotorcycle = true;
//                    }
//                }
//            }

//            if (!vehicleFound)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Vehicle not found!");
//            }
//            else
//            {
//                // step 2: check if the new spot is available for the user vehicle
//                Boolean vehicleCanBeMoved = false;
//                if (arParking[spotNumber] == null)
//                { // spot can hold a car or motorcycle since its empty
//                    vehicleCanBeMoved = true;
//                }
//                else if (arParking[spotNumber].EndsWith(":"))
//                { // spot can hold another motorcycle
//                    if (isMotorcycle)
//                    {
//                        vehicleCanBeMoved = true;
//                    }
//                }

//                if (!vehicleCanBeMoved)
//                {
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.WriteLine("New spot is full");
//                    Console.ResetColor();
//                    moveVehicle(vlicenseplate);
//                }
//                else
//                {
//                    // step 3: move the vehicle

//                    // 3.1: remove the vehicle from the old post
//                    if (isMotorcycle)
//                    {
//                        string[] mcs = arParking[vehicleIndex].Split(':');
//                        string mc1 = mcs[0];
//                        string mc2 = mcs[1];
//                        if (mc1 == vlicenseplate) // if our motorcycle is parked in the slot 1 of this spot
//                        {
//                            if (mc2.Length > 0)
//                            {
//                                arParking[vehicleIndex] = mc2 + ":";
//                            }
//                            else
//                            {
//                                arParking[vehicleIndex] = null;
//                            }
//                        }
//                        else
//                        { // if our motorcycle is parked in the slot 2 of this spot
//                            arParking[vehicleIndex] = mc1 + ":";
//                        }
//                    }
//                    else
//                    {
//                        arParking[vehicleIndex] = null;
//                    }

//                    // 3.2: add the vehicle to the new spot
//                    if (isMotorcycle)
//                    {
//                        if (arParking[vehicleIndex] == null)
//                        {
//                            arParking[spotNumber] = vlicenseplate + ":";
//                        }
//                        else
//                        {
//                            arParking[spotNumber] = arParking[spotNumber] + vlicenseplate;
//                        }
//                    }
//                    else
//                    {
//                        arParking[spotNumber] = vlicenseplate;
//                    }
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.WriteLine("Your vehicle has been moved to the new spot!");
//                }
//            }
//            Console.ResetColor();
//            Console.ReadLine();
//        }

//        void listParkingLots()
//        {

//            for (int i = 0; i < 100; i++)
//            {
//                string lot = arParking[i];

//                // for better display
//                string spotNumberStr = "";
//                if (i < 10)
//                {
//                    spotNumberStr = "0" + i;
//                }
//                else
//                {
//                    spotNumberStr = "" + i;
//                }

//                // go to new line on every 9 spots
//                if (i % 10 == 0)
//                {
//                    if (i != 0) Console.WriteLine();
//                    for (int j = 0; j < 10; j++) Console.Write("-----------------");
//                    Console.WriteLine();
//                }

//                if (lot == null)
//                {
//                    // if no vehicle on this spot, print empty spot
//                    Console.Write(spotNumberStr + "|      :      |");
//                }
//                else if (lot.Contains(":"))
//                {
//                    // if spot contains one or two motorcycles, print them
//                    string[] mcs = arParking[i].Split(':');

//                    Console.Write(spotNumberStr + "|");
//                    string mc1 = mcs[0];
//                    if (mc1.Length < 6)
//                    {
//                        Console.Write("      ");
//                    }
//                    else
//                    {
//                        Console.Write(mcs[0]);
//                    }

//                    Console.Write(":");

//                    string mc2 = mcs[1];
//                    if (mc2.Length < 6)
//                    {
//                        Console.Write("      ");
//                    }
//                    else
//                    {
//                        Console.Write(mcs[1]);
//                    }
//                    Console.Write("|");
//                }
//                else
//                {
//                    // spot contains a car
//                    Console.Write(spotNumberStr + "|   " + arParking[i] + "    |");
//                }

//                if (i == 99)
//                {
//                    Console.WriteLine();
//                    for (int j = 0; j < 10; j++) Console.Write("-----------------");
//                }

//            }

//        }


//        void askUserForInput()
//        {
//            int userChoice = 0;
//            while (userChoice != -1)
//            {
//                Console.Clear();

//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("                                    Welcome to Prague Parking!");
//                Console.ResetColor();
//                listParkingLots();
//                Console.WriteLine();

//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine("Please Select one of the following choices: 1. Park, 2. Dismiss, 3. Move, 4. Search, 5. Exit\n");
//                //Console.WriteLine("1. Park, 2. Dismiss, 3. Search, 4. List All, 5. Exit");
//                Console.ResetColor();

//                userChoice = Int32.Parse(Console.ReadLine());
//                Console.WriteLine();

//                switch (userChoice)
//                {
//                    case 1:
//                        parkVehicle();
//                        break;
//                    case 2:
//                        dismissVechicle();
//                        break;
//                    case 3:
//                        moveVehicle(null);
//                        break;
//                    case 4:
//                        SearchVehicle();
//                        break;
//                    case 5:
//                        Console.WriteLine("Are you sure you want to exit the program? (Y/N)");
//                        string input = Console.ReadLine();
//                        if (input == "y" || input == "Y")
//                        {
//                            Console.WriteLine("Goodbye!");
//                            Console.ReadLine();
//                            userChoice = -1;
//                            Console.Clear();
//                        }
//                        break;
//                    default:
//                        break;
//                }
//            }

//        }

//    }
//}