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
        //New DataTable
        DataTable dtBookings;
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
            SqlCommand insertAppointment = new SqlCommand("INSERT INTO Appointments (Date, Slot, Patient_Id, Doctor_ID) " +
                                                            "VALUES (@date, @timeSlot, @patientid, @doctorid)", newCon);
            insertAppointment.Parameters.Add(new SqlParameter("@date", m_date));
            insertAppointment.Parameters.Add(new SqlParameter("@timeSlot", m_timeSlot));
            insertAppointment.Parameters.Add(new SqlParameter("@patientid", m_patientID));
            insertAppointment.Parameters.Add(new SqlParameter("@doctorid", m_doctorID));
            insertAppointment.ExecuteNonQuery();
            insertAppointment.CommandText = "SELECT MAX(Appointment_Id) FROM Appointments";
            m_appointmentID = (int)insertAppointment.ExecuteScalar();
            newCon.Close();
        }

        public DataTable checkSlots(string selectedDate, string selectedDoctor)
        {
            newCon.Open();
            SqlCommand getSlotName = new SqlCommand("SELECT Patients.First_Name, Patients.Last_Name, Appointments.Patient_Id, Appointments.Slot, Appointments.Doctor_Id FROM Appointments JOIN Patients ON Appointments.Patient_Id=Patients.Patient_Id WHERE Appointments.Date=@date AND Appointments.Doctor_Id=@doctor", newCon);
            getSlotName.Parameters.Add(new SqlParameter("@date", selectedDate));
            getSlotName.Parameters.Add(new SqlParameter("@doctor", int.Parse(selectedDoctor)));
            SqlDataAdapter daBookings = new SqlDataAdapter(getSlotName);
            //Populate the DataSet
            dtBookings = new DataTable();
            daBookings.Fill(dtBookings);
            newCon.Close();
            return dtBookings;
        }

        public void cancelAppointment(int appointmentID, int patientID)
        {
            newCon.Open(); //Open connection
            SqlCommand deleteAppointment = new SqlCommand("DELETE from Appointments WHERE Appointment_Id=@appointmentid AND Patient_Id=@patientid", newCon); //Sql command 
            deleteAppointment.Parameters.Add(new SqlParameter("@appointmentid", appointmentID));
            deleteAppointment.Parameters.Add(new SqlParameter("@patientid", patientID));
            deleteAppointment.ExecuteNonQuery();
            newCon.Close(); //Close connection
        }

        public DataTable getAllAppointments()
        {
            newCon.Open(); //Open connection 
            SqlCommand allAppointment = new SqlCommand("SELECT Appointments.Appointment_Id, Appointments.Patient_Id, Patients.First_Name, Patients.Last_Name, Appointments.Date, Appointments.Slot, Staff.Surname, Appointments.Doctor_Id From Appointments JOIN Patients ON Appointments.Patient_Id = Patients.Patient_Id JOIN Staff ON Appointments.Doctor_Id = Staff.Staff_Id", newCon); //Sql command 
            SqlDataAdapter daBookings = new SqlDataAdapter(allAppointment);
            //Populate the DataSet
            dtBookings = new DataTable();
            daBookings.Fill(dtBookings);
            newCon.Close();
            return dtBookings;
        }
    }
}
