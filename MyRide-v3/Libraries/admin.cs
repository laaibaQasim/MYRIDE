using System;
using System.Collections.Generic;
using Driver;
using System.IO;
using System.Text.Json;
namespace Admin
{
    public class admin
    {
        static manager Mgr;
        public manager mgr
        {
            set
            {
                Mgr = value;
            }
            get
            {
                return Mgr;
            }
        }
        public admin()
        {
            mgr = new manager();
        }
        private bool isUniquePhoneNo(string pn)
        {
            //helper function to check if phone entered by driver is unique or not as two drivers can't have same phone no.
            List<driver> l = mgr.getAllDriver();

            foreach (driver d in l)
            {

                if (d.PhoneNo == pn)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isUniquePlateNo(string pn,string pl)
        {
            //helper function to check if license plate no entered by driver is unique or not as two vehicles can't have same license plate no.
            List<driver> l = mgr.getAllDriver();
            foreach (driver d in l)
            {
                if (d.Var_vehicle.LicensePlate == pn && d.Var_vehicle.LicensePlate !=pl)
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkIfNumbers(string s)
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
        public void addDriver()
        {
            string s;
            driver d = new driver();
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Name = Console.ReadLine();
            } while (d.Name == "");
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Age: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            } while (checkIfNumbers(s)==false || s == "");

            d.Age = Convert.ToInt32(s);

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Gender (M or F): ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Gender = Console.ReadLine();
            } while (d.Gender == "");
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Address: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Address = Console.ReadLine();
            } while (d.Address == "");

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.PhoneNo = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            } while (d.PhoneNo == "");


            while (isUniquePhoneNo(d.PhoneNo) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Phone No should be unique.\nEnter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.PhoneNo = Console.ReadLine();
            }
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Vehicle Type (car, bike, rickshaw): ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Var_vehicle.Type = Console.ReadLine();
            } while (d.Var_vehicle.Type == "");

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Vehicle Model: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Var_vehicle.Model = Console.ReadLine();
            } while (d.Var_vehicle.Model == "");
            string temp = d.Var_vehicle.LicensePlate;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Vehicle License Plate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Var_vehicle.LicensePlate = Console.ReadLine();
            } while (d.Var_vehicle.LicensePlate == "");
            while (isUniquePlateNo(d.Var_vehicle.LicensePlate,temp) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("License Plate No should be unique.\nEnter Vehicle License Plate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Var_vehicle.LicensePlate = Console.ReadLine();
            }
            mgr.saveDriver(d);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------DRIVER ADDED------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void removeDriver(int id)
        {
            bool flag = false;
            int co = 0;
            List<driver> listOfDrivers = mgr.getAllDriver();
            foreach (driver x in listOfDrivers)
            {
                if (x.id == id)
                {
                    mgr.removeDriver(id);
                    flag = true;
                    break;
                }
                co++;
            }
            if (flag == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("No Such Driver Exists.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }
        public void updateDriver(int id)
        {
            bool flag = false;
            int idx = 0;
            List<driver> listOfDrivers = mgr.getAllDriver();
            foreach (driver x in listOfDrivers)
            {
                if (x.id == id)
                {
                    flag = true;
                    break;
                }
                idx++;
            }
            if (flag == false)
            {
                Console.WriteLine("No Such Driver Exists.");
                return;
            }
            else
            {
                Console.WriteLine("Driver with ID " + id + " exists");
            }
            string s;

            Console.Write("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                listOfDrivers[idx].Name = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            while (s != "" && checkIfNumbers(s)==false )
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Age: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (s != "")
            {
                listOfDrivers[idx].Age = Convert.ToInt32(s);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                listOfDrivers[idx].Gender = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                listOfDrivers[idx].Address = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Phone No: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();

            while (isUniquePhoneNo(s) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Phone No should be unique.\nEnter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            }

            if (s != "")
            {
                listOfDrivers[idx].PhoneNo = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                listOfDrivers[idx].Var_vehicle.Type = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                listOfDrivers[idx].Var_vehicle.Model = s;
            }
            string temp = listOfDrivers[idx].Var_vehicle.LicensePlate;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();

            while (isUniquePlateNo(s,temp) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("License Plate No should be unique.\nEnter License Plate No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            }
            if (s != "")
            {
                listOfDrivers[idx].Var_vehicle.LicensePlate = s;
            }
            mgr.updateDriver(listOfDrivers[idx]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------INFORMATION UPDATED-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool searchDriver()
        {
            driver d = new driver();
            string s;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.id = Convert.ToInt32(s);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.Name = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.Age = Convert.ToInt32(s);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.Gender = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.Address = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Phone No: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.PhoneNo = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle Type: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.Var_vehicle.Type = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle Model: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.Var_vehicle.Model = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();

            if (s != "")
            {
                d.Var_vehicle.LicensePlate = s;
            }
            Console.ResetColor();
            return mgr.printDriver(d);
        }
    }
}
