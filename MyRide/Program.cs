using Passenger;
using Location;
using Driver;
using Vehicle;
using Admin;
namespace Assignment_01
{
    class Program
    {
        static void dummy_data(admin ad)
        {
            //harcoded locations
            location l1 = new location(6, 6);
            location l2 = new location(1, 1);
            location l3 = new location(5, 5);

            //hardcoded vehicle
            vehicle v1 = new vehicle("car", "abc", "1b2");
            vehicle v2 = new vehicle("bike", "abc", "1t4");
            vehicle v3 = new vehicle("car", "abc", "1x2");

            //hardcoded drivers
            driver d1 = new driver(1, "ali", 19, "M", "abc", "123", l1, v1);
            driver d2 = new driver(2, "ayesha", 20, "F", "def", "456", l2, v2);
            driver d3 = new driver(3, "zaroon", 21, "M", "ghi", "789", l3, v3);

            //adding all drivers to a list
            ad.ListOfDrivers.Add(d1);
            ad.ListOfDrivers.Add(d2);
            ad.ListOfDrivers.Add(d3);
        }
        static bool checkIfNumbers(string s)
        {
            //used for input validation 
            foreach (char ch in s)
            {
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;
        }
        static bool checkIfLetters(string s)
        {
            //used for input validation 
            foreach (char ch in s)
            {
                if ((ch < 'a' || ch > 'z') && (ch < 'A' || ch > 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            admin ad = new admin();
            dummy_data(ad);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t   WELCOME TO MYRIDE\t\t\t\t");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine(" 1. Book a Ride\n 2. Enter as Driver\n 3. Enter as Admin");
                Console.Write("Press 1 to 3 to select an option or Press 0 to exit program: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string option = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                while (option != "0" && option != "1" && option != "2" && option != "3")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Wrong Input.\nPress 1 to 3 to select an option: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    option = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //string used to take all inputs.
                string s;
                if (option == "1")
                {
                    //creating passenger for ride 
                    passenger p = new passenger();
                    p.bookRide(ad);
                }
                else if (option == "2")
                {
                    int id;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter ID: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    } while (checkIfNumbers(s) == false || s == "");

                    id = Convert.ToInt32(s);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Name can only have alphabetic characters.\nEnter Name: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    } while (checkIfLetters(s) == false || s == "");

                    //checking if driver exists or not.

                    bool flag = false;
                    driver x = new driver();
                    foreach (driver d in ad.ListOfDrivers)
                    {
                        if ((id == d.id) && (s == d.Name))
                        {
                            flag = true;
                            x = d;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("No such driver exists");
                        continue;
                    }
                    if (flag == true)
                    {
                        Console.WriteLine("Hello " + x.Name);
                        string[] s1;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter Location e.g: 1,2 : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        s1 = s.Split(',');

                        while (checkIfNumbers(s1[0]) == false || checkIfNumbers(s1[1]) == false || Convert.ToSingle(s1[0]) < 0 || Convert.ToSingle(s1[1]) < 0)
                        {
                            Console.Write("Coordinates should be positive and they should have numeric value.\nEnter your Location e.g:1,2 : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            s = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;

                            s1 = s.Split(',');
                        }

                        location l = new location(Convert.ToSingle(s1[0]), Convert.ToSingle(s1[1]));
                        x.updateLocation(l);

                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("1.Change availability\n2.Change location\n3.Exit as a driver\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            option = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                        } while (option != "1" && option != "2" && option != "3");

                        if (option == "1")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Change availabilty.\n1.Press 1 for available\n2.Press 2 for unavailable\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                            option = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;

                            while (option != "1" && option != "2")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Wrong Input.\nPress 1 or 2 to select an option: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                option = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            if (option == "1")
                            {
                                x.updateAvailablity(true);
                            }
                            else
                                x.updateAvailablity(false);
                        }
                        else if (option == "2")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("update your location\n");
                            Console.Write("Enter Location e.g: 1,2 : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            s = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;

                            s1 = s.Split(',');

                            while (checkIfNumbers(s1[0]) == false || checkIfNumbers(s1[1]) == false || Convert.ToSingle(s1[0]) < 0 || Convert.ToSingle(s1[1]) < 0)
                            {
                                Console.Write("Coordinates should be positive and they should have numeric values.\nEnter your Location e.g:1,2: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                s = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                s1 = s.Split(',');
                            }

                            l = new location(Convert.ToSingle(s1[0]), Convert.ToSingle(s1[1]));
                            x.updateLocation(l);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("No such driver exists. ");
                        continue;
                    }
                }
                else if (option == "0")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Choose an option.\n1.Add Driver\n2.Remove Driver\n3.Update Driver\n4.Search Driver\n5.Exit as Admin ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    option = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    while (option != "1" && option != "2" && option != "3" && option != "4" && option != "5")
                    {
                        Console.Write("Wrong Input.\nPress 1 to 5 to select an option: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        option = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (option == "1")
                    {
                        ad.addDriver();
                    }
                    else if (option == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter ID of driver: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                        while (checkIfNumbers(s) == false || s == "")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("ID should be a numeric value and it can't be empty. Enter ID of driver: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            s = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        int id = Convert.ToInt32(s);
                        ad.removeDriver(id);
                    }
                    else if (option == "3")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Enter ID of driver: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        while (checkIfNumbers(s) == false || s == "")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("ID should be a numeric value and it can't be empty. Enter ID of driver: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            s = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        int id = Convert.ToInt32(s);
                        ad.updateDriver(id);
                        continue;
                    }
                    else if (option == "4")
                    {
                        ad.searchDriver();
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

}
