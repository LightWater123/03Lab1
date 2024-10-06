using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OrganizationProfile.frmRegistration;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           Close();
         
        }

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName.Text = StudentInformationClass.SetFullName;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblBirthday.Text = StudentInformationClass.SetBirthDay;
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = "+63" + StudentInformationClass.SetContactNo.ToString();
            lblAge.Text = StudentInformationClass.SetAge.ToString();

            if(StudentInformationClass.SetContactNo.ToString().Length == 11)
            {
                lblContactNo.Text = "+63" + StudentInformationClass.SetContactNo.ToString().Substring(1);

            }
        }

        private void lblContactNo_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentNo_Click(object sender, EventArgs e)
        {

        }
    }
}
