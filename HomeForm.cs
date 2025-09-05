using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafe_Szechuan
{
    public partial class HomeForm : Form
    {
        string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";
        private DataTable reservationDataTable = new DataTable();
        private MySqlConnection connection;
        public HomeForm()
        {
            InitializeComponent();
            InitializeConnection();
            InitializeReservationDataTable();
            LoadReservationData();
            dataGridView1.DataSource = reservationDataTable;
        }
        private void InitializeReservationDataTable()
        {
            reservationDataTable.Columns.Add("CustomerID", typeof(int));
            reservationDataTable.Columns.Add("Name" , typeof(string));
            reservationDataTable.Columns.Add("Table" , typeof(string));
            reservationDataTable.Columns.Add("Order" , typeof(string));
            reservationDataTable.Columns.Add("Total" , typeof(string));
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkGray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkGray;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Black;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            FoodMenuForm foodMenuForm = new FoodMenuForm();
            foodMenuForm.ShowDialog();
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            StorageForm storageForm = new StorageForm();
            storageForm.ShowDialog();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM reservation";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int customerID))

            {
                DataRow newRow = reservationDataTable.NewRow();
                newRow["CustomerID"] = customerID;
                newRow["Name"] = textBox2.Text;
                newRow["Table"] = textBox3.Text;
                newRow["Order"] = textBox4.Text;
                newRow["Total"] = textBox5.Text;
                reservationDataTable.Rows.Add(newRow);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = reservationDataTable;
                SaveToDatabase(customerID, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Customer ID");
            }
        }
        private void SaveToDatabase(int customerID, string name, string table, string order, string total)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string insertQuery = $"INSERT INTO reservation (CustomerID, Name, `Table`, `Order`, Total)" +
                    "VALUES (@customerID, @name, @table, @order, @total)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Table", table);
                    cmd.Parameters.AddWithValue("@Order", order);
                    cmd.Parameters.AddWithValue("@Total", total);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeConnection()
        {
            string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        private void  LoadReservationData()
        {
            string selectQuery = "SELECT * FROM reservation";
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            dataAdapter.Fill(reservationDataTable);
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshReservationData();
        }
        private void RefreshReservationData()
        {
            reservationDataTable.Rows.Clear();
            LoadReservationData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
