using System;
using System.ComponentModel;
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
        bool isCanceling = false;
      
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Patients allPatients = new Patients();
            DataTable dtAllPatients = allPatients.getAllPatients(); 
            dataGridView1.DataSource = dtAllPatients;
            Save.Enabled = false;
            createAppBTN.Enabled = false;            
            doctorCombo.SelectedIndex = 0;
            monthCalendar1.SelectionStart = DateTime.Today;
            dataGridView1.CurrentCell = null;
        }

        //****Methods****
        //Get bookings method selects all patient bookings for a given date and doctor
        private void getBookings()
        {
            string selectedDate = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
            int selectedDoctor = doctorCombo.SelectedIndex + 2;
            Appointemts checkBookings = new Appointemts();
            DataTable dtBookings = checkBookings.checkSlots(selectedDate, selectedDoctor.ToString());
            Panel panel = panel1;
            var panelControls = panel1.Controls;
            foreach (Control seat in panelControls)
            {
                foreach (DataRow row in dtBookings.Rows)
                {
                    //Check vlaue of data row on seat id column against the text of the tabs buttons
                    if (seat.Text == row["Slot"].ToString() && selectedDoctor.ToString() == row["Doctor_Id"].ToString())
                    {
                        seat.BackColor = Color.LightSlateGray; //Colour seat yellow
                        seat.Enabled = false; //Disable seat
                        seat.Text = row["First_Name"].ToString() + " " + row["Last_Name"].ToString();
                    }
                }
            }
        }
        //Doctor avalibility selects all records for a given date and doctor
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
            Unavailable unavailable = new Unavailable();
            DataTable dtDoctorAvalibility = unavailable.checkAvailabilityMethod(selectedDate, comboID.ToString());
            Panel panel = panel1;
            var panelControls = panel1.Controls;
            foreach (Control seat in panelControls)
            {
                foreach (DataRow row in dtDoctorAvalibility.Rows)
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
                            seat.BackColor = Color.LightBlue; //Colour seat Blue
                        }
                        else if (row["Reason"].ToString() == "Meeting")
                        {
                            seat.BackColor = Color.LightYellow; //Colour seat Yellow
                        }
                        else if (row["Reason"].ToString() == "Other")
                        {
                            seat.BackColor = Color.LightGreen; //Colour seat Green
                        }
                    }
                }
            }
        }
        //Genertaes buttons for booking time slots
        private void slotButtonGenerator()
        {
            panel1.Controls.Clear();
            slotCount = 0;
            Button[] buttonArray = new Button[13]; //Declare array of buttons  
            string[] buttonText = new string[] {"9:30 - 10:00", "10:00 - 10:30", "10:30 - 11:00", "11:00 - 11:30", "11:30 - 12:00", "Lunch", "Lunch", "13:00 - 13:30", "13:30 - 14:00",
                                                "14:00 - 14:30", "14:30 - 15:00", "15:00 - 15:30", "15:30 - 16:00"};
            int horizotal = 0;
            int vertical = 0;
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
        //Resets textboxes and datagridview on form
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

        //****Event Handlers****
        //Register patient button 
        private void regBTN_Click(object sender, EventArgs e)
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
                Patients allPatients = new Patients();
                DataTable dtAllPatients = allPatients.getAllPatients();
                dataGridView1.DataSource = dtAllPatients;
                newCon.Close();
                dataGridView1.ClearSelection();
                dataGridView1.Sort(dataGridView1.Columns["Patient_Id"], ListSortDirection.Descending);
                dataGridView1.Rows[0].Selected = true;
                MessageBox.Show("Added correctly", "Correct");
            }
        }
        //Add appointment button
        private void createAppBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (isCanceling == false)
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
                    getBookings();
                }
                else
                {
                    dataGridView1.DataSource = null; //Empty datagrid view 
                    Patients allPatients = new Patients();
                    DataTable dtAllPatients = allPatients.getAllPatients();
                    dataGridView1.DataSource = dtAllPatients;
                    dataGridView1.CurrentCell = null;
                    button2.Enabled = true;
                    isCanceling = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No paitent selected\nPlease select a patient", "Booking error");
            }
        }
        //Clear button
        private void Clear_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            resetForm();
        }
        //Create unavailibility button
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
                doctorAvalibility();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }
        //Cancel appointments button 
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; //Empty datagrid view 
            Appointemts allAppointments = new Appointemts();
            DataTable dtAppointments = allAppointments.getAllAppointments(); //Call get all appointments from appointments class
            dataGridView1.DataSource = dtAppointments; //Fill datagrid with datatable
            dataGridView1.CurrentCell = null;
            button2.Enabled = false;
            createAppBTN.Enabled = true;
            isCanceling = true;
        }
        //Datagridview call click
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isCanceling == true)
            {
                int appointmentID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                int patientID = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                DialogResult result = MessageBox.Show("Are you sure you want cancel this appointment?", "Cancel Appointment" ,MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Appointemts appointemt = new Appointemts();
                    appointemt.cancelAppointment(appointmentID, patientID);
                    MessageBox.Show("Appointment Canceled", "Cancel Appointment");
                    DialogResult results = MessageBox.Show("Appointment Canceled. Would you like to\ncancel another?", "Cancel Appointment", MessageBoxButtons.YesNo);
                    if (results == DialogResult.Yes)
                    {
                        Appointemts allAppointments = new Appointemts();
                        DataTable dtAppointments = allAppointments.getAllAppointments();
                        dataGridView1.DataSource = dtAppointments; //Fill datagrid with datatable
                        dataGridView1.CurrentCell = null;
                    }
                    else
                    {
                        dataGridView1.DataSource = null; //Empty datagrid view 
                        Patients allPatients = new Patients();
                        DataTable dtAllPatients = allPatients.getAllPatients();
                        dataGridView1.DataSource = dtAllPatients;
                        dataGridView1.CurrentCell = null;
                        button2.Enabled = true;
                        isCanceling = false;
                    }
                } 
            }
            else
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
            //int i = 1;
            //regBTN.Enabled = false;
            //foreach (var cell in dataGridView1.SelectedRows)
            //{
            //    foreach (Control textbox in patientGB.Controls)
            //    {
            //        if (textbox is TextBox)
            //        {
            //            string currentValue = dataGridView1.CurrentRow.Cells[i].Value.ToString();
            //            textbox.Text = currentValue;
            //            i++;
            //        }
            //    }
            //}
        }
        //Datagridview when binding complete 
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }       
        //Slot button click 
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
                createAppBTN.Enabled = false;
                slotCount--;
            }
            else
            {                
                chairBtn.BackColor = Color.Yellow; //Colour button yellow 
                selectedApointment = chairBtn.Text;
                MessageBox.Show(selectedApointment);
                createAppBTN.Enabled = true;
                slotCount++;
            }

            //foreach (Button btn in panel1.Controls)
            //{
            //    if (chairBtn.BackColor == Color.Yellow)
            //    {
            //        btn.Enabled = false;
            //        chairBtn.Enabled = true;
            //        createAppBTN.Enabled = true;
            //    }
            //    else
            //    {
            //        btn.Enabled = true;
            //        createAppBTN.Enabled = false;
            //    }                
            //}           
        }
        //Month calendar date click
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            slotButtonGenerator();
            getBookings();
            doctorAvalibility();
        }
        //Doctors combo box 
        private void doctorCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            slotButtonGenerator();
            getBookings();
            doctorAvalibility();
        }
    }
}
