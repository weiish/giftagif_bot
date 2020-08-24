namespace GifBotManager
{
    partial class frmAddGifs
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
            this.lstFiles = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picGifPreview = new System.Windows.Forms.PictureBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.clbTags = new System.Windows.Forms.CheckedListBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.chkNSFW = new System.Windows.Forms.CheckBox();
            this.btnAddTag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGifPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.HideSelection = false;
            this.lstFiles.Location = new System.Drawing.Point(18, 30);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(455, 632);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.List;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gifs";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(18, 680);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(455, 30);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // picGifPreview
            // 
            this.picGifPreview.Location = new System.Drawing.Point(495, 30);
            this.picGifPreview.Name = "picGifPreview";
            this.picGifPreview.Size = new System.Drawing.Size(859, 632);
            this.picGifPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picGifPreview.TabIndex = 3;
            this.picGifPreview.TabStop = false;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(1367, 32);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 13);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "File Name";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(1371, 48);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(223, 20);
            this.txtFileName.TabIndex = 5;
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(1367, 156);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(31, 13);
            this.lblTags.TabIndex = 6;
            this.lblTags.Text = "Tags";
            // 
            // clbTags
            // 
            this.clbTags.FormattingEnabled = true;
            this.clbTags.Location = new System.Drawing.Point(1371, 177);
            this.clbTags.Name = "clbTags";
            this.clbTags.Size = new System.Drawing.Size(223, 484);
            this.clbTags.TabIndex = 8;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(1273, 768);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(148, 42);
            this.btnDone.TabIndex = 9;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1461, 768);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 42);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Location = new System.Drawing.Point(1370, 94);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(223, 20);
            this.txtIdentifier.TabIndex = 12;
            // 
            // lblIdentifier
            // 
            this.lblIdentifier.AutoSize = true;
            this.lblIdentifier.Location = new System.Drawing.Point(1366, 78);
            this.lblIdentifier.Name = "lblIdentifier";
            this.lblIdentifier.Size = new System.Drawing.Size(47, 13);
            this.lblIdentifier.TabIndex = 11;
            this.lblIdentifier.Text = "Identifier";
            // 
            // chkNSFW
            // 
            this.chkNSFW.AutoSize = true;
            this.chkNSFW.Location = new System.Drawing.Point(1370, 127);
            this.chkNSFW.Name = "chkNSFW";
            this.chkNSFW.Size = new System.Drawing.Size(58, 17);
            this.chkNSFW.TabIndex = 13;
            this.chkNSFW.Text = "NSFW";
            this.chkNSFW.UseVisualStyleBackColor = true;
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(1372, 675);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(221, 34);
            this.btnAddTag.TabIndex = 14;
            this.btnAddTag.Text = "Add Tag";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // frmAddGifs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1633, 822);
            this.Controls.Add(this.btnAddTag);
            this.Controls.Add(this.chkNSFW);
            this.Controls.Add(this.txtIdentifier);
            this.Controls.Add(this.lblIdentifier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.clbTags);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.picGifPreview);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFiles);
            this.Name = "frmAddGifs";
            this.Text = "frmAddGifs";
            this.Load += new System.EventHandler(this.frmAddGifs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGifPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox picGifPreview;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.CheckedListBox clbTags;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.CheckBox chkNSFW;
        private System.Windows.Forms.Button btnAddTag;
    }
}