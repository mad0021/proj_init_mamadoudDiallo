namespace proj_init_mamadoudDiallo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtDoors = new System.Windows.Forms.TextBox();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.txtUsageCount = new System.Windows.Forms.TextBox();
            this.txtLicensePlate = new System.Windows.Forms.TextBox();
            this.chkElectric = new System.Windows.Forms.CheckBox();
            this.chkHelmetCase = new System.Windows.Forms.CheckBox();
            this.rbMotorcycle = new System.Windows.Forms.CheckBox();
            this.rbBicycle = new System.Windows.Forms.CheckBox();
            this.rbCar = new System.Windows.Forms.CheckBox();
            this.chkCompetition = new System.Windows.Forms.CheckBox();
            this.btnSearchVehicle = new System.Windows.Forms.Button();
            this.btnDeleteVehicle = new System.Windows.Forms.Button();
            this.btnUpdateVehicle = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1401, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 32);
            this.button1.TabIndex = 30;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtDoors
            // 
            this.txtDoors.Location = new System.Drawing.Point(109, 226);
            this.txtDoors.Name = "txtDoors";
            this.txtDoors.Size = new System.Drawing.Size(141, 26);
            this.txtDoors.TabIndex = 29;
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToOrderColumns = true;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Location = new System.Drawing.Point(308, 85);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.RowHeadersWidth = 62;
            this.dgvVehicles.RowTemplate.Height = 28;
            this.dgvVehicles.Size = new System.Drawing.Size(1151, 514);
            this.dgvVehicles.TabIndex = 28;
            // 
            // txtUsageCount
            // 
            this.txtUsageCount.Location = new System.Drawing.Point(144, 166);
            this.txtUsageCount.Name = "txtUsageCount";
            this.txtUsageCount.Size = new System.Drawing.Size(141, 26);
            this.txtUsageCount.TabIndex = 27;
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.Location = new System.Drawing.Point(159, 108);
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(141, 26);
            this.txtLicensePlate.TabIndex = 26;
            // 
            // chkElectric
            // 
            this.chkElectric.AutoSize = true;
            this.chkElectric.Location = new System.Drawing.Point(776, 24);
            this.chkElectric.Name = "chkElectric";
            this.chkElectric.Size = new System.Drawing.Size(87, 24);
            this.chkElectric.TabIndex = 25;
            this.chkElectric.Text = "Electric";
            this.chkElectric.UseVisualStyleBackColor = true;
            // 
            // chkHelmetCase
            // 
            this.chkHelmetCase.AutoSize = true;
            this.chkHelmetCase.Location = new System.Drawing.Point(626, 24);
            this.chkHelmetCase.Name = "chkHelmetCase";
            this.chkHelmetCase.Size = new System.Drawing.Size(127, 24);
            this.chkHelmetCase.TabIndex = 24;
            this.chkHelmetCase.Text = "Helmet Case";
            this.chkHelmetCase.UseVisualStyleBackColor = true;
            // 
            // rbMotorcycle
            // 
            this.rbMotorcycle.AutoSize = true;
            this.rbMotorcycle.Location = new System.Drawing.Point(1020, 24);
            this.rbMotorcycle.Name = "rbMotorcycle";
            this.rbMotorcycle.Size = new System.Drawing.Size(111, 24);
            this.rbMotorcycle.TabIndex = 23;
            this.rbMotorcycle.Text = "Motorcycle";
            this.rbMotorcycle.UseVisualStyleBackColor = true;
            // 
            // rbBicycle
            // 
            this.rbBicycle.AutoSize = true;
            this.rbBicycle.Location = new System.Drawing.Point(1173, 24);
            this.rbBicycle.Name = "rbBicycle";
            this.rbBicycle.Size = new System.Drawing.Size(84, 24);
            this.rbBicycle.TabIndex = 22;
            this.rbBicycle.Text = "Bicycle";
            this.rbBicycle.UseVisualStyleBackColor = true;
            // 
            // rbCar
            // 
            this.rbCar.AutoSize = true;
            this.rbCar.Location = new System.Drawing.Point(903, 24);
            this.rbCar.Name = "rbCar";
            this.rbCar.Size = new System.Drawing.Size(60, 24);
            this.rbCar.TabIndex = 21;
            this.rbCar.Text = "Car";
            this.rbCar.UseVisualStyleBackColor = true;
            // 
            // chkCompetition
            // 
            this.chkCompetition.AutoSize = true;
            this.chkCompetition.Location = new System.Drawing.Point(480, 24);
            this.chkCompetition.Name = "chkCompetition";
            this.chkCompetition.Size = new System.Drawing.Size(120, 24);
            this.chkCompetition.TabIndex = 20;
            this.chkCompetition.Text = "Competition";
            this.chkCompetition.UseVisualStyleBackColor = true;
            // 
            // btnSearchVehicle
            // 
            this.btnSearchVehicle.Location = new System.Drawing.Point(1261, 619);
            this.btnSearchVehicle.Name = "btnSearchVehicle";
            this.btnSearchVehicle.Size = new System.Drawing.Size(198, 87);
            this.btnSearchVehicle.TabIndex = 19;
            this.btnSearchVehicle.Text = "Search Vehicle";
            this.btnSearchVehicle.UseVisualStyleBackColor = true;
            this.btnSearchVehicle.Click += new System.EventHandler(this.btnSearchVehicle_Click);
            // 
            // btnDeleteVehicle
            // 
            this.btnDeleteVehicle.Location = new System.Drawing.Point(893, 619);
            this.btnDeleteVehicle.Name = "btnDeleteVehicle";
            this.btnDeleteVehicle.Size = new System.Drawing.Size(198, 87);
            this.btnDeleteVehicle.TabIndex = 18;
            this.btnDeleteVehicle.Text = "Delete Vehicle";
            this.btnDeleteVehicle.UseVisualStyleBackColor = true;
            this.btnDeleteVehicle.Click += new System.EventHandler(this.btnDeleteVehicle_Click);
            // 
            // btnUpdateVehicle
            // 
            this.btnUpdateVehicle.Location = new System.Drawing.Point(567, 619);
            this.btnUpdateVehicle.Name = "btnUpdateVehicle";
            this.btnUpdateVehicle.Size = new System.Drawing.Size(198, 87);
            this.btnUpdateVehicle.TabIndex = 17;
            this.btnUpdateVehicle.Text = "Update Vehicle";
            this.btnUpdateVehicle.UseVisualStyleBackColor = true;
            this.btnUpdateVehicle.Click += new System.EventHandler(this.btnUpdateVehicle_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Location = new System.Drawing.Point(261, 619);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(198, 87);
            this.btnAddVehicle.TabIndex = 16;
            this.btnAddVehicle.Text = "Add Vehicle";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 26);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "License Plate";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 166);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 26);
            this.textBox2.TabIndex = 32;
            this.textBox2.Text = "Use Count";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(52, 226);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(51, 26);
            this.textBox3.TabIndex = 33;
            this.textBox3.Text = "Doors";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 709);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDoors);
            this.Controls.Add(this.dgvVehicles);
            this.Controls.Add(this.txtUsageCount);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.chkElectric);
            this.Controls.Add(this.chkHelmetCase);
            this.Controls.Add(this.rbMotorcycle);
            this.Controls.Add(this.rbBicycle);
            this.Controls.Add(this.rbCar);
            this.Controls.Add(this.chkCompetition);
            this.Controls.Add(this.btnSearchVehicle);
            this.Controls.Add(this.btnDeleteVehicle);
            this.Controls.Add(this.btnUpdateVehicle);
            this.Controls.Add(this.btnAddVehicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDoors;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.TextBox txtUsageCount;
        private System.Windows.Forms.TextBox txtLicensePlate;
        private System.Windows.Forms.CheckBox chkElectric;
        private System.Windows.Forms.CheckBox chkHelmetCase;
        private System.Windows.Forms.CheckBox rbMotorcycle;
        private System.Windows.Forms.CheckBox rbBicycle;
        private System.Windows.Forms.CheckBox rbCar;
        private System.Windows.Forms.CheckBox chkCompetition;
        private System.Windows.Forms.Button btnSearchVehicle;
        private System.Windows.Forms.Button btnDeleteVehicle;
        private System.Windows.Forms.Button btnUpdateVehicle;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

