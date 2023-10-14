using System;

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
                while(value=="" || checkIfLetters(value)==false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Name can only have alphabetic characters and it can't be empty.\nEnter name: ");
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
                while(value =="" || checkIfNumbers(value)==false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Phone no only contain numbers and it can't be empty.\nEnter phone no: ");
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
        public passenger(string n="",string pn="")
        {
            Name = n;
            PhoneNo = pn;
        }
    }
}
