using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Doctors
{
    public partial class MainForm : Form
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);
        int slotCount = 0;
        string selectedApointment;
        Patients patient;
        Appointemts appointemt;
        DataTable dtBookings;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
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
            Save.Enabled = false;
            createAppBTN.Enabled = false;            
            doctorCombo.SelectedIndex = 0;
            monthCalendar1.SelectionStart = DateTime.Today;
        }

        private void getBookings()
        {           
            string selectedDate = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
            int selectedDoctor = doctorCombo.SelectedIndex + 2;
            string DoctorID = selectedDoctor.ToString();
            //SqlCommand checkAvailability = new SqlCommand("SELECT Slot, Doctor_Id FROM Appointments WHERE Date=@date AND Doctor_Id=@doctor", newCon);
            //checkAvailability.Parameters.Add(new SqlParameter("@date", selectedDate));
            //checkAvailability.Parameters.Add(new SqlParameter("@doctor", selectedDoctor));
            //SqlDataAdapter daBookings = new SqlDataAdapter(checkAvailability);

            SqlCommand getSlotName = new SqlCommand("SELECT Patients.First_Name, Patients.Last_Name, Appointments.Patient_Id, Appointments.Slot, Appointments.Doctor_Id FROM Appointments JOIN Patients ON Appointments.Patient_Id=Patients.Patient_Id WHERE Appointments.Date=@date AND Appointments.Doctor_Id=@doctor", newCon);
            getSlotName.Parameters.Add(new SqlParameter("@date", selectedDate));
            getSlotName.Parameters.Add(new SqlParameter("@doctor", selectedDoctor));
            SqlDataAdapter daBookings = new SqlDataAdapter(getSlotName);

            //Populate the DataSet
            dtBookings = new DataTable();
            daBookings.Fill(dtBookings);
            newCon.Close();
            Panel panel = panel1;
            var panelControls = panel1.Controls;
            foreach (Control seat in panelControls)
            {
                foreach (DataRow row in dtBookings.Rows)
                {
                    //Check vlaue of data row on seat id column against the text of the tabs buttons
                    if (seat.Text == row["Slot"].ToString() && DoctorID == row["Doctor_Id"].ToString())
                    {
                        seat.BackColor = Color.Crimson; //Colour seat yellow
                        seat.Enabled = false; //Disable seat
                        seat.Text = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                    }
                }
            }
        }

        private void doctorAvalibility()
        {
            string selectedDate = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
            string selectedDoctor = doctorCombo.SelectedItem.ToString();
            int comboID = 0;
            if (doctorCombo.SelectedIndex == 0)
            {
                comboID = 2;
            }
            else if (doctorCombo.SelectedIndex == 1)
            {
                comboID = 3;
            }
            SqlCommand checkAvailability = new SqlCommand("SELECT Slot, Reason, Staff_Id FROM Unavailable WHERE Date=@date AND Staff_Id=@staffId" , newCon);
            checkAvailability.Parameters.Add(new SqlParameter("@date", selectedDate));
            checkAvailability.Parameters.Add(new SqlParameter("@staffId", comboID));
            SqlDataAdapter daBookings = new SqlDataAdapter(checkAvailability);
            //Populate the DataSet
            dtBookings = new DataTable();
            daBookings.Fill(dtBookings);
            newCon.Close();
            Panel panel = panel1;
            var panelControls = panel1.Controls;
            foreach (Control seat in panelControls)
            {
                foreach (DataRow row in dtBookings.Rows)
                {
                    //Check vlaue of data row on seat id column against the text of the tabs buttons
                    if (seat.Text == row["Slot"].ToString() && comboID.ToString() == row["Staff_Id"].ToString())
                    {
                        seat.Enabled = false; //Disable seat
                        seat.Text = row["Reason"].ToString();
                        if (row["Reason"].ToString() == "Hospital Visit")
                        {
                            seat.BackColor = Color.Red; //Colour seat Red
                        }
                        else if (row["Reason"].ToString() == "Home Visit")
                        {
                            seat.BackColor = Color.Blue; //Colour seat Blue
                        }
                        else if (row["Reason"].ToString() == "Meeting")
                        {
                            seat.BackColor = Color.Yellow; //Colour seat Yellow
                        }
                        else if (row["Reason"].ToString() == "Other")
                        {
                            seat.BackColor = Color.Green; //Colour seat Green
                        }  
                    }
                }
            }
        }

        private void slotButtonGenerator()
        {
            panel1.Controls.Clear();
            slotCount = 0;
            Button[] buttonArray = new Button[13]; //Declare array of buttons  
            string[] buttonText = new string[] {"9:30 - 10:00", "10:00 - 10:30", "10:30 - 11:00", "11:00 - 11:30", "11:30 - 12:00", "Lunch", "Lunch", "13:00 - 13:30", "13:30 - 14:00",
                                                "14:00 - 14:30", "14:30 - 15:00", "15:00 - 15:30", "15:30 - 16:00"};
            int horizotal = 0;
            int vertical = 10;
            for (int index = 0; index < buttonArray.Length;)
            {
                for (int textIndex = 0; textIndex < buttonText.Length; textIndex++)
                {
                    buttonArray[index] = new Button(); //New instrance of button every loop
                    buttonArray[index].Text = buttonText[textIndex]; //Button text
                    buttonArray[index].Size = new Size(232, 23);
                    buttonArray[index].Location = new Point(horizotal, vertical);
                    buttonArray[index].Click += seat_Click;
                    buttonArray[index].BackColor = default(Color);
                    if ((index + 1) % 15 == 0) horizotal = 0;
                    else vertical += 30;
                    panel1.Controls.Add(buttonArray[index]);
                    if (buttonArray[index].Text == "Lunch")
                    {
                        buttonArray[index].Enabled = false;
                        buttonArray[index].BackColor = Color.AliceBlue;
                    }
                    index++;
                }
            }
        }
      
        private void regBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(fnameTB.Text))
                {
                    MessageBox.Show("First name textbox empty", "Error");
                }
                else if (string.IsNullOrEmpty(LnameTB.Text))
                {
                    MessageBox.Show("Surname textbox empty", "Error");
                }
                else if (string.IsNullOrEmpty(ageTB.Text))
                {
                    MessageBox.Show("Age textbox empty", "Error");
                }
                else
                {
                    string fnameInput = fnameTB.Text, lnameInput = LnameTB.Text, addressInput = addressTB.Text, townInput = townTB.Text, countyInput = countyTB.Text, postcodeInput = postcodeTB.Text, telNoInput = telTB.Text;
                    int ageInput = int.Parse(ageTB.Text);
                    patient = new Patients(); //New instance of Patients class
                    patient.fName = fnameInput;
                    patient.lName = lnameInput;
                    patient.age = ageInput;
                    patient.address = addressInput;
                    patient.townCity = townInput;
                    patient.county = countyInput;
                    patient.postcode = postcodeInput;
                    patient.telNo = telNoInput;
                    patient.addPatient(); //Call add patient method
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    SqlCommand getPatients = new SqlCommand("Select * from Patients ORDER BY Patient_id DESC", newCon);
                    newCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = getPatients;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    newCon.Close();
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[0].Selected = true;
                    MessageBox.Show("Added correctly", "Correct");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error occured\n" + error,"Error");
            }
        }

        private void createAppBTN_Click(object sender, EventArgs e)
        {
            try
            {
                appointemt = new Appointemts();
                int patientID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                int doctorID = doctorCombo.SelectedIndex + 2;
                appointemt.date = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                appointemt.timeSlot = selectedApointment;
                appointemt.patientID = patientID;
                appointemt.doctorID = doctorID;
                appointemt.addAppointment();
                MessageBox.Show("Booking sucessful");
                createAppBTN.Enabled = false;
                Panel panel = panel1;
                var panelControls = panel1.Controls;
                dataGridView1.CurrentCell = null;
                foreach (Control seat in panelControls)
                {
                    if (seat.BackColor == Color.Yellow)
                    {
                        seat.BackColor = Color.Firebrick;
                        seat.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No paitent selected\nPlease select a patient", "Booking error");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            regBTN.Enabled = false;
            fnameTB.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            LnameTB.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ageTB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            addressTB.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            townTB.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            countyTB.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            postcodeTB.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            telTB.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            regBTN.Enabled = false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            foreach (Control control in patientGB.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                    dataGridView1.ClearSelection();
                    regBTN.Enabled = true;
                }
            }
        }

        private void seat_Click(object sender, EventArgs e)
        {
            Button chairBtn = (Button)sender; //Get the Button that was clicked
            //If the chair colour is already yellow
            if (chairBtn.BackColor == Color.Yellow)
            {
                MessageBox.Show(selectedApointment + " has been removed from the booking.",
                    "Seat removed", MessageBoxButtons.OK);
                chairBtn.BackColor = default(Color); //Return seat to default back colour
                selectedApointment = "";
                slotCount--;
            }
            else
            {                
                chairBtn.BackColor = Color.Yellow; //Colour button yellow 
                selectedApointment = chairBtn.Text;
                MessageBox.Show(selectedApointment);
                slotCount++;
            }

            foreach (Button btn in panel1.Controls)
            {
                if (chairBtn.BackColor == Color.Yellow)
                {
                    btn.Enabled = false;
                    chairBtn.Enabled = true;
                    createAppBTN.Enabled = true;
                }
                else
                {
                    btn.Enabled = true;
                    createAppBTN.Enabled = false;
                }                
            }           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            slotButtonGenerator();
            getBookings();
            doctorAvalibility();
        }

        private void doctorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            slotButtonGenerator();
            getBookings();
            doctorAvalibility();
        }       

        private void resetForm()
        {
            foreach (Control control in patientGB.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                    dataGridView1.ClearSelection();
                    regBTN.Enabled = true;
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.CurrentCell = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Unavailable unavailable = new Unavailable();
                int staffID = doctorCombo.SelectedIndex + 2;
                string reason = reasonCombo.SelectedItem.ToString();
                unavailable.staffID = staffID;
                unavailable.date = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                unavailable.slot = selectedApointment;
                unavailable.reason = reason;
                unavailable.addAvailability();
                MessageBox.Show("Booking sucessful");
                var panelControls = panel1.Controls;
                foreach (Control seat in panelControls)
                {
                    if (seat.BackColor == Color.Yellow)
                    {
                        seat.BackColor = Color.MediumTurquoise;
                        seat.Enabled = false;
                        seat.Text = reason;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
        }
    }
}
