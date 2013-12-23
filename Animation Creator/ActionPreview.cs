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
using Amimat.Player;

namespace Animation_Creator
{
    public partial class ActionPreview : Form
    {
        private AMTActionPlayer ExpandedActionPlayer = null;
        private AMTAction PreviewAction = null;
        private AMTAnimation PreviewAnimation = null;

        private List<byte[]> PreviewFrames = null;

        public ActionPreview(AMTAnimation Animation, AMTAction Action, List<byte[]> Frames)
        {
            InitializeComponent();
            PreviewAnimation = Animation;
            PreviewAction = Action;
            ExpandedActionPlayer = new AMTActionPlayer(Animation, Action);
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
            //Update Action
            if(ExpandedActionPlayer.GetLoopTime() > 0)
                ExpandedActionPlayer = new AMTActionPlayer(PreviewAnimation, PreviewAction);
            //Clear, load another frame, update inteveral
            ClearPictureBox();
            lblCurrentFrame.Text = ExpandedActionPlayer.GetCurrentFrame().ToString();
            AMTFrame f = ExpandedActionPlayer.GetNextFrameWithRandomness();
            LoadFrame(f.FrameRef);
            lblCurrentDelay.Text = f.Delay.ToString();
            PlayTimer.Interval = f.Delay;
        }
    }
}
