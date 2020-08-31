using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifBotManager
{
    public partial class frmProgressBarPopUp : Form
    {
        CancellationTokenSource cts;
        bool Done = false;
        bool Cancelled = false;
        bool CanCancel = true;
        public frmProgressBarPopUp(Progress<BaseProgressReportModel> progress, CancellationTokenSource cts) {
            InitializeComponent();
            progress.ProgressChanged += UpdateMe;
            this.cts = cts;
        }

        public void UpdateMe(object sender, BaseProgressReportModel progress) {
            if (!Cancelled) {
                Done = (progress.PercentageComplete >= 100);
                CanCancel = !Done && progress.CanCancel;
                this.Text = progress.MainTask;
                lblMainTask.Text = progress.MainTask;
                lblCurrentTask.Text = progress.CurrentTask;
                btnCancelOrDone.Text = Done ? "Done" : "Cancel";
                btnCancelOrDone.Enabled = CanCancel || Done;
                progressBar1.Value = progress.PercentageComplete;
                lblPercent.Text = progress.PercentageComplete.ToString() + "%";
                lblSpecialInfo.Text = progress.SpecialInfo;
            }
        }

        private void btnCancelOrDone_Click(object sender, EventArgs e) {
            if (Cancelled || Done) {
                this.Close();
            }
            else {
                cts.Cancel();
                lblCurrentTask.Text = "Cancelled!";
                Cancelled = true;
                btnCancelOrDone.Text = "Close";
                CanCancel = false;
            }


        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing && CanCancel) {
                // Confirm user wants to close
                switch (MessageBox.Show(this, "Are you sure you want to cancel and close?", "Closing", MessageBoxButtons.YesNo)) {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        cts.Cancel();
                        Cancelled = true;
                        break;
                }
            }


        }
    }
}
