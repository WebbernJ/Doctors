using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Doctors
{
    class Unavailable
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);
        //Declare property variables
        private int m_staffID;
        private string m_date, m_slot, m_reason;

        public int staffID
        {
            get
            {
                return m_staffID;
            }
            set
            {
                m_staffID = value;
            }
        }

        public string date
        {
            get
            {
                return m_date;
            }
            set
            {
                m_date = value;
            }
        }

        public string slot
        {
            get
            {
                return m_slot;
            }
            set
            {
                m_slot = value;
            }
        }

        public string reason
        {
            get
            {
                return m_reason;
            }
            set
            {
                m_reason = value;
            }
        }
         public void addAvailability()
        {
            newCon.Open(); //Open a connection
            SqlCommand insertPatient = new SqlCommand("INSERT INTO Unavailable (Staff_Id, Date, Slot, Reason) VALUES(@staffID, @date, @slot, @reason)", newCon);
            insertPatient.Parameters.Add(new SqlParameter("@staffID", m_staffID));
            insertPatient.Parameters.Add(new SqlParameter("@date", m_date));
            insertPatient.Parameters.Add(new SqlParameter("@slot", m_slot));
            insertPatient.Parameters.Add(new SqlParameter("@reason", m_reason));
            insertPatient.ExecuteNonQuery();         
            newCon.Close();
        }        
    }
}
