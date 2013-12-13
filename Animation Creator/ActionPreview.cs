using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using Amimat.Core;

namespace Animation_Creator
{
    public partial class ActionPreview : Form
    {
        private int FrameCount = 0;
        private AMTAction PreviewAction = null;
        private List<byte[]> PreviewFrames = null;

        public ActionPreview(AMTAction Action, List<byte[]> Frames)
        {
            InitializeComponent();
            PreviewAction = Action;
            PreviewFrames = Frames;
            this.Text = this.Text + " " + Action.Name;
            PlayTimer.Enabled = true;
        }

        private void ClearPictureBox()
        {
            try
            {
                if (pbAnimation.Image != null)
                {
                    pbAnimation.Image.Dispose();
                }
                pbAnimation.Image = null;
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
        private Bitmap ConvertBytesToImage(byte[] ImageBytes)
        {
            if (ImageBytes == null || ImageBytes.Length == 0)
            {
                return null;
            }

            try
            {
                //Read bytes into a MemoryStream
                using (MemoryStream ms = new MemoryStream(ImageBytes))
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

        private void LoadFrame(int Index)
        {
            pbAnimation.Image = ConvertBytesToImage(PreviewFrames[Index]);
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            //Clear, load another frame, update inteveral
            if (FrameCount > PreviewAction.Frames.Count - 1)
                FrameCount = 0;
            ClearPictureBox();
            LoadFrame(PreviewAction.Frames[FrameCount].FrameRef);
            PlayTimer.Interval = PreviewAction.Frames[FrameCount].Delay;
            FrameCount++;
        }
    }
}
