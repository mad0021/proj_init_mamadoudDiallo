using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace proj_init_mamadoudDiallo
{
    public partial class Form1 : Form
    {
        private VehicleController vehicleController;
        private string connectionString = "server=localhost;database=parkingdb;user=root;password=;";

        public Form1()
        {
            InitializeComponent();
            vehicleController = new VehicleController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadVehicles();

        }

        private void LoadVehicles(string licensePlate = null, bool? isCompetition = null, bool? hasHelmetCase = null, bool? isElectric = null, string vehicleType = null)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT LicensePlate, UseCount, IsCompetition, VehicleType, Doors, HasHelmetStorage, IsElectric FROM vehicles WHERE 1=1";

                    if (!string.IsNullOrEmpty(licensePlate))
                    {
                        query += " AND LicensePlate = @LicensePlate";
                    }
                    if (isCompetition.HasValue)
                    {
                        query += " AND IsCompetition = @IsCompetition";
                    }
                    if (hasHelmetCase.HasValue)
                    {
                        query += " AND HasHelmetStorage = @HasHelmetStorage";
                    }
                    if (isElectric.HasValue)
                    {
                        query += " AND IsElectric = @IsElectric";
                    }
                    if (!string.IsNullOrEmpty(vehicleType))
                    {
                        query += " AND VehicleType = @VehicleType";
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(licensePlate))
                        {
                            command.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        }
                        if (isCompetition.HasValue)
                        {
                            command.Parameters.AddWithValue("@IsCompetition", isCompetition.Value);
                        }
                        if (hasHelmetCase.HasValue)
                        {
                            command.Parameters.AddWithValue("@HasHelmetStorage", hasHelmetCase.Value);
                        }
                        if (isElectric.HasValue)
                        {
                            command.Parameters.AddWithValue("@IsElectric", isElectric.Value);
                        }
                        if (!string.IsNullOrEmpty(vehicleType))
                        {
                            command.Parameters.AddWithValue("@VehicleType", vehicleType);
                        }

                        DataTable dataTable = new DataTable();
                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }

                        dgvVehicles.DataSource = dataTable;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgvVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvVehicles.Rows[e.RowIndex];

                    string licensePlate = selectedRow.Cells["LicensePlate"].Value.ToString();

                    int useCount = GetUseCountFromDatabase(licensePlate);

                    useCount++;
                    MessageBox.Show($"The usage counter has been incremented to {useCount} for the vehicle with license plate: {licensePlate}.");

                    UpdateVehicleFields(selectedRow, licensePlate);

                    SaveUsageCount(licensePlate, useCount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting vehicle: {ex.Message}");
            }
        }

        private void UpdateVehicleFields(DataGridViewRow selectedRow, string licensePlate)
        {
            bool isCompetition = Convert.ToBoolean(selectedRow.Cells["IsCompetition"].Value);
            chkCompetition.Checked = isCompetition;

            string vehicleType = selectedRow.Cells["VehicleType"].Value.ToString();
            if (vehicleType == "Car")
            {
                rbCar.Checked = true;
                txtDoors.Text = selectedRow.Cells["Doors"].Value.ToString();
                txtLicensePlate.Text = licensePlate;
            }
            else if (vehicleType == "Motorcycle")
            {
                rbMotorcycle.Checked = true;
                chkHelmetCase.Checked = Convert.ToBoolean(selectedRow.Cells["HasHelmetStorage"].Value);
                txtLicensePlate.Text = licensePlate;
            }
            else if (vehicleType == "Bicycle")
            {
                rbBicycle.Checked = true;
                chkElectric.Checked = Convert.ToBoolean(selectedRow.Cells["IsElectric"].Value);
                txtLicensePlate.Text = "SPECIAL";
            }
        }

        private int GetUseCountFromDatabase(string licensePlate)
        {
            int useCount = 0;

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UseCount FROM vehicles WHERE LicensePlate = @LicensePlate";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            useCount = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("The vehicle does not exist in the database. The usage counter will be initialized to 0.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return useCount;
        }

        private void SaveUsageCount(string licensePlate, int newUseCount)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string queryCheck = "SELECT COUNT(*) FROM vehicles WHERE LicensePlate = @LicensePlate";
                    using (var commandCheck = new MySqlCommand(queryCheck, connection))
                    {
                        commandCheck.Parameters.AddWithValue("@LicensePlate", licensePlate);
                        int vehicleExists = Convert.ToInt32(commandCheck.ExecuteScalar());

                        if (vehicleExists > 0)
                        {
                            string queryUpdate = "UPDATE vehicles SET UseCount = @NewUseCount WHERE LicensePlate = @LicensePlate";
                            using (var commandUpdate = new MySqlCommand(queryUpdate, connection))
                            {
                                commandUpdate.Parameters.AddWithValue("@NewUseCount", newUseCount);
                                commandUpdate.Parameters.AddWithValue("@LicensePlate", licensePlate);
                                commandUpdate.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string queryInsert = "INSERT INTO vehicles (LicensePlate, UseCount) VALUES (@LicensePlate, @NewUseCount)";
                            using (var commandInsert = new MySqlCommand(queryInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@LicensePlate", licensePlate);
                                commandInsert.Parameters.AddWithValue("@NewUseCount", newUseCount);
                                commandInsert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SaveVehicle(bool isUpdate = false)
        {
            try
            {
                bool isCompetition = chkCompetition.Checked;
                string licensePlate = txtLicensePlate.Text;
                int currentUseCount = GetUseCountFromDatabase(licensePlate);

                if (isUpdate)
                {
                    if (rbCar.Checked)
                    {
                        int doorCount = int.Parse(txtDoors.Text);
                        Car car = new Car(licensePlate, currentUseCount, isCompetition, doorCount);
                        vehicleController.UpdateVehicle(car);
                        MessageBox.Show("Car updated successfully!");
                    }
                    else if (rbMotorcycle.Checked)
                    {
                        bool hasHelmetCase = chkHelmetCase.Checked;
                        Motorcycle motorcycle = new Motorcycle(licensePlate, currentUseCount, isCompetition, hasHelmetCase);
                        vehicleController.UpdateVehicle(motorcycle);
                        MessageBox.Show("Motorcycle updated successfully!");
                    }
                    else if (rbBicycle.Checked)
                    {
                        bool isElectric = chkElectric.Checked;
                        Bicycle bicycle = new Bicycle(currentUseCount, isCompetition, isElectric);
                        vehicleController.UpdateVehicle(bicycle);
                        MessageBox.Show("Bicycle updated successfully!");
                    }

                    LoadVehicles();
                    return;
                }

                if (currentUseCount > 0)
                {
                    currentUseCount++;
                    SaveUsageCount(licensePlate, currentUseCount);
                    MessageBox.Show($"The vehicle with license plate {licensePlate} already exists. Use count has been incremented to {currentUseCount}.");
                }
                else
                {
                    if (rbCar.Checked)
                    {
                        int doorCount = int.Parse(txtDoors.Text);
                        Car car = new Car(licensePlate, 1, isCompetition, doorCount);
                        vehicleController.AddVehicle(car);
                        MessageBox.Show("Car added successfully!");
                    }
                    else if (rbMotorcycle.Checked)
                    {
                        bool hasHelmetCase = chkHelmetCase.Checked;
                        Motorcycle motorcycle = new Motorcycle(licensePlate, 1, isCompetition, hasHelmetCase);
                        vehicleController.AddVehicle(motorcycle);
                        MessageBox.Show("Motorcycle added successfully!");
                    }
                    else if (rbBicycle.Checked)
                    {
                        bool isElectric = chkElectric.Checked;
                        Bicycle bicycle = new Bicycle(1, isCompetition, isElectric);
                        vehicleController.AddVehicle(bicycle);
                        MessageBox.Show("Bicycle added successfully with license plate 'SPECIAL'!");
                    }
                }

                LoadVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            SaveVehicle();
        }

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            SaveVehicle(true);
        }

        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                string licensePlate = txtLicensePlate.Text;

                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    MessageBox.Show("Please enter a valid license plate.");
                    return;
                }

                vehicleController.DeleteVehicle(licensePlate);
                MessageBox.Show("Vehicle deleted successfully!");

                LoadVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting vehicle: {ex.Message}");
            }
        }

        private void btnSearchVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                string licensePlate = txtLicensePlate.Text;
                bool? isCompetition = chkCompetition.Checked ? (bool?)true : null;
                bool? hasHelmetCase = chkHelmetCase.Checked ? (bool?)true : null;
                bool? isElectric = chkElectric.Checked ? (bool?)true : null;

                string vehicleType = rbCar.Checked ? "Car" : rbMotorcycle.Checked ? "Motorcycle" : rbBicycle.Checked ? "Bicycle" : null;

                LoadVehicles(licensePlate, isCompetition, hasHelmetCase, isElectric, vehicleType);

                if (!string.IsNullOrEmpty(licensePlate))
                {
                    int currentUseCount = GetUseCountFromDatabase(licensePlate);
                    SaveUsageCount(licensePlate, currentUseCount + 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for vehicle: {ex.Message}");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
