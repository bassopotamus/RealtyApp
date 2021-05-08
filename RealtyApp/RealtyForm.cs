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
using System.Data.OleDb;
using Microsoft.Data.SqlClient;

namespace RealtyApp
{
    public partial class RealtyForm : Form
    {

        List<PropertyModel> propertyModelList = new List<PropertyModel>();

        public RealtyForm()
        {
            InitializeComponent();

            CreateMenuFunctionality();
                        
        }

        private void CreateMenuFunctionality()
        {
            Exit.Click += new System.EventHandler(this.Exit_Click);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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
            livHouses.View = View.Details;
            livHouses.Columns.Add("Address", 150);
            livHouses.Columns.Add("Address 2", 100);
            livHouses.Columns.Add("City", 110);
            livHouses.Columns.Add("State", 50);
            livHouses.Columns.Add("Zip", 70);

        }

        private void txtSearch_OnGotFocus(object sender, EventArgs e)
        {
            lblIDError.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string realtorID = txtSearch.Text;

            propertyModelList.Clear();

            string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dusti\source\repos\RealtyApp\RealtyApp\Realty.mdf;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);

            try
            {
                connect.Open();
            }
            catch
            {
                String[] noDBConnection = new string[0];
                //MessageBox.Show("Failure");
            }

            //Check if RealtorID exists
            string queryStringAgentNumber = $"SELECT RealtorId FROM dbo.Realtors WHERE RealtorId = '{realtorID}'";
            SqlCommand commandStringAgentNumber = new SqlCommand(queryStringAgentNumber, connect);
            SqlDataReader dataReaderAgentNumber = commandStringAgentNumber.ExecuteReader();

            if (dataReaderAgentNumber.HasRows == false)
            {
                lblIDError.Visible = true;
                livHouses.Items.Clear();
            }
            else
            {
                dataReaderAgentNumber.Close();

                //Execute query to obtain properties related to RealtorID
                string queryString = $"SELECT * FROM dbo.Property WHERE RealtorID = '{realtorID}'";
                SqlCommand commandString = new SqlCommand(queryString, connect);
                SqlDataReader dataReader = commandString.ExecuteReader();

                while (dataReader.Read())
                {
                    string setAddress2;
                    string setNotes;

                    if (dataReader.IsDBNull(2))
                    {
                        setAddress2 = String.Empty;
                    }
                    else
                    {
                        setAddress2 = dataReader.GetString(2);
                    }

                    if (dataReader.IsDBNull(8))
                    {
                        setNotes = String.Empty;
                    }
                    else
                    {
                        setNotes = dataReader.GetString(8);
                    }

                    PropertyModel nextPropertyModel = new PropertyModel
                    {
                        propID = dataReader.GetInt32(0),
                        address1 = dataReader.GetString(1),
                        address2 = setAddress2,
                        city = dataReader.GetString(3),
                        state = dataReader.GetString(4),
                        zip = dataReader.GetString(5),
                        status = dataReader.GetString(6),
                        region = dataReader.GetString(7),
                        notes = setNotes
                    };

                    propertyModelList.Add(nextPropertyModel);
                   

                }
                populatePropertyListView(propertyModelList);

            }
        }

        private void populatePropertyListView(List<PropertyModel> propertyList)
        {
            livHouses.Items.Clear();

            foreach (var house in propertyList)
            {
                ListViewItem addItem;
                string[] itemArray = new string[6];

                itemArray[0] = house.address1;
                itemArray[1] = house.address2;
                itemArray[2] = house.city;
                itemArray[3] = house.state;
                itemArray[4] = house.zip;
                itemArray[5] = house.propID.ToString();

                addItem = new ListViewItem(itemArray);

                livHouses.Items.Add(addItem);
            }

        }

        private void livHouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (livHouses.SelectedIndices.Count > 0){
                int propIndex = Convert.ToInt32(livHouses.SelectedIndices[0]);
                ChangeFullInfo(propIndex);

            }

        }

        private void ChangeFullInfo(int propertyID)
        {
            txtAddress1.Text = propertyModelList[propertyID].address1;
            txtAddress2.Text = propertyModelList[propertyID].address2;
            txtCity.Text = propertyModelList[propertyID].city;
            txtState.Text = propertyModelList[propertyID].state;
            txtZipCode.Text = propertyModelList[propertyID].zip;
            txtStatus.Text = propertyModelList[propertyID].status;
            txtRegion.Text = propertyModelList[propertyID].region;
            rtbNotes.Text = propertyModelList[propertyID].notes;

        }
    }
}
