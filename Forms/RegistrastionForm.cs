using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StudentRegisterApp.Forms
{
    public partial class RegistrastionForm : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K53JPJ9\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;Encrypt=False");
        private string connectionString;
        private object btnClear;

        public object ClearButton { get; private set; }

        public RegistrastionForm()
        {
            InitializeComponent();
            LoadRegNumbers();
            maleradioButton.Checked = true;
        }


        private void backli1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           
        }

        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       

        private void RegistrastionForm_Load(object sender, EventArgs e)
        {
            try
            {
                RegNOBox.Items.Clear();

                string query = "SELECT RegNo FROM Registration_Table";
                SqlCommand cmd = new SqlCommand(query, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RegNOBox.Items.Add(reader["RegNo"].ToString());
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading registration numbers: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            FNBox.Clear();
            LNBox.Clear();
            dateTimePicker.Value = DateTime.Now;
            maleradioButton.Checked = true;
            ADBox.Clear();
            EBox.Clear();
            MPBox.Clear();
            HPBox.Clear();
            PNBox.Clear();
            NICBox.Clear();
            CNOBox.Clear();
            RegNOBox.SelectedIndex = -1;
        }

        

        private void LoadRegNumbers()
        {
            try
            {
                RegNOBox.Items.Clear();

                string query = "SELECT RegNo FROM Registration_Table";
                SqlCommand cmd = new SqlCommand(query, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RegNOBox.Items.Add(reader["RegNo"].ToString());
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading registration numbers: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
            //Register Students Details
            int regNo = int.Parse(RegNOBox.Text);
            string fn = FNBox.Text;
            string ln = LNBox.Text;
            string dob = dateTimePicker.Value.ToString("yyyy-MM-dd");
            string gender = "";
            if (maleradioButton.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            string address = ADBox.Text;
            string email = EBox.Text;
            string mobile = MPBox.Text;
            string home = HPBox.Text;
            string parentName = PNBox.Text;
            string NIC = NICBox.Text;
            string contact = CNOBox.Text;

            string query = "INSERT INTO Registration_Table VALUES('" + regNo + "','" + fn + "','" + ln + "','" + dob + "','" + gender + "', '" + address + "','" +
                email + "','" + mobile + "','" + home + "','" + parentName + "','" + NIC + "','" + contact + "')";


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Saved Successfully", "SUCCESS");
                this.Refresh();
                LoadRegNumbers();
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void RefreshRegistrationComboBox()
        {
            throw new NotImplementedException();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            FNBox.Clear();
            LNBox.Clear();
            PNBox.Clear();
            NICBox.Clear();
            CNOBox.Clear();
            ADBox.Clear();
            EBox.Clear();
            MPBox.Clear();
            HPBox.Clear();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (RegNOBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a registration number to delete", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int regNo = int.Parse(RegNOBox.SelectedItem.ToString());

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Registration_Table WHERE RegNo = @RegNo";

                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@RegNo", regNo);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the registration numbers combo box
                    LoadRegNumbers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //update student details 

            int regNo = int.Parse(RegNOBox.Text);
            string fn = FNBox.Text;
            string ln = LNBox.Text;
            string dob = dateTimePicker.Value.ToString("yyyy-MM-dd");
            string gender = "";
            if (maleradioButton.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            string address = ADBox.Text;
            string email = EBox.Text;
            string mobile = MPBox.Text;
            string home = HPBox.Text;
            string parentName = PNBox.Text;
            string NIC = NICBox.Text;
            string contact = CNOBox.Text;

            string query = "UPDATE Registration_Table SET firstName = '" + fn + "'," +
                "lastName = '" + ln + "', dateOfBirth = '" + dob + "',gender = '" + gender + "', address = '" + address + "'," +
                "email = '" + email + "', mobilPhone = " + mobile + ", homePhone = '" + home + "', " +
                "parentName = '" + parentName + "',nic = '" + NIC + "', contactNo = '" + contact + "' WHERE regNo = " + regNo;


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully", "SUCCESS");
                this.Refresh();
                LoadRegNumbers();
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void RefreshRegNOBox()
        {
            RegNOBox.Items.Clear();
            RegNOBox.Items.Add("New Register");

            using (SqlConnection mycon = new SqlConnection(connectionString))
            {
                try
                {
                    mycon.Open();
                    string query_select = "SELECT regNo FROM Registration_Table";
                    SqlCommand cmd = new SqlCommand(query_select, mycon);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        RegNOBox.Items.Add(reader["regNo"].ToString());
                    }
                    RegNOBox.SelectedIndex = 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error refreshing registration numbers: " + ex.Message);
                }
            }
        }
            

        private void RegNoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string no = RegNOBox.Text;
            if (no != "New Register")
            {
                con.Open();
                string query_select = "SELECT * FROM Registration_Table WHERE regNo=" + no;
                SqlCommand cmd = new SqlCommand(query_select, con);
                SqlDataReader row = cmd.ExecuteReader();
                while (row.Read())
                {
                    FNBox.Text = row[1].ToString();
                    LNBox.Text = row[2].ToString();
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = "yyyy/MM/dd";

                    string dateString = row[3].ToString();
                    DateTime dobDate;
                    if (DateTime.TryParse(dateString, out dobDate))
                    {
                        dateTimePicker.Value = dobDate;
                    }
                    if (row[4].ToString() == "Male")
                    {
                        maleradioButton.Checked = true;
                        femaleradioButton.Checked = false;
                    }
                    else
                    {
                        maleradioButton.Checked = false;
                        maleradioButton.Checked = true;
                    }
                    ADBox.Text = row[5].ToString();
                    EBox.Text = row[6].ToString();
                    MPBox.Text = row[7].ToString();
                    HPBox.Text = row[8].ToString();
                    PNBox.Text = row[9].ToString();
                    NICBox.Text = row[10].ToString();
                    CNOBox.Text = row[11].ToString();

                }
                con.Close();
                RegBtn.Enabled = false;
                UpdateBtn.Enabled = true;
                DeleteBtn.Enabled = true;
            }
            else
            {
                FNBox.Text = "";
                LNBox.Text = "";
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dateTimePicker.Text = thisDay.ToString();

                maleradioButton.Checked = true;
                femaleradioButton.Checked = false;

                ADBox.Text = "";
                EBox.Text = "";
                MPBox.Text = "";
                HPBox.Text = "";
                PNBox.Text = "";
                NICBox.Text = "";
                CNOBox.Text = "";
                RegNOBox.Enabled = true;
                UpdateBtn.Enabled = true;
                DeleteBtn.Enabled = true;
            }
        }

        private void Exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BackLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to back?", "Back Confirmation",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrastionForm registrastionForm = new RegistrastionForm();
            registrastionForm.Show();
        }
    }

           
            
      
}
