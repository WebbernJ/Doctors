using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Doctors
{
    class Unavailable
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);
        DataTable dtDoctorAvalibility;
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
        
        public DataTable checkAvailabilityMethod(string selectedDate, string DoctorID)
        {
            newCon.Open();
            SqlCommand checkAvailability = new SqlCommand("SELECT Slot, Reason, Staff_Id FROM Unavailable WHERE Date=@date AND Staff_Id=@staffId", newCon);
            checkAvailability.Parameters.Add(new SqlParameter("@date", selectedDate));
            checkAvailability.Parameters.Add(new SqlParameter("@staffId", int.Parse(DoctorID)));
            SqlDataAdapter daBookings = new SqlDataAdapter(checkAvailability);
            //Populate the DataSet
            dtDoctorAvalibility = new DataTable();
            daBookings.Fill(dtDoctorAvalibility);
            newCon.Close();
            return dtDoctorAvalibility;
        }
    }
}
