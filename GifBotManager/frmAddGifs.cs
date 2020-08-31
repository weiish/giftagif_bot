using GiftAGifBot.DAL;
using GiftAGifBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifBotManager
{
    // TO DO
    /*
     * Wire up Done button to actually save everything to the database
     * should copy all files to a specific dedicated folder from the app config 
     * see how hard it is to make a gif editor
     * 
     * Create 2nd form that should be very similar to the add form which instead lets you EDIT gif data and tags
     * 
     */
    public partial class frmAddGifs : Form
    {
        int lastSelected = -1;
        List<string> FilePaths = new List<string>();
        List<string> DuplicateFilePaths = new List<string>();
        Dictionary<string, Gif> gifDictionary = new Dictionary<string, Gif>();
        public frmAddGifs() {
            InitializeComponent();
        }

        private void frmAddGifs_Load(object sender, EventArgs e) {
            RefreshTags(null);
        }

        private void SaveGifs(List<string> filePaths) {
            if (filePaths.Count == 0) {
                return;
            }
            //Make this async and not on the main UI thread
            using (var gifContext = new GifContext()) {
                filePaths.ForEach(file => {
                    try {
                        lstFiles.Items.RemoveByKey(file);
                        Gif gif = gifDictionary[Path.GetFileName(file)];
                        gifContext.Gifs.Add(gif);
                        foreach (var giftag in gif.GifTags) {
                            gifContext.Entry(giftag.Tag).State = System.Data.Entity.EntityState.Unchanged;
                        }
                        File.Copy(file, Path.Combine(Gif.TargetDirectory, Path.GetFileName(file)));
                    }
                    catch (IOException ioException) {

                    }
                    catch (Exception exception) {

                    }
                });
                gifContext.SaveChanges(); // Save changes to DB
            }
            MessageBox.Show("Saved " + filePaths.Count + " gifs");
            filePaths.Clear();
            gifDictionary.Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Select Gifs to Add";
            fileDialog.Filter = "Gifs (*.GIF)|*.GIF|" + "All files (*.*)|*.*";
            DialogResult dr = fileDialog.ShowDialog();
            if (dr == DialogResult.OK) {

                using (var gifContext = new GifContext()) {
                    List<Gif> gifs = gifContext.Gifs.ToList<Gif>();

                    // Read the files                
                    foreach (String file in fileDialog.FileNames) {
                        // Create a PictureBox.
                        try {
                            if (!FilePaths.Contains(file)) {
                                if (!gifs.Any(gif => gif.FileName == Path.GetFileName(file))) {
                                    Gif gif = new Gif { FileName = Path.GetFileName(file), CreatorId = User.ManagerId };
                                    lstFiles.Items.Add(file, file, 0);
                                    FilePaths.Add(file);
                                    gifDictionary[Path.GetFileName(file)] = gif;
                                }
                                else {
                                    if (!DuplicateFilePaths.Contains(file)) {
                                        DuplicateFilePaths.Add(file);
                                        lstDuplicate.Items.Add(file);
                                    }
                                }
                            }

                        }
                        catch (SecurityException ex) {
                            // The user lacks appropriate permissions to read files, discover paths, etc.
                            MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                                "Error message: " + ex.Message + "\n\n" +
                                "Details (send to Support):\n\n" + ex.StackTrace
                            );
                        }
                        catch (Exception ex) {
                            // Could not load the image - probably related to Windows file system permissions.
                            MessageBox.Show("Cannot add the image: " + file.Substring(file.LastIndexOf('\\'))
                                + ". You may not have permission to read the file, or " +
                                "it may be corrupt.\n\nReported error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e) {
            if (lastSelected > -1) {
                //Save last item                
                List<Tag> tags = GetTags();
                string fileName = lstFiles.Items[lastSelected].Text;
                Gif gif = gifDictionary[Path.GetFileName(fileName)];
                gif.FileName = txtFileName.Text;
                gif.IsNSFW = chkNSFW.Checked;
                if (clbTags.CheckedItems.Count > 0) {
                    if (gif.GifTags == null) gif.GifTags = new List<GifTag>();
                    foreach (var item in clbTags.CheckedItems) {
                        if (!gif.GifTags.Any(gifTag => gifTag.Tag.Name == item.ToString())) {
                            gif.GifTags.Add(new GifTag { GifId = gif.Id, Tag = tags.First(tag => tag.Name == item.ToString()) });
                        }
                    }
                }
            }

            if (lstFiles.SelectedItems.Count > 0) {
                lastSelected = lstFiles.SelectedIndices[0];
                //Load new item
                string fileName = lstFiles.SelectedItems[0].Text;
                picGifPreview.Image = Image.FromFile(fileName);
                Gif gif = gifDictionary[Path.GetFileName(fileName)];
                if (gif == null) {
                    gif = new Gif();
                    gif.GifTags = new List<GifTag>();
                }
                txtFileName.Text = Path.GetFileName(fileName);
                chkNSFW.Checked = gif.IsNSFW;
                List<Tag> tags = GetTags();
                RefreshTags(tags);
                if (gif.GifTags?.Count > 0) {
                    foreach (GifTag giftag in gif.GifTags) {
                        clbTags.SetItemChecked(tags.FindIndex(tag => tag.Name == giftag.Tag.Name), true);
                    }
                }

            }
        }

        private void btnAddTag_Click(object sender, EventArgs e) {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new tag name",
                       "Add Tag",
                       "Default",
                       600,
                       600).Trim();

            if (input.Length > 0) {
                using (var gifContext = new GifContext()) {
                    List<Tag> tags = gifContext.Tags.ToList<Tag>();
                    if (!tags.Any(tag => tag.Name == input)) {
                        gifContext.Tags.Add(new Tag { Name = input, CreatorId = User.ManagerId });
                        gifContext.SaveChanges(); // Save changes to DB
                    }
                    RefreshTags(null);
                }
            }

        }
        private void RefreshTags(List<Tag> tags) {
            if (tags == null) tags = GetTags();
            this.clbTags.Items.Clear();
            tags.ForEach(tag => this.clbTags.Items.Add(tag.Name));
        }

        private List<Tag> GetTags() {
            using (var gifContext = new GifContext()) {
                return gifContext.Tags.ToList<Tag>();
            }

        }

        private void btnDone_Click(object sender, EventArgs e) {
            SaveGifs(FilePaths);
        }

        private void clbTags_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void clbTags_ItemCheck(object sender, ItemCheckEventArgs e) {
            //Get all selected in lstGifs
            if (lstFiles.SelectedItems.Count == 0) {
                return;
            }

            string tagName = clbTags.Items[e.Index].ToString();
            List<Tag> tags = GetTags();
            foreach (ListViewItem item in lstFiles.SelectedItems) {
                string fileName = Path.GetFileName(item.Text);
                Gif gif = gifDictionary[Path.GetFileName(fileName)];
                if (e.NewValue == CheckState.Unchecked) {
                    gif.GifTags.Remove(gif.GifTags.First(giftag => giftag.Tag.Name == tagName));
                }
                else if (e.NewValue == CheckState.Checked) {
                    if (gif.GifTags == null) gif.GifTags = new List<GifTag>();
                    if (!gif.GifTags.Any(gifTag => gifTag.Tag.Name == tagName)) {
                        gif.GifTags.Add(new GifTag { GifId = gif.Id, Tag = tags.First(tag => tag.Name == tagName) });
                    }
                }
            }

        }
    }
}
