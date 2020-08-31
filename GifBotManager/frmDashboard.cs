using GiftAGifBot.DAL;
using GiftAGifBot.DAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            using (var gifContext = new GifContext()) {
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

        private async void btnQuickAdd_Click(object sender, EventArgs e) {
            CancellationTokenSource cts = new CancellationTokenSource();
            Progress<BaseProgressReportModel> progress = new Progress<BaseProgressReportModel>();
            frmProgressBarPopUp frmProgress = new frmProgressBarPopUp(progress, cts);           
            frmProgress.Show();
            try {
                await QuickAddAsync(progress, cts.Token);
            } catch (OperationCanceledException) {
                
            }
            
        }

        private async Task QuickAddAsync(IProgress<BaseProgressReportModel> progress, CancellationToken cancellationToken) {
            int completed = 0;
            int numNewGifs = 0;
            int totalGifs = 0;
            progress.Report(new BaseProgressReportModel() {
                MainTask = "Quick Add Gifs",
                CurrentTask = "Starting",
                PercentageComplete = 0,
                SpecialInfo = "Total New Gifs: " + numNewGifs.ToString(),
                CanCancel = true
            });
            using (var gifcontext = new GifContext()) {
                var gifHashSet = new HashSet<string>(gifcontext.Gifs.Select(gif => gif.FileName));               
                string[] files = Directory.GetFiles(Gif.TargetDirectory);
                totalGifs = files.Length;
                foreach (var file in files) {
                    completed++;
                    if (!gifHashSet.Contains(Path.GetFileName(file))) {
                        gifcontext.Gifs.Add(new Gif() { FileName = Path.GetFileName(file), CreatorId = User.ManagerId });
                        numNewGifs++;
                        progress.Report(new BaseProgressReportModel() {
                            MainTask = "Quick Add Gifs",
                            CurrentTask = "Added " + file,
                            SpecialInfo = "Total New Gifs: " + numNewGifs.ToString(),
                            PercentageComplete = (completed * 100 / (totalGifs + 10)) }); ;                        
                    } else {
                        progress.Report(new BaseProgressReportModel() {
                            MainTask = "Quick Add Gifs",
                            CurrentTask = "Scanned Duplicate " + file,
                            SpecialInfo = "Total New Gifs: " + numNewGifs.ToString(),
                            PercentageComplete = (completed * 100 / (totalGifs + 10)) });
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                }
                
                if (numNewGifs > 0) {
                    progress.Report(new BaseProgressReportModel() {
                        MainTask = "Quick Add Gifs",
                        CurrentTask = "Saving Changes to Database...",
                        PercentageComplete = (completed * 100 / (totalGifs + 10)),
                        SpecialInfo = "Total New Gifs: " + numNewGifs.ToString(),
                        CanCancel = false
                    }); ;
                    await Task.Delay(1000);

                    await gifcontext.SaveChangesAsync();
                }

                progress.Report(new BaseProgressReportModel() {
                    MainTask = "Quick Add Gifs",
                    CurrentTask = String.Format("Added {0} new gifs for a total of {1} gifs", numNewGifs, totalGifs),
                    PercentageComplete = 100,
                    SpecialInfo = "Total New Gifs: " + numNewGifs.ToString(),
                    CanCancel = false
                });
            }
        }
        
    }
}
