using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Doctors
{
    class Appointemts
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);
        //Declare property variables
        private int m_appointmentID, m_patientID, m_doctorID;
        private string m_date, m_timeSlot;

        public int appointmentID
        {
            get
            {
                return m_appointmentID;
            }
            set
            {
                m_appointmentID = value;
            }
        }

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

        public int doctorID
        {
            get
            {
                return m_doctorID;
            }
            set
            {
                m_doctorID = value;
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

        public string timeSlot
        {
            get
            {
                return m_timeSlot;
            }
            set
            {
                m_timeSlot = value;
            }
        }
      
        public void addAppointment()
        {
            newCon.Open(); //Open a connection
            SqlCommand insertAppointment= new SqlCommand("INSERT INTO Appointments (Date, Slot, Patient_Id, Doctor_ID) VALUES (@date, @timeSlot, @patientid, @doctorid)", newCon);
            insertAppointment.Parameters.Add(new SqlParameter("@date", m_date));
            insertAppointment.Parameters.Add(new SqlParameter("@timeSlot", m_timeSlot));
            insertAppointment.Parameters.Add(new SqlParameter("@patientid", m_patientID));
            insertAppointment.Parameters.Add(new SqlParameter("@doctorid", m_doctorID));
            insertAppointment.ExecuteNonQuery();
            insertAppointment.CommandText = "SELECT MAX(Appointment_Id) FROM Appointments";
            m_appointmentID = (int)insertAppointment.ExecuteScalar();
            newCon.Close();
        }

        //public void checkSlots()
        //{
        //    newCon.Open(); //Open a connection
        //    SqlCommand checkAvailability = new SqlCommand("SELECT Slot FROM Appointments WHERE Date=@date", newCon);
        //    checkAvailability.Parameters.Add(new SqlParameter("@date", selectedDate));
        //    checkAvailability.P
        //    SqlDataAdapter daBookings = new SqlDataAdapter(checkAvailability);
        //    //Populate the DataSet
        //    dtBookings = new DataTable();
        //    daBookings.Fill(dtBookings);
        //    newCon.Close();
        //}
    }
}
