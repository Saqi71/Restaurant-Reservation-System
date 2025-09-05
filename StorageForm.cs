using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cafe_Szechuan
{
    public partial class StorageForm : Form
    {
        string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";
        private DataTable storageDataTable = new DataTable();
        private MySqlConnection connection;
        public StorageForm()
        {
            InitializeComponent();
            InitializeConnection();
            LoadStorageData();
            dataGridView1.DataSource = storageDataTable;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm();
            homeForm.ShowDialog();
            this.Hide();
        }

        private void StorageForm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM storage";
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
        private void InitializeConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void LoadStorageData()
        {
            string selectQuery = "SELECT * FROM storage";
            MySqlCommand cmd = new MySqlCommand(selectQuery, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            dataAdapter.Fill(storageDataTable);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM storage", connection))
            {
                MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(dataAdapter);

                try
                {
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.Update(storageDataTable);

                    // For debugging, display the generated UPDATE query
                    string updateQuery = cmdBuilder.GetUpdateCommand().CommandText;
                    MessageBox.Show("Generated UPDATE query: " + updateQuery);

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
            }
        }
    }
}
