using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2_AccessDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AccessDatabase()
        {
            String ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\athen\\Desktop\\FarmInfo.accdb;
                            Persist Security Info = False";
            String error_Msg = "Error! No data found.";
            String q = Input.Text;
            String query = "Select * from " + q + ";"; // will hold the query
            OleDbConnection conn = null; // declaring variable connection 

            try
            {
                conn = new OleDbConnection(ConnStr); //create object - connection string 
                conn.Open(); // starts the actual connection
                OleDbCommand cmd = new OleDbCommand(query, conn)
                {
                    Connection = conn,
                    CommandText = query
                };

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                DataGrid.DataSource = dataTable;

                conn.Close(); //close connection
            }
            catch (Exception)
            {
                MessageBox.Show(error_Msg); //will display error message if query is invalid
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            AccessDatabase();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Input.Clear();
            this.DataGrid.DataSource = null;
            this.DataGrid.Rows.Clear();
        }
    }
}