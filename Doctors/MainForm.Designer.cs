namespace Doctors
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.patientGB = new System.Windows.Forms.GroupBox();
            this.ClearTB = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.postcodeTB = new System.Windows.Forms.TextBox();
            this.postcodeLBL = new System.Windows.Forms.Label();
            this.countyTB = new System.Windows.Forms.TextBox();
            this.countyLBL = new System.Windows.Forms.Label();
            this.townTB = new System.Windows.Forms.TextBox();
            this.townLBL = new System.Windows.Forms.Label();
            this.addressTB = new System.Windows.Forms.TextBox();
            this.regBTN = new System.Windows.Forms.Button();
            this.telTB = new System.Windows.Forms.TextBox();
            this.telLBL = new System.Windows.Forms.Label();
            this.addressLBL = new System.Windows.Forms.Label();
            this.ageTB = new System.Windows.Forms.TextBox();
            this.ageLBL = new System.Windows.Forms.Label();
            this.lnameLBL = new System.Windows.Forms.Label();
            this.fnameLBL = new System.Windows.Forms.Label();
            this.LnameTB = new System.Windows.Forms.TextBox();
            this.fnameTB = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DoctorLBL = new System.Windows.Forms.Label();
            this.doctorCombo = new System.Windows.Forms.ComboBox();
            this.createAppBTN = new System.Windows.Forms.Button();
            this.doctorGB = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reasonCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.patientGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.doctorGB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // patientGB
            // 
            this.patientGB.Controls.Add(this.ClearTB);
            this.patientGB.Controls.Add(this.Save);
            this.patientGB.Controls.Add(this.postcodeTB);
            this.patientGB.Controls.Add(this.postcodeLBL);
            this.patientGB.Controls.Add(this.countyTB);
            this.patientGB.Controls.Add(this.countyLBL);
            this.patientGB.Controls.Add(this.townTB);
            this.patientGB.Controls.Add(this.townLBL);
            this.patientGB.Controls.Add(this.addressTB);
            this.patientGB.Controls.Add(this.regBTN);
            this.patientGB.Controls.Add(this.telTB);
            this.patientGB.Controls.Add(this.telLBL);
            this.patientGB.Controls.Add(this.addressLBL);
            this.patientGB.Controls.Add(this.ageTB);
            this.patientGB.Controls.Add(this.ageLBL);
            this.patientGB.Controls.Add(this.lnameLBL);
            this.patientGB.Controls.Add(this.fnameLBL);
            this.patientGB.Controls.Add(this.LnameTB);
            this.patientGB.Controls.Add(this.fnameTB);
            this.patientGB.Location = new System.Drawing.Point(12, 12);
            this.patientGB.Name = "patientGB";
            this.patientGB.Size = new System.Drawing.Size(308, 301);
            this.patientGB.TabIndex = 1;
            this.patientGB.TabStop = false;
            this.patientGB.Text = "Patient Details";
            // 
            // ClearTB
            // 
            this.ClearTB.Location = new System.Drawing.Point(188, 239);
            this.ClearTB.Name = "ClearTB";
            this.ClearTB.Size = new System.Drawing.Size(107, 23);
            this.ClearTB.TabIndex = 19;
            this.ClearTB.Text = "Clear";
            this.ClearTB.UseVisualStyleBackColor = true;
            this.ClearTB.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(9, 268);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(107, 23);
            this.Save.TabIndex = 18;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // postcodeTB
            // 
            this.postcodeTB.Location = new System.Drawing.Point(85, 176);
            this.postcodeTB.Name = "postcodeTB";
            this.postcodeTB.Size = new System.Drawing.Size(106, 20);
            this.postcodeTB.TabIndex = 17;
            // 
            // postcodeLBL
            // 
            this.postcodeLBL.AutoSize = true;
            this.postcodeLBL.Location = new System.Drawing.Point(6, 183);
            this.postcodeLBL.Name = "postcodeLBL";
            this.postcodeLBL.Size = new System.Drawing.Size(52, 13);
            this.postcodeLBL.TabIndex = 16;
            this.postcodeLBL.Text = "Postcode";
            // 
            // countyTB
            // 
            this.countyTB.Location = new System.Drawing.Point(85, 150);
            this.countyTB.Name = "countyTB";
            this.countyTB.Size = new System.Drawing.Size(210, 20);
            this.countyTB.TabIndex = 15;
            // 
            // countyLBL
            // 
            this.countyLBL.AutoSize = true;
            this.countyLBL.Location = new System.Drawing.Point(6, 157);
            this.countyLBL.Name = "countyLBL";
            this.countyLBL.Size = new System.Drawing.Size(40, 13);
            this.countyLBL.TabIndex = 14;
            this.countyLBL.Text = "County";
            // 
            // townTB
            // 
            this.townTB.Location = new System.Drawing.Point(85, 124);
            this.townTB.Name = "townTB";
            this.townTB.Size = new System.Drawing.Size(210, 20);
            this.townTB.TabIndex = 13;
            // 
            // townLBL
            // 
            this.townLBL.AutoSize = true;
            this.townLBL.Location = new System.Drawing.Point(6, 131);
            this.townLBL.Name = "townLBL";
            this.townLBL.Size = new System.Drawing.Size(59, 13);
            this.townLBL.TabIndex = 12;
            this.townLBL.Text = "Town/ City";
            // 
            // addressTB
            // 
            this.addressTB.Location = new System.Drawing.Point(85, 98);
            this.addressTB.Name = "addressTB";
            this.addressTB.Size = new System.Drawing.Size(210, 20);
            this.addressTB.TabIndex = 11;
            // 
            // regBTN
            // 
            this.regBTN.Location = new System.Drawing.Point(9, 239);
            this.regBTN.Name = "regBTN";
            this.regBTN.Size = new System.Drawing.Size(107, 23);
            this.regBTN.TabIndex = 10;
            this.regBTN.Text = "Register";
            this.regBTN.UseVisualStyleBackColor = true;
            this.regBTN.Click += new System.EventHandler(this.regBTN_Click);
            // 
            // telTB
            // 
            this.telTB.Location = new System.Drawing.Point(85, 202);
            this.telTB.Name = "telTB";
            this.telTB.Size = new System.Drawing.Size(106, 20);
            this.telTB.TabIndex = 9;
            // 
            // telLBL
            // 
            this.telLBL.AutoSize = true;
            this.telLBL.Location = new System.Drawing.Point(6, 209);
            this.telLBL.Name = "telLBL";
            this.telLBL.Size = new System.Drawing.Size(39, 13);
            this.telLBL.TabIndex = 8;
            this.telLBL.Text = "Tel No";
            // 
            // addressLBL
            // 
            this.addressLBL.AutoSize = true;
            this.addressLBL.Location = new System.Drawing.Point(6, 105);
            this.addressLBL.Name = "addressLBL";
            this.addressLBL.Size = new System.Drawing.Size(45, 13);
            this.addressLBL.TabIndex = 7;
            this.addressLBL.Text = "Address";
            // 
            // ageTB
            // 
            this.ageTB.Location = new System.Drawing.Point(85, 72);
            this.ageTB.Name = "ageTB";
            this.ageTB.Size = new System.Drawing.Size(42, 20);
            this.ageTB.TabIndex = 5;
            // 
            // ageLBL
            // 
            this.ageLBL.AutoSize = true;
            this.ageLBL.Location = new System.Drawing.Point(6, 79);
            this.ageLBL.Name = "ageLBL";
            this.ageLBL.Size = new System.Drawing.Size(26, 13);
            this.ageLBL.TabIndex = 4;
            this.ageLBL.Text = "Age";
            // 
            // lnameLBL
            // 
            this.lnameLBL.AutoSize = true;
            this.lnameLBL.Location = new System.Drawing.Point(6, 53);
            this.lnameLBL.Name = "lnameLBL";
            this.lnameLBL.Size = new System.Drawing.Size(49, 13);
            this.lnameLBL.TabIndex = 3;
            this.lnameLBL.Text = "Surname";
            // 
            // fnameLBL
            // 
            this.fnameLBL.AutoSize = true;
            this.fnameLBL.Location = new System.Drawing.Point(6, 27);
            this.fnameLBL.Name = "fnameLBL";
            this.fnameLBL.Size = new System.Drawing.Size(57, 13);
            this.fnameLBL.TabIndex = 2;
            this.fnameLBL.Text = "First Name";
            // 
            // LnameTB
            // 
            this.LnameTB.Location = new System.Drawing.Point(85, 46);
            this.LnameTB.Name = "LnameTB";
            this.LnameTB.Size = new System.Drawing.Size(210, 20);
            this.LnameTB.TabIndex = 1;
            // 
            // fnameTB
            // 
            this.fnameTB.Location = new System.Drawing.Point(85, 20);
            this.fnameTB.Name = "fnameTB";
            this.fnameTB.Size = new System.Drawing.Size(210, 20);
            this.fnameTB.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 407);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1036, 404);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 49);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(795, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 389);
            this.panel1.TabIndex = 4;
            // 
            // DoctorLBL
            // 
            this.DoctorLBL.AutoSize = true;
            this.DoctorLBL.Location = new System.Drawing.Point(9, 27);
            this.DoctorLBL.Name = "DoctorLBL";
            this.DoctorLBL.Size = new System.Drawing.Size(81, 13);
            this.DoctorLBL.TabIndex = 6;
            this.DoctorLBL.Text = "Choose Doctor:";
            // 
            // doctorCombo
            // 
            this.doctorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorCombo.FormattingEnabled = true;
            this.doctorCombo.Items.AddRange(new object[] {
            "Patel",
            "Jones"});
            this.doctorCombo.Location = new System.Drawing.Point(134, 20);
            this.doctorCombo.Name = "doctorCombo";
            this.doctorCombo.Size = new System.Drawing.Size(104, 21);
            this.doctorCombo.TabIndex = 0;
            this.doctorCombo.SelectedIndexChanged += new System.EventHandler(this.doctorCombo_SelectedIndexChanged);
            // 
            // createAppBTN
            // 
            this.createAppBTN.Location = new System.Drawing.Point(12, 223);
            this.createAppBTN.Name = "createAppBTN";
            this.createAppBTN.Size = new System.Drawing.Size(96, 35);
            this.createAppBTN.TabIndex = 5;
            this.createAppBTN.Text = "Create Appointment";
            this.createAppBTN.UseVisualStyleBackColor = true;
            this.createAppBTN.Click += new System.EventHandler(this.createAppBTN_Click);
            // 
            // doctorGB
            // 
            this.doctorGB.Controls.Add(this.button1);
            this.doctorGB.Controls.Add(this.label2);
            this.doctorGB.Controls.Add(this.label1);
            this.doctorGB.Controls.Add(this.reasonCombo);
            this.doctorGB.Location = new System.Drawing.Point(536, 288);
            this.doctorGB.Name = "doctorGB";
            this.doctorGB.Size = new System.Drawing.Size(246, 113);
            this.doctorGB.TabIndex = 7;
            this.doctorGB.TabStop = false;
            this.doctorGB.Text = "Doctor Availability";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Create Unavailability";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reson:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reson:";
            // 
            // reasonCombo
            // 
            this.reasonCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reasonCombo.FormattingEnabled = true;
            this.reasonCombo.Items.AddRange(new object[] {
            "Meeting",
            "Hospital Visit",
            "Home Visit",
            "Other"});
            this.reasonCombo.Location = new System.Drawing.Point(106, 24);
            this.reasonCombo.Name = "reasonCombo";
            this.reasonCombo.Size = new System.Drawing.Size(132, 21);
            this.reasonCombo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.createAppBTN);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.doctorCombo);
            this.groupBox1.Controls.Add(this.DoctorLBL);
            this.groupBox1.Location = new System.Drawing.Point(536, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 270);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointment Booking";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel Appointments";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 823);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.doctorGB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.patientGB);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.patientGB.ResumeLayout(false);
            this.patientGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.doctorGB.ResumeLayout(false);
            this.doctorGB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox patientGB;
        private System.Windows.Forms.TextBox telTB;
        private System.Windows.Forms.Label telLBL;
        private System.Windows.Forms.Label addressLBL;
        private System.Windows.Forms.TextBox ageTB;
        private System.Windows.Forms.Label ageLBL;
        private System.Windows.Forms.Label lnameLBL;
        private System.Windows.Forms.Label fnameLBL;
        private System.Windows.Forms.TextBox LnameTB;
        private System.Windows.Forms.TextBox fnameTB;
        private System.Windows.Forms.Button regBTN;
        private System.Windows.Forms.TextBox postcodeTB;
        private System.Windows.Forms.Label postcodeLBL;
        private System.Windows.Forms.TextBox countyTB;
        private System.Windows.Forms.Label countyLBL;
        private System.Windows.Forms.TextBox townTB;
        private System.Windows.Forms.Label townLBL;
        private System.Windows.Forms.TextBox addressTB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ClearTB;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button createAppBTN;
        private System.Windows.Forms.ComboBox doctorCombo;
        private System.Windows.Forms.Label DoctorLBL;
        private System.Windows.Forms.GroupBox doctorGB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reasonCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
    }
}