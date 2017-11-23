using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;

namespace Doctors
{
    public partial class Existing : Form
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);

        public Existing()
        {
            InitializeComponent();
        }

        private void Existing_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SqlCommand getPatients = new SqlCommand("Select * from Patients", newCon);
            newCon.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = getPatients;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            newCon.Close();
        }   
    }
}
