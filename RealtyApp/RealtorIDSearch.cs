using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;

namespace RealtyApp
{
    public partial class RealtorIDSearch : Form
    {
        List<PropertyModel> propertyModelList = new List<PropertyModel>();

        public RealtorIDSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            string realtorID = txtRealtorID.Text;

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

            }
            this.Visible = false;

        }

        private void txtRealtorID_OnGotFocus(object sender, EventArgs e)
        {
            lblIDError.Visible = false;
        }
    }
}
