using System;
using Ride;
using Passenger;
using Location;
using Driver;
using Vehicle;
using Admin;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace HW_02
{
    class Program
    {
        static void dummy_data(admin ad)
        {
            string deleteAll = "delete from drivers";
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Drivers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand comm=new SqlCommand(deleteAll, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
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
            ad.mgr.saveDriver(d1);
            ad.mgr.saveDriver(d2);
            ad.mgr.saveDriver(d3);
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

                    Console.ForegroundColor = ConsoleColor.White;
                    location start_loc = new location();
                    Console.Write("Enter Start Location e.g:1,2 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    s = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    string[] s1 = s.Split(',');

                    //Input validation as coordinates can't be negative.
                    while (checkIfNumbers(s1[0]) == false || checkIfNumbers(s1[1]) == false || Convert.ToSingle(s1[0]) < 0 || Convert.ToSingle(s1[1]) < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Coordinates should be positive and they should have numeric value.\nEnter Start Location e.g:1,2 : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        s1 = s.Split(',');
                    }
                    start_loc.Latitude = Convert.ToSingle(s1[0]);
                    start_loc.Longitude = Convert.ToSingle(s1[1]);

                    location end_loc = new location();
                    Console.Write("Enter End Location e.g:1,2 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    s = Console.ReadLine();
                    s1 = s.Split(',');
                    Console.ForegroundColor = ConsoleColor.White;
                    //Input validation

                    while (checkIfNumbers(s1[0]) == false || checkIfNumbers(s1[1]) == false || Convert.ToSingle(s1[0]) < 0 || Convert.ToSingle(s1[1]) < 0 || (Convert.ToSingle(s1[0]) == start_loc.Latitude && Convert.ToSingle(s1[1]) == start_loc.Longitude))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Coordinates should be positive.\nThey should have numeric value.\nStart location and End location can't be same.\nEnter End Location e.g:1,2 : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        s1 = s.Split(',');
                    }
                    end_loc.Latitude = Convert.ToSingle(s1[0]);
                    end_loc.Longitude = Convert.ToSingle(s1[1]);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter Ride Type (Bike, Rickshaw, Car): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    s = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    //Ride can only be Car,Rickshaw or Bike
                    while (s != "Bike" && s != "bike" && s != "Rickshaw" && s != "rickshaw" && s != "Car" && s != "car")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You can only choose Bike, Rickshaw or Car");
                        Console.Write("Enter Ride Type: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    //creating a driver with required vehicle.
                    string v = s;
                    //creating a new ride which passenger has requested.
                    ride r = new ride(start_loc, end_loc, p);
                    r.calculatePrice(v);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("------------------------------------------THANK YOU-------------------------------------------");
                    Console.WriteLine("Price for the ride is: " + r.Price);
                    Console.Write("Enter Y if you want to book a ride, enter N if you want to cancel operation: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    s = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;

                    while (s != "y" && s != "Y" && s != "n" && s != "N")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Input can only be Y or N.\nEnter Y if you want to book a ride, enter N if you want to cancel operation: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (s == "Y" || s == "y")
                    {
                        r.assignPassenger(p);
                        vehicle vh = new vehicle();
                        vh.Type = v;
                        List<driver> listOfDrivers = ad.mgr.getAllDriver();
                        bool f = r.assignDriver(listOfDrivers, vh);
                        if (f == true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("HAPPY TRAVEL\nGive rating out of 5: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            s = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;


                            while (s != "1" && s != "2" && s != "3" && s != "4" && s != "5")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Wrong Input. Give rating out of 5: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                s = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            int i = Convert.ToInt32(s);
                            r.giveRating(i);
                        }
                    }
                    else
                    {
                        continue;
                    }

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
                    List<driver> listOfDrivers = ad.mgr.getAllDriver();
                    foreach (driver d in listOfDrivers)
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


                        string query = $"update drivers set location='{l.Longitude},{l.Longitude}' where id={x.id}";
                        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Drivers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                        SqlConnection conn = new SqlConnection(connString);
                        SqlCommand comm = new SqlCommand(query, conn);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();

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
                                query = $"update drivers set availability=1 where id={x.id}";
                                conn = new SqlConnection(connString);
                                comm = new SqlCommand(query, conn);
                                conn.Open();
                                comm.ExecuteNonQuery();
                                conn.Close();
                            }
                            else
                            {
                                query = $"update drivers set availability=0 where id={x.id}";
                                conn = new SqlConnection(connString);
                                comm = new SqlCommand(query, conn);
                                conn.Open();
                                comm.ExecuteNonQuery();
                                conn.Close();
                            }
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
                            ad.removeDriver(x.id);
                            x.updateLocation(l);
                            ad.mgr.saveDriver(x);
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
