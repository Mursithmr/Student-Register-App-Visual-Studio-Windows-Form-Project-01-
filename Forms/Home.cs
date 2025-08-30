using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegisterApp.Forms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDBDataSet.Registration_Table' table. You can move, or remove it, as needed.
            this.registration_TableTableAdapter.Fill(this.studentDBDataSet.Registration_Table);
            // TODO: This line of code loads data into the 'studentDBDataSet.Registration_Table' table. You can move, or remove it, as needed.
            this.registration_TableTableAdapter.Fill(this.studentDBDataSet.Registration_Table);

        }

        private void DashBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void RegBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrastionForm registrastionForm = new RegistrastionForm();
            registrastionForm.Show();
        }

        private void LogoutBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                LogForm logForm = new LogForm();
                logForm.Show();
            }
        }
    }
}
