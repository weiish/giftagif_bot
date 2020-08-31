namespace GifBotManager
{
    partial class frmProgressBarPopUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMainTask = new System.Windows.Forms.Label();
            this.lblCurrentTask = new System.Windows.Forms.Label();
            this.btnCancelOrDone = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblSpecialInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // lblMainTask
            // 
            this.lblMainTask.AutoSize = true;
            this.lblMainTask.Location = new System.Drawing.Point(9, 9);
            this.lblMainTask.Name = "lblMainTask";
            this.lblMainTask.Size = new System.Drawing.Size(57, 13);
            this.lblMainTask.TabIndex = 1;
            this.lblMainTask.Text = "Main Task";
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.Location = new System.Drawing.Point(9, 60);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(68, 13);
            this.lblCurrentTask.TabIndex = 2;
            this.lblCurrentTask.Text = "Current Task";
            // 
            // btnCancelOrDone
            // 
            this.btnCancelOrDone.Location = new System.Drawing.Point(404, 85);
            this.btnCancelOrDone.Name = "btnCancelOrDone";
            this.btnCancelOrDone.Size = new System.Drawing.Size(114, 29);
            this.btnCancelOrDone.TabIndex = 4;
            this.btnCancelOrDone.Text = "Cancel";
            this.btnCancelOrDone.UseVisualStyleBackColor = true;
            this.btnCancelOrDone.Click += new System.EventHandler(this.btnCancelOrDone_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(480, 8);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 5;
            this.lblPercent.Text = "%";
            // 
            // lblSpecialInfo
            // 
            this.lblSpecialInfo.AutoSize = true;
            this.lblSpecialInfo.Location = new System.Drawing.Point(10, 90);
            this.lblSpecialInfo.Name = "lblSpecialInfo";
            this.lblSpecialInfo.Size = new System.Drawing.Size(60, 13);
            this.lblSpecialInfo.TabIndex = 6;
            this.lblSpecialInfo.Text = "SpecialInfo";
            // 
            // frmProgressBarPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 129);
            this.Controls.Add(this.lblSpecialInfo);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.btnCancelOrDone);
            this.Controls.Add(this.lblCurrentTask);
            this.Controls.Add(this.lblMainTask);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmProgressBarPopUp";
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMainTask;
        private System.Windows.Forms.Label lblCurrentTask;
        private System.Windows.Forms.Button btnCancelOrDone;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblSpecialInfo;
    }
}