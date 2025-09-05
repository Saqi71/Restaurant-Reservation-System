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
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

          private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor= Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor= Color.White;
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "admin" && password == "program")
            {
                // Close the login form
                this.Hide();

                // Open the main form
                HomeForm mainForm = new HomeForm();
                mainForm.ShowDialog();

                // Close the application when the main form is closed
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Loginform_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
