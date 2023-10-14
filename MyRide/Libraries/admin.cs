using System;
using System.Collections.Generic;
using Driver;
namespace Admin
{
    public class admin
    {
        List<driver> listOfDrivers;
        public List<driver> ListOfDrivers
        {
            set
            {
                listOfDrivers = value;
            }
            get
            {
                return listOfDrivers;
            }
        }
        public admin()
        {
            listOfDrivers = new List<driver>();
        }
        private bool isUniquePhoneNo(string pn)
        {
            //helper function to check if phone entered by driver is unique or not as two drivers can't have same phone no.
            foreach(driver d in listOfDrivers)
            {
                if(d.PhoneNo==pn)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isUniquePlateNo(string pn)
        {
            //helper function to check if license plate no entered by driver is unique or not as two vehicles can't have same license plate no.
            foreach (driver d in listOfDrivers)
            {
                if (d.Var_vehicle.LicensePlate == pn)
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
        private bool checkIfLetters(string s)
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
        public void addDriver()
        {
            string s;
            driver d = new driver();
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter ID: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            } while (checkIfNumbers(s)==false || s == "");
            Console.ForegroundColor = ConsoleColor.White;
            d.id = Convert.ToInt32(s);

            bool flag = false;
            foreach (driver x in listOfDrivers)
            {
                if (x.id == d.id)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Driver already exists.");
                return;
            }

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
            } while (s == "");

            d.Age = Convert.ToInt32(s);

            do
            { 
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Gender (M or F): ");
            Console.ForegroundColor = ConsoleColor.Green;
            d.Gender = Console.ReadLine(); 
            } while (d.Gender == "") ;
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

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter Vehicle License Plate: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Var_vehicle.LicensePlate = Console.ReadLine();
            } while (d.Var_vehicle.LicensePlate == "");
            while (isUniquePlateNo(d.Var_vehicle.LicensePlate) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("License Plate No should be unique.\nEnter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                d.Var_vehicle.LicensePlate = Console.ReadLine();
            }

            listOfDrivers.Add(d);
            Console.WriteLine("------------------------------DRIVER ADDED------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void removeDriver(int id)
        {
            bool flag = false;
            int co = 0;
            foreach (driver x in listOfDrivers)
            {
                if(x.id==id)
                {
                    listOfDrivers.RemoveAt(co);
                    flag = true;
                    break;
                }
                co++;   
            }
            if (flag == false)
            {
                Console.WriteLine("No Such Driver Exists.");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------DRIVER REMOVED------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void updateDriver(int id)
        {
            bool flag = false;
            int idx = 0;
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
            if(s!="")
            {
                listOfDrivers[idx].Name = s;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if(s!="")
            {
                listOfDrivers[idx].Age = Convert.ToInt32(s);
            }
            else
            {
                s = "";
                listOfDrivers[idx].Age = 0;
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter Vehicle License Plate: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();

            while (isUniquePlateNo(s) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("License Plate No should be unique.\nEnter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            }
            if (s != "")
            {
                listOfDrivers[idx].Var_vehicle.LicensePlate = s;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------INFORMATION UPDATED-------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool searchDriver()
        {
            driver d=new driver();
            string s;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            s = Console.ReadLine();
            if (s != "")
            {
                d.id = Convert.ToInt32(s);
            }
            else
            {
                s = "";
                d.id = 0;
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
            else
            {
                s = "";
                d.Age = 0;
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
            while(isUniquePhoneNo(s)==false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Phone No should be unique.\nEnter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            }
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

            while (isUniquePlateNo(s) == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("License Plate No should be unique.\nEnter Phone No: ");
                Console.ForegroundColor = ConsoleColor.Green;
                s = Console.ReadLine();
            }
            if (s != "")
            {
                d.Var_vehicle.LicensePlate = s;
            }
            Console.ResetColor();
            bool flag = false;
            foreach(driver x in listOfDrivers)
            {
                if((d.id == 0 || x.id == d.id) && (d.Name=="" || x.Name==d.Name) && (d.Age == 0 || d.Age == x.Age) && (d.Address=="" || d.Address==x.Address) && (d.PhoneNo=="" || d.PhoneNo==x.PhoneNo) && (d.Gender=="" || d.Gender==x.Gender.ToLower() || d.Gender == x.Gender.ToUpper()))
                {
                    if ((d.Var_vehicle.Type == "" || d.Var_vehicle.Type == null || d.Var_vehicle.Type == x.Var_vehicle.Type) && (d.Var_vehicle.Model == "" || d.Var_vehicle.Model == null || d.Var_vehicle.Model == x.Var_vehicle.Model) && (d.Var_vehicle.LicensePlate == "" || d.Var_vehicle.LicensePlate == null || d.Var_vehicle.LicensePlate == x.Var_vehicle.LicensePlate))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.WriteLine("Name\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License");
                        Console.WriteLine(x.Name + "\t\t\t" + x.Age + "\t\t\t" + x.Gender + "\t\t\t" + x.Var_vehicle.Type + "\t\t\t" + x.Var_vehicle.Model + "\t\t\t" + x.Var_vehicle.LicensePlate);
                        flag = true;
                    }
                }
            }
            if(flag==false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("No such driver exists");
            }
            return flag;
        }
    }
}
