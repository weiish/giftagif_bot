using GiftAGifBot.DAL;
using GiftAGifBot.DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            //var optionsBuilder = new DbContextOptionsBuilder<GifContext>();
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["GifModel"].ConnectionString);
            //using (var gifContext = new GifContext(optionsBuilder.Options)) {
            using (var gifContext = new GifModel()) {
                var user = new User { Id = new Guid(), Username = "Raene", Usertag = "4948"};
                gifContext.Users.Add(user); // Add user
                gifContext.SaveChanges(); // Save changes to DB
            }
        }

        private void btnAddGifs_Click(object sender, EventArgs e) {
            frmAddGifs frmAddGifs = new frmAddGifs();
            frmAddGifs.Show();
        }

        private void frmDashboard_Load(object sender, EventArgs e) {

        }

        private void frmDashboard_FormClosing(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
