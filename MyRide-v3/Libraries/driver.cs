using System;
using System.Collections;
using Location;
using Vehicle;
namespace Driver
{
    public class driver
    {
        int ID;
        string name;
        int age;
        string gender;
        string address;
        string phoneNo;
        location curr_location;
        vehicle var_vehicle;
        ArrayList rating;
        bool availability;

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
                if (ch!=' ' && (ch < 'a' || ch > 'z') && (ch < 'A' || ch > 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
        public int id
        {
            set
            {
                while (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("ID cant be negative. Enter ID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value = Convert.ToInt32(Console.ReadLine());
                }
                Console.ForegroundColor = ConsoleColor.White;
                ID = value;
            }
            get
            {
                return ID;
            }
        }
        public string Name
        {
            set
            {
                while(value!="" && checkIfLetters(value)==false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Name can only have alphabetic letters.\nEnter name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                name = value;
            }
            get
            {
                return name;
            }
        }
        public int Age
        {
            set
            {
                while(value<0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Age can't be nagative.\nEnter Age: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value =Convert.ToInt32(Console.ReadLine());
                }
                Console.ForegroundColor = ConsoleColor.White;
                age = value;
            }
            get
            {
                return age;
            }
        }
        public string Gender
        {
            set
            {
                while(value != "f" && value != "F" && value != "M" &&  value != "m" && value !="")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Gender can only be M or F.\nEnter Gender: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                gender = value;
            }
            get
            {
                return gender;
            }
        }
        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }
        public string PhoneNo
        {
            set
            {
                while (value!="" && checkIfNumbers(value) == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Phone no can only have numeric values.\nEnter Phone no: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                phoneNo = value;
            }
            get
            {
                return phoneNo;
            }
        }
        public location Curr_location
        {
            set
            {
                curr_location = value;
            }
            get
            {
                return curr_location;
            }
        }
        public vehicle Var_vehicle
        {
            set
            {
                var_vehicle = value;
            }
            get
            {
                return var_vehicle;
            }
        }
        public ArrayList Rating
        {
            set
            {
                rating = value;
            }
            get
            {
                return rating;
            }
        }
        public bool Availability
        {
            set
            {
                availability = value;
            }
            get
            {
                return availability;
            }
        }
        public driver()
        {
            Name = "";
            Age = 0;
            Gender = "";
            Address = "";
            PhoneNo = "";
            Curr_location = new location();
            Curr_location.Latitude=0;
            Curr_location.Longitude = 0;
            rating = new ArrayList();
            Var_vehicle = new vehicle();
            Availability = true;
        }
        public driver(int i,string n,int a,string g,string add,string p,location l,vehicle v)
        {
            id = i;
            Name = n;
            Age = a;
            Gender = g;
            Address = add;
            PhoneNo = p;
            Curr_location = new location();
            Curr_location.Latitude = l.Latitude;
            Curr_location.Longitude = l.Longitude;
            rating = new ArrayList();
            Var_vehicle = new vehicle();
            Var_vehicle = v;
            Availability = true;
        }
        public void updateAvailablity(bool x)
        {
            Availability = x;
        }
        public float getRating()
        {
            int sum = 0;
            foreach(int x in Rating)
            {
                sum += x;
            }
            if(rating.Count > 0)
            return (sum / Rating.Count);
            else return 0;
        }
        public void updateLocation(location loc)
        {
            Curr_location.Latitude = loc.Latitude;
            Curr_location.Longitude = loc.Longitude;
        }
    }
    
}
