﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifBotManager
{
    public partial class frmConnect : Form
    {
        DBConnection dbCon;
        public frmConnect() {
            InitializeComponent();
            dbCon = DBConnection.Instance();
            AutoPopulateFromFile();
        }
        private void btnConnect_Click(object sender, EventArgs e) {
            dbCon.DatabaseName = txtDatabase.Text.Trim();
            dbCon.Username = txtUsername.Text.Trim();
            dbCon.Password = txtPassword.Text.Trim();
            if (dbCon.IsConnect()) {
                Hide();
                frmDashboard frmDashboard = new frmDashboard();
                frmDashboard.Show();
                dbCon.Close();
            }
        }

        private void AutoPopulateFromFile() {
            string path = Directory.GetCurrentDirectory();
            try {
                string[] lines = System.IO.File.ReadAllLines(path + @"\config.coffee");
                txtDatabase.Text = lines[0].Trim();
                txtUsername.Text = lines[1].Trim();
                txtPassword.Text = lines[2].Trim();
            }
            catch (Exception e) {
                Console.WriteLine("Config file not found for autopopulating");
            }

            
        }

        private void btnSqlServerConnect_Click(object sender, EventArgs e) {
            string connectionString = null;
            SqlConnection cnn;
            connectionString = @"Data Source=localhost\GIFBOT;Initial Catalog=GIFBOT;integrated security=SSPI;Connection Timeout=2";
            cnn = new SqlConnection(connectionString);
            try {
                cnn.Open();
                cnn.Close();
                Hide();
                frmDashboard frmDashboard = new frmDashboard();
                frmDashboard.Show();                
            }
            catch (Exception ex) {
                MessageBox.Show("Can not open connection ! ");
            }
        }
    }
}
