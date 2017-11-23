using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace Doctors
{
    public partial class LoginForm : Form
    {
        //Database conncetion string
        static string myConnectionString = ConfigurationManager.ConnectionStrings["Appdbconstring"].ConnectionString;
        //New connection 
        SqlConnection newCon = new SqlConnection(myConnectionString);
        //Login attempts variable
        int loginAttempts = 3;
        //Declare new timer for lockout functionality
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                newCon.Open(); //Open a connection
                MessageBox.Show("Connection Open", "Connection Open");
            }
            catch
            {
                MessageBox.Show("Cabbage Code");
            }
            newCon.Close(); //Close a connection
        }
        //Enable login button after lock out event handler
        void endoftimer(object sender, System.EventArgs e)
        {
            loginBTN.Enabled = true; //Enable login button
            timer.Stop(); //Stop timer
            loginBTN.BackColor = default(Color); //Reset back color to default
            loginAttempts = 3; //Reset login attempts
        }
        //Login button event handler
        private void loginBTN_Click(object sender, EventArgs e)
        {   //Variables holding textbox inputs
            string usernameInput = userTB.Text;
            string passwordInput = passTB.Text;
            try
            {   
                newCon.Open(); //Open a connection
                //Create sql command
                SqlCommand ValidateLogin = new SqlCommand("SELECT * fROM staff WHERE Username = @id COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @pass COLLATE SQL_Latin1_General_CP1_CS_AS", newCon);
                //Add parameters
                ValidateLogin.Parameters.Add(new SqlParameter("@id", usernameInput));
                ValidateLogin.Parameters.Add(new SqlParameter("@pass", passwordInput));
                //Read data
                SqlDataReader reader = ValidateLogin.ExecuteReader();
                //If reader finds data there must be a matching record in the database
                if (reader.Read())
                {
                    MessageBox.Show("Logged in", "Correct");
                    loginAttempts = 3; //Reset the amount of remaing login attempts
                    this.Hide(); //Hide this form
                    var mainform = new MainForm(); //New instance of main form
                    mainform.Show(); //Open main form
                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "Incorrect");
                    loginAttempts--; //Take one away from login attempts
                    //If failed to log in three times 
                    if (loginAttempts == 0)
                    {
                        MessageBox.Show("Too many failed log in attempts\nthe login button is now disabled for ten seconds", "Error");
                        timer.Interval = 10000; //Duration of timer in milliseconds
                        timer.Tick += endoftimer; //Attach event handler
                        timer.Start(); //Start timer
                        loginBTN.Enabled = false; //Disable login button
                        loginBTN.BackColor = Color.Red; // Color button red
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("An unknown error occured. Details: " + error, "Error");
            } 
            newCon.Close(); //Close database connection
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
