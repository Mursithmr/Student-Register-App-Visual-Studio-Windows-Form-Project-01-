using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegisterApp.Forms
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void LogForm_Load(object sender, EventArgs e)
        {

        }

        private void Exitbtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Add this new method for clear button functionality



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ShowBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowBtn.Checked)
            {
                pwordBox.UseSystemPasswordChar = false; // Show password
            }
            else
            {
                pwordBox.UseSystemPasswordChar = true; // Hide password
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = unameBox.Text.Trim();
            string password = pwordBox.Text;

            // Validation
            if (username == "Admin" && password == "Skills@123")
            {
                MessageBox.Show("Login Successful!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Home home = new Home();
                home.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
