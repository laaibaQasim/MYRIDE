using Location;
using Ride;
using Vehicle;
using Admin;

namespace Passenger
{
    public class passenger
    {
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
        string name;
        public string Name
        {
            set
            {
                while (value != "" && checkIfLetters(value) == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Name can only have alphabetic characters.\nEnter name: ");
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
        string phoneNo;
        public string PhoneNo
        {
            set
            {
                while (value != "" && checkIfNumbers(value) == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Phone no only contain numbers.Enter phone no: ");
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
        public passenger(string n = "", string pn = "")
        {
            Name = n;
            PhoneNo = pn;
        }
        public void bookRide(admin ad)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter phone no: ");
            Console.ForegroundColor = ConsoleColor.Green;
            PhoneNo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            location start_loc = new location();
            Console.Write("Enter Start Location e.g:1,2 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            string s = Console.ReadLine();
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
            while (checkIfNumbers(s1[0]) == false || checkIfNumbers(s1[1]) == false || Convert.ToSingle(s1[0]) < 0 || Convert.ToSingle(s1[1]) < 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Coordinates should be positive and they should have numeric value.\nEnter End Location e.g:1,2 : ");
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
            ride r = new ride(start_loc, end_loc, this);
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
                r.assignPassenger(this);
                vehicle vh = new vehicle();
                vh.Type = v;
                bool f = r.assignDriver(ad.ListOfDrivers, vh);
                if (f == true)
                {
                    giveRating(r);
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write("HAPPY TRAVEL\nGive rating out of 5: ");
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //s = Console.ReadLine();
                    //Console.ForegroundColor = ConsoleColor.White;


                    //while (s != "1" && s != "2" && s != "3" && s != "4" && s != "5")
                    //{
                    //    Console.ForegroundColor = ConsoleColor.White;
                    //    Console.Write("Wrong Input. Give rating out of 5: ");
                    //    Console.ForegroundColor = ConsoleColor.Green;
                    //    s = Console.ReadLine();
                    //    Console.ForegroundColor = ConsoleColor.White;

                    //}
                    //int i = Convert.ToInt32(s);
                    //r.giveRating(i);
                }
            }
        }
        public void giveRating(ride r)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("HAPPY TRAVEL\nGive rating out of 5: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string s = Console.ReadLine();
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
            r.VarDriver.Rating.Add(i);
        }
    }
}
