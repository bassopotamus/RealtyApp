using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealtyApp
{
    public partial class RealtyForm : Form
    {
        

        public RealtyForm()
        {
            InitializeComponent();

            CreateMenuFunctionality();

        }

        /*private void Form1_Load(object sender, EventArgs e)
        {
            
        }*/

        private void CreateMenuFunctionality()
        {
            Exit.Click += new System.EventHandler(this.Exit_Click);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtAddress1.Enabled = true;
            txtAddress2.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtZipCode.Enabled = true;
            txtStatus.Enabled = true;
            txtRegion.Enabled = true;
            rtbNotes.Enabled = true;
            btnEdit.Visible = false;
            btnCancel.Visible = true;
            btnSave.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAddress1.Enabled = false;
            txtAddress2.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtZipCode.Enabled = false;
            txtStatus.Enabled = false;
            txtRegion.Enabled = false;
            rtbNotes.Enabled = false;
            btnEdit.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtAddress1.Enabled = false;
            txtAddress2.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtZipCode.Enabled = false;
            txtStatus.Enabled = false;
            txtRegion.Enabled = false;
            rtbNotes.Enabled = false;
            btnEdit.Visible = true;
            btnCancel.Visible = false;
            btnSave.Visible = false;
        }

        private void RealtyForm_Load(object sender, EventArgs e)
        {
            livHouses.Items.Add("Name");
            livHouses.Items.Add("Words");
            livHouses.Items.Add("Name");
            livHouses.Items.Add("Words");

            
        }
    }
}
