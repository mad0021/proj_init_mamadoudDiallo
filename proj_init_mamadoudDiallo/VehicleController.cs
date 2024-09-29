using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proj_init_mamadoudDiallo
{
    public class VehicleController
    {
        private string connectionString = "server=localhost;database=parkingdb;user=root;password=;";

        public void AddVehicle(Vehicle vehicle)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO vehicles (LicensePlate, UseCount, VehicleType, IsCompetition, Doors, IsElectric, HasHelmetStorage) " +
                                   "VALUES (@licensePlate, @useCount, @type, @isCompetition, @doors, @isElectric, @hasHelmetStorage)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@useCount", vehicle.UseCount);
                    cmd.Parameters.AddWithValue("@type", vehicle.GetType().Name);
                    cmd.Parameters.AddWithValue("@isCompetition", vehicle.IsCompetition ? 1 : 0);

                    if (vehicle is Car car)
                    {
                        cmd.Parameters.AddWithValue("@doors", car.Doors);
                        cmd.Parameters.AddWithValue("@isElectric", DBNull.Value);
                        cmd.Parameters.AddWithValue("@hasHelmetStorage", DBNull.Value);
                    }
                    else if (vehicle is Motorcycle motorcycle)
                    {
                        cmd.Parameters.AddWithValue("@doors", DBNull.Value);
                        cmd.Parameters.AddWithValue("@isElectric", DBNull.Value); 
                        cmd.Parameters.AddWithValue("@hasHelmetStorage", motorcycle.HasHelmetStorage ? 1 : 0);
                    }
                    else if (vehicle is Bicycle bicycle)
                    {
                        cmd.Parameters.AddWithValue("@doors", DBNull.Value);
                        cmd.Parameters.AddWithValue("@isElectric", bicycle.IsElectric ? 1 : 0);
                        cmd.Parameters.AddWithValue("@hasHelmetStorage", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE vehicles SET UseCount = @useCount, VehicleType = @type, IsCompetition = @isCompetition, " +
                                   "Doors = @doors, IsElectric = @isElectric, HasHelmetStorage = @hasHelmetStorage " +
                                   "WHERE LicensePlate = @licensePlate";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@licensePlate", vehicle.LicensePlate);
                    cmd.Parameters.AddWithValue("@useCount", vehicle.UseCount);
                    cmd.Parameters.AddWithValue("@type", vehicle.GetType().Name);
                    cmd.Parameters.AddWithValue("@isCompetition", vehicle.IsCompetition ? 1 : 0);

                    if (vehicle is Car car)
                    {
                        cmd.Parameters.AddWithValue("@doors", car.Doors);
                        cmd.Parameters.AddWithValue("@isElectric", DBNull.Value);
                        cmd.Parameters.AddWithValue("@hasHelmetStorage", DBNull.Value);
                    }
                    else if (vehicle is Motorcycle motorcycle)
                    {
                        cmd.Parameters.AddWithValue("@doors", DBNull.Value);
                        cmd.Parameters.AddWithValue("@isElectric", DBNull.Value);
                        cmd.Parameters.AddWithValue("@hasHelmetStorage", motorcycle.HasHelmetStorage ? 1 : 0);
                    }
                    else if (vehicle is Bicycle bicycle)
                    {
                        cmd.Parameters.AddWithValue("@doors", DBNull.Value);
                        cmd.Parameters.AddWithValue("@isElectric", bicycle.IsElectric ? 1 : 0);
                        cmd.Parameters.AddWithValue("@hasHelmetStorage", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void DeleteVehicle(string licensePlate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM vehicles WHERE LicensePlate = @licensePlate";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public Vehicle GetVehicleByLicensePlate(string licensePlate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM vehicles WHERE LicensePlate = @licensePlate";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@licensePlate", licensePlate);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string type = reader.GetString("VehicleType");
                        int useCount = reader.GetInt32("UseCount");
                        bool isCompetition = reader.GetBoolean("IsCompetition");
                        int doors = reader.IsDBNull(reader.GetOrdinal("Doors")) ? 0 : reader.GetInt32("Doors");
                        bool isElectric = reader.IsDBNull(reader.GetOrdinal("IsElectric")) ? false : reader.GetBoolean("IsElectric");
                        bool hasHelmetStorage = reader.IsDBNull(reader.GetOrdinal("HasHelmetStorage")) ? false : reader.GetBoolean("HasHelmetStorage");

                        switch (type)
                        {
                            case "Car":
                                return new Car(licensePlate, useCount, isCompetition, doors);
                            case "Motorcycle":
                                return new Motorcycle(licensePlate, useCount, isCompetition, hasHelmetStorage);
                            case "Bicycle":
                                return new Bicycle(useCount, isCompetition, isElectric);
                        }
                    }
                }
            }
            return null;
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM vehicles";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string vehicleType = reader["VehicleType"].ToString();
                        string licensePlate = reader["LicensePlate"].ToString();
                        int useCount = Convert.ToInt32(reader["UseCount"]);
                        bool isCompetition = Convert.ToBoolean(reader["IsCompetition"]);
                        int doors = reader.IsDBNull(reader.GetOrdinal("Doors")) ? 0 : reader.GetInt32("Doors");
                        bool isElectric = reader.IsDBNull(reader.GetOrdinal("IsElectric")) ? false : reader.GetBoolean("IsElectric");
                        bool hasHelmetStorage = reader.IsDBNull(reader.GetOrdinal("HasHelmetStorage")) ? false : reader.GetBoolean("HasHelmetStorage");

                        switch (vehicleType)
                        {
                            case "Car":
                                vehicles.Add(new Car(licensePlate, useCount, isCompetition, doors));
                                break;
                            case "Motorcycle":
                                vehicles.Add(new Motorcycle(licensePlate, useCount, isCompetition, hasHelmetStorage));
                                break;
                            case "Bicycle":
                                vehicles.Add(new Bicycle(useCount, isCompetition, isElectric));
                                break;
                        }
                    }
                }
            }
            return vehicles;
        }
    }
}
