using System;
using Driver;
using Admin;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace Admin
{
    public class manager
    {
        static string fileName;
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Drivers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private bool tableExists()
        {
            string tableExistsSql = "IF OBJECT_ID('Drivers', 'U') IS NOT NULL SELECT 1 ELSE SELECT 0";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(tableExistsSql, connection))
                {
                    int result = (int)command.ExecuteScalar();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }
        public void saveDriver(driver d)
        {

            string insertDriverSql = "insert into Drivers(Name,Age,Gender,PhoneNo,Address,VehicleType,vehicleModel,vehicleNo,Location,Availability,rating)" +
                $" values('{d.Name}',{d.Age},upper('{d.Gender}'),'{d.PhoneNo}','{d.Address}',upper('{d.Var_vehicle.Type}'),'{d.Var_vehicle.Model}','{d.Var_vehicle.LicensePlate}','{d.Curr_location.Longitude},{d.Curr_location.Latitude}',{Convert.ToInt32(d.Availability)},{d.getRating()})";
            if (tableExists() == true)
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(insertDriverSql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void printDrivers()
        {
            List<driver> l=getAllDriver();
            foreach(driver x in l)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                Console.WriteLine("ID\t\t\tName\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License");
                Console.WriteLine(x.id + "\t\t\t" + x.Name + "\t\t\t" + x.Age + "\t\t\t" + x.Gender + "\t\t\t" + x.Var_vehicle.Type + "\t\t\t" + x.Var_vehicle.Model + "\t\t\t" + x.Var_vehicle.LicensePlate);
            }
        }
        public bool printDriver(driver d)
        {
            List<driver> listOfDrivers = getAllDriver();

            bool flag = false;
            foreach (driver x in listOfDrivers)
            {
                if ((d.id == 0 || x.id == d.id) && (d.Name == "" || x.Name == d.Name) && (d.Age == 0 || d.Age == x.Age) && (d.Address == "" || d.Address == x.Address) && (d.PhoneNo == "" || d.PhoneNo == x.PhoneNo) && (d.Gender == "" || d.Gender == x.Gender.ToLower() || d.Gender == x.Gender.ToUpper()))
                {
                    if ((d.Var_vehicle.Type == "" || d.Var_vehicle.Type == null || d.Var_vehicle.Type.ToUpper() == x.Var_vehicle.Type) && (d.Var_vehicle.Model == "" || d.Var_vehicle.Model == null || d.Var_vehicle.Model == x.Var_vehicle.Model) && (d.Var_vehicle.LicensePlate == "" || d.Var_vehicle.LicensePlate == null || d.Var_vehicle.LicensePlate == x.Var_vehicle.LicensePlate))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.WriteLine("ID\t\t\tName\t\t\tAge\t\t\tGender\t\t\tV.Type\t\t\tV.Model\t\t\tV.License");
                        Console.WriteLine(x.id + "\t\t\t" + x.Name + "\t\t\t" + x.Age + "\t\t\t" + x.Gender + "\t\t\t" + x.Var_vehicle.Type + "\t\t\t" + x.Var_vehicle.Model + "\t\t\t" + x.Var_vehicle.LicensePlate);
                        flag = true;
                    }
                }
            }
            if (flag == false)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("No such driver exists");
            }
            return flag;
        }
        public driver getDriver(string name)
        {
            string getDriver=$"select * from Drivers where name={name}";
            
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(getDriver, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            driver d = new driver();
            while (reader.Read())
            {
                d.id = reader.GetInt32(0);
                d.Name = reader.GetString(1);
                d.Age = reader.GetInt32(2);
                d.Gender = reader.GetString(3);
                d.PhoneNo = reader.GetString(4);
                d.Address = reader.GetString(5);
                d.Var_vehicle.Type = reader.GetString(6);
                d.Var_vehicle.Model = reader.GetString(7);
                d.Var_vehicle.LicensePlate = reader.GetString(8);
                string s = reader.GetString(9);
                string[] s1 = s.Split(',');
                d.Curr_location.Longitude = Convert.ToSingle(s1[0]);
                d.Curr_location.Latitude = Convert.ToSingle(s1[1]);
                d.Availability = reader.GetBoolean(10);
            }
            conn.Close();
            return d;
        }
        public List<driver> getAllDriver()
        {
            string getDriver = $"select * from Drivers";

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(getDriver, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<driver> l = new List<driver>();
            while (reader.Read())
            {
                driver d = new driver();
                d.id = reader.GetInt32(0);
                d.Name = reader.GetString(1);
                d.Age = reader.GetInt32(2);
                d.Gender = reader.GetString(3);
                d.PhoneNo = reader.GetString(4);
                d.Address = reader.GetString(5);
                d.Var_vehicle.Type = reader.GetString(6);
                d.Var_vehicle.Model= reader.GetString(7);
                d.Var_vehicle.LicensePlate= reader.GetString(8);
                string s=reader.GetString(9);
                string[] s1 = s.Split(',');
                d.Curr_location.Longitude = Convert.ToSingle(s1[0]);
                d.Curr_location.Latitude = Convert.ToSingle(s1[1]);
                d.Availability = reader.GetBoolean(10);
                l.Add(d);
            }
            conn.Close();
            return l;
        }
        public void updateDriver(driver d)
        {
            string updateDriver = $"update Drivers set name='{d.Name}'," +
                      $"age={d.Age}," +
                      $"gender=upper('{d.Gender}')," +
                      $"phoneNo='{d.PhoneNo}'," +
                      $"address='{d.Address}'," +
                      $"vehicleType=upper('{d.Var_vehicle.Type}')," +
                      $"location='{d.Curr_location.Longitude},{d.Curr_location.Latitude}'," +
                      $"availability={Convert.ToInt32(d.Availability)} " +
                      $"where id={d.id}";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(updateDriver, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void removeDriver(int id)
        {
            string removeDriver = $"delete from drivers where id={id}";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(removeDriver, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
