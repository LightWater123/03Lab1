using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;


namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;

        public long StudentNumber(string studNum)
        {
            try
            {
                if(Regex.IsMatch(studNum, @"^[0-9]{11,12}$"))
                {
                    _StudentNo = long.Parse(studNum);
                }
            }catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Please enter a number.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{11,12}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Please enter a number.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName +", "+ MiddleInitial;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Please enter a letter.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Please enter a number.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }                        
            return _Age;
        }

        public class StudentInformationClass
        {
            public static int SetStudentNo = 0;
            public static int SetContactNo = 0;
            public static int SetAge = 0;
            public static string SetProgram = " ";
            public static string SetGender = " ";
            public static string SetBirthDay = " ";
            public static string SetFullName = " ";
        }
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // if the fields are all left empty
            
            if (string.IsNullOrWhiteSpace(txtStudentNo.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtMiddleInitial.Text) ||
                string.IsNullOrWhiteSpace(txtContactNo.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                cbPrograms.SelectedIndex == -1 ||
                cbGender.SelectedIndex == -1)
            {
                
                MessageBox.Show("Please fill in the details", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            // Using the provided methods
            StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = (int) StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = (int)ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirtday.Value.ToString("yyyy-MM-dd");

            // Show confirmation form
            frmConfirmation frm = new frmConfirmation();
            frm.ShowDialog();

            try
            {
                StudentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNo.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Student Number format: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Student Number cannot be empty: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Value too large: " + ex.Message);
            }
            finally
            {
                // clear method
                Clear();
            }

        }

        public void Clear()
        {
            txtStudentNo.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleInitial.Text = "";
            txtAge.Text = "";
            txtContactNo.Text = "";
            cbPrograms.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            datePickerBirtday.Value = DateTime.Now;

        }
        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
     {
        "BS Information Technology",
        "BS Computer Science",
        "BS Information Systems",
        "BS in Accountancy",
        "BS in Hospitality Management",
        "BS in Tourism Management"
     };
            for (int i = 0; i < ListOfProgram.Length; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i]);
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
    


        }
    }
}
