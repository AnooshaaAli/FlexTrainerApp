﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class trainer : Form
    {
        int trainerID;
        string uname;
        string dob;
        public trainer(int userid)
        {
            trainerID = userid;
            InitializeComponent();
        }

        private void trainer_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=10N5Q8AKAMRA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");//connection string 
            conn.Open();
            string dob;
            SqlCommand cm1, cm2;
            string query1 = "SELECT tName FROM Trainer WHERE trainerID ='" + this.trainerID + "'";
            cm1 = new SqlCommand(query1, conn);
            object result = cm1.ExecuteScalar();
            uname = result.ToString();
            cm1.Dispose();
            string query2 = "SELECT dob FROM Trainer WHERE trainerID ='" + this.trainerID + "'";
            cm2 = new SqlCommand(query2, conn);
            object result2 = cm2.ExecuteScalar();
            dob = result2.ToString();
            cm2.Dispose();
            label20.Text += ": " + uname;
            label19.Text += ": " + dob;
            conn.Close();
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void createworkoutplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trainer_Workout_Plan form = new Trainer_Workout_Plan();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void workoutplanreport_Click(object sender, EventArgs e)
        {
            Hide();
            using (report form = new report())
                form.ShowDialog();
            Show();
        }

        private void createdietplan_Click(object sender, EventArgs e)
        {
            this.Hide();
            dietplanTrainer form = new dietplanTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void dietplanreport_Click(object sender, EventArgs e)
        {
            Hide();
            using (report form = new report())
                form.ShowDialog();
            Show();
        }

        private void booktrainingsession_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainingSessionRequest form = new TrainingSessionRequest(trainerID);
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }

        private void givefeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FeedbackTrainer form = new FeedbackTrainer();
            form.Show();
            form.FormClosed += (s, argc) => this.Close();
        }
    }
}
