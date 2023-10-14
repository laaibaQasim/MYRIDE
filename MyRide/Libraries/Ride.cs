using System;
using Location;
using Driver;
using Vehicle;
using Passenger;
using Admin;
using System.Collections.Generic;
namespace Ride
{
    public class ride
    {
        location start_location;
        location end_location;
        int price;
        driver varDriver;
        passenger varPassenger;
        public location Start_location
        {
            set
            {
                start_location = value;
            }
            get
            {
                return start_location;
            }
        }
        public location End_location
        {
            set
            {
                end_location = value;
            }
            get
            {
                return end_location;
            }
        }
        public int Price
        {
            set
            {
                price = value;
            }
            get
            {
                return price;
            }
        }
        public driver VarDriver
        {
            set
            {
                varDriver = value;
            }
            get
            {
                return varDriver;
            }
        }
        public passenger VarPassenger
        {
            set
            {
                varPassenger = value;
            }
            get
            {
                return varPassenger;
            }
        }
        public ride()
        {

            start_location = new location();
            end_location = new location();
            start_location.Latitude = 0;
            start_location.Longitude = 0;
            end_location.Latitude = 0;
            end_location.Longitude = 0;

            price = 0;
            varPassenger = new passenger();
            VarDriver = new driver();
        }
        public ride(location sl, location el, passenger p)
        {
            start_location = new location();
            start_location.Latitude = sl.Latitude;
            start_location.Longitude = sl.Longitude;

            End_location = new location();
            end_location.Latitude = el.Latitude;
            end_location.Longitude = end_location.Longitude;
            varPassenger = p;
            price = 0;
            varDriver = new driver();
        }
        public ride(location sl, location el, int p, driver vd, passenger vp)
        {
            start_location = new location();
            start_location = sl;
            end_location = new location();
            end_location = el;

            price = p;
            varDriver = vd;
            varPassenger = vp;
        }
        public void assignPassenger(passenger obj)
        {
            varPassenger = obj;
        }
        private (int, int) min(List<int> l)
        {
            //helper function to calculate minimum distance of all the distances of drivers.
            int min = l[0];
            int min_idx = 0;
            int co = 0;
            foreach (int i in l)
            {
                if (min > i)
                {
                    min = i;
                    min_idx = co;
                }
                co++;
            }
            return (min, min_idx);
        }
        public bool assignDriver(List<driver> l, vehicle v)
        {
            //AssignDriver will calculate distance of all drivers from start location of ride and availabe driver
            //with smallest distance will be assigned to ride.
            float x1, x2;
            float y1 = start_location.Latitude;
            float y2 = start_location.Longitude;
            List<int> l2 = new List<int>();
            foreach (driver x in l)
            {
                x1 = x.Curr_location.Latitude;
                x2 = x.Curr_location.Longitude;
                float a = (y1 - x1);
                float b = (y2 - x1);
                int d = (int)Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                l2.Add(d);
            }
            int co = 0;
            while (true && l2.Count > 0)
            {
                (int m, int min_idx) = min(l2);
                if (l[min_idx + co].Availability == true && l[min_idx + co].Var_vehicle.Type == v.Type)
                {
                    varDriver = l[min_idx + co];
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.WriteLine("your driver will be " + l[min_idx + co].Name + " with vehicle's License no: " + l[min_idx + co].Var_vehicle.LicensePlate);
                    return true;
                }
                else
                {
                    l2.Remove(m);
                    co++;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("No available driver.");
            return false;
        }
        public (location, location) getLocations()
        {
            return (start_location, end_location);
        }
        public void calculatePrice(string v)
        {
            int f;
            double comm = 0;
            float y1 = start_location.Latitude;
            float y2 = start_location.Longitude;
            float x1 = end_location.Latitude;
            float x2 = end_location.Longitude;
            int d = (int)Math.Sqrt(Math.Pow((y1 - x1), 2) + Math.Pow((y2 - x1), 2));
            if (v == "bike" || v == "Bike")
            {
                f = 50;
                comm = 0.05;
            }
            else if (v == "Rickshaw" || v == "rickshaw")
            {
                f = 35;
                comm = 0.1;
            }
            else
            {
                f = 15;
                comm = 0.2;
            }
            price = Convert.ToInt32(((d * 150) / f) + comm);
        }
    }
}
