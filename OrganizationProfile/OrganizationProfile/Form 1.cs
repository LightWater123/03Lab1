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

    public class StudentInformationClass
    {
        public static long SetStudentNo = 0;
        public static long SetContactNo = 0;
        public static int SetAge = 0;
        public static string SetProgram = " ";
        public static string SetGender = " ";
        public static string SetBirthDay = " ";
        public static string SetFullName = " ";
    }
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        private bool isError = false;


        public long StudentNumber(string studNum)
        {
            try
            {
                isError = true;
                if (Regex.IsMatch(studNum, @"^[0-9]+$"))
                {
                    _StudentNo = long.Parse(studNum);
                    isError = true;
                }
                else if (string.IsNullOrWhiteSpace(txtStudentNo.Text))
                {
                    throw new FormatException("Student number cannot be empty.");
                }
                else
                {
                    throw new FormatException("Invalid student number format. Only numeric characters are allowed");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Student number error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Full name field error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                     
            
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            isError = true;
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                    isError = false;
                }
                else if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    throw new FormatException("Contact number cannot be empty.");
                }
                else
                {
                    throw new FormatException("Only numeric characters are allowed.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Contact number error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
                
            
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                isError = true;
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") && Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                    isError = false;
                }
                else if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtMiddleInitial.Text))
                {

                    throw new InvalidFullNameException("Name fields cannot be empty.");
                }
                else
                {

                    throw new FormatException("Names can only contain alphabetic characters.");
                }
            }
            catch (InvalidFullNameException ex)
            {
                MessageBox.Show(ex.Message, "Full name error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Full name error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uknown Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                   
            
            return _FullName;
        }

        public int Age(string age)
        {
            isError = true;
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                    isError = false;
                }
                else if (string.IsNullOrWhiteSpace(txtAge.Text))
                {
                    throw new FormatException("Age cannot be empty");
                }
                else
                {
                    throw new FormatException("Only enter numeric characters.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Age Field Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            
                                    
            return _Age;
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

            // Using the provided methods
            StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirtday.Value.ToString("yyyy-MM-dd");

            // Show confirmation form
            if(!isError)
            {
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
                // clear method
                Clear();
            }
            

            /*try
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
                
            }*/

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

            cbPrograms.SelectedIndex = 0;
            cbGender.SelectedIndex = 0;
        }


        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
    


        }

        // CUSTOM EXCEPTIONS
        public class InvalidFullNameException : Exception
        {
            public InvalidFullNameException(string message) : base(message)
            {
            }
        }
    }
}
