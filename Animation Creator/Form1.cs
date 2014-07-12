using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.IO;
using System.Drawing.Imaging;

using System.Security.Cryptography;
using System.Diagnostics;

//AmiMat
using Amimat.Core;
using Amimat.Util;
using Amimat.Config;
//Json
using Newtonsoft.Json;

namespace Animation_Creator
{
    public partial class MainWindow : Form
    {
        public MainWindow(string [] args)
        {
            InitializeComponent();
            Arguments = args;
        }
        string [] Arguments = null;
        AMTPackage Package = null;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ClearElements();
            InitData();
            Package.PackageState = AMTUtil.State.EMPTY;
        }
        private void ClearElements()
        {
            lblFrameCount.Text = "0";
            lbGifFrames.Items.Clear();
            ClearPictureBoxImage();
            lblMd5.Text = "MD5";
            lbActions.Items.Clear();
            lblCurrentAction.Text = "null";
            lbFrames.Items.Clear();
            tssProjectName.Text = "Ready";
            tssWorkingDir.Text = "...";
        }
        private void InitData()
        {
            Package = new AMTPackage();
            tAutoSave.Interval = 1000 * 60 * 2; //2min autosave cycle
        }
        private void ClearPictureBoxImage()
        {
            try
            {
                if (pbFrame.Image != null)
                {
                    pbFrame.Image.Dispose();
                }
                pbFrame.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }
        }
        private void lbFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbGifFrames.SelectedIndex == -1)
                {
                    return;
                }

                //Make sure frames have been extracted
                if (Package.CurrentResource.Frames == null || Package.CurrentResource.Frames.Count() == 0)
                {
                    throw new NoNullAllowedException("Frames have not been extracted");
                }

                //Make sure the selected index is within range
                if (lbGifFrames.SelectedIndex > Package.CurrentResource.Frames.Count() - 1)
                {
                    throw new IndexOutOfRangeException("Frame list does not contain index: " + lbGifFrames.SelectedIndex.ToString());
                }

                //Clear the PictureBox
                ClearPictureBoxImage();

                //Load the image from the byte array
                pbFrame.Image = AMTUtil.BytesToImage(Package.CurrentResource.Frames[lbGifFrames.SelectedIndex]);

                lblMd5.Text = "MD5: " + AMTUtil.ImageMD5(pbFrame.Image);

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }
        }
        private void PopulateAssetFrames()
        {
            lbGifFrames.Items.Clear();
            for (int i = 0; i < Package.CurrentResource.Frames.Count(); i++)
            {
                lbGifFrames.Items.Add(i.ToString());
            }
            lblFrameCount.Text = Package.CurrentResource.Frames.Count().ToString();
        }
        private void PopulateAction()
        {
            lbActions.Items.Clear();
            //lbFrames.Items.Clear();
            foreach (string fileName in Package.Animation.Manifest.ActionFileName)
            {
                string actionName = Path.GetFileNameWithoutExtension(fileName);
                if (actionName == Package.Animation.Manifest.DefaultAction)
                    actionName = "*dft* " + actionName; 
                lbActions.Items.Add(actionName);
            }
            lbActions.SelectedIndex = 0;
            PopulateFrames();
        }
        private void PopulateFrames()
        {
            lbFrames.Items.Clear();
            foreach (AMTFrame frame in Package.Animation.Actions[lbActions.SelectedIndex].Frames)
            {
                lbFrames.Items.Add(AMTUtil.FrameToString(frame));
            }
        }
        private void PopulateResources()
        {
            lbAssets.Items.Clear();
            foreach (KeyValuePair<string, string> s in Package.Resources)
            {
                lbAssets.Items.Add(s.Value);
            }
        }
        private void PopulateUI()
        {
            PopulateAction();
            lbActions.SelectedIndex = 0;
            PopulateFrames();
            tssProjectName.Text = Package.Name;
            tssWorkingDir.Text = Package.WorkingDir;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ClearElements();
            InitData();
            string PromptValue = InputPrompt.ShowDialog("Name of the project", "New Project");
            if (PromptValue == null)
                return;
            if (PromptValue == "")
            {
                MessageBox.Show("Input Empty!");
            }
            FolderBrowserDialog FolderDialog = new FolderBrowserDialog();
            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                Package.Name = PromptValue;
                tssProjectName.Text = Package.Name;
                Package.PackageState = AMTUtil.State.LOADED;
                Package.WorkingDir = FolderDialog.SelectedPath;
                tssWorkingDir.Text = Package.WorkingDir;
            }
            /*OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = "gif files (*.gif)|*.*";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Package.PackageState = AMTUtil.State.LOADED;
                //Clear UI Before this and Data
                ClearElements();
                InitData();
                AMTUtil.LoadAsset(Package, OpenFileDialog.FileName);
                tssProjectName.Text = OpenFileDialog.FileName;
                //Creating New Dir
                Package.WorkingDir = Path.GetDirectoryName(OpenFileDialog.FileName);
                Package.WorkingDir = Directory.CreateDirectory(AMTUtil.GetAbsPath(Package.WorkingDir, Path.GetFileNameWithoutExtension(OpenFileDialog.FileName))).FullName;
                tssWorkingDir.Text = Package.WorkingDir;
                //Copy
                File.Copy(OpenFileDialog.FileName, AMTUtil.GetAbsPath(Package.WorkingDir, "asset.gif"));
                AMTUtil.InitAnimation(Package, (int)nudDefaultDelay.Value);
                FileType = "amf";
                PopulateImage();
                PopulateUI();
            }*/
        }

        private void btnOpenExisting_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = AMTConfig.PackageExtension + " files (*" + 
                                  AMTConfig.PackageExtension + ")|*" + AMTConfig.PackageExtension;
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Clear UI Before this and Data
                Package.PackageState = AMTUtil.State.LOADED;
                ClearElements();
                InitData();
                //File Loading
                if (!AMTUtil.OpenPackage(Package, OpenFileDialog.FileName))
                {
                    MessageBox.Show("Project Load Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Package = new AMTPackage();
                    Package.PackageState = AMTUtil.State.EMPTY;
                }
                else
                {
                    PopulateResources();
                    lbAssets.SelectedIndex = 0;
                    PopulateAssetFrames();
                    lbGifFrames.SelectedIndex = 0;
                    PopulateUI();
                }
            }
        }

        private void btnShowText_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.SelectedItems.Count > 1)
            {
                MessageBox.Show("You cannot view more than one frame.");
                return;
            }
            FrameInfo InfoWindow = new FrameInfo(Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex]);
            InfoWindow.Show();
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            //When more than one frame, create duplicate action and view action
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.SelectedItems.Count > 1)
            {
                MessageBox.Show("You cannot view more than one frame.");
                return;
            }
            if (Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].ActionRef == null)
            {
                AMTResource PreviewResource = AMTUtil.GetResourceFromName(Package, Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].Resource);
                FramePreview PreviewWindow = new FramePreview(AMTUtil.BytesToImage(PreviewResource.Frames[Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].FrameRef]));
                PreviewWindow.Show();
            }
            else
            {
                ActionPreview PreviewWindow = new ActionPreview(Package,
                AMTUtil.GetActionFromName(Package.Animation, Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].ActionRef));
                PreviewWindow.Show();
            }
        }

        private void btnCreateAsNew_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            string PromptValue = InputPrompt.ShowDialog("Input New Action Name", "New Action");
            if (PromptValue == null)
                return;
            if (PromptValue == "")
            {
                MessageBox.Show("Input Empty!");
            }
            else if (Package.Animation.Manifest.ActionFileName.Contains(PromptValue))
            {
                MessageBox.Show("Action Already Exist!");
            }
            else
            {
                Package.Animation.Manifest.ActionFileName.Add(PromptValue);
                Package.Animation.Actions.Add(new AMTAction());
                Package.Animation.Actions.Last().Name = PromptValue;
                foreach (object o in lbGifFrames.SelectedItems)
                {
                    Package.Animation.Actions.Last().Frames.Add(new AMTFrame());
                    Package.Animation.Actions.Last().Frames.Last().Resource = Package.CurrentResource.Name;
                    Package.Animation.Actions.Last().Frames.Last().Delay = (int)nudDefaultDelay.Value;
                    Package.Animation.Actions.Last().Frames.Last().FrameRef = lbGifFrames.Items.IndexOf(o);
                    Package.Animation.Actions.Last().Frames.Last().MD5 = Package.CurrentResource.FrameUID[lbGifFrames.Items.IndexOf(o)];
                    Package.Animation.Actions.Last().Frames.Last().Tags.Add("null");
                }
                PopulateUI();
            }
        }

        private void lbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbActions.SelectedIndex == -1)
                return;
            lblCurrentAction.Text = Package.Animation.Manifest.ActionFileName[lbActions.SelectedIndex];
            PopulateFrames();
        }

        private void btnAddToExisting_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbActions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select an action!");
                return;
            }
            foreach (object o in lbGifFrames.SelectedItems)
            {
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.Add(new AMTFrame());
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().Resource = Package.CurrentResource.Name;
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().Delay = (int)nudDefaultDelay.Value;
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().FrameRef = lbGifFrames.Items.IndexOf(o);
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().MD5 = Package.CurrentResource.FrameUID[lbGifFrames.Items.IndexOf(o)];
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().Tags.Add("null");
            }
            PopulateFrames();
            lbFrames.SelectedIndex = lbFrames.Items.Count - 1;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.SelectedItems.Count > 1)
            {
                MessageBox.Show("You cannot move more than one frame.");
                return;
            }
            if (lbFrames.SelectedIndex == 0)
                return;
            else
            {
                //Swap
                int index = lbFrames.SelectedIndex;
                AMTUtil.Swap<AMTFrame>(Package.Animation.Actions[lbActions.SelectedIndex].Frames, lbFrames.SelectedIndex, lbFrames.SelectedIndex - 1);
                PopulateFrames();
                lbFrames.SelectedIndex = index - 1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.SelectedItems.Count > 1)
            {
                MessageBox.Show("You cannot move more than one frame.");
                return;
            }
            if (lbFrames.SelectedIndex == lbFrames.Items.Count - 1)
                return;
            else
            {
                //Swap
                int index = lbFrames.SelectedIndex;
                AMTUtil.Swap<AMTFrame>(Package.Animation.Actions[lbActions.SelectedIndex].Frames, lbFrames.SelectedIndex, lbFrames.SelectedIndex + 1);
                PopulateFrames();
                lbFrames.SelectedIndex = index + 1;
            }
        }

        private void btnDeleteFrame_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection Indices = lbFrames.SelectedIndices;

            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (Indices.Count >= lbFrames.Items.Count)
            {
                MessageBox.Show("Cannot delete all frame in action.");
                return;
            }
            /*if (lbFrames.SelectedItems.Count > 1)
            {
                MessageBox.Show("Cannot delete more than one frame at a time.");
                return;
            }*/
            if (MessageBox.Show("Do you want to delete this frame?", "Delete " +
                Package.Animation.Manifest.ActionFileName[lbActions.SelectedIndex], MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            for (int i = lbFrames.SelectedItems.Count - 1; i >= 0; i--)
            {
                Package.Animation.Actions[lbActions.SelectedIndex].Frames.RemoveAt(Indices[i]);
                lbFrames.SelectedItems.Remove(Indices[i]);
            }
            //int selectefFrame = lbFrames.SelectedIndex;
            //Package.Animation.Actions[lbActions.SelectedIndex].Frames.RemoveAt(lbFrames.SelectedIndex);
            PopulateFrames();
           // if(selectefFrame != 0)
                //lbFrames.SelectedIndex = selectefFrame - 1;
            //else
                //lbFrames.SelectedIndex = selectefFrame;
        }

        private void btnChangeDelay_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            string PromptValue = InputPrompt.ShowDialog("Input a new time in milliseconds", "Edit time", 
                Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].Delay.ToString());
            //User Cancel Action
            if (PromptValue == null)
                return;
            if (PromptValue == "")
            {
                MessageBox.Show("Input Empty!");
            }
            else
            {
                foreach (object o in lbFrames.SelectedItems)
                {
                    Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.Items.IndexOf(o)].Delay = Convert.ToInt32(AMTUtil.GetNumbers(PromptValue));
                }
            }
            PopulateFrames();
        }

        private void btnEditTag_Click(object sender, EventArgs e)
        {
            string tags = "";
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            foreach (string s in Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].Tags)
            {
                tags += (s + ",");
            }
            string PromptValue = InputPrompt.ShowDialog("Input tags, seperated by comma", "Edit Tags",
                tags);
            //User Cancel Action
            if (PromptValue == null)
                return;
            foreach (object o in lbFrames.SelectedItems)
            {
                Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.Items.IndexOf(o)].Tags.Clear();
                foreach (string s in PromptValue.Split(','))
                {
                    if (s != "")
                        Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.Items.IndexOf(o)].Tags.Add(s);
                }
            }
            PopulateFrames();
            //No Previous Selection Recovery
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            int index = lbActions.SelectedIndex;
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbActions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a action!");
                return;
            }
            if(Package.Animation.Actions[lbActions.SelectedIndex].Name.Equals(Package.Animation.Manifest.DefaultAction))
            {
                MessageBox.Show("Cannot delete default action.");
                return;
            }
            if (lbActions.Items.Count == 1)
            {
                MessageBox.Show("Cannot Delete Only action in animation.");
                return;
            }
            //Confirm??
            if (MessageBox.Show("Do you want to delete this action?", "Delete " +
                Package.Animation.Manifest.ActionFileName[lbActions.SelectedIndex], MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //Update Manifest
            //Delete action in Package.Animation
            //Delete file
            //Update UI
            //
            //
            //
            throw new NotImplementedException();
            //

            //File.Delete(AMTUtil.GetAbsPath(Package.WorkingDir, Package.Animation.Manifest.ActionFileName[lbActions.SelectedIndex] + AMTConfig.ActionExtension));
            Package.Animation.Manifest.ActionFileName.RemoveAt(lbActions.SelectedIndex);
            Package.Animation.Actions.RemoveAt(lbActions.SelectedIndex);
            PopulateUI();
            //
            //
            //
            //Replace
            //
            //
            lblAutoSave.Text = DateTime.Now.ToString();
            lbActions.SelectedIndex = index - 1;
        }

        private void btnPlayAction_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbActions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a action!");
                return;
            }
            ActionPreview PreviewWindow = new ActionPreview(Package, Package.Animation.Actions[lbActions.SelectedIndex]);
            PreviewWindow.Show();
        }

        private void btnFrameRef_Click(object sender, EventArgs e)
        {
            int index = lbFrames.SelectedIndex;
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            string FileName = (string)Selection_Prompt<string>.ShowDialog("Select a action you want to add as reference", "Action Selection", Package.Animation.Manifest.ActionFileName);
            if (FileName == null)
                return;
            //Cannot Have reference conflict
            string CheckResult = AMTUtil.CheckReference(Package.Animation, Package.Animation.Actions[lbActions.SelectedIndex],
                AMTUtil.GetActionFromName(Package.Animation, Path.GetFileNameWithoutExtension(FileName)));
            if (CheckResult != null)
            {
                MessageBox.Show("Reference conflict in: " + CheckResult, "Critical Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //lblDebug.Text = FileName;
            Package.Animation.Actions[lbActions.SelectedIndex].Frames.Add(new AMTFrame());
            Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().Delay = (int)nudDefaultDelay.Value;
            Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().ActionRef = Path.GetFileNameWithoutExtension(FileName);
            Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().MD5 = null;
            Package.Animation.Actions[lbActions.SelectedIndex].Frames.Last().Tags.Add("null");
            PopulateFrames();
            lbFrames.SelectedIndex = lbFrames.Items.Count - 1;
        }

        private void tAutoSave_Tick(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            //
            //
            //
            //
            //
            //
            //
            lblAutoSave.Text = DateTime.Now.ToString();
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAsset_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (Package.SavePackage())
                MessageBox.Show("Package save success!", "Package", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("Project save error!", "Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            string PromptValue = InputPrompt.ShowDialog("Input a new randomness", "Edit Randomness",
                Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].Randomness.ToString());
            //User Cancel Action
            if (PromptValue == null)
                return;
            if (PromptValue == "")
            {
                MessageBox.Show("Input Empty!");
            }
            else
            {
                foreach (object o in lbFrames.SelectedItems)
                {
                    if (Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.Items.IndexOf(o)].ActionRef != null)
                        MessageBox.Show("Action reference frames are not changed.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        Package.Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.Items.IndexOf(o)].Randomness = Convert.ToDouble(AMTUtil.GetDouble(PromptValue));
                }
            }
            PopulateFrames();
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            if (Package.PackageState != AMTUtil.State.READY)
                return;
            if (lbActions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a action!");
                return;
            }
            if (MessageBox.Show("Do you want to default this action?", "Default " +
                Package.Animation.Manifest.ActionFileName[lbActions.SelectedIndex], MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            Package.Animation.Manifest.DefaultAction = Package.Animation.Actions[lbActions.SelectedIndex].Name;
            PopulateUI();
        }

        private void btnNewAsset_Click(object sender, EventArgs e)
        {
            if (Package.PackageState == AMTUtil.State.EMPTY)
                return;
            string PromptValue = InputPrompt.ShowDialog("Name of the resource", "New Resource");
            if (PromptValue == null)
                return;
            if (PromptValue == "")
            {
                MessageBox.Show("Input Empty!");
            }
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = "gif files (*.gif)|*.gif";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Package.AddResource(PromptValue, OpenFileDialog.FileName, ResourceType.GIF))
                    MessageBox.Show("Resource Load Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateResources();
            }
            if (Package.PackageState != AMTUtil.State.READY)
            {
                if (MessageBox.Show("Do you want to initialize animation using this resource?", "Initialize Animation",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    AMTUtil.InitAnimation(Package, Package.CurrentResource.Name);
                    PopulateUI();
                }
            }
        }

        private void btnLoadToExisting_Click(object sender, EventArgs e)
        {

        }

        private void lbAssets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAssets.SelectedIndex != -1)
            {
                if(Package.CurrentResource == null)
                    Package.SwitchResource(Package.Resources[lbAssets.SelectedIndex].Value);
                if (Package.Resources[lbAssets.SelectedIndex].Value != Package.CurrentResource.Name)
                    Package.SwitchResource(Package.Resources[lbAssets.SelectedIndex].Value);
                PopulateAssetFrames();
            }
        }

        private void btnLoadExistingAsset_Click(object sender, EventArgs e)
        {
            if (Package.PackageState == AMTUtil.State.EMPTY)
                return;
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = "resource files (*" + AMTConfig.ResourceExtension + ")|*" + AMTConfig.ResourceExtension;
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Package.AddExistingResource(OpenFileDialog.FileName);
                PopulateResources();
                if (Package.PackageState != AMTUtil.State.READY)
                {
                    if (MessageBox.Show("Do you want to initialize animation using this resource?", "Initialize Animation",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        AMTUtil.InitAnimation(Package, Package.CurrentResource.Name);
                        PopulateUI();
                    }
                }
            }
            Package.SavePackage();
        }

        private void btnNormalLoad_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = "resource files (*" + AMTConfig.ResourceExtension + ")|*" + AMTConfig.ResourceExtension;
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                AMTResource TestResource = new AMTResource();
                stopWatch.Start();
                TestResource = (AMTResource)JsonConvert.DeserializeObject<AMTResource>(File.ReadAllText(OpenFileDialog.FileName));
                stopWatch.Stop();
                Console.WriteLine(TestResource.UID);
                Console.WriteLine(JsonConvert.SerializeObject(TestResource.FrameUID));
            }
            lblDebug.Text = "Elapsed: " + stopWatch.ElapsedMilliseconds + "ms";
        }

        private void btnQuickLoad_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = "resource files (*" + AMTConfig.ResourceExtension + ")|*" + AMTConfig.ResourceExtension;
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                AMTResourceQ TestResource = new AMTResourceQ();
                stopWatch.Start();
                TestResource = (AMTResourceQ)JsonConvert.DeserializeObject<AMTResourceQ>(File.ReadAllText(OpenFileDialog.FileName));
                stopWatch.Stop();
                Console.WriteLine(TestResource.UID);
                Console.WriteLine(JsonConvert.SerializeObject(TestResource.FrameUID));
            }
            lblDebug.Text = "Elapsed: " + stopWatch.ElapsedMilliseconds + "ms";
        }
    }
}
