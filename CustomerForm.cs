using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafe_Szechuan
{
    public partial class CustomerForm : Form
    {
        string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";
        private DataTable customerDataTable = new DataTable();

        public CustomerForm()

        {
            InitializeComponent();
            

            customerDataTable.Columns.Add("CustomerID", typeof(int));
            customerDataTable.Columns.Add("Name", typeof(string));
            customerDataTable.Columns.Add("PhoneNumber", typeof(string));
            customerDataTable.Columns.Add("Address", typeof(string));
            dataGridView1.DataSource = customerDataTable;

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void CustomerForm_Load(object sender, EventArgs e)

        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM customers";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void CustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int customerID))

            {
                DataRow newRow = customerDataTable.NewRow();
                newRow["CustomerID"] = customerID;
                newRow["Name"] = textBox1.Text;
                newRow["PhoneNumber"] = textBox2.Text;
                newRow["Address"] = textBox3.Text;
                customerDataTable.Rows.Add(newRow);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = customerDataTable;
                SaveToDatabase(customerID, textBox1.Text, textBox2.Text, textBox3.Text);
                textBox4.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Customer ID");
            }
        }
        private void SaveToDatabase(int customerID, string name, string phoneNumber, string address)
        {
            string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string insertQuery = $"INSERT INTO customers (CustomerID, Name, `Phone Number`, Address)" +
                    "VALUES (@customerID, @Name, @PhoneNumber, @Address)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Address", address);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        private void CustomerForm_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshCustomerData();
        }
        private void RefreshCustomerData()
        {
            customerDataTable.Rows.Clear();
        }
    }
}
