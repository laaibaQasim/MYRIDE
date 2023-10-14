using System;

namespace Vehicle
{
    public class vehicle
    {

        private string type;
        public string Type
        {
            set
            {
                //Input validation for vehicle type as vehicle can only be rickshaw, car or bike.
                while(value!="" && value!="Rickshaw" && value!="rickshaw" && value != "Car" && value!="car" && value!="Bike" && value !="bike")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter Vehicle Type (Rickshaw, Car, Bike): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value = Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                type = value;
            }
            get
            {
                return type;
            }
        }
        private string model;
        public string Model
        {
            set
            {
                model = value;
            }
            get
            {
                return model;
            }
        }
        private string licensePlate;
        public string LicensePlate
        {
            set
            {
                licensePlate = value;
            }
            get
            {
                return licensePlate;
            }
        }
        public vehicle()
        {
            Type = "";
            Model = "";
            LicensePlate = "";
        }
        public vehicle(string t,string m,string l)
        {
            Type = t;
            Model = m;
            LicensePlate = l;
        }
    }
}
