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

        private void LoadVehicles()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT LicensePlate, UseCount, IsCompetition, VehicleType, Doors, HasHelmetStorage, IsElectric FROM vehicles";

                    using (var command = new MySqlCommand(query, connection))
                    {
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

                    txtUsageCount.Text = selectedRow.Cells["UseCount"].Value.ToString();
                    chkCompetition.Checked = Convert.ToBoolean(selectedRow.Cells["IsCompetition"].Value);

                    string vehicleType = selectedRow.Cells["VehicleType"].Value.ToString();

                    if (vehicleType == "Car")
                    {
                        rbCar.Checked = true;
                        txtDoors.Text = selectedRow.Cells["Doors"].Value.ToString();
                        txtLicensePlate.Text = selectedRow.Cells["LicensePlate"].Value.ToString();
                    }
                    else if (vehicleType == "Motorcycle")
                    {
                        rbMotorcycle.Checked = true;
                        chkHelmetCase.Checked = Convert.ToBoolean(selectedRow.Cells["HasHelmetStorage"].Value);
                        txtLicensePlate.Text = selectedRow.Cells["LicensePlate"].Value.ToString();
                    }
                    else if (vehicleType == "Bicycle")
                    {
                        rbBicycle.Checked = true;
                        chkElectric.Checked = Convert.ToBoolean(selectedRow.Cells["IsElectric"].Value);
                        txtLicensePlate.Text = "ESPECIAL";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting vehicle: {ex.Message}");
            }
        }

        private void SaveVehicle(bool isUpdate = false)
        {
            try
            {
                int useCount = int.Parse(txtUsageCount.Text);
                bool isCompetition = chkCompetition.Checked;

                if (rbCar.Checked)
                {
                    string licensePlate = txtLicensePlate.Text;
                    int doorCount = int.Parse(txtDoors.Text);
                    Car car = new Car(licensePlate, useCount, isCompetition, doorCount);
                    if (isUpdate)
                    {
                        vehicleController.UpdateVehicle(car);
                        MessageBox.Show("Car updated successfully!");
                    }
                    else
                    {
                        vehicleController.AddVehicle(car);
                        MessageBox.Show("Car added successfully!");
                    }
                }
                else if (rbMotorcycle.Checked)
                {
                    string licensePlate = txtLicensePlate.Text;
                    bool hasHelmetCase = chkHelmetCase.Checked;
                    Motorcycle motorcycle = new Motorcycle(licensePlate, useCount, isCompetition, hasHelmetCase);
                    if (isUpdate)
                    {
                        vehicleController.UpdateVehicle(motorcycle);
                        MessageBox.Show("Motorcycle updated successfully!");
                    }
                    else
                    {
                        vehicleController.AddVehicle(motorcycle);
                        MessageBox.Show("Motorcycle added successfully!");
                    }
                }
                else if (rbBicycle.Checked)
                {
                    bool isElectric = chkElectric.Checked;
                    Bicycle bicycle = new Bicycle(useCount, isCompetition, isElectric);
                    if (isUpdate)
                    {
                        vehicleController.UpdateVehicle(bicycle);
                        MessageBox.Show("Bicycle updated successfully!");
                    }
                    else
                    {
                        vehicleController.AddVehicle(bicycle);
                        MessageBox.Show("Bicycle added successfully with license plate 'ESPECIAL'!");
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
            SaveVehicle();
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

                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    MessageBox.Show("Please enter a valid license plate.");
                    return;
                }

                Vehicle vehicle = vehicleController.GetVehicleByLicensePlate(licensePlate);

                if (vehicle != null)
                {
                    txtUsageCount.Text = vehicle.UseCount.ToString();
                    chkCompetition.Checked = vehicle.IsCompetition;

                    if (vehicle is Car car)
                    {
                        rbCar.Checked = true;
                        txtDoors.Text = car.Doors.ToString();
                    }
                    else if (vehicle is Motorcycle motorcycle)
                    {
                        rbMotorcycle.Checked = true;
                        chkHelmetCase.Checked = motorcycle.HasHelmetStorage;
                    }
                    else if (vehicle is Bicycle bicycle)
                    {
                        rbBicycle.Checked = true;
                        chkElectric.Checked = bicycle.IsElectric;
                    }
                }
                else
                {
                    MessageBox.Show("Vehicle not found!");
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
