using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifBotManager
{
    public partial class frmDashboard : Form
    {
        DBConnection dbCon;
        public frmDashboard() {
            InitializeComponent();

            dbCon = DBConnection.Instance();
            this.label1.Text = "Welcome, you are connected to " + dbCon.DatabaseName;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (dbCon.IsConnect()) {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM users";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Console.Write(reader["userId"] + " ");
                    Console.Write(reader["username"] + " ");
                    Console.Write(reader["usertag"] + " ");
                    Console.WriteLine(reader["points"]);
                }
                dbCon.Close();
            }            
        }

    }
}
