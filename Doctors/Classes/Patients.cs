using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Doctors
{
    class Patients
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);
        //Declare property variables
        private int m_patientID;
        private string m_fName, m_LName, m_address, m_townCity, m_county, m_postcode, m_telNo;
        private int m_age;

        public int patientID
        {
            get
            {
                return m_patientID;
            }
            set
            {
                m_patientID = value;
            }
        }

        public string fName
        {
            get
            {
                return m_fName;
            }
            set
            {
                m_fName = value;
            }
        }
        
        public string lName
        {
            get
            {
                return m_LName;
            }
            set
            {
                m_LName = value;
            }
        }

        public int age
        {
            get
            {
                return m_age;
            }
            set
            {
                m_age = value;
            }
        }

        public string address
        {
            get
            {
                return m_address;
            }
            set
            {
                m_address = value;
            }
        }

        public string townCity
        {
            get
            {
                return m_townCity;
            }
            set
            {
                m_townCity = value;
            }
        }

        public string county
        {
            get
            {
                return m_county;
            }
            set
            {
                m_county = value;
            }
        }

        public string postcode
        {
            get
            {
                return m_postcode;
            }
            set
            {
                m_postcode = value;
            }
        }

        public string telNo
        {
            get
            {
                return m_telNo;
            }
            set
            {
                m_telNo = value;
            }
        }

        public void addPatient()
        {
            newCon.Open(); //Open a connection
            SqlCommand insertPatient = new SqlCommand("INSERT INTO Patients (First_Name, Last_Name, Age, Address, TownCity, County, Postcode, Tel) " +
                "                                       VALUES(@fname, @lname, @age, @address, @townCity, @county, @postcode, @tel)", newCon);
            insertPatient.Parameters.Add(new SqlParameter("@fname", m_fName));
            insertPatient.Parameters.Add(new SqlParameter("@lname", m_LName));
            insertPatient.Parameters.Add(new SqlParameter("@age", m_age));
            insertPatient.Parameters.Add(new SqlParameter("@address", m_address));
            insertPatient.Parameters.Add(new SqlParameter("@townCity", m_townCity));
            insertPatient.Parameters.Add(new SqlParameter("@county", m_county));
            insertPatient.Parameters.Add(new SqlParameter("@postcode", m_postcode));
            insertPatient.Parameters.Add(new SqlParameter("@tel", m_telNo));
            insertPatient.ExecuteNonQuery();
            insertPatient.CommandText = "SELECT MAX(Patient_Id) FROM Patients";
            m_patientID = (int)insertPatient.ExecuteScalar();
            newCon.Close();
        }

        public DataTable getAllPatients()
        {
            newCon.Open();
            SqlCommand getPatients = new SqlCommand("Select * from Patients", newCon); // Sql command: get all records from the patients table 
            SqlDataAdapter daGetPatients = new SqlDataAdapter(getPatients); // Fill data adapter with results from query
            //Populate the DataSet
            DataTable dtAllPatients = new DataTable(); //New datatabke
            daGetPatients.Fill(dtAllPatients); //Fill datatable 
            newCon.Close();
            return dtAllPatients;
        }
    }
}
