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
    public partial class FoodMenuForm : Form
    {
        string connectionString = "server=localhost;user=root;password=sahtosaqib78.;database=cafeszechuan;";
        private DataTable foodmenuDataTable = new DataTable();
        public FoodMenuForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = foodmenuDataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm();
            homeForm.ShowDialog();
            this.Hide();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor= Color.White;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void FoodMenuForm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM foodmenu";
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
