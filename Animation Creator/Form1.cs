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

//AmiMat
using Amimat.Core;
//Json
using Newtonsoft.Json;

namespace Animation_Creator
{
    enum State
    {
        EMPTY,
        LOADED,
        READY
    }
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string WorkingDir = @"";
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        List<byte[]> Frames = new List<byte[]>() { };
        AMTAnimation Animation = null;

        State ProgramState = State.EMPTY;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ClearElements();
            InitData();
            ProgramState = State.EMPTY;
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
            tssAsset.Text = "Ready";
            tssWorkingDir.Text = "...";
        }
        private void InitData()
        {
            Animation = null;
        }
        private void LoadGif(string pathToImage)
        {
            try
            {
                //Try extracting the frames
                Frames = EnumerateFrames(pathToImage);
                if (Frames == null || Frames.Count() == 0)
                {
                    throw new NoNullAllowedException("Unable to obtain frames from " + pathToImage);
                }

                lblFrameCount.Text = Frames.Count().ToString();

                for (int i = 0; i < Frames.Count(); i++)
                {
                    lbGifFrames.Items.Add(i.ToString());
                }

                lbGifFrames.SelectedIndex = 0;

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
        private List<byte[]> EnumerateFrames(string imagePath)
        {
            try
            {
                //Make sure the image exists
                if (!File.Exists(imagePath))
                {
                    throw new FileNotFoundException("Unable to locate " + imagePath);
                }

                Dictionary<Guid, ImageFormat> guidToImageFormatMap = new Dictionary<Guid, ImageFormat>()
                {
                    {ImageFormat.Bmp.Guid,  ImageFormat.Bmp},
                    {ImageFormat.Gif.Guid,  ImageFormat.Png},
                    {ImageFormat.Icon.Guid, ImageFormat.Png},
                    {ImageFormat.Jpeg.Guid, ImageFormat.Jpeg},
                    {ImageFormat.Png.Guid,  ImageFormat.Png}
                };

                List<byte[]> tmpFrames = new List<byte[]>() { };

                using (Image img = Image.FromFile(imagePath, true))
                {
                    //Check the image format to determine what
                    //format the image will be saved to the 
                    //memory stream in
                    ImageFormat imageFormat = null;
                    Guid imageGuid = img.RawFormat.Guid;

                    foreach (KeyValuePair<Guid, ImageFormat> pair in guidToImageFormatMap)
                    {
                        if (imageGuid == pair.Key)
                        {
                            imageFormat = pair.Value;
                            break;
                        }
                    }

                    if (imageFormat == null)
                    {
                        throw new NoNullAllowedException("Unable to determine image format");
                    }

                    //Get the frame count
                    FrameDimension dimension = new FrameDimension(img.FrameDimensionsList[0]);
                    int frameCount = img.GetFrameCount(dimension);

                    //Step through each frame
                    for (int i = 0; i < frameCount; i++)
                    {
                        //Set the active frame of the image and then 
                        //write the bytes to the tmpFrames array
                        img.SelectActiveFrame(dimension, i);
                        using (MemoryStream ms = new MemoryStream())
                        {

                            img.Save(ms, imageFormat);
                            tmpFrames.Add(ms.ToArray());
                        }
                    }

                }

                return tmpFrames;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }

            return null;
        }
        private Bitmap ConvertBytesToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return null;
            }

            try
            {
                //Read bytes into a MemoryStream
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    //Recreate the frame from the MemoryStream
                    using (Bitmap bmp = new Bitmap(ms))
                    {
                        return (Bitmap)bmp.Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }

            return null;
        }
        private byte[] ConvertImageToBytes(Image image)
        {
            if (image == null)
            {
                return null;
            }

            try
            {
                //Read bytes into a MemoryStream
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error type: " + ex.GetType().ToString() + "\n" +
                    "Message: " + ex.Message,
                    "Error in " + MethodBase.GetCurrentMethod().Name
                    );
            }
            return null;
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
        private string ImageMD5(Image image)
        {
            byte[] md5Hash = MD5.ComputeHash(ConvertImageToBytes(image));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5Hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
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
                if (Frames == null || Frames.Count() == 0)
                {
                    throw new NoNullAllowedException("Frames have not been extracted");
                }

                //Make sure the selected index is within range
                if (lbGifFrames.SelectedIndex > Frames.Count() - 1)
                {
                    throw new IndexOutOfRangeException("Frame list does not contain index: " + lbGifFrames.SelectedIndex.ToString());
                }

                //Clear the PictureBox
                ClearPictureBoxImage();

                //Load the image from the byte array
                pbFrame.Image = ConvertBytesToImage(Frames[lbGifFrames.SelectedIndex]);

                lblMd5.Text = "MD5: " + ImageMD5(pbFrame.Image);

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
        private void InitManifest()
        {
            Animation = new AMTAnimation();
            Animation.Manifest.AssetName = "asset.gif";
            Animation.Manifest.ActionFileName.Add("null.act");
            Animation.Actions.Add(new AMTAction());
            Animation.Actions[0].Name = "null";
            Animation.Actions[0].Frames.Add(new AMTFrame());
            Animation.Actions[0].Frames[0].Delay = 100;
            Animation.Actions[0].Frames[0].FrameRef = 0;
            Animation.Actions[0].Frames[0].Tags.Add("null");
            Animation.Actions[0].Frames[0].MD5 = ImageMD5(ConvertBytesToImage(Frames[0]));
            //First Time Save
            Save();
            PopulateUI();
            ProgramState = State.READY;
        }
        private string FrameToString(AMTFrame frame)
        {
            string str = "";
            str = "Frame Reference: [" + frame.FrameRef + "]" + "Frame Delay: " + "["  + frame.Delay + "ms" + "]";
            str += "Tags: [";
            foreach (string s in frame.Tags)
            {
                str += "(";
                str += s;
                str += ")";
            }
            str += "]";
            return str;
        }
        private void PopulateUI()
        {
            int index = lbActions.SelectedIndex;
            lbActions.Items.Clear();
            lbFrames.Items.Clear();
            foreach (string actionName in Animation.Manifest.ActionFileName)
            {
                lbActions.Items.Add(actionName);
            }
            lbActions.SelectedIndex = index;
            /*lbActions.SelectedIndex = 0;
            foreach (AMTFrame frame in Animation.Actions[lbActions.SelectedIndex].Frames)
            {
                lbFrames.Items.Add(FrameToString(frame));
            }*/
        }
        private void Save()
        {
            //Serialize
            File.WriteAllText(Path.Combine(WorkingDir, "AMT.mf"), JsonConvert.SerializeObject(Animation.Manifest, Formatting.Indented));
            foreach(AMTAction a in Animation.Actions)
            {
                File.WriteAllText(Path.Combine(WorkingDir, a.Name + ".act"), JsonConvert.SerializeObject(a, Formatting.Indented));
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ProgramState = State.LOADED;
            //Clear UI Before this and Data
            ClearElements();
            InitData();
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            OpenFileDialog.Filter = "gif files (*.gif)|*.*";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadGif(OpenFileDialog.FileName);
                tssAsset.Text = OpenFileDialog.FileName;
                //Creating New Dir
                WorkingDir = Path.GetDirectoryName(OpenFileDialog.FileName);
                WorkingDir = Directory.CreateDirectory(Path.Combine(WorkingDir, Path.GetFileNameWithoutExtension(OpenFileDialog.FileName))).FullName;
                tssWorkingDir.Text = WorkingDir;
                //Copy
                File.Copy(OpenFileDialog.FileName, Path.Combine(WorkingDir, "asset.gif"));
                InitManifest();
            }
        }

        private void btnOpenExisting_Click(object sender, EventArgs e)
        {
        }

        private void btnShowText_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            FrameInfo InfoWindow = new FrameInfo(Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex]);
            InfoWindow.Show();
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            FramePreview PreviewWindow = new FramePreview(ConvertBytesToImage(Frames[Animation.Actions[lbActions.SelectedIndex].Frames[lbFrames.SelectedIndex].FrameRef]));
            PreviewWindow.Show();
        }

        private void btnCreateAsNew_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            string PromptValue = InputPrompt.ShowDialog("Input New Action Name", "New Action");
            if (PromptValue == "")
            {
                MessageBox.Show("Input Empty!");
            }
            else if (Animation.Manifest.ActionFileName.Contains(PromptValue + ".act"))
            {
                MessageBox.Show("Action Already Exist!");
            }
            else
            {
                Animation.Manifest.ActionFileName.Add(PromptValue + ".act");
                Animation.Actions.Add(new AMTAction());
                Animation.Actions.Last().Name = PromptValue;
                Animation.Actions.Last().Frames.Add(new AMTFrame());
                Animation.Actions.Last().Frames[0].Delay = 100;
                Animation.Actions.Last().Frames[0].FrameRef = lbGifFrames.SelectedIndex;
                Animation.Actions.Last().Frames[0].MD5 = ImageMD5(ConvertBytesToImage(Frames[lbGifFrames.SelectedIndex]));
                Animation.Actions.Last().Frames[0].Tags.Add("null");
                PopulateUI();
            }
        }

        private void lbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCurrentAction.Text = Animation.Manifest.ActionFileName[lbActions.SelectedIndex];
            lbFrames.Items.Clear();
            foreach (AMTFrame frame in Animation.Actions[lbActions.SelectedIndex].Frames)
            {
                lbFrames.Items.Add(FrameToString(frame));
            }
        }

        private void btnAddToExisting_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            if (lbActions.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select an action!");
                return;
            }
            Animation.Actions[lbActions.SelectedIndex].Frames.Add(new AMTFrame());
            Animation.Actions[lbActions.SelectedIndex].Frames.Last().Delay = 100;
            Animation.Actions[lbActions.SelectedIndex].Frames.Last().FrameRef = lbGifFrames.SelectedIndex;
            Animation.Actions[lbActions.SelectedIndex].Frames.Last().MD5 = ImageMD5(ConvertBytesToImage(Frames[lbGifFrames.SelectedIndex]));
            Animation.Actions[lbActions.SelectedIndex].Frames.Last().Tags.Add("null");
            PopulateUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            Save();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.SelectedIndex == 0)
                return;
            else
            {
                //Swap
                int index = lbFrames.SelectedIndex;
                Swap<AMTFrame>(Animation.Actions[lbActions.SelectedIndex].Frames, lbFrames.SelectedIndex, lbFrames.SelectedIndex - 1);
                PopulateUI();
                lbFrames.SelectedIndex = index - 1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.SelectedIndex == lbFrames.Items.Count - 1)
                return;
            else
            {
                //Swap
                int index = lbFrames.SelectedIndex;
                Swap<AMTFrame>(Animation.Actions[lbActions.SelectedIndex].Frames, lbFrames.SelectedIndex, lbFrames.SelectedIndex + 1);
                PopulateUI();
                lbFrames.SelectedIndex = index + 1;
            }
        }

        private void btnDeleteFrame_Click(object sender, EventArgs e)
        {
            if (ProgramState != State.READY)
                return;
            if (lbFrames.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a frame!");
                return;
            }
            if (lbFrames.Items.Count == 1)
            {
                MessageBox.Show("Cannot Delete Only Frame in Action.");
                return;
            }
            else
            {
                int index = lbFrames.SelectedIndex;
                Animation.Actions[lbActions.SelectedIndex].Frames.RemoveAt(lbFrames.SelectedIndex);
                PopulateUI();
                if(index != 0)
                    lbFrames.SelectedIndex = index - 1;
                else
                    lbFrames.SelectedIndex = index + 1;
            }
        }
    }
}
