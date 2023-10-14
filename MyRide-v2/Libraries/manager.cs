using System;
using Driver;
using Admin;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Admin
{
    public class manager
    {
        static string fileName;
        public manager()
        {
            fileName = "drivers.txt";
            FileStream file = new FileStream(fileName, FileMode.Create);
            file.Close();
        }
        private void saveDriver(driver d, string file2)
        {
            StreamWriter sw = new StreamWriter(file2, true);
            string str = JsonSerializer.Serialize(d);
            sw.WriteLine(str);
            sw.Close();
        }
        public void saveDriver(driver d)
        {
            StreamWriter sw = new StreamWriter(fileName, true);
            string str = JsonSerializer.Serialize(d);
            sw.WriteLine(str);
            sw.Close();
        }
        public void printDrivers()
        {
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadLine();

            while (str != null)
            {
                driver x = JsonSerializer.Deserialize<driver>(str);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine("ID\t\t\tName\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License");
                Console.WriteLine(x.id + "\t\t\t" + x.Name + "\t\t\t" + x.Age + "\t\t\t" + x.Gender + "\t\t\t" + x.Var_vehicle.Type + "\t\t\t" + x.Var_vehicle.Model + "\t\t\t" + x.Var_vehicle.LicensePlate);
                str = sr.ReadLine();
            }
            sr.Close();
        }
        public bool printDriver(driver d)
        {
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadLine();
            bool flag = false;
            while (str != null)
            {
                driver x = JsonSerializer.Deserialize<driver>(str);
                Console.ForegroundColor = ConsoleColor.White;
                if ((d.id == 0 || x.id == d.id) && (d.Name == "" || x.Name == d.Name) && (d.Age == 0 || d.Age == x.Age) && (d.Address == "" || d.Address == x.Address) && (d.PhoneNo == "" || d.PhoneNo == x.PhoneNo) && (d.Gender == "" || d.Gender == x.Gender.ToLower() || d.Gender == x.Gender.ToUpper()))
                {
                    if ((d.Var_vehicle.Type == "" || d.Var_vehicle.Type == null || d.Var_vehicle.Type == x.Var_vehicle.Type) && (d.Var_vehicle.Model == "" || d.Var_vehicle.Model == null || d.Var_vehicle.Model == x.Var_vehicle.Model) && (d.Var_vehicle.LicensePlate == "" || d.Var_vehicle.LicensePlate == null || d.Var_vehicle.LicensePlate == x.Var_vehicle.LicensePlate))
                    {
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.WriteLine("ID\t\t\tName\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License");
                        Console.WriteLine(x.id + "\t\t\t" + x.Name + "\t\t\t" + x.Age + "\t\t\t" + x.Gender + "\t\t\t" + x.Var_vehicle.Type + "\t\t\t" + x.Var_vehicle.Model + "\t\t\t" + x.Var_vehicle.LicensePlate);
                        flag = true;
                    }
                }
                str = sr.ReadLine();
            }
            if (flag == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("No such driver exists");
            }
            sr.Close();
            return flag;
        }
        public driver getDriver(string name)
        {
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadLine();
            while (str != null)
            {
                driver d2 = JsonSerializer.Deserialize<driver>(str);
                if (d2.Name == name)
                {
                    return d2;
                }
                str = sr.ReadLine();
            }
            sr.Close();
            return null;
        }
        public List<driver> getAllDriver()
        {
            List<driver> l = new List<driver>();
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadLine();

            while (str != null)
            {
                driver d2 = JsonSerializer.Deserialize<driver>(str);
                l.Add(d2);
                str = sr.ReadLine();
            }
            sr.Close();
            return l;
        }
        public void updateDriver(int idx, driver d)
        {
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadLine();
            int i = 0;
            while (str != null)
            {
                if (i == idx)
                {
                    saveDriver(d, "temp.txt");
                    str = sr.ReadLine();
                    i++;
                    continue;
                }
                driver d2 = JsonSerializer.Deserialize<driver>(str);
                saveDriver(d2, "temp.txt");
                str = sr.ReadLine();
                i++;
            }
            sr.Close();
            File.Delete(fileName);
            File.Move("temp.txt", fileName);

        }
        public void removeDriver(int id)
        {
            StreamReader sr = new StreamReader(fileName);
            string str = sr.ReadLine();
            while (str != null)
            {
                driver d2 = JsonSerializer.Deserialize<driver>(str);
                if (d2.id == id)
                {
                    str = sr.ReadLine();
                    continue;
                }
                saveDriver(d2, "temp.txt");
                str = sr.ReadLine();
            }
            sr.Close();
            File.Delete(fileName);
            File.Move("temp.txt", fileName);

        }
    }
}
